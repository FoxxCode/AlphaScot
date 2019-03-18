using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class FormaAccesso
	{
		public System.Int32 idrol{ get; set; }
		public System.Int32 idforma{ get; set; }
		public System.Boolean acceso{ get; set; }
		public System.Boolean insercion{ get; set; }
		public System.Boolean modificacion{ get; set; }
		public System.Boolean eliminacion{ get; set; }
		public System.Boolean consulta{ get; set; }
		public System.Boolean impresion{ get; set; }
		public System.Boolean operacion{ get; set; }
	}
}
