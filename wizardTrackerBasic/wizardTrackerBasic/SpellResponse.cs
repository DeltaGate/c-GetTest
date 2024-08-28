using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace wizardTrackerBasic
{
    public class SpellResponse
    {
        [JsonPropertyName("desc")]
        public string[] descript {  get; set; }  //class object with sepcific json property linked name
    }
}
