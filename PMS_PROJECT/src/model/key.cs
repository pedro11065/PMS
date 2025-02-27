using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.Json;


namespace PMS_PROJECT.src.model.key
{


    class Key
    {
        [RequiresUnreferencedCode("Calls System.Text.Json.JsonSerializer.Deserialize<TValue>(String, JsonSerializerOptions)")]
        [RequiresDynamicCode("Calls System.Text.Json.JsonSerializer.Deserialize<TValue>(String, JsonSerializerOptions)")]
        static public void DatabaseConfigurator()
        {

            string filePath= "C:\\Users\\fsxre\\source\\repos\\PMS_SOLUTION\\PMS_PROJECT\\src\\model\\key.json";
            string jsonString = File.ReadAllText(filePath);
            JsonLayout data_db = JsonSerializer.Deserialize<JsonLayout>(jsonString)!;

            Console.WriteLine($"host: {data_db.host}");

        }
    }

    public class JsonLayout 
    {
        public string host { get; set; }
        public string port { get; set; }
        public string database { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }


}



  //{
  //  "host": "localhost",
  //  "port": "5432",
  //  "database": "PMS_PHSQ",
  //  "username": "postgres",
  //  "password": "32372403",
  //}