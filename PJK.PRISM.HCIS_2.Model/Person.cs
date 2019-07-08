using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJK.PRISM.HCIS_2.Model
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Forename { get; set; }
        public int NoOfDaysLeft { get; set; }

        public List<Leave> LeaveItems { get; set; }
    }
}
