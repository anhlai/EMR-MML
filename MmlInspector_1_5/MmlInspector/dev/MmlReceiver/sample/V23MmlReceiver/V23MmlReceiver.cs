using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Xml.Linq;

namespace V23MmlReceiver
{
    public class V23MmlReceiver : Yos731.MmlReceiver.IMmlReceiver
    {
        public void Receive(System.Net.Sockets.Socket socket, out string mml)
        {
            mml = null;

            string v23MmlDocument;

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

                v23MmlDocument = Encoding.Unicode.GetString(dataBuffer);

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

            // 受信したMML Version 2.3ドキュメントをMML Version 3.0ドキュメントに変換
            try
            {
                XElement v23Mml = XElement.Parse(v23MmlDocument);

                mml = convertV23toV30(v23Mml);
            }
            catch (Yos731.MmlReceiver.MmlReceiverException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new Yos731.MmlReceiver.MmlReceiverException("Failure to convert MML Document from v2.3 to v3.0", e);
            }
        }

        // MML Version 2.3の要素をMML Version 3.0のテンプレートに埋め込みます。
        // MML InspectorはHL7 CDAのCDA Header, CDA Bodyの検証は行いませんので、
        // テンプレートで定義している値はダミーです。
        private string convertV23toV30(XElement v23Mml)
        {
            XElement v30Mml = XElement.Parse(V30Template.MML_HEADER);
            XElement v30LocalHeader = v30Mml.Descendants("local_header").First();
            XElement v30Body = v30Mml.Descendants("body").First();

            // MML Header
            var mmlHeaderList = v23Mml.Descendants("MmlHeader");

            if (mmlHeaderList.Count() != 1)
                throw new Yos731.MmlReceiver.MmlReceiverException("Invalid MML Version 2.3 Format. (MmlHeader)", null);

            XElement elemMmlHeader = mmlHeaderList.First();
            changeNamespaceToMml(elemMmlHeader);

            v30LocalHeader.Add(elemMmlHeader);

            // Section
            foreach (XElement elem in v23Mml.Descendants("MmlModuleItem"))
            {
                // DocInfo
                var docInfoList = elem.Descendants("docInfo");

                if (docInfoList.Count() != 1)
                    throw new Yos731.MmlReceiver.MmlReceiverException("Invalid MML version 2.3 Format. (DocInfo)", null);

                XElement elemDocInfo = docInfoList.First();
                changeNamespaceToMml(elemDocInfo);

                XElement elemDocInfoParagraph = XElement.Parse(V30Template.PARAGRAPH);
                elemDocInfoParagraph.Descendants("local_markup").First().Add(elemDocInfo);

                // Module
                var contentList = elem.Descendants("content");

                if (contentList.Count() != 1)
                    throw new Yos731.MmlReceiver.MmlReceiverException("Invalid MML Version 2.3 Format. (content)", null);

                XElement elemContent = contentList.First();

                XElement elemModuleParagraph = XElement.Parse(V30Template.PARAGRAPH);
                elemModuleParagraph.Descendants("local_markup").First().Add(elemContent);

                XElement elemSection = new XElement("section");
                elemSection.Add(elemDocInfoParagraph);
                elemSection.Add(elemModuleParagraph);

                v30Body.Add(elemSection);
            }

            return v30Mml.ToString();
        }

        private void changeNamespaceToMml(XElement elem)
        {
            XNamespace ns = "http://www.medxml.net/MML";

            foreach (XNode node in elem.DescendantNodesAndSelf())
            {
                if (node is XElement)
                {
                    XElement el = (XElement)node;

                    if (String.IsNullOrEmpty(el.Name.NamespaceName))
                        el.Name = ns.GetName(el.Name.LocalName);
                }
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
