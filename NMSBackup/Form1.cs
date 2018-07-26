using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Windows.Forms;
using System.Diagnostics;

namespace NMSBackup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string NMS_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\HelloGames\\";
        private void button2_Click_1(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", @NMS_PATH);
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            textBox1.AppendText("NMS Save path detected:" + Environment.NewLine + NMS_PATH + Environment.NewLine);
        }

        public bool NMS_IS_RUNNING = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(Process.GetProcessesByName("NMS").Length > 0)
            {
                statusLabel.ForeColor = Color.Green;
                statusLabel.Text = "Running";
                NMS_IS_RUNNING = true;
            }
            else
            {
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = "Stopped";
                NMS_IS_RUNNING = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (NMS_IS_RUNNING)
            {

                ZipFile.CreateFromDirectory(@NMS_PATH+"\\NMS", @NMS_PATH + "/" + DateTime.Now.ToString("yyyy-dd-M-HH-mm-ss") +".zip",CompressionLevel.Optimal,false);
                textBox1.AppendText("Backed up save:" + Environment.NewLine + DateTime.Now.ToString("yyyy-dd-M-HH-mm-ss") + ".zip" + Environment.NewLine);
            }
        }
    }
}
