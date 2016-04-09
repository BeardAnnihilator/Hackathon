using Strava.Activities;
using Strava.Athletes;
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

        public KeyValuePair<AthleteSummary, int> GetUserWithMaxWorkout()
        {
            Dictionary<AthleteSummary, int> cache = new Dictionary<AthleteSummary, int>();
            foreach (Club c in Global.Global.strava.GetClubs())
            {
                var activities = Global.Global.strava.GetClubActivities(c.Id.ToString());

                var users = Global.Global.strava.GetClubMembers(c.Id.ToString());

                foreach (var act in activities)
                {
                    var us = users.Where(u => u.Id == act.Athlete.Id).First();
                    if (!cache.ContainsKey(us)) 
                    {
                        cache[us] = 1;
                    }
                    else
                    {
                        cache[us]++;
                    }
                }
            }
            return cache.OrderByDescending(d => d.Value).FirstOrDefault();
        }

        public KeyValuePair<AthleteSummary, int> GetUserWithMaxSuffer()
        {
            List<ActivitySummary> activities = new List<ActivitySummary>();
            List<AthleteSummary> users = new List<AthleteSummary>();
            Dictionary<AthleteSummary, int> cache = new Dictionary<AthleteSummary, int>();
            foreach (Club c in Global.Global.strava.GetClubs())
            {
                var act = Global.Global.strava.GetClubActivities(c.Id.ToString());
                var us = Global.Global.strava.GetClubMembers(c.Id.ToString());
                activities.AddRange(act);
                users.AddRange(us);
            }
            foreach (var u in users.Distinct())
            {
                cache[u] = (int)activities.Distinct().Where(a => a.Athlete.Id == u.Id).Average(a => a.SufferScore.HasValue?a.SufferScore.Value:0);
            }

            return cache.OrderByDescending(d => d.Value).FirstOrDefault();
        }

        public KeyValuePair<AthleteSummary, int> GetUserWithMaxCalories()
        {
            List<ActivitySummary> activities = new List<ActivitySummary>();
            List<AthleteSummary> users = new List<AthleteSummary>();
            Dictionary<AthleteSummary, int> cache = new Dictionary<AthleteSummary, int>();
            foreach (Club c in Global.Global.strava.GetClubs())
            {
                var act = Global.Global.strava.GetClubActivities(c.Id.ToString());
                var us = Global.Global.strava.GetClubMembers(c.Id.ToString());
                activities.AddRange(act);
                users.AddRange(us);
            }
            foreach (var u in users.Distinct())
            {
                cache[u] = (int)activities.Distinct().Where(a => a.Athlete.Id == u.Id).Average(a => a.Kilojoules);
            }

            return cache.OrderByDescending(d => d.Value).FirstOrDefault();
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