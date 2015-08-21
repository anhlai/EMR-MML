using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace SampleMmlSender
{
    public partial class SampleMmlSenderForm : Form
    {
        public SampleMmlSenderForm()
        {
            InitializeComponent();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                IPAddress ipAddress = IPAddress.Parse(textBoxServerAddress.Text);

                IPEndPoint ipEp = new IPEndPoint(ipAddress, Convert.ToInt32(numericUpDownServerPort.Value));

                socket.Connect(ipEp);

                // MMLドキュメントサイズ送信
                int length = Encoding.Unicode.GetByteCount(textBoxMml.Text);
                byte[] mmlLength = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(length));
                SendData(socket, mmlLength, mmlLength.Length);

                // MMLドキュメント送信
                byte[] mmlDocument = Encoding.Unicode.GetBytes(textBoxMml.Text);
                SendData(socket, mmlDocument, mmlDocument.Length);

                // ACK受信
                byte[] ackBuffer = new byte[1];

                if (ReceiveData(socket, ackBuffer, ackBuffer.Length))
                {
                    if (ackBuffer[0] == 0x1)
                        MessageBox.Show("Succeeded.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Failed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Failure to receive ACK message.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                socket.Close();
            }
        }

        private static void SendData(Socket socket, byte[] msg, int length)
        {
            int writeCount, msgPtr = 0;

            while (true)
            {
                writeCount = socket.Send(msg, msgPtr, length, SocketFlags.None);

                if ((length -= writeCount) == 0)
                    break;
                else
                    msgPtr += writeCount;
            }
        }

        private static bool ReceiveData(Socket socket, byte[] msg, int length)
        {
            int readCount, msgPtr = 0;

            while (true)
            {
                if (0 == (readCount = socket.Receive(msg, msgPtr, length, SocketFlags.None)))
                    return false;

                if ((length -= readCount) == 0)
                    break;
                else
                    msgPtr += readCount;
            }

            return true;
        }
    }
}
