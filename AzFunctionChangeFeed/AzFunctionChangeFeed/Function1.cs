using System;
using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzFunctionChangeFeed
{
    public class Course
    {
        public string courseid { get; set; }
        public string courseName { get; set; }
        public int Rating { get; set; }

    }
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([CosmosDBTrigger(
            databaseName: "appdb",
            collectionName: "course",
            ConnectionStringSetting = "cosmosdb",
            LeaseCollectionName = "leases",CreateLeaseCollectionIfNotExists =true )]IReadOnlyList<Document> input, ILogger log)
        {
            if (input != null && input.Count > 0)
            {
                foreach (var _course in input)
                {
                    log.LogInformation("Documents modified " + _course.GetPropertyValue <string>("courseName"));
                    log.LogInformation("First document Id " + input[0].Id);
                }
               
                
            }
        }
    }
}
