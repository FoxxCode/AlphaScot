using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class Costeo
	{
		public System.Guid idllamada{ get; set; }
		public System.Int32 idinternousuario{ get; set; }
		public System.Int32 idusuariodepto{ get; set; }
		public System.String idinterno{ get; set; }
		public System.Int32 idusuariocuenta{ get; set; }
		public System.String idcuenta{ get; set; }
		public System.Int32 idcentral{ get; set; }
		public System.String idlinea{ get; set; }
		public System.Int32 idproveedor{ get; set; }
		public System.Int32 idtramo{ get; set; }
		public System.Int32 idtarifa{ get; set; }
		public System.Guid id{ get; set; }
		public System.DateTime fecha{ get; set; }
		public System.DateTime hora{ get; set; }
		public System.DateTime duracion{ get; set; }
		public System.String numero{ get; set; }
		public System.Double costo{ get; set; }
	}
}
