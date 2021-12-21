using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureCosmosDB
{
    class Program
    {
        public static string _connectionstring = "AccountEndpoint=https://udemydemo.documents.azure.com:443/;AccountKey=jjGx98N8G4nEbU5wF9oxLyJioHq1qvfQDGCepiGDhl8QFsLzoJJQGNzPG1jxGcNi83jMVbhuVmCsBpyfGdfQQg==;";
        public static string _databasename = "appdb";
        public static string _containername = "course";
        public static string _partitionkey = "/courseid";

        static void Main(string[] args)
        {
            //**********************************************************
            //(1) Create a Database and Container(Table)

            ////(a) Create Database
            //CosmosClient _client = new CosmosClient(_connectionstring);
            //_client.CreateDatabaseAsync(_databasename).GetAwaiter();
            //Console.WriteLine("Database Created");

            ////(b) Get object of database to create a container(Table)
            //Database _database = _client.GetDatabase(_databasename);
            //_database.CreateContainerAsync(_containername, _partitionkey).GetAwaiter();
            //Console.WriteLine("Container Created");

            //Console.ReadKey();


            ////**********************************************************
            ////(2) Add an item to the container

            //CosmosClient _client = new CosmosClient(_connectionstring);
            //Course courseobj = new Course("2", "C0001", "AZ205", 4);

            //Container container = _client.GetContainer(_databasename, _containername);

            //container.CreateItemAsync<Course>(courseobj, new PartitionKey(courseobj.courseid)).GetAwaiter().GetResult();

            //Console.WriteLine("Item Added");
            //Console.ReadKey();


            //**********************************************************
            //(3) Bulk Insert of item to the container

            //CosmosClient _client = new CosmosClient(_connectionstring, new CosmosClientOptions() { AllowBulkExecution = true });
            //List<Course> courseobj = new List<Course>()
            //{
            //     new Course("4", "C0001", "AZ305", 7),
            //     new Course("5", "C0001", "AZ306", 7),
            //     new Course("6", "C0003", "AZ307", 7)
            //};

            //Container container = _client.GetContainer(_databasename, _containername);

            //List<Task> _DoTask = new List<Task>();
            //foreach (Course _crse in courseobj)
            //{
            //    _DoTask.Add(container.CreateItemAsync<Course>(_crse, new PartitionKey(_crse.courseid)));
            //}

            //Task.WhenAll(_DoTask).GetAwaiter().GetResult();

            //Console.WriteLine("Bluk Add Complete");
            //Console.ReadKey();





            //(4) Read Data

            //CosmosClient _client = new CosmosClient(_connectionstring, new CosmosClientOptions() { AllowBulkExecution = true });
            //Container container = _client.GetContainer(_databasename, _containername);
            //string _query = "select * from c where c.courseid='C0003'";
            //QueryDefinition _definition = new QueryDefinition(_query);
            //FeedIterator<Course> _iterator = container.GetItemQueryIterator<Course>(_definition);
            //while (_iterator.HasMoreResults)
            //{
            //    FeedResponse<Course> _response = _iterator.ReadNextAsync().GetAwaiter().GetResult();
            //    foreach (Course _course in _response)
            //    {
            //        Console.WriteLine("******************");
            //        Console.WriteLine(_course.courseName);
            //        Console.WriteLine("******************");
            //    }
            //}
            //Console.ReadKey();


            //(5) Execute a Simple Stored Procedure
            CosmosClient _client = new CosmosClient(_connectionstring, new CosmosClientOptions() { AllowBulkExecution = true });
            Container container = _client.GetContainer(_databasename, _containername);

            string _result=container.Scripts.ExecuteStoredProcedureAsync<string>("demoem", new PartitionKey(string.Empty), null).GetAwaiter().GetResult();

            Console.WriteLine(_result);
            Console.ReadKey();

        }
    }
}
