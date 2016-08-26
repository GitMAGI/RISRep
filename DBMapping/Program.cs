using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace DBMapping
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            XmlDocument xmlDoc = new XmlDocument();

            XmlNode dB = xmlDoc.CreateElement("dB");
            xmlDoc.AppendChild(dB);
            XmlNode connectionString = xmlDoc.CreateElement("connectionString");
            connectionString.InnerText = "";
            xmlDoc.AppendChild(connectionString);
            XmlNode tables = xmlDoc.CreateElement("tables");
            xmlDoc.AppendChild(tables);

            XmlNode table = xmlDoc.CreateElement("table");
            tables.AppendChild(table);
            XmlNode tableName = xmlDoc.CreateElement("tableName");
            tableName.InnerText = "hlt_ricardiologica";
            table.AppendChild(tableName);
            XmlNode cols = xmlDoc.CreateElement("cols");
            table.AppendChild(cols);

            XmlNode col = xmlDoc.CreateElement("col");
            cols.AppendChild(col);
            XmlNode colName = xmlDoc.CreateElement("colName");
            colName.InnerText = "";
            col.AppendChild(colName);
            XmlNode outName = xmlDoc.CreateElement("outName");
            outName.InnerText = "";
            col.AppendChild(outName);
            */

            Stopwatch sw = new Stopwatch();
            sw.Start();

            try
            {
                string path = "../../XMLResources/";
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
