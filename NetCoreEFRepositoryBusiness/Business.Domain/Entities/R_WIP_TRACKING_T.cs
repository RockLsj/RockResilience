using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Common.Domain.Entities;

namespace Business.Domain.Entities
{
    public class R_WIP_TRACKING_T : IEntity
    {
        [Key]
        public string SERIAL_NUMBER { get; set; }
        public string MO_NUMBER { get; set; }
        public string MODEL_NAME { get; set; }
        public string VERSION_CODE { get; set; }
        public string LINE_NAME { get; set; }
        public string SECTION_NAME { get; set; }
        public string GROUP_NAME { get; set; }
        public string STATION_NAME { get; set; }
        public Nullable<int> STATION_SEQ { get; set; }
        public string ERROR_FLAG { get; set; }
        public Nullable<System.DateTime> IN_STATION_TIME { get; set; }
        public Nullable<System.DateTime> IN_LINE_TIME { get; set; }
        public Nullable<System.DateTime> OUT_LINE_TIME { get; set; }
        public string SHIPPING_SN { get; set; }
        public string WORK_FLAG { get; set; }
        public string FINISH_FLAG { get; set; }
        public string SPECIAL_ROUTE { get; set; }
        public string PALLET_NO { get; set; }
        public string QA_NO { get; set; }
        public string QA_RESULT { get; set; }
        public string SCRAP_FLAG { get; set; }
        public string NEXT_STATION { get; set; }
        public string CUSTOMER_NO { get; set; }
        public string KEY_PART_NO { get; set; }
        public string CARTON_NO { get; set; }
        public Nullable<System.DateTime> WARRANTY_DATE { get; set; }
        public string REWORK_NO { get; set; }
        public Nullable<int> REPAIR_CNT { get; set; }
        public string EMP_NO { get; set; }
        public string PALLET_FULL_FLAG { get; set; }
        public string SHIP_NO { get; set; }
        public string STATUS_FLAG { get; set; }
        public string STATE_FLAG { get; set; }
        public string RMA_NO { get; set; }
        public string SW_BOM { get; set; }
        public Nullable<System.DateTime> SHIPPING_DATE { get; set; }
        public string SMT_PART_NO { get; set; }
        public string SN_LINE { get; set; }
        public string CR_FLAG { get; set; }
        public string CUSTOMER_SW { get; set; }
        public string LOCK_FLAG { get; set; }
        public string WATERPROOF { get; set; }
        public string HOLD_FLAG { get; set; }
        public string HOLD_NO { get; set; }
        public string SN_NO { get; set; }
        public string GRADE_FLAG { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
