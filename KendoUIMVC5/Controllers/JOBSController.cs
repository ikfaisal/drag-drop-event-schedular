using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using KendoUIMVC5.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace KendoUIMVC5.Controllers
{
    public class JOBSController : Controller
    {
        public ActionResult Techs()
        {
            List<EmMstr> assignToList = new List<EmMstr>();

            assignToList = this.LoadEmployee(false);
            foreach (EmMstr em in assignToList)
            {
                em.TechName = em.TechName + " (" + em.emm_code + ")";
            }

            return Json(assignToList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JobSchedule_Read([DataSourceRequest] DataSourceRequest request)
        {
            int jobHour = 0;
            int jobMinute = 0;
            DateTime startDateTime = new DateTime();
            DateTime endDateTime = new DateTime();

            List<TaskViewModel> tasks = new List<TaskViewModel>();

            List<SchJsdDet> schJsdDets = this.LoadSchJsdDets(false);

            foreach (var item in schJsdDets)
            {
                jobHour = Convert.ToInt32(DBUtility.GetHourMinuteFromSecond(item.sch_start_time).Substring(0, 2));
                jobMinute = Convert.ToInt32(DBUtility.GetHourMinuteFromSecond(item.sch_start_time).Substring(2, 2));
                startDateTime = new DateTime(item.sch_sch_date.Year, item.sch_sch_date.Month, item.sch_sch_date.Day, jobHour, jobMinute, 0);

                jobHour = Convert.ToInt32(DBUtility.GetHourMinuteFromSecond(item.sch_end_time).Substring(0, 2));
                jobMinute = Convert.ToInt32(DBUtility.GetHourMinuteFromSecond(item.sch_end_time).Substring(2, 2));
                endDateTime = new DateTime(item.sch_sch_date.Year, item.sch_sch_date.Month, item.sch_sch_date.Day, jobHour, jobMinute, 0);

                tasks.Add(new TaskViewModel()
                {
                    TechName = item.sch_assto,
                    emm_code = item.sch_assto,
                    Title = item.sch_product,
                    Start = startDateTime,
                    End = endDateTime
                });
            }

            return Json(tasks.ToDataSourceResult(request));
        }

        public ActionResult JobSchedule_Update([DataSourceRequest]DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid == true)
            {
                // Getting Wrong Value Here
                DateTime startDate = task.Start;
                DateTime endDate = task.End;
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        private List<SchJsdDet> LoadSchJsdDets(bool FromXML)
        {
            List<SchJsdDet> SchJsdDetList = new List<SchJsdDet>();

            if (FromXML == true)
            {
                DataSet ds = new DataSet();
                ds.ReadXml(@"C:\Temp\PESTAPP\tt_sch_jsd_det", XmlReadMode.ReadSchema);
                ds.AcceptChanges();

                SchJsdDetList = ds.Tables[0].DataTableToList<SchJsdDet>();
            }
            else
            {
                SchJsdDet sjd = new SchJsdDet();
                sjd.sch_start_time = 1800;
                sjd.sch_end_time = 3600;
                sjd.sch_sch_date = DateTime.Now.Date;
                sjd.sch_assto = "Dan";
                sjd.sch_product = "ABC";
                SchJsdDetList.Add(sjd);

                sjd = new SchJsdDet();
                sjd.sch_start_time = 54000;
                sjd.sch_end_time = 55800;
                sjd.sch_sch_date = DateTime.Now.Date;
                sjd.sch_assto = "Lach";
                sjd.sch_product = "XYZ";
                SchJsdDetList.Add(sjd);
            }

            return SchJsdDetList;
        }

        private List<EmMstr> LoadEmployee(bool FromXML)
        {
            List<EmMstr> EmMstrList = new List<EmMstr>();

            if (FromXML == true)
            {
                DataSet ds = new DataSet();
                ds.ReadXml(@"C:\Temp\PESTAPP\emmstrDataSet", XmlReadMode.ReadSchema);
                ds.AcceptChanges();

                EmMstrList = ds.Tables[0].DataTableToList<EmMstr>();
            }
            else
            {
                EmMstr em = new EmMstr();
                em.TechName = "Kevork";
                em.emm_code = "Dan";
                EmMstrList.Add(em);

                em = new EmMstr();
                em.TechName = "Temisgian";
                em.emm_code = "Lach";
                EmMstrList.Add(em);
            }

            return EmMstrList;
        }
    }
}