using NUnit.Framework;

namespace OrderedJobs.Tests.Steps
{
  internal abstract class TestBase
  {
    protected Instructions _instructions = new Instructions();

    [SetUp]
    public void BddStyleSetup()
    {
      Given();
      When();
    }

    protected abstract void Given();
    protected abstract void When();
  }
}