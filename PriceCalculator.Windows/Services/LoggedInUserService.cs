using System;

namespace PriceCalculator.Windows.Services
{
    public static class LoggedInUserService
    {
        public static string GetLoggedInUserName()
        {
            return Environment.UserDomainName + "/" + Environment.UserName;
        }
    }
}
