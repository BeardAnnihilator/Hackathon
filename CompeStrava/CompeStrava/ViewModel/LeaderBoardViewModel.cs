using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompeStrava.ViewModel
{
    public class LeaderBoardViewModel
    {
        public List<Tuple<global::Strava.Activities.ActivityType, global::Strava.Clubs.Club, Business.CompestravaBusiness.LeaderboardVMentry>> data { get; set; }
    }
}