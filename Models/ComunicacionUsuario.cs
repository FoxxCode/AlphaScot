using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class ComunicacionUsuario
	{
		public System.Int32 idcomunicacion{ get; set; }
		public System.String idtipocomunicacion{ get; set; }
		public System.String valor{ get; set; }
		public System.Boolean pordefecto{ get; set; }
	}
}
