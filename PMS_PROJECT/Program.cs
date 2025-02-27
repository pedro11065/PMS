using System;
using System.Security.Cryptography;
using PMS.src.model.athlete.search;
using PMS_PROJECT.src.model.key;

class Program
{
    static void Main()
    {

        Key.DatabaseConfigurator();

        List<Dictionary<string, object>> data = Search.db_search(); // Chamando a função db_search()
    }
}
