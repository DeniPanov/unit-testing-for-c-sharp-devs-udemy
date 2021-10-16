using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        private CustomerController controller;

        [SetUp]
        public void SetUp()
        {
            this.controller = new CustomerController();
        }

        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            var result = this.controller.GetCustomer(0);

            // Not found
            Assert.That(result, Is.TypeOf<NotFound>());
        }

        [Test]
        public void GetCustomer_IdIsNotZero_ReturnOk()
        {
            var result = this.controller.GetCustomer(1);

            // Ok or instance of its derivatives
            Assert.That(result, Is.InstanceOf<Ok>());
        }
    }
}
