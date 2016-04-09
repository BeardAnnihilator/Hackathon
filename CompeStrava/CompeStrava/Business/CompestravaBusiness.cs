using Strava.Activities;
using Strava.Clubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompeStrava.Business
{
    public class CompestravaBusiness
    {
        public List<Tuple<ActivityType, Club, LeaderboardVMentry>> GetLeaderBoard()
        {
            List<Tuple<ActivityType, Club, LeaderboardVMentry>> ret = new List<Tuple<ActivityType, Club, LeaderboardVMentry>>();
            foreach (Club c in Global.Global.strava.GetClubs())
            {
                var activities = Global.Global.strava.GetClubActivities(c.Id.ToString());

                foreach (ActivityType type in activities.Select(s => s.Type).Distinct().ToList())
                {
                    var act = activities.Where(a => a.Type == type);
                    var dist = act.Sum(a => a.Distance / 1000);
                    var dur = act.Sum(a => a.ElapsedTime);
                    var clim = 0;
                    var suf = act.Average(a => a.SufferScore);
                    var cal = act.Sum(a => a.Kilojoules);

                    ret.Add(new Tuple<ActivityType, Club, LeaderboardVMentry>(type, c, new LeaderboardVMentry(){
                        distance = dist,
                        duration = dur,
                        climbing = clim,
                        sufferScore = suf.HasValue ? suf.Value : 0,
                        calories = cal
                    }));
                }
            }
            return ret;
        }

        public class LeaderboardVMentry
        {
            public double distance;
            public double duration;
            public int climbing;
            public double sufferScore;
            public double calories;
        }
    }
}