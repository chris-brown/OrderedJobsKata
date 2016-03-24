using System.Linq;
using OrderedJobs.Exceptions;

namespace OrderedJobs
{
  public class Job
  {
    private readonly string[] _sequence;

    public Job(string[] sequence)
    {
      _sequence = sequence;

      if(HasDependency && DependencyName == Name) throw new SelfReferencingDependencyException();
    }

    public string Name
    {
      get { return _sequence.First().Trim(); }
    }

    public string DependencyName
    {
      get
      {
        return (_sequence.Length > 1) ? _sequence[1].Trim() : null;
      }
    }

    public bool HasDependency
    {
      get { return DependencyName != null; }
    }
  }
}