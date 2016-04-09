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
                        distance = Convert.ToInt32(dist),
                        duration = System.TimeSpan.FromSeconds(dur),
                        climbing = clim,
                        sufferScore = suf.HasValue ? Convert.ToInt32(suf.Value) : 0,
                        calories = Convert.ToInt32(cal)
                    }));
                }
            }
            return ret;
        }

        public class LeaderboardVMentry
        {
            public int distance;
            public TimeSpan duration;
            public int climbing;
            public int sufferScore;
            public int calories;
        }
    }
}