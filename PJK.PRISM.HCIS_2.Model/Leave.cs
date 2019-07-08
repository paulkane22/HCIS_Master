using System;
using System.ComponentModel.DataAnnotations;




namespace PJK.PRISM.HCIS_2.Model
{

        public class Leave
        {
            [Key]
            public int Id { get; set; }
            [Required]
            public LeaveType LeaveTypeId { get; set; }
            public DateTime FromDate { get; set; }
            public DateTime ToDate { get; set; }
            public int NoWorkingDays { get; set; }
            [Required]
            public int PersonId { get; set; }

        }

        public enum LeaveType
        {
            AnnualLeave = 1,
            SickLeave = 2,
            SpecialLeave = 3
        }

}
