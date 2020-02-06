using Microsoft.AspNet.SignalR.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace MegaDesk
{
    class DeskQuote
    {
        //Values to save
        public Guid id { get; set; }
        public DateTime date { get; set; }
        public int depth { get; set; }
        public int width { get; set; }
        public int drawers { get; set; }
        public int drawerCost { get; set; }
        public int area { get; set; }
        public int areaCost { get; set; }
        public int materialCost { get; set; }
        public int shippingCost{ get; set; }
        public string material { get; set; }
        public string customerName { get; set; }
        public double quote { get; set; }
        public string rush { get; set; }


        public string filepath = "quote.json";
        private const string QUOTE_SEPARATOR = "#QUOTE#";

        public int AreaCalculate(int depth, int width)
        {
            int area = depth * width;
            return area;
        }

        public int AreaCost(int depth, int width)
        {
            int area = depth * width;
            if (area > 1000)
            {
                int areaCost = 200 + (area - 1000);
                return areaCost;
            }
            return 200;
        }

        public int ShippingCost(string shipping, int area)
        {
            switch (shipping)
            {
                case "3 Day":
                    if (area < 1000) return 60;
                    if (area >= 1000 && area <= 2000) return 70;
                    if (area > 2000) return 80;
                    return 0;
                case "5 Day":
                    if (area < 1000) return 40;
                    if (area >= 1000 && area <= 2000) return 50;
                    if (area > 2000) return 60;
                    return 0;
                case "7 Day":
                    if (area < 1000) return 30;
                    if (area >= 1000 && area <= 2000) return 35;
                    if (area > 2000) return 40;
                    return 0;
                default:
                    return 0;
            }
        }

        public string OpenFile()
        {
            string json = System.IO.File.ReadAllText(filepath);

            if (json.Contains("}{"))
                json = json.Replace("}{", "},{");
            if (!json.Contains("[") && json.Contains(","))
            {
                json = "[" + json + "]";
            };
            
            Console.WriteLine(json);
            return json;

        }

        public void SaveToFile(DeskQuote DeskQuoteParse)
        {

            JObject savefile = saveFileFormat(DeskQuoteParse);

            File.AppendAllText(filepath, savefile.ToString());

        }

        public JObject saveFileFormat(DeskQuote DeskQuoteParse)
        {
            JObject savefile = new JObject(
                new JProperty("id",             DeskQuoteParse.id),
                new JProperty("date",           DeskQuoteParse.date),
                new JProperty("depth",          DeskQuoteParse.depth),
                new JProperty("width",          DeskQuoteParse.width),
                new JProperty("drawers",        DeskQuoteParse.drawers),
                new JProperty("drawerCost",     DeskQuoteParse.drawerCost),
                new JProperty("area",           DeskQuoteParse.area),
                new JProperty("areaCost",       DeskQuoteParse.areaCost),
                new JProperty("material",       DeskQuoteParse.material),
                new JProperty("materialCost",   DeskQuoteParse.materialCost),
                new JProperty("customerName",   DeskQuoteParse.customerName),
                new JProperty("rush",           DeskQuoteParse.rush),
                new JProperty("shippingCost",   DeskQuoteParse.shippingCost),
                new JProperty("quote",          DeskQuoteParse.quote));

            return savefile;
        }

    }
}
