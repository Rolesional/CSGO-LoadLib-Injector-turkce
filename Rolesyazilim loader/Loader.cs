using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Diagnostics;
namespace Rolesyazilim_loader
{
    public partial class Loader : Form
    {
        string dll_ismi = "win68dll";
        int beklemesüresi = 40000;

        public Loader()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Button1.Text = "Başlatılıyor";

            WebClient wb = new WebClient();
            string mainpath = "C:\\Windows\\" + dll_ismi + ".dll";
            wb.DownloadFile("İndirme Bağlantısını Buraya Yerleştiriniz.", mainpath);

            Button1.Text = "Oyun Açılıyor...";

            Process.Start("steam://rungameid/730");
            await Task.Delay(beklemesüresi);
            Process csgo = Process.GetProcessesByName("csgo").FirstOrDefault();
            Process[] csgo_array = Process.GetProcessesByName("csgo");
            if (csgo_array.Length != 0)
            {
                Button1.Text = "Inject Ediliyor...";
                this.Hide();
                MessageBox.Show("Inject Başarılı!", "Rolesional Injector");

                Inject.InjectMethod.Inject(mainpath, "csgo");
                Environment.Exit(0);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}






