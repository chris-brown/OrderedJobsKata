using NUnit.Framework;

namespace OrderedJobs.Tests.Steps
{
  [TestFixture]
  class Step5 : TestBase
  {
    private string _result;
    private string _sequence;

    protected override void Given()
    {
      _sequence = @"a =>
                    b => c
                    c => f
                    d => a
                    e => b
                    f =>";
    }

    protected override void When()
    {
      _result = _instructions.Process(_sequence);
    }

    [Test]
    public void Multiple_Jobs_Multiple_Dependency(){
      Assert.That(_result, Is.EqualTo("afcbde"));
    }
  }
}
