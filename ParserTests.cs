using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCase;

namespace UnitTests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void TestCorrect()
        {
            string check = "a";
            string min = "1";
            string max = "5";
            string password = "abcdj";
            string testsource = String.Format("{0} {1}-{2}: {3}",check, min, max, password);
            ParserToPasswordLimitation parser = new ParserToPasswordLimitation();
            PasswordLimitation pL = parser.Parse(testsource);
            Assert.AreEqual(check, pL.charCheck.ToString());
            Assert.AreEqual(min, pL.min.ToString());
            Assert.AreEqual(max, pL.max.ToString());
            Assert.AreEqual(password, pL.sourcePass.ToString());
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), ExceptionMessages.badFormatting)]
        public void TestLessParams()
        {
            string check = "a";
            string min = "1";
            string max = "";
            string password = "abcdj";
            string testsource = String.Format("{0} {1}-{2}: {3}", check, min, max, password);
            ParserToPasswordLimitation parser = new ParserToPasswordLimitation();
            PasswordLimitation pL = parser.Parse(testsource);;
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), ExceptionMessages.badFormatting)]
        public void TestMoreParams()
        {
            string check = "a";
            string min = "1";
            string max = "5";
            string password = "abcdj somethingelse";
            string testsource = String.Format("{0} {1}-{2}: {3}", check, min, max, password);
            ParserToPasswordLimitation parser = new ParserToPasswordLimitation();
            PasswordLimitation pL = parser.Parse(testsource);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), ExceptionMessages.badChar)]
        public void TestWrongChar()
        {
            string check = "ab";
            string min = "1";
            string max = "5";
            string password = "abcdj";
            string testsource = String.Format("{0} {1}-{2}: {3}", check, min, max, password);
            ParserToPasswordLimitation parser = new ParserToPasswordLimitation();
            PasswordLimitation pL = parser.Parse(testsource);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), ExceptionMessages.minGreaterThanMax)]
        public void TestMinMoreThanMax()
        {
            string check = "a";
            string min = "10";
            string max = "5";
            string password = "abcdj";
            string testsource = String.Format("{0} {1}-{2}: {3}", check, min, max, password);
            ParserToPasswordLimitation parser = new ParserToPasswordLimitation();
            PasswordLimitation pL = parser.Parse(testsource);
        }
        [TestMethod]
        public void EmptyPassword()
        {
            string check = "a";
            string min = "1";
            string max = "5";
            string password = "";
            string testsource = String.Format("{0} {1}-{2}: {3}", check, min, max, password);
            ParserToPasswordLimitation parser = new ParserToPasswordLimitation();
            PasswordLimitation pL = parser.Parse(testsource);
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            string consoleout = stringWriter.ToString();
            Assert.AreEqual(check, pL.charCheck.ToString());
            Assert.AreEqual(min, pL.min.ToString());
            Assert.AreEqual(max, pL.max.ToString());
            Assert.AreEqual(password, pL.sourcePass.ToString());
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), ExceptionMessages.badInts)]
        public void BadMin()
        {
            string check = "a";
            string min = "f";
            string max = "5";
            string password = "";
            string testsource = String.Format("{0} {1}-{2}: {3}", check, min, max, password);
            ParserToPasswordLimitation parser = new ParserToPasswordLimitation();
            PasswordLimitation pL = parser.Parse(testsource);
            
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), ExceptionMessages.badInts)]
        public void BadMax()
        {
            string check = "a";
            string min = "1";
            string max = "e";
            string password = "";
            string testsource = String.Format("{0} {1}-{2}: {3}", check, min, max, password);
            ParserToPasswordLimitation parser = new ParserToPasswordLimitation();
            PasswordLimitation pL = parser.Parse(testsource);
        }
    }
}