using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzFunBlobTrigger
{
    public class Blob
    {
        public string BlobID { get; set; }
        public string BlobName { get; set; }
        public string BlobSize { get; set; }
    }
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([BlobTrigger("demodata/{name}", Connection = "storage_connection")]Stream myBlob,
             [CosmosDB(
                databaseName: "appdb",
                collectionName: "blobs",
                ConnectionStringSetting = "CosmosDBConnection")]out dynamic document,
            string name, ILogger log)
        {
            Blob _blob = new Blob()
            {
                BlobID = Guid.NewGuid().ToString(),
                BlobName = name,
                BlobSize = myBlob.Length.ToString()
            };
            document = _blob;

            log.LogInformation($"C# Blob trigger function Triggered");
        }
    }
}
