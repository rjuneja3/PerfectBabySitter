using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace PerfectBabysitter.Models
{

    public class AppliedJob
    {
        [Key]
        public int Id { get; set; }
        public int JobId { get; set; }
        public string ApplicantName { get; set; }
        public string Status { get; set; }




    }
}
