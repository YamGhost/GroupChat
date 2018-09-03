using GroupChat_Client.Net;
using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace GroupChat_Client
{
    public partial class Form1 : Form {
        
        private TCP_Client client;

        public static Panel loginIn;
        public static RichTextBox input;
        public static RichTextBox output;

        public Form1() {
            InitializeComponent();

            loginIn = LoginIn;
            input = InputTextBox;
            output = OutputLabel;

            LoginIn.BringToFront();
        }

        private void SendButton_Click(object sender, EventArgs e) {

            try {
                client.socket.Send(Encoding.ASCII.GetBytes(InputTextBox.Text + '\0'));
                InputTextBox.Text = "";
            } catch (SocketException ex) {

                MessageBox.Show(ex.Message, "SocketException", MessageBoxButtons.OK);
                if (client.socket != null) {
                    client.socket.Dispose();
                    InputTextBox.Text = "";
                    OutputLabel.Text = "";
                }
                LoginIn.Visible = true;
            }
            
        }

        private void EmptyButton_Click(object sender, EventArgs e) {
            InputTextBox.Text = "";
        }

        private void LinkButton_Click(object sender, EventArgs e) {
            client = new TCP_Client(IP_TextBox.Text, 8700);
            IP_TextBox.Text = "";

            if(client.connect())
                LoginIn.Visible = false;
        }

        private void LoginoutButton_Click(object sender, EventArgs e) {
            if (client.socket != null) {
                client.socket.Dispose();
                InputTextBox.Text = "";
                OutputLabel.Text = "";
            }
            LoginIn.Visible = true;
        }
    }
}
