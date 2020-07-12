using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Xml.Serialization;
using System.Linq;

namespace NOTISSTest
{
    public abstract class Zal
    {
        public  static void Sl()
        {
            Console.Write("SL");
            Sk();
        }

        public abstract void SLL();

        private static void Sk()
        {
            Console.WriteLine("SK");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Zal.Sl();
            XmlSerializer serialaizer = new XmlSerializer(typeof(Catalog));
            HttpClient httpClient = new HttpClient();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            // Encoding.GetEncoding("windows-1251");
            Stream res = httpClient.GetStreamAsync("https://yastatic.net/market-export/_/partner/help/YML.xml").Result;
            StreamReader reader = new StreamReader(res, Encoding.GetEncoding("windows-1251"));
            string text = reader.ReadToEnd();
            Console.WriteLine(text);
            FileStream fs = new FileStream("1.txt", FileMode.Open);
            var doc = serialaizer.Deserialize(httpClient.GetStreamAsync("https://yastatic.net/market-export/_/partner/help/YML.xml").Result);
            fs.Position = 0;
            reader = new StreamReader(fs, Encoding.GetEncoding("windows-1251"));
            text = reader.ReadToEnd();
            Console.WriteLine(text);

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VisualStudio\source\repos\NOTISSTest\NOTISSTest\ctlgDB.mdf;Integrated Security=True";
            DBinteractions db = new DBinteractions();
            db.InsertOffer(((Catalog)doc).shop.offers);
        }
    }
}

