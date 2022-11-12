using System;
using System.Windows.Forms;
using TCPGeckoSharp;

namespace TCPGeckoSharp_Example
{
    public partial class Example : Form
    {
        public Example()
        {
            InitializeComponent();
            this.DisconnectButton.Enabled = false;
        }

        public TCPGecko gecko;

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            this.gecko = new TCPGecko(WiiUIPv4Text.Text, 7331);

            /* 
             * The connection process starts here
             * 7331 is the port number of WiiUTCPGecko
             * Basically, you can use it as it is
             */

            try
            {
                this.gecko.Connect();
                this.ConnectButton.Text = "Connected";
                this.ConnectButton.Enabled = false;
                this.DisconnectButton.Enabled = true;
            }
            catch (ETCPGeckoException ex)
            {
                //Connection Failure
                MessageBox.Show(ex.Message,"TCPGeckoSharp");
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                //IP is unclear
                MessageBox.Show(ex.Message,"TCPGeckoSharp");
            }
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.gecko.Disconnect();
                this.ConnectButton.Text = "Connect";
                this.ConnectButton.Enabled = true;
                this.DisconnectButton.Enabled = false;
            }
            finally
            {
            }
        }
    }
}
