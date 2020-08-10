using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace helloazurestoragedemo
{
    public class AppSetttings
    {
        public string SourceSASToken { get; set; }
        public string SourceAccountName { get; set; }
        public string SourceContainerName { get; set; }
        public string DestinationSASToken { get; set; }
        public string DestinationAccountName { get; set; }
        public string DestinationContainerName { get; set; }
        public object Name { get; set; }

        public static AppSetttings LoadAppSettings()
        {
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                .AddJsonFile("AppSettings.json", false)
                .Build();

            AppSetttings appSetttings = configurationRoot.Get<AppSetttings>();

            return appSetttings;
        }
    }
}