using NUnit.Framework;

namespace DataModel.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var repo = new EFRepository();
            repo.GetSubscription();
            Assert.Pass();
        }
    }
}