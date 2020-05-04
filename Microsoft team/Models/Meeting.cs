using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft_team.Models
{
    public class Meeting
    {
        public string Subject { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StartTime { get; set; }
        public int TimeDuration { get; set; }
        public string JoinURL { get; set; }
    }
}