using System.IO;
using System.Reflection;

namespace PriceCalculator.BLL.Constants
{
    public static class Constants
    {
        #region PC
        // Local .exe location
        private static string exePathLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string ExePathLocation
        {
            get
            {
                return exePathLocation;
            }
        }

        // Exe file
        private static string exeFile = Path.Combine(exePathLocation, "PriceCalculator.exe");
        public static string ExeFile
        {
            get
            {
                return exeFile;
            }
        }

        // Local database file location
        private static string localDBPath = ExePathLocation + "\\Contents\\Database\\PriceCalculator.db";
        public static string LocalDBPath
        {
            get
            {
                if (!Directory.Exists(ExePathLocation + "\\Contents\\Database\\"))
                {
                    if (!Directory.Exists(ExePathLocation + "\\Contents\\"))
                    {
                        Directory.CreateDirectory(ExePathLocation + "\\Contents\\");
                        Directory.CreateDirectory(ExePathLocation + "\\Contents\\Database\\");
                    }
                    else
                    {
                        Directory.CreateDirectory(ExePathLocation + "\\Contents\\Database\\");
                    }
                }

                return localDBPath;
            }
        }

        // Local images location
        private static string localImagesPath = ExePathLocation + "\\Contents\\Images\\";
        public static string LocalImagesPath
        {
            get
            {
                if (!Directory.Exists(ExePathLocation + "\\Contents\\Images\\"))
                {
                    if (!Directory.Exists(ExePathLocation + "\\Contents\\"))
                    {
                        Directory.CreateDirectory(ExePathLocation + "\\Contents\\");
                        Directory.CreateDirectory(ExePathLocation + "\\Contents\\Images\\");
                    }
                    else
                    {
                        Directory.CreateDirectory(ExePathLocation + "\\Contents\\Images\\");
                    }
                }

                return localImagesPath;
            }
        }
        #endregion
    }
}
