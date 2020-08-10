using System;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Azure.Storage.Blob;

namespace helloazurestoragedemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //await GetSystemProperties();
            await GetName();
        }

        private static async Task GetName()
        {
            AppSetttings appSettings = AppSetttings.LoadAppSettings();

            Console.WriteLine("Name : " + appSettings.Name);
        }

        private static async Task GetSystemProperties()
        {
            AppSetttings appSettings = AppSetttings.LoadAppSettings();

            CloudBlobClient blobClient = Common.CreateBlobClientFromAccountAndKey(appSettings.SourceAccountName, appSettings.SourceSASToken);
            CloudBlobContainer container = blobClient.GetContainerReference(appSettings.SourceContainerName);
            await container.CreateIfNotExistsAsync();

            container.FetchAttributes();

            Console.WriteLine($"Properties for container {container.StorageUri.PrimaryUri.ToString()}");
            Console.WriteLine($"Etag: {container.Properties.ETag}");
            Console.WriteLine($"Last modified: {container.Properties.LastModified.ToString()}");
            Console.WriteLine($"Lease Status: {container.Properties.LeaseStatus.ToString()}");

            container.Metadata.Add("department", "Technical");
            container.Metadata["category"] = "Knowledge Base";
            container.Metadata.Add("docType", "txtDocuments");

            container.SetMetadata();

            container.FetchAttributes();
            foreach (var item in container.Metadata)
            {
                Console.WriteLine($"Key: {item.Key}");
                Console.WriteLine($"Value: {item.Value}");
            }
        }
    }
}
