using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IFileDownloadService
    {
        void DownloadFile(string customerName, string installerName);
    }

    public class FileDownloadService : IFileDownloadService
    {
        private readonly string _setupDestinationFile;

        public FileDownloadService(string setupDestinationFile)
        {
            _setupDestinationFile = setupDestinationFile;
        }
        public void DownloadFile(string customerName, string installerName)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(
                    $"http://example.com/{customerName}/{installerName}",
                    _setupDestinationFile);                
            }
        }

    }
}
