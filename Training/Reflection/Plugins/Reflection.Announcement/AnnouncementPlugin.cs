using Reflection.Shared;
using System;

namespace Reflection.Announcement
{
    public class AnnouncementPlugin : IPlugin
    {
        public string PluginName => "Announcement Plugin";

        public string Data { get ; set; }

        public string PluginDescription => "Şahsa ait duyurular";

        public void Invoke()
        {
            Invoke(Data);
        }

        public void Invoke(string parameter)
        {
            Console.WriteLine("Merhaba "+parameter);

            if (parameter == "Mehmet")
            {
                Console.WriteLine("Önümüzde ki hafta 3 gün izin hakkı kazandın.");
            }
            else if (parameter == "Mustafa")
            {
                Console.WriteLine("Önümüzde ki hafta 3 gün mesai hakkı kazandın.");
            }

            Console.WriteLine("11 Haziran Tarihinde Happy Hour Yapılacaktır.");
        }
    }
}
