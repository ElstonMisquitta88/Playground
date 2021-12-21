using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace AzureCosmosDB
{
    public class Course
    {
        public string id { get; set; }
        public string courseid { get; set; }
        public string courseName { get; set; }
        public int Rating { get; set; }

        public Course() { }

        public Course(string _id,string _Courseid,string _CourseName,int _Rating)
        {
            id = _id;
            courseid = _Courseid;
            courseName = _CourseName;
            Rating = _Rating;
        }

    }
}
