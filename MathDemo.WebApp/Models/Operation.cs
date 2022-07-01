using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace MathDemo.WebApp.Models
{
    public class Operation
    {
        [Display(Name = "First Number")]
        public double NumberA { get; set; }

        [Display(Name = "Second Number")]
        public double NumberB { get; set; }

        [Display(Name = "Result")]
        public double Result { get; set; }

        [Display(Name = "Operation")]
        public OperationType OperationType { get; set; }
    }
    
}
