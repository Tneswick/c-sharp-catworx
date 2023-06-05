using System;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
  class Program
  {
    async static Task Main(string[] args)
    {
      List<Employee> employees = new List<Employee>();
      while (true)
      {
        Console.WriteLine("Would you like to enter employee data? (y|n)");
        string res1 = Console.ReadLine() ?? "";
        if (res1 == "y" || res1 == "yes" || res1 == "Yes")
        {
          employees = PeopleFetcher.GetEmployees();
          Util.MakeCSV(employees);
          await Util.MakeBadges(employees);
        }

        Console.WriteLine("Would you like to generate random user data? (y|n)");
        string res2 = Console.ReadLine() ?? "";
        if (res2 == "y" || res2 == "yes" || res2 == "Yes")
        {
          employees = await PeopleFetcher.GetFromApi();
          Util.MakeCSV(employees);
          await Util.MakeBadges(employees);
        }
      }
    }
  }
}