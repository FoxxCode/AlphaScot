using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace proyecto.Models
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	
	public class FormaAccessoController : Controller
	{
		FormaAccessoDataAccess objFormaAccesso = new FormaAccessoDataAccess();

		// GET: api/FormaAccesso
		[HttpGet("[action]")]
		public IEnumerable<FormaAccesso> ConsultarFormaAccesso()
		{
			return objFormaAccesso.ConsultarFormaAccesso();
		}

		// GET: api/FormaAccesso/5
		[HttpGet("{id0,id1}", Name = "BuscarFormaAccesso")]
		public FormaAccesso BuscarFormaAccesso(System.Int32 idrol,System.Int32 idforma)
		{
			return objFormaAccesso.BuscarFormaAccesso(idrol,idforma);
		}

		// POST: api/FormaAccesso
		[HttpPost]
		public ActionResult InsertarFormaAccesso([FromBody] FormaAccesso data)
		{
			return objFormaAccesso.InsertarFormaAccesso(data);
		}

		// PUT: api/FormaAccesso
		[HttpPut]
		public ActionResult ActualizarFormaAccesso([FromBody] FormaAccesso data)
		{
			return objFormaAccesso.ActualizarFormaAccesso(data);
		}

		// DELETE: api/FormaAccesso
		[HttpDelete]
		public ActionResult EliminarFormaAccesso([FromBody] FormaAccesso data)
		{
			return objFormaAccesso.EliminarFormaAccesso(data);
		}
	}
}
