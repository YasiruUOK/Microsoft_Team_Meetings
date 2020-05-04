using Microsoft_team.Helpers;
using Microsoft_team.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Microsoft_team.Controllers
{
    public class MeetingController : BaseController
    {
        // GET: Meeting
        public ActionResult Index()
        {
            return View();
        }

        

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Index(Meeting meeting)
        {
            string Subject = meeting.Subject;
            DateTime StartDate = meeting.StartDate;
            DateTime StartTime = meeting.StartTime;
            int TimeDuration = meeting.TimeDuration;
            DateTime xMinsLater;
            string Time = StartTime.ToString("HH:mm:ss tt");
            string startTimeString = StartTime.ToString("HH:mm:ss.fffffff");
            string endTime = "";
            if (TimeDuration == 0)
            {
                xMinsLater = StartTime.AddMinutes(30);
                endTime = xMinsLater.ToString("HH:mm:ss.ffffffff");
            }else if (TimeDuration == 1)
            {
                xMinsLater = StartTime.AddMinutes(60);
                endTime = xMinsLater.ToString("HH:mm:ss.fffffff");
            }
            else if (TimeDuration == 2)
            {
                xMinsLater = StartTime.AddMinutes(90);
                endTime = xMinsLater.ToString("HH:mm:ss.fffffff");
            }
            else if (TimeDuration == 3)
            {
                xMinsLater = StartTime.AddMinutes(120);
                endTime = xMinsLater.ToString("HH:mm:ss.fffffff");
            }
            string StartdateString= StartDate.ToString("yyyy-MM-dd");
            string StartDateAndTime = StartdateString + "T" + startTimeString + "+05:30";
            string EndDateAndTime = StartdateString + "T" + endTime + "+05:30";
            var meetingDetails = await GraphHelper.GetMeetingAsync(Subject, StartDateAndTime, EndDateAndTime);
            string joinURL = meetingDetails.JoinUrl;
            return RedirectToAction("CreateNewMeeting", "Meeting", new { @joinURL = joinURL });
        }

        public ActionResult CreateNewMeeting(string joinURL)
        {
            ViewData["JoinURL"] = joinURL;
            return View();
        }
    }
}