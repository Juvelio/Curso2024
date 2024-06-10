using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.Models
{
    public class Persona
    {
        [MaxLength(50)]
        public string Nombres { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
    }
}
