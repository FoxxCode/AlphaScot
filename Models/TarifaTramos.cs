using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class TarifaTramos
	{
		public System.Int32 idtramo{ get; set; }
		public System.Int32 idtarifa{ get; set; }
		public System.String etiqueta{ get; set; }
		public System.String horainicio{ get; set; }
		public System.String horafinal{ get; set; }
	}
}
