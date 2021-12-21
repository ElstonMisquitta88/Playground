using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using HelloWorld.Webiste.Models;


namespace HelloWorld.Webiste.Services
{
    public class ParticipantDetailService
    {
        public Helper _HelperService;
        public ParticipantDetailService(Helper HelperService)
        {
            _HelperService = HelperService;
        }


        public bool AddParticipant(ParticipantDetail _participant)
        {
            using (IDbConnection connection = new SqlConnection(_HelperService.CnnVal("BoSwaraj")))
            {
                connection.Execute("Proc_ParticipantAdd @FirstName, @LastName", _participant);
            }
            return true;
        }
    }
}
