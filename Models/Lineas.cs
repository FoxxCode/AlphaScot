using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class Lineas
	{
		public System.String idlinea{ get; set; }
		public System.Int32 idcentral{ get; set; }
		public System.Int32 idproveedor{ get; set; }
		public System.String etiqueta{ get; set; }
		public System.String descripcion{ get; set; }
		public System.String numero{ get; set; }
		public System.Boolean reportaentrada{ get; set; }
		public System.Boolean reportasalida{ get; set; }
	}
}
