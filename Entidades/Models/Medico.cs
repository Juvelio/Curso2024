using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Models
{
	public class Medico
	{
		[Key]
		public int Id { get; set; }
		public string Nombre { get; set; }
        public string Paterno { get; set; }
		public string Materno { get; set; }


		[ForeignKey("Especialidad")]
		public int EspecialidadId { get; set; }
		public Especialidad Especialidad { get; set; }
	}
}
