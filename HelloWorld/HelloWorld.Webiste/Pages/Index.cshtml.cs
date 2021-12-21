using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Webiste.Models;
using HelloWorld.Webiste.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HelloWorld.Webiste.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public ParticipantDetail _ParticipantDetail { get; set; }


        public ParticipantDetailService _ParticipantService;
        public IndexModel(ILogger<IndexModel> logger, ParticipantDetailService ParticipantService)
        {
            _logger = logger;
            _ParticipantService = ParticipantService;
        }

        public void OnGet()
        {
            // Fetch All Data in a Grid
            //_ParticipantDetail.FirstName = "HHHHHH";
        }

        public void OnPostSave()
        {
            // Call Service to Save Data
            _ParticipantService.AddParticipant(_ParticipantDetail);
        }

    }
}
