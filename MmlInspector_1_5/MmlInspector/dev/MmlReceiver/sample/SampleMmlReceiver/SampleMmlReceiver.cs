using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Net;

namespace SampleMmlReceiver
{
    public class SampleMmlReceiver : Yos731.MmlReceiver.IMmlReceiver
    {
        public void Receive(System.Net.Sockets.Socket socket, out string mml)
        {
            mml = null;

            try
            {
                // MMLドキュメントサイズを受信
                byte[] lengthBuffer = new byte[4];

                if (!ReceiveData(socket, lengthBuffer, lengthBuffer.Length))
                    new Yos731.MmlReceiver.MmlReceiverException("Failure to receive mml length.", null);

                int length = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(lengthBuffer, 0));

                // MMLドキュメントを受信
                byte[] dataBuffer = new byte[length];

                if (!ReceiveData(socket, dataBuffer, length))
                    new Yos731.MmlReceiver.MmlReceiverException("Failure to receive mml data.", null);

                mml = Encoding.Unicode.GetString(dataBuffer);

                // ACK(0x1)を送信
                byte[] ackData = new byte[1];
                ackData[0] = 0x1;
                SendData(socket, ackData, ackData.Length);
            }
            catch (Yos731.MmlReceiver.MmlReceiverException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                // 発生した例外をスロー
                throw new Yos731.MmlReceiver.MmlReceiverException("Failure to receive MML document.", e);
            }
            finally
            {
                socket.Close();
            }
        }

        private void SendData(Socket socket, byte[] msg, int length)
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

        private bool ReceiveData(Socket socket, byte[] msg, int length)
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
