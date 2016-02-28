using NUnit.Framework;

namespace OrderedJobs.Tests.Steps
{
  [TestFixture]
  class Step1 : TestBase
  {
    private string _result;
    private string _value;

    protected override void Given()
    {
      _value = string.Empty;
    }

    protected override void When()
    {
      _result = _instructions.Process(_value);
    }

    [Test]
    public void Empty_String(){
      Assert.That(_result, Is.Empty);
    }
  }
}
