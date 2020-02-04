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
            json = json.Replace("\\", "");
            json = json.Replace("\"{", "{");
            json = json.Replace("}\"", "}");
            Console.WriteLine(json);
            return json;

        }

        public void SaveToFile(string json)
        {
            json = json.Replace("\\", "");
            json = json.Replace("\"{", "{");
            json = json.Replace("}\"", "}");
            //open file stream
            using (StreamWriter file = File.AppendText(filepath))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, json);
            }
        }

        //EXPERIMENTAL
        public List<string> CreateList()
        {
            string json = File.ReadAllText(filepath);
            List<string> quoteList = JsonConvert.DeserializeObject<List<string>>(json);
            Console.WriteLine(quoteList);
            return quoteList;
        }

        //EXPERIMENTAL
        public object AddJSONValues(string jsonData, DeskQuote newQuote)
        {
            //ADD VALUES FROM EXISTING TO NEW
            var quoteList = JsonConvert.DeserializeObject<List<object>>(jsonData);
            quoteList.Add(new DeskQuote()
            {
            
            id              = newQuote.id,
            date            = newQuote.date,
            depth           = newQuote.depth,
            width           = newQuote.width,
            drawers         = newQuote.drawers,
            drawerCost      = newQuote.drawerCost,
            area            = newQuote.area,
            areaCost        = newQuote.areaCost,
            material        = newQuote.material,
            materialCost    = newQuote.materialCost,
            customerName    = newQuote.customerName,
            rush            = newQuote.rush,
            shippingCost    = newQuote.shippingCost,
            quote           = newQuote.quote
            });

            return quoteList;
        }

    }
}
