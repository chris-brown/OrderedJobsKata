using NUnit.Framework;

namespace OrderedJobs.Tests.Steps
{
  [TestFixture]
  class Step7 : TestBase
  {
    private string _sequence;
    private string _result;

    protected override void Given()
    {
      _sequence = @"a =>
                    b => c
                    c => f
                    d => a
                    e =>
                    f => b";
    }

    protected override void When()
    {
      _result = _instructions.Process(_sequence);
    }

    [Test]
    public void Multiple_Jobs_Circular_Dependency_Chain()
    {
      Assert.That(_result, Is.EqualTo("circular dependency found"));
    }
  }
}
