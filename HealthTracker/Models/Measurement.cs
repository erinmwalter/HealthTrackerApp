using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthTracker.Models
{
    public class Measurement
    {
        [Key]
        public int MeasId { get; set; }

        public DateTime MeasDate { get; set; }
        public double Weight { get; set; }
        public double Waist { get; set; }
        public double Chest { get; set; }
        public double Fupa { get; set; }
        public double Hip { get; set; }
        public double Arm { get; set; }
        public double Leg { get; set; }
        public string Notes { get; set; }
        public int UserId { get; set; }
    }
}
