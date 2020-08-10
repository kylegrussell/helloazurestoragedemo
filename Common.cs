using System;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.Storage.Auth;
namespace helloazurestoragedemo
{
    public class Common
    {
        public static CloudBlobClient CreateBlobClientFromAccountAndKey(string accountName, string keyValue)
        {
            CloudStorageAccount storageAccount;
            CloudBlobClient blobClient;

            try
            {
                StorageCredentials credentials = new StorageCredentials(accountName, keyValue);
                storageAccount = new CloudStorageAccount(credentials, accountName, null, true);
                blobClient = storageAccount.CreateCloudBlobClient();
            }
            catch (Exception ex)
            {
                throw;
            }

            return blobClient;
        }
    }
}
