using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthTracker.Models
{
    public class Lift
    {
        [Key]
        public int LiftId { get; set; }
        public string LiftName { get; set; }
        public string BodyPart { get; set; }
        public string LiftWeight { get; set; }
        public DateTime LiftDate { get; set; }
        public string Notes { get; set; }
        public int UserId { get; set; }

    }
}
