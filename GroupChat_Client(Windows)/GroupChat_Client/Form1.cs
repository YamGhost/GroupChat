using GroupChat_Client.Net;
using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace GroupChat_Client
{
    //[Serializable]
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

            SuportType.Packet packet = new SuportType.Packet();

            try {
                //client.socket.Send(Encoding.ASCII.GetBytes(InputTextBox.Text + '\0'));
                //packet.type = SuportType.Type.messages;
                ////InputTextBox.Text
                //byte[] bytes = Encoding.Default.GetBytes(InputTextBox.Text + '\0');
                ////packet.message = Encoding.UTF8.GetString(bytes);
                //packet.message = Encoding.ASCII.GetChars(bytes);

                //BinaryFormatter buf = new BinaryFormatter();
                //MemoryStream stream = new MemoryStream();
                //buf.Serialize(stream, packet);
                
                string st = "1ase三二一";
                Debug.WriteLine("string size = {0}", Encoding.UTF8.GetByteCount(st));
                //Debug.WriteLine("size = {0}", Marshal.SizeOf(packet));
                //Debug.WriteLine(stream.ToArray().Length);
                //Debug.WriteLine(stream.ToArray().Length);


                //client.socket.Send(stream.ToArray());

                //client.socket.Send(stream.ToArray(), sizeof(packet), 0);
                client.socket.Send(Encoding.UTF8.GetBytes(InputTextBox.Text));
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

        private void fileButton_Click(object sender, EventArgs e) {
            byte[] buf = new byte[13];
            int len, index;

            string path = @"C:\Users\Public\Desktop\test.txt";
            if (!File.Exists(path)) {
                len = client.socket.Receive(buf);
                using (StreamWriter sw = File.CreateText(path)) {
                    //sw.Write(buf, 0, len);
                    sw.Write(Encoding.UTF8.GetChars(buf, 0, len));
                    index = len;
                }

                //while ((len = client.socket.Receive(buf)) > 0) {
                if(client.socket.Receive(buf, SocketFlags.Peek) > 0) {
                    len = client.socket.Receive(buf);
                    using (StreamWriter sw = File.AppendText(path)) {
                        //sw.Write(buf, 0, len);
                        sw.Write(Encoding.UTF8.GetChars(buf, 0, len));
                        index += len;
                    }
                }
                
                //}                
            }
        }
    }
}
