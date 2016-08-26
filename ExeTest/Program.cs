using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace ExeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            try
            {
                string path = "../../../xmlResources/";
                string filename = "msgMirth_working.xml";
                XmlDocument doc = new XmlDocument();

                doc.Load(path + filename);

                string _tmp = xml2String(doc);
                _tmp = Regex.Replace(_tmp, "paglio", "testare", RegexOptions.IgnoreCase);

                System.Console.WriteLine("Request:\n{0}\n\n", _tmp);

                string xmlRequest = _tmp;

                wsMirth.DefaultAcceptMessageClient client = new wsMirth.DefaultAcceptMessageClient();
                string response = client.acceptMessage(xmlRequest);

                string msgResponse = null;
                if (response == null)
                {
                    msgResponse = "NULL - An Error Occurred!";
                }
                else
                {
                    msgResponse = response;
                }
                System.Console.WriteLine("Mirth Response:\n{0}\n", msgResponse);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error Occurred! Exception catched:\n{0}", ex.Message);
            }

            sw.Stop();

            System.Console.WriteLine("ElapsedTime {0}\n\n", sw.Elapsed);

            System.Console.WriteLine("Press a key to Close!");
            System.Console.ReadKey();
        }

        public static string xml2String(XmlDocument xmlDoc)
        {
            using (var stringWriter = new StringWriter())
            using (var xmlTextWriter = XmlWriter.Create(stringWriter))
            {
                xmlDoc.WriteTo(xmlTextWriter);
                xmlTextWriter.Flush();
                return stringWriter.GetStringBuilder().ToString();
            }
        }
    }
}
