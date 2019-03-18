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
	
	public class UsuarioInternoController : Controller
	{
		UsuarioInternoDataAccess objUsuarioInterno = new UsuarioInternoDataAccess();

		// GET: api/UsuarioInterno
		[HttpGet("[action]")]
		public IEnumerable<UsuarioInterno> ConsultarUsuarioInterno()
		{
			return objUsuarioInterno.ConsultarUsuarioInterno();
		}

		// GET: api/UsuarioInterno/5
		[HttpGet("{id0}", Name = "BuscarUsuarioInterno")]
		public UsuarioInterno BuscarUsuarioInterno(System.Int32 idinternousuario)
		{
			return objUsuarioInterno.BuscarUsuarioInterno(idinternousuario);
		}

		// POST: api/UsuarioInterno
		[HttpPost]
		public ActionResult InsertarUsuarioInterno([FromBody] UsuarioInterno data)
		{
			return objUsuarioInterno.InsertarUsuarioInterno(data);
		}

		// PUT: api/UsuarioInterno
		[HttpPut]
		public ActionResult ActualizarUsuarioInterno([FromBody] UsuarioInterno data)
		{
			return objUsuarioInterno.ActualizarUsuarioInterno(data);
		}

		// DELETE: api/UsuarioInterno
		[HttpDelete]
		public ActionResult EliminarUsuarioInterno([FromBody] UsuarioInterno data)
		{
			return objUsuarioInterno.EliminarUsuarioInterno(data);
		}
	}
}
