using NUnit.Framework;

namespace OrderedJobs.Tests.Steps
{
  [TestFixture]
  class Step4 : TestBase
  {
    private string _result;
    private string _sequence;

    protected override void Given()
    {
      _sequence = @"a =>
                    b => c
                    c =>";
    }

    protected override void When()
    {
      _result = _instructions.Jobs(_sequence);
    }

    [Test]
    public void Multiple_Jobs_Single_Dependency(){
      Assert.That(_result, Is.EqualTo("acb"));
    }
  }
}
