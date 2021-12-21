using System;
using System.IO;
using System.Reflection.Metadata;
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Sas;

namespace AzureBlobs
{
    class Program
    {
        static void Main(string[] args)
        {

            string _StorageAccountConn = "";


            // [1] Creation of a Blob Container
            //string _Containername = "trekimages";

            // (a) Service
            //BlobServiceClient BlobServiceobj = new BlobServiceClient(_StorageAccountConn);
            //BlobServiceobj.CreateBlobContainer(_Containername);

            //Console.WriteLine("Container Created");
            //Console.Read();

            // ****************************************************************************
            // ****************************************************************************

            ////[2] Upload File to Blob Container
            //string _Containername = "trekimages";
            //string _blobName = "Desert.jpg";
            //string _filepath = "D:\\BImg\\Desert.jpg";

            //// (a) Service
            //BlobServiceClient BlobServiceobj = new BlobServiceClient(_StorageAccountConn);

            //// (b) Container
            //BlobContainerClient _containerobj = BlobServiceobj.GetBlobContainerClient(_Containername);

            // (c) Blob
            //BlobClient _clientobj = _containerobj.GetBlobClient(_blobName);
            //_clientobj.Upload(_filepath);


            //Console.WriteLine("File Uploaded");
            //Console.ReadLine();


            // ****************************************************************************
            // ****************************************************************************

            //[3] List all items in Blob Container
            //string _Containername = "trekimages";

            //// (a) Service
            //BlobServiceClient BlobServiceobj = new BlobServiceClient(_StorageAccountConn);

            //// (b) Container
            //BlobContainerClient _containerobj = BlobServiceobj.GetBlobContainerClient(_Containername);

            //foreach(BlobItem item in _containerobj.GetBlobs())
            //{
            //    Console.WriteLine("Name " + item.Name);
            //}
            //Console.ReadLine();


            // ****************************************************************************
            // ****************************************************************************
            //[4] Download Blob in Blob Container

            //string _Containername = "trekimages";
            //string _blobName = "Desert.jpg";
            //string _filepath = "D:\\BImg\\Desert_New.jpg";

            //// (a) Service
            //BlobServiceClient BlobServiceobj = new BlobServiceClient(_StorageAccountConn);

            //// (b) Container
            //BlobContainerClient _containerobj = BlobServiceobj.GetBlobContainerClient(_Containername);

            //// (c) Blob
            //BlobClient _clientobj = _containerobj.GetBlobClient(_blobName);
            //_clientobj.DownloadTo(_filepath);

            //Console.WriteLine("File Downloaded");
            //Console.ReadLine();



            // ****************************************************************************
            // ****************************************************************************
            ////[5] Shared Access Signatures
            //string _Containername = "trekimages";
            //string _blobName = "Desert.jpg";
            //string _filepath = "D:\\BImg\\Desert_New1.jpg";
            //// (a) Service
            //BlobServiceClient BlobServiceobj = new BlobServiceClient(_StorageAccountConn);

            //// (b) Container
            //BlobContainerClient _containerobj = BlobServiceobj.GetBlobContainerClient(_Containername);

            //// (c) Blob
            //BlobClient _clientobj = _containerobj.GetBlobClient(_blobName);


            //BlobSasBuilder _builder = new BlobSasBuilder()
            //{
            //    BlobContainerName = _Containername,
            //    BlobName = _blobName,
            //    Resource ="b"
            //};

            //_builder.SetPermissions(BlobSasPermissions.Read | BlobSasPermissions.List);
            //_builder.ExpiresOn = DateTimeOffset.UtcNow.AddHours(1);

            //Uri  _URI = _clientobj.GenerateSasUri(_builder);
            //Console.WriteLine(_URI);


            //// Download Blob Using the URI
            //BlobClient _clientobj1 = new BlobClient(_URI);
            //_clientobj1.DownloadTo(_filepath);


            // ****************************************************************************
            //[6] Blob Properties And MetaData

            //string _Containername = "data";
            //string _blobName = "Desert.jpg";

            //// (a) Service
            //BlobServiceClient BlobServiceobj = new BlobServiceClient(_StorageAccountConn);

            //// (b) Container
            //BlobContainerClient _containerobj = BlobServiceobj.GetBlobContainerClient(_Containername);

            //// (c) Blob
            //BlobClient _clientobj = _containerobj.GetBlobClient(_blobName);

            //BlobProperties _properties = _clientobj.GetProperties();
            //Console.WriteLine("AccessTier " + _properties.AccessTier);
            //Console.WriteLine("BlobType " + _properties.BlobType);
            //Console.ReadLine();



            // ****************************************************************************
            // [7] Blob Lease Example

            string _Containername = "data";
            string _blobName = "testfile.txt";

            // (a) Service
            BlobServiceClient BlobServiceobj = new BlobServiceClient(_StorageAccountConn);

            // (b) Container
            BlobContainerClient _containerobj = BlobServiceobj.GetBlobContainerClient(_Containername);

            // (c) Blob
            BlobClient _clientobj = _containerobj.GetBlobClient(_blobName);


            MemoryStream _memoryobj = new MemoryStream();
            _clientobj.DownloadTo(_memoryobj);

            StreamReader _reader = new StreamReader(_memoryobj);
            Console.WriteLine(_reader.ReadToEnd());



            BlobLeaseClient _bloblease = _clientobj.GetBlobLeaseClient();
            BlobLease _lease = _bloblease.Acquire(TimeSpan.FromSeconds(30));



            StreamWriter _writer = new StreamWriter(_memoryobj);
            _writer.WriteLine(" Ahh Added new text V1");
            _writer.Flush();


            BlobUploadOptions _blobuploadoptions = new BlobUploadOptions()
            {
                Conditions = new BlobRequestConditions()
                {
                    LeaseId = _lease.LeaseId
                }
            };


            _memoryobj.Position = 0;
            //_clientobj.Upload(_memoryobj, true); // OverWrite set to True
            _clientobj.Upload(_memoryobj, _blobuploadoptions); // Using Blob Upload Options for using Lease ID
            _bloblease.Release();  // Release Lease

            Console.ReadLine();


        }
    }
}
