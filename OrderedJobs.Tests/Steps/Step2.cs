using NUnit.Framework;

namespace OrderedJobs.Tests.Steps
{
  [TestFixture]
  class Step2 : TestBase
  {
    private string _result;
    private string _value;

    protected override void Given()
    {
      _value = "a =>";
    }

    protected override void When()
    {
      _result = _instructions.Jobs(_value);
    }

    [Test]
    public void Single_Job(){
      Assert.That(_result, Is.EqualTo("a"));
    }
  }
}
