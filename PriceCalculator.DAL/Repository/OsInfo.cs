using System;

namespace PriceCalculator.DAL.Repository
{
    /// <summary>
    /// Get some information about Operating System
    /// </summary>
    public static class OsInfo
    {
        public static string GetOsInfo(bool isWithArchitecture = true)
        {
            OperatingSystem os = Environment.OSVersion;
            Version vs = os.Version;

            string operatingSystem = "";

            if (os.Platform == PlatformID.Win32Windows)
            {
                //This is a pre-NT version of Windows
                switch (vs.Minor)
                {
                    case 0:
                        operatingSystem = "95";
                        break;
                    case 10:
                        if (vs.Revision.ToString() == "2222A")
                            operatingSystem = "98SE";
                        else
                            operatingSystem = "98";
                        break;
                    case 90:
                        operatingSystem = "Me";
                        break;
                    default:
                        break;
                }
            }
            else if (os.Platform == PlatformID.Win32NT)
            {
                switch (vs.Major)
                {
                    case 3:
                        operatingSystem = "NT 3.51";
                        break;
                    case 4:
                        operatingSystem = "NT 4.0";
                        break;
                    case 5:
                        if (vs.Minor == 0)
                            operatingSystem = "2000";
                        else
                            operatingSystem = "XP";
                        break;
                    case 6:
                        if (vs.Minor == 0)
                            operatingSystem = "Vista";
                        else if (vs.Minor == 1)
                            operatingSystem = "7";
                        else if (vs.Minor == 2)
                            operatingSystem = "8";
                        else
                            operatingSystem = "8.1";
                        break;
                    case 10:
                        operatingSystem = "10";
                        break;
                    default:
                        break;
                }
            }

            if (operatingSystem != "")
            {
                operatingSystem = "Windows " + operatingSystem;
                // There is a service pack installed.
                if (os.ServicePack != "")
                {
                    //Append it to the OS name --- "Windows XP Service Pack 3"
                    operatingSystem += " " + os.ServicePack;
                }

                //Append the OS architecture.  i.e. "Windows XP Service Pack 3 32-bit"
                if (isWithArchitecture)
                {
                    operatingSystem += " " + getOsArchitecture().ToString() + "-bit";
                }
            }

            return operatingSystem;
        }

        private static int getOsArchitecture()
        {
            string pa = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");

            return ((String.IsNullOrEmpty(pa) || String.Compare(pa, 0, "x86", 0, 3, true) == 0) ? 32 : 64);
        }
    }
}
