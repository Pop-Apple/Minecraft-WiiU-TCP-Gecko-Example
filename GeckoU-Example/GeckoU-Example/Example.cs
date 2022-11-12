using System;
using System.IO;
using System.Windows.Forms;
using com.wiiplaza.geckou;

namespace GeckoU_Example
{
    public partial class Example : Form
    {
        public Example()
        {
            InitializeComponent();
            this.DisconnectButton.Enabled = false;
        }

        public static GeckoUCore GeckoU;

        private void ConnectButton_Click(object sender, EventArgs e)
        {

            /*
             * The connection process starts here
             * 7331 is the port number of WiiUTCPGecko
             * Basically, you can use it as it is
             */

            try
            {
                GeckoU = new GeckoUCore(WiiUIPv4Text.Text, 7331);
                GeckoU.GUC.Connect();
                this.ConnectButton.Text = "Connected";
                this.ConnectButton.Enabled = false;
                this.DisconnectButton.Enabled = true;
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message,"GeckoU");
            }
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {

            GeckoU.GUC.Close();
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.Enabled = true;
            this.DisconnectButton.Enabled = false;
        }
    }
}
