using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace wizardTrackerBasic
{
    public class damage_at_slot_level
    {
        [JsonPropertyName("1")]
        public string l1 { get; set; }

        [JsonPropertyName("2")]
        public string l2 { get; set; }

        [JsonPropertyName("3")]
        public string l3 { get; set; }

        [JsonPropertyName("4")]
        public string l4 { get; set; }

        [JsonPropertyName("5")]
        public string l5 { get; set; }

        [JsonPropertyName("6")]
        public string l6 { get; set; }

        [JsonPropertyName("7")]
        public string l7 { get; set; }

        [JsonPropertyName("8")]
        public string l8 { get; set; }

        [JsonPropertyName("9")]
        public string l9 { get; set; }

        [JsonPropertyName("10")]
        public string l10 { get; set; }

    }

    public class damage_type  // subsubclass, same as below but down a level :)
    {
        public string name { get; set; }

    }
    public class damage         // subclass accessed and used when required by main class
    {
        public damage_type damage_type {  get; set; }

        public damage_at_slot_level damage_at_slot_level { get; set; }
    }
    public class SpellResponse
    {

        public string name {  get; set; }

        [JsonPropertyName("desc")]
        public string[] desc {  get; set; }  //class object with sepcific json property linked name
        public string[] higher_level { get; set; }
        public string range { get; set; }
        public string[] components { get; set; }
        public string material { get; set; }
        public bool ritual { get; set; }
        public string duration { get; set; }
        public bool concentration { get; set; }
        public string casting_time { get; set; }
        public int level { get; set; }
        public damage damage { get; set; } // create damage varible of class damage


        // converted propeties
        public string descAsString { get; set; }
        public string higher_levelAsString {  get; set; }
        public string componentsAsString {  get; set; }
        public string damage_at_slot_levelAsString { get; set; }


    }

}
