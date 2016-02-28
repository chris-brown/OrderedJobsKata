using NUnit.Framework;

namespace OrderedJobs.Tests.Steps
{
  [TestFixture]
  class Step6 : TestBase
  {
    private string _sequence;
    private string _result;

    protected override void Given()
    {
      _sequence = @"a =>
                    b =>
                    c => c";
    }

    protected override void When()
    {
      _result = _instructions.Process(_sequence);
    }

    [Test]
    public void Multiple_Jobs_Self_Referencing_Dependency()
    {
      Assert.That(_result, Is.EqualTo("jobs can’t depend on themselves"));
    }
  }
}
