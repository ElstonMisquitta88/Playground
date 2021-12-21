using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureTables
{
    public class Customer : TableEntity
    {
        public string Customername { get; set; }

        public Customer()
        {

        }
        public Customer(string _PartitionKey, string _RowKey, string _Customername)
        {
            PartitionKey = _PartitionKey;
            RowKey = _RowKey;
            Customername = _Customername;
        }
    }
}
