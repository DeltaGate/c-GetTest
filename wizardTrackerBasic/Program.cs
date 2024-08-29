using System.Text;
using System.Text.Json;
using wizardTrackerBasic;
using Microsoft.Data.Sqlite;  // using Nuget Package

namespace WizardsRule
{ 
    class SpellTable
    {

        static void Main(string[] args)
        {

            // connect to database
            var dBLocation = "Data Source=C:\\Users\\Connor\\Desktop\\coding 2024\\c# interview work\\wizardTrackerBasic\\Spells - Copy.db"; //db location
            var connection = new SqliteConnection(dBLocation); // create object with location of db
            connection.Open(); //open connection



            Console.WriteLine("Please Enter the spell your wish to recieve:");
            string scrySpell = Console.ReadLine();

            using (var client = new HttpClient()) 
                //creates an HttpClient Object for contacting web end points. creates with using so when done the obj is dropped and connection is closed
            {

                var endPoint = new Uri("https://www.dnd5eapi.co/api/spells/" + scrySpell); //sets 

                var result = client.GetAsync(endPoint).Result.Content;
                //telling httpClient obj to send a get call to spell page, and send back content as a readable string, the .result tells it to wait for the result as by default async is all at once so won't wait otherwise.
                 
                Console.WriteLine(result.ReadAsStringAsync().Result);

                string held = result.ReadAsStringAsync().Result;

                //JsonObject damageDetails = new JsonObject(result.ReadAsStringAsync().Result);

                SpellResponse arcaneKnowledge = JsonSerializer.Deserialize<SpellResponse>(held); //deserialise or extract json data by catagory to object
                Console.WriteLine(arcaneKnowledge.desc[0]); // display specific data.

                arcaneKnowledge.descAsString = string.Join(" ", arcaneKnowledge.desc);
                arcaneKnowledge.descAsString = arcaneKnowledge.descAsString.Replace("'", "");


                Console.WriteLine("--------");
                Console.WriteLine(arcaneKnowledge.descAsString);
                Console.WriteLine("--------");


                arcaneKnowledge.higher_levelAsString = string.Join(" ", arcaneKnowledge.higher_level);
                arcaneKnowledge.higher_levelAsString = arcaneKnowledge.higher_levelAsString.Replace("'", "");

                arcaneKnowledge.componentsAsString = string.Join(" ", arcaneKnowledge.components);
                arcaneKnowledge.componentsAsString = arcaneKnowledge.componentsAsString.Replace("'", "");

                if(arcaneKnowledge.material != null) { arcaneKnowledge.material = arcaneKnowledge.material.Replace("'", ""); }




                if(arcaneKnowledge.damage == null) { var addToDB = new SqliteCommand("INSERT INTO unprepared (name, desc, higher_level, range, components, material, ritual, duration, concentration, casting_time, level) VALUES('" + arcaneKnowledge.name + "', '" + arcaneKnowledge.descAsString + "', '" + arcaneKnowledge.higher_levelAsString + "', '" + arcaneKnowledge.range + "', '" + arcaneKnowledge.componentsAsString + "', '" + arcaneKnowledge.material + "', '" + arcaneKnowledge.ritual + "', '" + arcaneKnowledge.duration + "', '" + arcaneKnowledge.concentration + "', '" + arcaneKnowledge.casting_time + "', '" + arcaneKnowledge.level + "');", connection);
                    addToDB.ExecuteNonQuery();
                }
                else
                {
                    var addToDB = new SqliteCommand("INSERT INTO unprepared (name, desc, higher_level, range, components, material, ritual, duration, concentration, casting_time, level, attack_type, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10) VALUES('" + arcaneKnowledge.name + "', '" + arcaneKnowledge.descAsString + "', '" + arcaneKnowledge.higher_levelAsString + "', '" + arcaneKnowledge.range + "', '" + arcaneKnowledge.componentsAsString + "', '" + arcaneKnowledge.material + "', '" + arcaneKnowledge.ritual + "', '" + arcaneKnowledge.duration + "', '" + arcaneKnowledge.concentration + "', '" + arcaneKnowledge.casting_time + "', '" + arcaneKnowledge.level + "', '" + arcaneKnowledge.damage.damage_type.name + "', '" + arcaneKnowledge.damage.damage_at_slot_level.l1 + "', '" + arcaneKnowledge.damage.damage_at_slot_level.l2 + "', '" + arcaneKnowledge.damage.damage_at_slot_level.l3 + "', '" + arcaneKnowledge.damage.damage_at_slot_level.l4 + "', '" + arcaneKnowledge.damage.damage_at_slot_level.l5 + "', '" + arcaneKnowledge.damage.damage_at_slot_level.l6 + "', '" + arcaneKnowledge.damage.damage_at_slot_level.l7 + "', '" + arcaneKnowledge.damage.damage_at_slot_level.l8 + "', '" + arcaneKnowledge.damage.damage_at_slot_level.l9 + "', '" + arcaneKnowledge.damage.damage_at_slot_level.l10 + "');", connection);

                    addToDB.ExecuteNonQuery();
                }
                




                // runs sql query to insert data into db




                var checkTables = new SqliteCommand("SELECT name FROM sqlite_master WHERE type = 'table' ORDER BY 1", connection);

                var reader = checkTables.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0));
                }
                //runs sql query to read through table names and display them to console

                var checkSpellList = new SqliteCommand("SELECT * FROM unprepared", connection);

                reader = checkSpellList.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0));
                }

                // same as above, but cycles through the spell list
            }

        }

    }




}

