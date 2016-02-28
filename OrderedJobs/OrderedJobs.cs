using System.Collections.Generic;

namespace OrderedJobs
{
  public class OrderedJobs : List<Job>
  {
    public IEnumerable<string> OrderedList()
    {
      var dependencyList = new List<string>();
      foreach (var job in this)
      {
        if (job.HasDependency)
        {
          AddIfExists(dependencyList, job.DependencyName);
          AddIfExists(dependencyList, job.Name);
        }
        else
        {
          AddIfExists(dependencyList, job.Name);
        }
      }
      return dependencyList;
    }

    private static void AddIfExists(List<string> dependencyList, string name)
    {
      if (!dependencyList.Contains(name))
      {
        dependencyList.Add(name);
      }
    }
  }
}