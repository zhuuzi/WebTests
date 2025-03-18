using System;
using System.IO;

namespace EpamTests.Utils
{
    public static class Constants
    {
        public static class Timeouts
        {
            public const int ImplicitWait = 10;
            public const int PageLoadTimeout = 30;
            public const int FileDownloadWait = 5000;
        }

        public static class Urls
        {
            public const string EpamUrl = "https://www.epam.com/";
        }

        public static class FilePaths
        {
            public static readonly string DownloadsPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            public const string FileName = "EPAM_Corporate_Overview_Q4FY-2024.pdf";
        }

        public static class Configurations
        {
            public const bool Headless = false;
        }
    }
}