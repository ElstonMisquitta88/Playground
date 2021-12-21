using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace AzureTables
{
    class Program
    {
        public static string _Connectionstring = "";
        public static string _tablename = "customerdetails";
        static void Main(string[] args)
        {
            //// (1) Create a Table in Storage Account
            //CloudStorageAccount _account = CloudStorageAccount.Parse(_Connectionstring);
            //CloudTableClient _tableclient = _account.CreateCloudTableClient();
            //CloudTable _table = _tableclient.GetTableReference(_tablename);
            //_table.CreateIfNotExists();

            //Console.WriteLine(_tablename + " : Table Created");
            //Console.ReadKey();


            // (2) Add Data to the Table
            //CloudStorageAccount _account = CloudStorageAccount.Parse(_Connectionstring);
            //CloudTableClient _tableclient = _account.CreateCloudTableClient();
            //CloudTable _table = _tableclient.GetTableReference(_tablename);

            //Customer custobj = new Customer("Mumbai", "1", "Elston");
            //TableOperation _operation = TableOperation.Insert(custobj);
            //TableResult _result = _table.Execute(_operation);


            //Console.WriteLine(" Record Added");
            //Console.ReadKey();



            //// (3) Batch Operation  - Insert a Batch of Entities at a Time

            //CloudStorageAccount _account = CloudStorageAccount.Parse(_Connectionstring);
            //CloudTableClient _tableclient = _account.CreateCloudTableClient();
            //CloudTable _table = _tableclient.GetTableReference(_tablename);

            //List<Customer> _customers = new List<Customer>()
            //{
            //    new Customer("Mumbai", "2", "Sam"),
            //    new Customer("Mumbai", "3", "Ham"),
            //    new Customer("Mumbai", "4", "Ram"),
            //};
            //TableBatchOperation _operation = new TableBatchOperation();
            //foreach (Customer cust in _customers)
            //{
            //    _operation.Insert(cust);
            //}

            //TableBatchResult  _result = _table.ExecuteBatch (_operation);


            //Console.WriteLine(" Records Added");
            //Console.ReadKey();


            //// (4) Read Entity from a Table

            //CloudStorageAccount _account = CloudStorageAccount.Parse(_Connectionstring);
            //CloudTableClient _tableclient = _account.CreateCloudTableClient();
            //CloudTable _table = _tableclient.GetTableReference(_tablename);

            //string _partitonkey = "Mumbai";
            //string _RowKey = "3";
            //TableOperation _operation = TableOperation.Retrieve<Customer>(_partitonkey, _RowKey);
            //TableResult _result = _table.Execute(_operation);
            //Customer _custresult = (Customer)_result.Result;

            //Console.WriteLine(_custresult.PartitionKey);
            //Console.WriteLine(_custresult.RowKey);
            //Console.WriteLine(_custresult.Customername);
            //Console.ReadKey();    


            //// (5) Update Entity from a Table

            //CloudStorageAccount _account = CloudStorageAccount.Parse(_Connectionstring);
            //CloudTableClient _tableclient = _account.CreateCloudTableClient();
            //CloudTable _table = _tableclient.GetTableReference(_tablename);

            //Customer custobj = new Customer("Mumbai", "1", "ElstonMisquitta1");

            //TableOperation _operation = TableOperation.InsertOrMerge(custobj);
            ////TableOperation _operation = TableOperation.InsertOrReplace(custobj);
            //TableResult _result = _table.Execute(_operation);

            //Console.WriteLine("Update Done");
            //Console.ReadKey();




            // (6) Delete Entity from a Table

            CloudStorageAccount _account = CloudStorageAccount.Parse(_Connectionstring);
            CloudTableClient _tableclient = _account.CreateCloudTableClient();
            CloudTable _table = _tableclient.GetTableReference(_tablename);

            string _partitonkey = "Mumbai";
            string _RowKey = "3";
            
            //(a) First Retive Row Object
            TableOperation _operation = TableOperation.Retrieve<Customer>(_partitonkey, _RowKey);
            TableResult _result = _table.Execute(_operation);
            Customer _custresult = (Customer)_result.Result;

            //(b) Then Delete
            TableOperation _deleteoperation = TableOperation.Delete(_custresult);
            TableResult _resultdelete = _table.Execute(_deleteoperation);
            
            Console.WriteLine("Delete Done");
            Console.ReadKey();

        }
    }
}
