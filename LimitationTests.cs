using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCase;

namespace UnitTests
{
    [TestClass]
    public class LimitationTests
    {
        [TestMethod]
        public void TestLessThanMin()
        {
            PasswordLimitation lim = new PasswordLimitation(1, 5, 'a', "kfdjndf");
            bool check = lim.Check();
            Assert.IsFalse(check);
        }
        [TestMethod]
        public void TestMin()
        {
            PasswordLimitation lim = new PasswordLimitation(1, 5, 'a', "akfdjndf");
            bool check = lim.Check();
            Assert.IsTrue(check);
        }
        [TestMethod]
        public void TestMinPlusOne()
        {
            PasswordLimitation lim = new PasswordLimitation(1, 5, 'a', "aakfdjndf");
            bool check = lim.Check();
            Assert.IsTrue(check);
        }
        [TestMethod]
        public void TestMaxMinusOne()
        {
            PasswordLimitation lim = new PasswordLimitation(1, 5, 'a', "akfaadjnadfa");
            bool check = lim.Check();
            Assert.IsTrue(check);
        }
        [TestMethod]
        public void TestMax()
        {
            PasswordLimitation lim = new PasswordLimitation(1, 5, 'a', "aaakfdajndaf");
            bool check = lim.Check();
            Assert.IsTrue(check);
        }
        [TestMethod]
        public void TestMoreThanMax()
        {
            PasswordLimitation lim = new PasswordLimitation(1, 5, 'a', "aaakfdjnaadfa");
            bool check = lim.Check();
            Assert.IsFalse(check);
        }
    }
}