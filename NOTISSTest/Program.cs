using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Xml.Serialization;
using System.Linq;

namespace NOTISSTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: добавить связи между таблицами 
            XmlSerializer serialaizer = new XmlSerializer(typeof(Catalog));
            HttpClient httpClient = new HttpClient();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            try
            {
                var doc = serialaizer.Deserialize(httpClient.GetStreamAsync("https://yastatic.net/market-export/_/partner/help/YML.xml").Result);

                DBinteractions db = new DBinteractions();

                db.InsertCategory(((Catalog)doc).shop.categories);
                db.InsertCurrency(((Catalog)doc).shop.currencies);
                db.InsertOffer(((Catalog)doc).shop.offers);

                Console.WriteLine("Offers added successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("press any key to exit");
            Console.ReadKey();
        }
    }
}

