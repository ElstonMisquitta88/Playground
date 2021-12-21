using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace HelloWorld.Webiste.Models
{
    public class ParticipantDetail
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string City { get; set; }

        // Get Json Data of the Class Object
        public override string ToString() => JsonSerializer.Serialize<ParticipantDetail>(this);

    }
}
