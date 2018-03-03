using System;
using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private readonly IFileDownloadService _fileDownloadService;
        private string _setupDestinationFile;

        public InstallerHelper(IFileDownloadService fileDownloadService)
        {
            _fileDownloadService = fileDownloadService;
        }
        public bool DownloadInstaller(string customerName, string installerName)
        {
            try
            {
                _fileDownloadService.DownloadFile(customerName, installerName);
                return true;
            }
            catch (WebException)
            {
                return false;
            }
        }

    }
}