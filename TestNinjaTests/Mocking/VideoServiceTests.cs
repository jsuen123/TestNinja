using System.Collections.Generic;
using System.Data.Entity;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinjaTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private Mock<IVideoRepository> _repository;
        private VideoService _videoService;

        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<IVideoRepository>();
            _videoService = new VideoService(_repository.Object);
        }

        [Test]
        public void GetUnprocessedVideosAsAsCsc_AllVideosAreProcessed_ReturnAnEmptyString()
        {
            _repository.Setup(vc => vc.GetUnprocessedVideo()).Returns(new List<Video>());

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideosAsAsCsc_WhenCalled_ReturnAStringWithIdOfUnprocessedVideos()
        {
            _repository.Setup(vc => vc.GetUnprocessedVideo()).Returns(new List<Video>()
            {
                new Video(){Id=1, IsProcessed = false},
                new Video(){Id=3, IsProcessed = false},
            });
            
            var result = _videoService.GetUnprocessedVideosAsCsv();
            
            Assert.That(result, Is.EqualTo("1,3"));
        }
    }
}