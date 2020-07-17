using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Configuration;
using System.IO;

namespace NOTISSTest
{
    class DBinteractions
    {
        private SqlConnection connection;
        //private string connectionString;
        public DBinteractions()
        {
            //this.connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VisualStudio\source\repos\NOTISSTest\NOTISSTest\AppData\ctlgDB.mdf;Integrated Security=True";
            string fromSett = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string relative = @"..\..\..\AppData";
            string absolute = Path.GetFullPath(relative);
            fromSett = fromSett.Replace("|DataDirectory|", absolute);
            connection = new SqlConnection(fromSett);
        }

        public void InsertCurrency(Currency[] currencies)
        {
            foreach (var cur in currencies)
            {
                using (var command = new SqlCommand("dbo.InsertCurrency", connection) { CommandType = CommandType.StoredProcedure })
                {
                    command.Parameters.AddWithValue("id", cur.ID);
                    command.Parameters.AddWithValue("rate", cur.Rate);
                    command.Parameters.AddWithValue("plus", cur.Plus);
                    connection.Open();
                    var res = command.ExecuteNonQuery();
                    if (res == 0)
                    {
                        Console.WriteLine("Error");
                    }
                    connection.Close();
                }
            }
        }
        public void InsertCategory(Category[] categories)
        {
            foreach (var cat in categories)
            {
                using (var command = new SqlCommand("dbo.InsertCategory", connection) { CommandType = CommandType.StoredProcedure })
                {
                    
                    command.Parameters.AddWithValue("id", cat.id);
                    command.Parameters.AddWithValue("parentId", cat.parentId);
                    command.Parameters.AddWithValue("name", cat.name);
                    connection.Open();
                    var res = command.ExecuteNonQuery();
                    if (res == 0)
                    {
                        Console.WriteLine("Error");
                    }
                    connection.Close();
                }
            }
        }

        public void InsertOffer(Offer[] offers)
        {
            foreach (var o in offers)
            {
                using (var command = new SqlCommand("dbo.InsertOffer", connection) { CommandType = CommandType.StoredProcedure })
                {
                    var offer = new Offer();
                    var fieldList = offer.GetType().GetFields();

                    command.Parameters.AddWithValue("@id", o.id);
                    command.Parameters.AddWithValue("@typeoffer", o.typeOffer);
                    command.Parameters.AddWithValue("@bid", o.bid);
                    command.Parameters.AddWithValue("@cbid", o.cbid);
                    command.Parameters.AddWithValue("@available", o.available);
                    command.Parameters.AddWithValue("@url", o.url);
                    command.Parameters.AddWithValue("@price", o.price);
                    command.Parameters.AddWithValue("@currencyId", o.currencyId);
                    command.Parameters.AddWithValue("@categoryId", o.categoryId);
                    command.Parameters.AddWithValue("@picture", o.picture);
                    command.Parameters.AddWithValue("@typeCatId", o.typeCatId);
                    command.Parameters.AddWithValue("@description", o.description);
                    command.Parameters.AddWithValue("@local_delivery_cost", o.local_delivery_cost);
                    command.Parameters.AddWithValue("@delivery", o.delivery);
                    command.Parameters.AddWithValue("@typePrefix", o.typePrefix);
                    command.Parameters.AddWithValue("@vendor", o.vendor);
                    command.Parameters.AddWithValue("@vendorCode", o.vendorCode);
                    command.Parameters.AddWithValue("@model", o.model);
                    command.Parameters.AddWithValue("@manufacturer_warranty", o.manufacturer_warranty);
                    command.Parameters.AddWithValue("@country_of_origin", o.country_of_origin);
                    command.Parameters.AddWithValue("@author", o.author);
                    command.Parameters.AddWithValue("@name", o.name);
                    command.Parameters.AddWithValue("@publisher", o.publisher);
                    command.Parameters.AddWithValue("@year", o.year);
                    command.Parameters.AddWithValue("@ISBN", o.ISBN);
                    command.Parameters.AddWithValue("@language", o.language);
                    command.Parameters.AddWithValue("@performed_by", o.performed_by);
                    command.Parameters.AddWithValue("@performance_type", o.performance_type);
                    command.Parameters.AddWithValue("@storage", o.storage);
                    command.Parameters.AddWithValue("@format", o.format);
                    command.Parameters.AddWithValue("@recording_length", o.recording_length);
                    command.Parameters.AddWithValue("@downlodable", o.downlodable);
                    command.Parameters.AddWithValue("@artist", o.artist);
                    command.Parameters.AddWithValue("@title", o.title);
                    command.Parameters.AddWithValue("@media", o.media);
                    command.Parameters.AddWithValue("@starring", o.starring);
                    command.Parameters.AddWithValue("@director", o.director);
                    command.Parameters.AddWithValue("@originalName", o.originalName);
                    command.Parameters.AddWithValue("@country", o.country);
                    command.Parameters.AddWithValue("@worldRegion", o.worldRegion);
                    command.Parameters.AddWithValue("@region", o.region);
                    command.Parameters.AddWithValue("@days", o.days);

                    if (o.dataTour != null)
                    {
                        command.Parameters.AddWithValue("@dataTourBegin", o.dataTour[0].name);
                        command.Parameters.AddWithValue("@dataTourEnd", o.dataTour[1].name);
                    }

                    command.Parameters.AddWithValue("@hotel_stars", o.hotel_stars);
                    command.Parameters.AddWithValue("@room", o.room);
                    command.Parameters.AddWithValue("@meal", o.meal);
                    command.Parameters.AddWithValue("@included", o.included);
                    command.Parameters.AddWithValue("@transport", o.transport);
                    command.Parameters.AddWithValue("@place", o.place);
                    command.Parameters.AddWithValue("@hall", o.hall);
                    command.Parameters.AddWithValue("@plan", o.plan);
                    command.Parameters.AddWithValue("@hall_part", o.hall_part);
                    command.Parameters.AddWithValue("@date", o.date);
                    command.Parameters.AddWithValue("@is_premiere", o.is_premiere);
                    command.Parameters.AddWithValue("@is_kids", o.is_kids);

                    connection.Open();
                    var res = command.ExecuteNonQuery();
                    if (res == 0)
                    { 
                        Console.WriteLine("Error");
                    }
                    connection.Close();
                }
            }
        }
    }
}
