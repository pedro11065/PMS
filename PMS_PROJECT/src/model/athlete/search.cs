using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Npgsql;

namespace PMS.src.model.athlete.search
{
    class Search
    {
        static public List<Dictionary<string, object>> db_search()
        {
            string connectionString = "Host=ep-solitary-sky-a5yq9sp8-pooler.us-east-2.aws.neon.tech;" +
                "Port=5432;" +
                "Database=PMS;" +
                "User Id=PMS_owner;" +
                "Password=npg_nU6PrBHtxy3E;" +
                "SSL Mode=Require; Trust Server Certificate=true;";

            Console.WriteLine("Conectando ao banco de dados...");
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();

            try
            {
                using var connection = new NpgsqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("Conexão bem-sucedida!");

                using var cmd = new NpgsqlCommand("SELECT * FROM admin", connection);
                using var reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    Console.WriteLine("Nenhum dado encontrado na tabela 'admin'.");
                    return data;
                }

                Console.WriteLine("Dados encontrados com sucesso!");

                while (reader.Read())
                {
                    Dictionary<string, object> row = new Dictionary<string, object>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row[reader.GetName(i)] = reader.GetValue(i);
                    }
                    data.Add(row);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            return data;
        }
  
        static public Dictionary<string, object> db_read()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();

            return data;
        }

        


    }
}