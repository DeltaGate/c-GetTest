﻿using System.Text;
using System.Text.Json;

namespace WizardsRule
{ 
    class SpellTable
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter the spell your wish to recieve:");
            string scrySpell = Console.ReadLine();

            using (var client = new HttpClient()) 
                //creates an HttpClient Object for contacting web end points. creates with using so when done the obj is dropped and connection is closed
            {

                var endPoint = new Uri("https://www.dnd5eapi.co/api/spells/" + scrySpell); //sets 

                var result = client.GetAsync(endPoint).Result.Content.ReadAsStringAsync().Result;
                //telling httpClient obj to send a get call to spell page, and send back content as a readable string, the .result tells it to wait for the result as by default async is all at once so won't wait otherwise.
                 
                Console.WriteLine(result);

            }

        }

    }




}

