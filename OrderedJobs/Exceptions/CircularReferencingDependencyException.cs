using System;

namespace OrderedJobs.Exceptions
{
  public class CircularReferencingDependencyException : Exception
  {
    public CircularReferencingDependencyException() : base("circular dependency found") {}
  }
}