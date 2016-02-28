using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderedJobs
{
  public class OrderedJobs : List<Job>
  {
    public IEnumerable<string> OrderedList()
    {
      var dependencyList = this.Where(job => !job.HasDependency).Select(job => job.Name).ToList();

      foreach (var job in this.Where(job => job.HasDependency))
      {
        if (job.DependencyName.Equals(job.Name, StringComparison.InvariantCultureIgnoreCase))
        {
          throw new SelfReferencingDependencyException();
        }
        AddIfExists(dependencyList, job.DependencyName);
        AddIfExists(dependencyList, job.Name);
      }
      return dependencyList;
    }

    private static void AddIfExists(ICollection<string> dependencyList, string name)
    {
      if (!dependencyList.Contains(name))
      {
        dependencyList.Add(name);
      }
    }
  }
}