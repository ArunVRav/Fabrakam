using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.DataModels
{
    public class Orders
    {

        public string ID { get; set; }

        [JsonProperty(PropertyName = "login")]
        public string login1 { get; set; }

        [JsonProperty(PropertyName = "chips")]
        public int HotChips { get; set; }

        [JsonProperty(PropertyName = "potatoes")]
        public int RoastPotatoes { get; set; }

        [JsonProperty(PropertyName = "vegsalad")]
        public int VegetableSalad { get; set; }

        [JsonProperty(PropertyName = "fruitsalad")]
        public int FruitSalad { get; set; }

        [JsonProperty(PropertyName = "eggparm")]
        public int EggplantParm { get; set; }

        [JsonProperty(PropertyName = "vegburger")]
        public int VeggieBurger { get; set; }

        [JsonProperty(PropertyName = "smoothie")]
        public int Smoothie { get; set; }

        [JsonProperty(PropertyName = "Price")]
        public double Price { get; set; }
    }
}
