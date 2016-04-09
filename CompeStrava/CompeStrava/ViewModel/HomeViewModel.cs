using Strava.Athletes;
using Strava.Clubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompeStrava.ViewModel
{
    public class HomeViewModel
    {
        public List<Club> clubs {get;set;}
        public KeyValuePair<AthleteSummary, int> indiv {get;set;}
        public KeyValuePair<AthleteSummary, int> suffer { get; set; }
        public KeyValuePair<AthleteSummary, int> cal { get; set; }
    }
}