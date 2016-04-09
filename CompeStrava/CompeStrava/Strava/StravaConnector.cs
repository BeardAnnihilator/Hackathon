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

        public List<AthleteSummary> GetClubMembers(string clubid)
        {
            return client.Clubs.GetClubMembers(clubid);
        }
    }
}