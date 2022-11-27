using NUnit.Framework;
using VforNGOss.Utilities;

namespace VforNGOss.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EmailIsValidTest()
        {
            string email = "babis@gmail.com";

            bool isValid = ValidateEmail.EmailIsValid(email);

            Assert.AreEqual(true, isValid);

        }
    }
}