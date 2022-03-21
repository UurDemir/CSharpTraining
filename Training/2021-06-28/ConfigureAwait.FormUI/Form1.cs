using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfigureAwait.FormUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnMessage_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Training");
        }

        private async void btnCounter_Click(object sender, EventArgs e)
        {
            await CounterAsync();
        }

        private Task CounterAsync()
        {
            return Task.Run(async () =>
            {
                for (int i = 0; i < 100; i++)
                {
                    await Task.Delay(200);
                }
                MessageBox.Show("Counter Finished");
            });
        }

        private void btnGetGoogle_Click(object sender, EventArgs e)
        {
            string result = GetGoogleHtml().Result;
        }

        private void btnGetGoogleFixed_Click(object sender, EventArgs e)
        {
            string result = GetGoogleHtmlFixed().Result;
        }

        private async Task<string> GetGoogleHtml()
        {
            using HttpClient httpClient = new();
            HttpResponseMessage response = await httpClient.GetAsync("https://google.com");
            return await response.Content.ReadAsStringAsync();
        }

        private async Task<string> GetGoogleHtmlFixed()
        {
            using HttpClient httpClient = new();
            HttpResponseMessage response = await httpClient.GetAsync("https://google.com").ConfigureAwait(false);

            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }
    }
}
