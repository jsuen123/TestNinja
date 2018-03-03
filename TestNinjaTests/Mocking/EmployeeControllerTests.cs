using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinjaTests.Mocking
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        private EmployeeController _employeeController;
        private Mock<IEmployeeStorage> _employeeStorage;
        [SetUp]
        public void Setup()
        {
            _employeeStorage = new Mock<IEmployeeStorage>();
            _employeeController = new EmployeeController(_employeeStorage.Object);

        }
        [Test]
        public void DeleteEmployee_WhenCalled_ReturnActionResult()
        {
            var result = _employeeController.DeleteEmployee(It.IsAny<int>());

            Assert.That(result, Is.TypeOf<RedirectResult>());
        }

        [Test]
        public void DeleteEmployee_WhenCalled_DeleteEmployeeFromDb()
        {
            _employeeController.DeleteEmployee(1);            

            _employeeStorage.Verify(m => m.DeleteEmployee(1));
        }
    }
}