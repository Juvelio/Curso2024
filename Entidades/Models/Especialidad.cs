using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Models
{
	public class Especialidad
	{
		[Key]
		public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}
