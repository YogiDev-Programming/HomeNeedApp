using DataAccess.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeNeedsWebAPI.Settings
{
    public class ConnectionStringSetting : IConnectionStringSettings
    {
        private readonly AppSettings appSettings;
        public string ConnectionString { get; set; }
        public ConnectionStringSetting(IOptions<AppSettings> options)
        {
            this.appSettings = options.Value;

            //assign connection string value
            this.ConnectionString = appSettings.ConnectionString;

        }
    }
}
