using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinjaTests.Mocking
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private Mock<IFileDownloadService> _fileDownloadService;
        private InstallerHelper _installerHelper;

        [SetUp]
        public void Setup()
        {
            _fileDownloadService = new Mock<IFileDownloadService>();
            _installerHelper = new InstallerHelper(_fileDownloadService.Object);

        }

        [Test]
        public void DownloadInstaller_DownloadSuccess_ReturnTrue()
        {
            //Arrange

            //Act
            var result = _installerHelper.DownloadInstaller("a", "b");

            //Assert
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void DownloadInstaller_DownloadFails_ReturnFalse()
        {
            //Arrange
            _fileDownloadService.Setup(m => m.DownloadFile(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();

            //Act
            var result = _installerHelper.DownloadInstaller("customer", "installer");

            //Assert
            Assert.That(result, Is.EqualTo(false));
        }
    }
}
