using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLTransactionIsolationLevel.Models;

namespace SQLTransactionIsolationLevel.UserControls
{

    public partial class CRUD : UserControl
    {
        public IsolationManager IsolationManager { get; set; }
        public delegate void SelectionResult(List<Member> members);
        public event SelectionResult OnSelection;

        public CRUD()
        {
            InitializeComponent();
        }

        public CRUD(IsolationManager isolationManager) : this()
        {
            IsolationManager = isolationManager;
        }

        private async void btnInsert_Click(object sender, EventArgs e)
        {
            ToggleButtons();
            lblStatus.Text = "Inserting...";
            await IsolationManager.InsertMember();
            lblStatus.Text = "Inserting Done";
            ToggleButtons();

        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            ToggleButtons();
            lblStatus.Text = "Updating...";
            await IsolationManager.UpdateMember();
            lblStatus.Text = "Updating Done";
            ToggleButtons();
        }

        private async void btnCommit_Click(object sender, EventArgs e)
        {
            ToggleButtons();
            lblStatus.Text = "Committing...";
            await IsolationManager.Commit();
            lblStatus.Text = "Committing Done";
            ToggleButtons();
        }

        private async void btnRollback_Click(object sender, EventArgs e)
        {
            ToggleButtons();
            lblStatus.Text = "Rollbacking...";
            await IsolationManager.RollBack();
            lblStatus.Text = "Rollbacking Done";
            ToggleButtons();
        }

        private async void btnSelect_Click(object sender, EventArgs e)
        {
            ToggleButtons();
            lblStatus.Text = "Fetching...";
            var selectionResult = await IsolationManager.FetchMembers();
            OnSelection?.Invoke(selectionResult);
            lblStatus.Text = "Fetching Done";
            ToggleButtons();
        }

        private async void btnSelectWithoutFirst_Click(object sender, EventArgs e)
        {
            ToggleButtons();
            lblStatus.Text = "Fetching...";
            var selectionResult = await IsolationManager.FetchMembersWithoutFirst();
            OnSelection?.Invoke(selectionResult);
            lblStatus.Text = "Fetching Done";
            ToggleButtons();
        }

        private void ToggleButtons()
        {
            foreach (var control in this.Controls)
            {
                if (control is Button)
                {
                    (control as Button).Enabled = !(control as Button).Enabled;
                }
            }
        }
    }
}
