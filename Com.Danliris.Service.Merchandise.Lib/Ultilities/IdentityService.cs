﻿

namespace Com.Danliris.Service.Merchandiser.Lib.Ultilities
{
   
    public class IdentityService : IIdentityService
    {

        public string Username { get; set; }
        public string Token { get; set; }
        public int TimezoneOffset { get; set; }

        
    }
}
