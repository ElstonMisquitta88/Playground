using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Webiste
{
    public class Helper
    {
        public IConfiguration _configuration;

        public Helper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CnnVal(string name)
        {
            string connString = _configuration.GetConnectionString(name);
            return connString;
        }
    }
}
