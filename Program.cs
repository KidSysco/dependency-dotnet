using System;
using System.Collections.Generic;
using System.Linq;

namespace DependencyOrderResolver
{
  public class Program
  {
    public static void Main(string[] args)
    {
      try
      {
        // Meeting the primary requirement here.
        // See tests for more examples.
        string[,] input = new string[,]
        {
          { "t-shirt", "dress shirt" },
          { "dress shirt", "pants" },
          { "dress shirt", "suit jacket" },
          { "tie", "suit jacket" },
          { "pants", "suit jacket" },
          { "belt", "suit jacket" },
          { "suit jacket", "overcoat" },
          { "dress shirt", "tie" },
          { "suit jacket", "sun glasses" },
          { "sun glasses", "overcoat" },
          { "left sock", "pants" },
          { "pants", "belt" },
          { "suit jacket", "left shoe" },
          { "suit jacket", "right shoe" },
          { "left shoe", "overcoat" },
          { "right sock", "pants" },
          { "right shoe", "overcoat" },
          { "t-shirt", "suit jacket" }
        };

        var output = DependencyOrderResolver.GetItemOrderByDependency(input);
        Console.WriteLine(output);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        throw;
      }
    }
  }
}
