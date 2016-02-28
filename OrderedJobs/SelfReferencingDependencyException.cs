using System;

namespace OrderedJobs
{
  public class SelfReferencingDependencyException : Exception
  {
    public SelfReferencingDependencyException() : base("jobs can’t depend on themselves") {}
  }
}
