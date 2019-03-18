using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class Departamento
	{
		public System.String iddepartamento{ get; set; }
		public System.Int32 idempresa{ get; set; }
		public System.String descripcion{ get; set; }
		public System.Int32 nivel{ get; set; }
		public System.String deptopadre{ get; set; }
	}
}
