using Strava.Activities;
using Strava.Athletes;
using Strava.Authentication;
using Strava.Clients;
using Strava.Clubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompeStrava.Strava
{
    public class StravaConnector
    {
        StravaClient client = null;

        public StravaConnector()
        {
            const String token = "5a034173fa52b384a43aac8ae83b4293230ef9bc";
            StaticAuthentication auth = new StaticAuthentication(token);
            client = new StravaClient(auth);
        }

        public List<Club> GetClubs()
        {
            Athlete clubAthlete = client.Athletes.GetAthlete();
            return clubAthlete.Clubs;
        }

        public Club GetClub(string clubId)
        {
            return client.Clubs.GetClub(clubId);
        }

        private Dictionary<string, List<AthleteSummary>> clubmembers = new Dictionary<string, List<AthleteSummary>>();
        public List<AthleteSummary> GetClubMembers(string clubid)
        {
            if (!clubmembers.ContainsKey(clubid))
            {
                clubmembers[clubid] = client.Clubs.GetClubMembers(clubid);
            }

                return clubmembers[clubid];
        }

        private Dictionary<string, List<ActivitySummary>> clubact = new Dictionary<string, List<ActivitySummary>>();
        internal List<ActivitySummary> GetClubActivities(string clubid)
        {
            if (!clubact.ContainsKey(clubid))
            {
                clubact[clubid] = client.Clubs.GetLatestClubActivities(clubid, 1, 20);
            }

            return clubact[clubid];
        }

        private Dictionary<string, List<ClubEvent>> clubevent = new Dictionary<string, List<ClubEvent>>();
        public List<ClubEvent> ClubEvents(string clubid)
        {
            if (!clubevent.ContainsKey(clubid))
            {
                clubevent[clubid] = client.Clubs.GetClubEvents(clubid);
            }

            return clubevent[clubid];
        }

        //public List<ClubEvent> ClubEventsByDateRange(string clubid, Tuple<DateTime,DateTime> daterange)
        //{
        //    return client.Clubs.GetClubEvents(clubid).Where(e => date e.Occurences );
        //}

        //private occuranceBeteenDates(string[] occurances  Tuple<DateTime, DateTime> daterange)


        public void joinClub(string clubId)
        {
            client.Clubs.JoinClub(clubId);
        }
    }
}