using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class Central
	{
		public System.Int32 idcentral{ get; set; }
		public System.Int32 idciudad{ get; set; }
		public System.Int32 idpais{ get; set; }
		public System.Int32 idempresa{ get; set; }
		public System.String descripcion{ get; set; }
		public System.String codigo{ get; set; }
		public System.Boolean procesaentrada{ get; set; }
		public System.Boolean procesasalida{ get; set; }
		public System.Boolean procesacuentas{ get; set; }
	}
}
