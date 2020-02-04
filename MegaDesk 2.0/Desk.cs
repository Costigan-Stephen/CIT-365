using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk
{
    class Desk
    {
        Desk desk = new Desk();
        DeskQuote quote = new DeskQuote();

        public enum Materials
        {
            Oak         = 200,
            Laminate    = 100,
            Pine        = 50,
            Rosewood    = 300,
            Veneer      = 125,
        }

        public enum DeskSize
        {
            minWidth = 24,
            maxWidth = 96,
            minDepth = 12,
            maxDepth = 48,
        }

        public int DeskMaterialCost(string material)
        {
            switch (Enum.Parse(typeof(Materials), material))
            {
                case Materials.Oak:
                    return (int)Materials.Oak;
                case Materials.Laminate:
                    return (int)Materials.Laminate;
                case Materials.Pine:
                    return (int)Materials.Pine;
                case Materials.Rosewood:
                    return (int)Materials.Rosewood;
                case Materials.Veneer:
                    return (int)Materials.Veneer;
                default:
                    return 0;
            }
        }

        //EXPERIMENTAL
        public string JSONappend()
        {
            // Read existing json data
            var jsonData = System.IO.File.ReadAllText(quote.filepath);
            // De-serialize to object or create new list

            quote.AddJSONValues(jsonData, quote);

            // Update json data string
            jsonData = JsonConvert.SerializeObject(quote);
            System.IO.File.WriteAllText(quote.filepath, jsonData);
            return jsonData;
        }
    }
}
