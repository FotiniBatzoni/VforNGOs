using NUnit.Framework;
using VforNGOss.Utilities;

namespace VforNGOss.Tests
{
    [TestFixture,Description("Validating Email")]
    public class Tests
    {
        [Test,Description("The given email is in correct format")]
        public void EmailIsValid()
        {
            string email = "babis@gmail.com";

            bool isValid = ValidateEmail.EmailIsValid(email);

            Assert.AreEqual(true, isValid);

        }

        [Test, Description("The given email is in incorrect format .com/en/etc is missing")]
        public void EmailIsValid_MissingDotPart()
        {
            string email = "babis@gmail";

            bool isValid = ValidateEmail.EmailIsValid(email);

            Assert.AreEqual(false, isValid);

        }
    }
}