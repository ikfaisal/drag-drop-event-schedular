using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KendoUIMVC5.Models
{
    public class SchJsdDet
    {
        public string sch_assto { get; set; }
        public string sch_sitename { get; set; }
        public decimal sch_grossamt { get; set; }
        public string sch_suburb { get; set; }
        public string sch_contact { get; set; }
        public string sch_instructions { get; set; }
        public string sch_invoice_desc { get; set; }
        public string sch_streetno { get; set; }
        public string sch_jaddr { get; set; }
        public string sch_phone1 { get; set; }
        public decimal sch_netamt { get; set; }
        public DateTime sch_sch_date { get; set; }
        public int sch_start_time { get; set; }
        public int sch_end_time { get; set; }
        public string sch_prcode { get; set; }
        public int sch_schno { get; set; }
        public int sch_jobno { get; set; }
        public int sch_lineno { get; set; }
        public decimal sch_cmcode { get; set; }
        public int sch_siteno { get; set; }
        public int sch_sitecode { get; set; }
        public bool sch_scheduled { get; set; }
        public bool sch_checked { get; set; }
        public bool sch_quote { get; set; }
        public bool sch_jobsheet_printed { get; set; }
        public bool sch_hh_sent { get; set; }
        public int sch_stat { get; set; }
        public string schjd_ds_identifier { get; set; }
        public string sch_product { get; set; }
    }
}