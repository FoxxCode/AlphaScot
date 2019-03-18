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
	
	public class UsuarioController : Controller
	{
		UsuarioDataAccess objUsuario = new UsuarioDataAccess();

		// GET: api/Usuario
		[HttpGet("[action]")]
		public IEnumerable<Usuario> ConsultarUsuario()
		{
			return objUsuario.ConsultarUsuario();
		}

		// GET: api/Usuario/5
		[HttpGet("{id0,id1}", Name = "BuscarUsuario")]
		public Usuario BuscarUsuario(System.String idusuario,System.Int32 idempresa)
		{
			return objUsuario.BuscarUsuario(idusuario,idempresa);
		}

		// POST: api/Usuario
		[HttpPost]
		public ActionResult InsertarUsuario([FromBody] Usuario data)
		{
			return objUsuario.InsertarUsuario(data);
		}

		// PUT: api/Usuario
		[HttpPut]
		public ActionResult ActualizarUsuario([FromBody] Usuario data)
		{
			return objUsuario.ActualizarUsuario(data);
		}

		// DELETE: api/Usuario
		[HttpDelete]
		public ActionResult EliminarUsuario([FromBody] Usuario data)
		{
			return objUsuario.EliminarUsuario(data);
		}
	}
}
