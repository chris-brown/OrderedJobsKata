using System;

namespace OrderedJobs.Exceptions
{
  public class SelfReferencingDependencyException : Exception
  {
    public SelfReferencingDependencyException() : base("jobs can’t depend on themselves") {}
  }
}
