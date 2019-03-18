using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class Usuario
	{
		public System.String idusuario{ get; set; }
		public System.Int32 idempresa{ get; set; }
		public System.Int32 idcomunicacion{ get; set; }
		public System.String descripcion{ get; set; }
		public System.Boolean encargado{ get; set; }
	}
}
