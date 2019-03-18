using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class DireccionEmpresa
	{
		public System.Int32 iddireccion{ get; set; }
		public System.Int32 idempresa{ get; set; }
		public System.String idzona{ get; set; }
		public System.Int32 idciudad{ get; set; }
		public System.Int32 idpais{ get; set; }
		public System.String descripcion{ get; set; }
		public System.Int32 numero{ get; set; }
		public System.Boolean pordefecto{ get; set; }
	}
}
