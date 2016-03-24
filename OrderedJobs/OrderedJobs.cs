using System.Collections.Generic;
using System.Linq;
using OrderedJobs.Exceptions;

namespace OrderedJobs
{
  public class OrderedJobs : List<Job>
  {
    private const int DependencyDepth = 3;

    public Job this[string name]
    {
      get { return this.FirstOrDefault(job => job.Name.Equals(name)); }
    }

    public IEnumerable<string> OrderedList()
    {
      var dependencyList = this.Where(job => !job.HasDependency).Select(job => job.Name).ToList();

      foreach (var job in this.Where(job => job.HasDependency))
      {
        Validate(job, this);
        AddIfExists(dependencyList, job.DependencyName);
        AddIfExists(dependencyList, job.Name);
      }
      return dependencyList;
    }

    private static void Validate(Job job, OrderedJobs dependencyList)
    {
      var givenJob = job;

      while (givenJob.HasDependency)
      {
        givenJob = JobHasNoDependency(givenJob, dependencyList, 0);
      }
    }

    private static Job JobHasNoDependency(Job job, OrderedJobs dependencyList, int i)
    {
      if (string.IsNullOrEmpty(job.DependencyName)) return job;

      var dependentJob = dependencyList[job.DependencyName];

      if (dependentJob == null || string.IsNullOrEmpty(dependentJob.DependencyName)) return dependentJob;

      if (i++ >= DependencyDepth)
      {
        throw new CircularReferencingDependencyException();
      }

      return JobHasNoDependency(dependentJob, dependencyList, i);
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