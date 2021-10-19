using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        private ErrorLogger logger;

        [SetUp]
        public void SetUp()
        {
            this.logger = new ErrorLogger();
        }

        [Test]
        public void Log_WhenCalled_SetLastErrorProperty()
        {
            this.logger.Log("abc");

            Assert.That(logger.LastError, Is.EqualTo("abc"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void Log_InvalidError_ThrowsArgumentNulllException(string error)
        {
            //this.logger.Log(error); -> Throws ArgumentNullException

            Assert.That(() => this.logger.Log(error), Throws.ArgumentNullException);
        }

        [Test]
        public void Log_ValidError_RaiseErrorLogEvent()
        {
            var id = Guid.Empty;

            this.logger.ErrorLogged += (sender, args) => { id = args; };

            this.logger.Log("abc");

            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }
    }
}
