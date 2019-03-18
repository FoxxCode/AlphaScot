using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class Tarifa
	{
		public System.Int32 idtarifa{ get; set; }
		public System.Int32 idservicio{ get; set; }
		public System.String descripcion{ get; set; }
		public System.Int32 idciudad{ get; set; }
		public System.Int32 idpais{ get; set; }
		public System.String etiqueta{ get; set; }
	}
}
