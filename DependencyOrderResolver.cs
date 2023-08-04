using System.Collections.Generic;

namespace DependencyOrderResolver
{
  public class DependencyOrderResolver
  {
    public static string GetItemOrderByDependency(string[,] dependencies)
    {
      try
      {
        // Create a dictionary to store the dependencies and their items.
        Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();

        // Build the graph and calculate the indegree for each item.
        for (int i = 0; i < dependencies.GetLength(0); i++)
        {
          string dependency = dependencies[i, 0];
          string item = dependencies[i, 1];

          // Initialize an empty list for the item if it doesn't exist in the graph.
          if (!graph.ContainsKey(dependency))
          {
            graph[dependency] = new List<string>();
          }
          if (!graph.ContainsKey(item))
          {
            graph[item] = new List<string>();
          }

          // Add the dependency as an outgoing edge from the item in the graph.
          graph[dependency].Add(item);
        }

        // Initialize the indegree for each item.
        Dictionary<string, int> indegree = new Dictionary<string, int>();
        foreach (var key in graph.Keys)
        {
          indegree[key] = 0;
        }

        // Calculate the indegree for each item.
        foreach (var dependenciesList in graph.Values)
        {
          foreach (var dependency in dependenciesList)
          {
            indegree[dependency]++;
          }
        }

        // Perform topological sorting using a queue.
        Queue<string> queue = new Queue<string>();
        foreach (var item in graph.Keys)
        {
          if (indegree[item] == 0)
          {
            queue.Enqueue(item);
          }
        }

        List<string> output = new List<string>();

        // Process items level by level, adding those with no dependencies to the output.
        while (queue.Count > 0)
        {
          List<string> currentItems = new List<string>();
          int queueLength = queue.Count;
          for (int i = 0; i < queueLength; i++)
          {
            var currentItem = queue.Dequeue();
            currentItems.Add(currentItem);

            // Decrease the indegree of neighboring items and add them to the queue if indegree becomes 0.
            foreach (var neighbor in graph[currentItem])
            {
              indegree[neighbor]--;
              if (indegree[neighbor] == 0)
              {
                queue.Enqueue(neighbor);
              }
            }
          }

          // Sort the this level items alphabetically and add to the output.
          currentItems.Sort();
          output.Add(string.Join(", ", currentItems));
        }

        return string.Join("\n", output);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        throw;
      }
    }
  }
}
