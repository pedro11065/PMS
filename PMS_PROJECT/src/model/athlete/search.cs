using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Npgsql;
using System.Text.Json;


namespace PMS.src.model.athlete.search
{
    class Search
    {
        static public List<Dictionary<string, object>> db_search()
        {
            string connectionString = "host=localhost;" +
                "Port=5432;" +
                "Database=PMS_PHSQ;" +
                "User Id=postgres;" +
                "Password=32372403;";

            Console.WriteLine("Conectando ao banco de dados...");
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();

            try
            {
                using var connection = new NpgsqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("Conexão bem-sucedida!");

                using var cmd = new NpgsqlCommand("SELECT * FROM athlete", connection);
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
        }// procurar no banco de dados

   
    }
}