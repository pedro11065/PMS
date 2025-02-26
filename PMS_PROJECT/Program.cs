using System;
using PMS.src.model.athlete.search; 

class Program
{
    static void Main()
    {
        List<Dictionary<string, object>> data = Search.db_search(); // Chamando a função db_search()

        foreach (var line in data)
        {
            foreach (var item in line)
            {
                Console.Write($"{item.Key}: {item.Value} | ");
            }
            Console.WriteLine();
        }
    }
}
