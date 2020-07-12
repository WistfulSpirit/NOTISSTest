using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace NOTISSTest
{
    [XmlRootAttribute("yml_catalog")]
    [XmlInclude(typeof(Shop))]
    public class Catalog {
        [XmlElement(ElementName = "shop")]
        public Shop shop;
    }
    //[XmlRootAttribute("yml_catalog")]
    
    [XmlRootAttribute("shop")]
    [XmlInclude(typeof(Currency))]
    [XmlInclude(typeof(Category))]
    [XmlInclude(typeof(Offer))]
    public class Shop
    {
        [XmlElement(ElementName = "name")]
        public string name;
        [XmlElement(ElementName = "company")]
        public string company;
        [XmlElement(ElementName = "url")]
        public string url;
        [XmlArray(ElementName = "currencies"), XmlArrayItem("currency")]
        public Currency[] currencies;
        [XmlArray(ElementName = "categories"), XmlArrayItem("category")]
        public Category[] categories;
        [XmlText]
        [XmlElement(ElementName = "local_delivery_cost")]
        public string local_delivery_cost;
        [XmlArray(ElementName = "offers"), XmlArrayItem("offer")]
        public Offer[] offers;

    }

    [XmlRoot("currency")]
    public class Currency
    {
        [XmlAttribute("id")]
        public string ID;
        [XmlAttribute("rate")]
        public int Rate;
        [XmlAttribute("plus")]
        public int Plus;
        
    }

    [XmlRoot("category")]
    public class Category
    {
        [XmlAttribute("id")]
        public int id;
        [XmlAttribute("parentId")]
        public int parentId;
        [XmlText]
        public string name;
    }
    [XmlRoot("offer")]
    [XmlInclude(typeof(DataTour))]
    public class Offer
    {
        //Offer attributes 
        [XmlAttribute]
        public int id;
        [XmlAttribute("type")]
        public string typeOffer;
        [XmlAttribute]
        public int bid;
        [XmlAttribute]
        public int cbid;
        [XmlAttribute]
        public bool available;

        #region common in Offers
        public string url;
        public double price;
        public string currencyId;
        public int categoryId;
        public string picture;
        [XmlAttribute("type", Namespace = "categoryId")]
        public string typeCatId;
        public string description;
        #endregion



        public int local_delivery_cost;
        public bool delivery;
        public string typePrefix;
        public string vendor;
        public string vendorCode;
        public string model;
        public bool manufacturer_warranty;
        public string country_of_origin;

        public string author;
        public string name;
        public string publisher;
        public int year;
        public string ISBN;
        public string language;
        public string performed_by;
        public string performance_type;
        public string storage;
        public string format;
        public string recording_length;
        public bool downlodable;

        public string artist;
        public string title;
        public string media;

        public string starring;
        public string director;
        public string originalName;
        public string country;

        public string worldRegion;
        public string region;
        public int days;
        [XmlElement("dataTour")]
        public DataTour[] dataTour;
        //[XmlElement("dataTour")]
        //public string dataTour2;
        public string hotel_stars;
        public string room;
        public string meal;
        public string included;
        public string transport;

        public string place;
        public string hall;
        [XmlAttribute("plan")]
        public string plan;
        public string hall_part;
        public string date;
        public bool is_premiere;
        public bool is_kids;
    }
    [XmlRoot("dataTour")]
    public class DataTour
    {
        [XmlText]
        public string name;
    }
}
