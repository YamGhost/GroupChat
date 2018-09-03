using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroupChat_Client.Net {
    class TCP_Client {

        public Socket socket { get; private set; }
        private IPEndPoint ipEndPoint;

        private string ipv4;
        private UInt16 port;
        private readonly int buf_len; 

        //public enum PacketType { cmd, message };
        //public enum CmdType { stopRecv, stopSend };

        public TCP_Client(string ipv4, UInt16 port) {

            this.ipv4 = ipv4;
            this.port = port;
            buf_len = 256;
        }

        ~TCP_Client() {

            if (socket != null) {
                socket.Close();
            }               
        }

        public bool connect() { //Client Socket連線

            try {

                ipEndPoint = new IPEndPoint(IPAddress.Parse(ipv4), port);
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ipEndPoint);
                //socket.IOControl(IOControlCode.KeepAliveValues, KeepAlive(1, 10, 5), null);
                
                ThreadPool.QueueUserWorkItem(callBack => { clientHandle(); }); //接收封包執行緒

                return true;

            } catch (SocketException ex) {

                MessageBox.Show(ex.Message, "SocketException", MessageBoxButtons.OK);
                return false;

            } catch (FormatException ex) {

                MessageBox.Show(ex.Message, "FormatException", MessageBoxButtons.OK);
                return false;

            } catch (Exception ex) {

                Debug.WriteLine(ex.Message);
                Environment.Exit(1);

                return false;
            }
        }

        private byte[] KeepAlive(int onOff, int keepAliveTime, int keepAliveInterval) {
            byte[] buffer = new byte[12];
            BitConverter.GetBytes(onOff).CopyTo(buffer, 0);
            BitConverter.GetBytes(keepAliveTime).CopyTo(buffer, 4);
            BitConverter.GetBytes(keepAliveInterval).CopyTo(buffer, 8);
            return buffer;
        }

        #region cmd
        //public byte[] createCmdPacket(CmdType type) {

        //    byte[] data = new byte[7];

        //    data[0] = 0x00; data[1] = 0xff;
        //    data[2] = (byte)PacketType.cmd; data[3] = (byte)type;
        //    data[4] = unchecked((byte)(~(data[2] + data[3]) + 1));  //checksum
        //    data[5] = 0xff; data[6] = 0x00;

        //    return data;
        //}

        //public byte[] createMessagePacket(byte[] message) {

        //    byte[] data = new byte[7 + (byte)message.Length]; //0x00, 0xff, type, num, [message], checksum, 0x00, 0xff

        //    data[0] = 0x00; data[1] = 0xff;
        //    data[2] = (byte)PacketType.message;
        //    data[3] = (byte)message.Length;
        //    for (byte i = 0; i < data[3]; i++)
        //        data[i + 4] = message[i];
        //    data[data[3] + 4] = unchecked((byte)(~(data[2] + data[data[3] + 3]) + 1));  //checksum
        //    data[data[3] + 5] = 0xff; data[data[3] + 6] = 0x00;

        //    return data;
        //}

        //public bool analysisPacket() {

        //}
        #endregion

        public void clientHandle() {

            byte[] buf = new byte[buf_len];
            int recvlen;

            try {

                while (true) {

                    if (socket.Receive(buf, SocketFlags.Peek) > 0) { //成功接收封包
                    

                        recvlen = socket.Receive(buf);

                        Form1.output.Invoke(new Action(() => {  //輸出至聊天室
                            Form1.output.Text += Encoding.ASCII.GetString(buf);
                            Form1.output.Text += "\n";

                            Form1.output.ScrollBars = RichTextBoxScrollBars.Vertical;
                            Form1.output.SelectionStart = Form1.output.TextLength;
                            Form1.output.ScrollToCaret();
                        }));

                        Debug.WriteLine("recv fin!");

                    } else { //接收封包失敗(Server離線)

                        Form1.input.Invoke(new Action(() => {
                            Form1.input.Text = "";
                        }));

                        Form1.output.Invoke(new Action(() => {
                            Form1.output.Text = "";
                        }));

                        Form1.loginIn.Invoke(new Action(() => {
                            Form1.loginIn.Visible = true;
                        }));

                        socket.Dispose();
                        MessageBox.Show("Server已關閉(" + ipv4 + ":" + port + ")", "SocketException", MessageBoxButtons.OK);

                        return;
                    }
                }

            } catch (Exception ex) {

                Debug.WriteLine(ex.Message);
                //Form1.input.Invoke(new Action(() => {
                //    Form1.input.Text = "";
                //}));

                //Form1.output.Invoke(new Action(() => {
                //    Form1.output.Text = "";
                //}));

                //Form1.loginIn.Invoke(new Action(() => {
                //    Form1.loginIn.Visible = true;
                //}));

                //socket.Dispose();
                //MessageBox.Show("Server已關閉(" + ipv4 + ":" + port + ")", "SocketException", MessageBoxButtons.OK);

                return;
            }
        }
    }
}
