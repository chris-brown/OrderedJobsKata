using NUnit.Framework;

namespace OrderedJobs.Tests.Steps
{
  [TestFixture]
  class Step3 : TestBase
  {
    private string _result;
    private string _value;

    protected override void Given()
    {
      _value = @"a =>
                  b =>
                  c =>";
    }

    protected override void When()
    {
      _result = _instructions.Process(_value);
    }

    [Test]
    public void Multiple_Jobs(){
      Assert.That(_result, Is.EqualTo("abc"));
    }
  }
}
