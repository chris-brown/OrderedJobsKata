using System;
using NUnit.Framework;

namespace OrderedJobs.Tests
{
  [TestFixture(Description = "http://invalidcast.tumblr.com/post/52980617776/the-ordered-jobs-kata"), Ignore]
  class JobsKata
  {
    private readonly Instructions _instructions = new Instructions();

    [Test]
    public void Step1_GivenAnEmptyString_ResultShouldBeEmpty()
    {
      var result = _instructions.Process(string.Empty);

      Assert.That(result, Is.Empty);
    }

    [Test]
    public void Step2_GivenSingleJob_ExpectedSingleJobA()
    {
      var result = _instructions.Process("a =>");

      Assert.That(result, Is.EqualTo("a"));
    }

    [Test]
    public void Step3_GivenMultipleJobs_ReturnInExpectedSequence()
    {
      const string structure = @"a =>
                        b =>
                        c => ";
      var result = _instructions.Process(structure);

      Assert.That(result, Is.EqualTo("abc"));
    }

    [Test(Description = "The result should be a sequence that positions c before b, containing all three jobs"), Ignore]
    public void Step4_GivenMultipleJobsWithSingleDependency_ReturnInExpectedSequence()
    {
      const string structure = @"a =>
                                b => c
                                c =>";

      var result = _instructions.Process(structure);

      Assert.That(result, Is.EqualTo("acb"));
    }
  }
}
