using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
	public class SMDR
	{
		public System.Guid idllamada{ get; set; }
		public System.Int32 idestado{ get; set; }
		public System.String codigo{ get; set; }
		public System.String fecha{ get; set; }
		public System.String hora{ get; set; }
		public System.String duracion{ get; set; }
		public System.String linea{ get; set; }
		public System.String interno{ get; set; }
		public System.String cuenta{ get; set; }
		public System.String numero{ get; set; }
	}
}
