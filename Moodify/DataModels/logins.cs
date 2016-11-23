using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify.DataModels
{
    public class logins
    {
        [JsonProperty(PropertyName = "Id")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "pass")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string PrefName { get; set; }

        public static string CurrentName;
        public static string Current
        {
            get { return CurrentName; }
            set { CurrentName = value; }
        }
        private static int currIndex;
        public static int indexer
        {
            get { return currIndex; }
            set { currIndex = value; }
        }
    }
}
