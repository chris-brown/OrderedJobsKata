using System;

namespace OrderedJobs
{
  public class Instructions
  {
    private static readonly string[] StructureSplit = { "=>" };
    private readonly string[] _lineReturnSplit = { Environment.NewLine };
    private static OrderedJobs _orderedJobs;

    public Instructions()
    {
      _orderedJobs = new OrderedJobs();
    }

    public string Process(string job)
    {
      if (string.IsNullOrEmpty(job)) return job;

      foreach (var line in job.Split(_lineReturnSplit, StringSplitOptions.RemoveEmptyEntries))
      {
        ParseInstruction(line);
      }

      try
      {
        return string.Join("", _orderedJobs.OrderedList());
      }
      catch (SelfReferencingDependencyException ex)
      {
        return ex.Message;
      }
    }

    private static void ParseInstruction(string instruction)
    {
      var jobSequence = instruction.Split(StructureSplit, StringSplitOptions.RemoveEmptyEntries);

      _orderedJobs.Add(new Job(jobSequence));
    }
  }
}
