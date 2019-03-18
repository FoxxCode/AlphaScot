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
	
	public class DireccionUsuarioController : Controller
	{
		DireccionUsuarioDataAccess objDireccionUsuario = new DireccionUsuarioDataAccess();

		// GET: api/DireccionUsuario
		[HttpGet("[action]")]
		public IEnumerable<DireccionUsuario> ConsultarDireccionUsuario()
		{
			return objDireccionUsuario.ConsultarDireccionUsuario();
		}

		// GET: api/DireccionUsuario/5
		[HttpGet("{id0,id1}", Name = "BuscarDireccionUsuario")]
		public DireccionUsuario BuscarDireccionUsuario(System.Int32 iddireccion,System.String idusuario)
		{
			return objDireccionUsuario.BuscarDireccionUsuario(iddireccion,idusuario);
		}

		// POST: api/DireccionUsuario
		[HttpPost]
		public ActionResult InsertarDireccionUsuario([FromBody] DireccionUsuario data)
		{
			return objDireccionUsuario.InsertarDireccionUsuario(data);
		}

		// PUT: api/DireccionUsuario
		[HttpPut]
		public ActionResult ActualizarDireccionUsuario([FromBody] DireccionUsuario data)
		{
			return objDireccionUsuario.ActualizarDireccionUsuario(data);
		}

		// DELETE: api/DireccionUsuario
		[HttpDelete]
		public ActionResult EliminarDireccionUsuario([FromBody] DireccionUsuario data)
		{
			return objDireccionUsuario.EliminarDireccionUsuario(data);
		}
	}
}
