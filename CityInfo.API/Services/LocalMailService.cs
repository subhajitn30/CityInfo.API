using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    public class LocalMailService: IMailServices
    {
        private string _mailTo = Startup.Configuration["mailSetting:mailToAddress"];
        private string _mailFrom = "suti.sp1989@gmail.com";

        public void Send(string subject, string message)
        {
            Debug.WriteLine($"Mail from {_mailFrom} to {_mailTo}");
            Debug.WriteLine($"Subject:" , subject);
        }
    }
}
