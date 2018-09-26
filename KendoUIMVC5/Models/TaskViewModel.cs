using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KendoUIMVC5.Models
{
    public class TaskViewModel : ISchedulerEvent
    {
        private DateTime _Start;
        private DateTime _End;
        private DateTime _ReservationDate;
        private DateTime _UntilDate;

        public TaskViewModel()
        {
        }

        public int SkillId { get; set; }
        public string Skill { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public DateTime End { get { return this._End; } set { this._End = new DateTime(value.Ticks, DateTimeKind.Utc); } }
        public string EndTimezone { get; set; }
        public bool IsAllDay { get; set; }
        public string RecurrenceException { get; set; }
        public string RecurrenceRule { get; set; }
        public DateTime Start { get { return this._Start; } set { this._Start = new DateTime(value.Ticks, DateTimeKind.Utc); } }
        public string StartViewDate { get; set; }
        public string StartViewTime { get; set; }
        public string StartTimezone { get; set; }
        public string TechName { get; set; }
        public string emm_code { get; set; }
        public string Title { get; set; }
        public string ReservationID { get; set; }
        public string ReservedBy { get; set; }
        public DateTime ReservationDate { get { return this._ReservationDate; } set { this._ReservationDate = new DateTime(value.Ticks, DateTimeKind.Utc); } }
        public string ReservationViewDate { get; set; }
        public string ReservationTime { get; set; }
        public string ReservationViewTime { get; set; }
        public string Duration { get; set; }
        public string KeyFlag { get; set; }
        public string IsRecurring { get; set; }
        public string SelectedTech { get; set; }
        public string Frequency { get; set; }
        public string DayWeekMonth { get; set; }
        public string IsNonBusinessDaysIncluded { get; set; }
        public DateTime UntilDate { get { return this._UntilDate; } set { this._UntilDate = new DateTime(value.Ticks, DateTimeKind.Utc); } }
        public string ScheduleType { get; set; }
        public decimal sch_cmcode { get; set; }
        public string sch_sitename { get; set; }
        public string sch_jaddr { get; set; }
        public string sch_suburb { get; set; }
        public string sch_contact { get; set; }
        public string sch_phone1 { get; set; }
        public string sch_instructions { get; set; }
        public int sch_siteno { get; set; }
        public int sch_sitecode { get; set; }
        public int sch_jobno { get; set; }
        public int sch_lineno { get; set; }
        public int sch_schno { get; set; }
        public string JobStatus { get; set; }
        public string JobStatusColour { get; set; }
        public bool IsScheduled { get; set; }
        public bool IsQuote { get; set; }
        public bool hasReport { get; set; }
        public string taskview_ds_identifier { get; set; }
        public string taskview_image_url { get; set; }
        public string taskview_image_class { get; set; }
        public string sch_assto { get; set; }
        public bool sch_checked { get; set; }
        public int sch_stat { get; set; }
        public string sch_hh_msgtype { get; set; }
        public bool sch_hh_sent { get; set; }
        public bool sch_hh_ack { get; set; }
        public decimal sch_net_amount { get; set; }
        public decimal sch_gross_amount { get; set; }
        public string sch_product { get; set; }
        public string sch_item { get; set; }
    }
}