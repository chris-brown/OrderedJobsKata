﻿using System;
using System.Text;
using System.Threading.Tasks;

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

    public string Jobs(string job)
    {
      var sequence = string.Empty;
      if (string.IsNullOrEmpty(job)) return sequence;

      foreach (var line in job.Split(_lineReturnSplit, StringSplitOptions.RemoveEmptyEntries))
      {
        ParseInstruction(line);
      }

      return string.Join("", _orderedJobs.OrderedList());
    }

    private static void ParseInstruction(string instruction)
    {
      var jobSequence = instruction.Split(StructureSplit, StringSplitOptions.RemoveEmptyEntries);

      var job = new Job(jobSequence);

      _orderedJobs.Add(job);

      return;
    }
  }
}
