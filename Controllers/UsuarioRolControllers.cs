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
	
	public class UsuarioRolController : Controller
	{
		UsuarioRolDataAccess objUsuarioRol = new UsuarioRolDataAccess();

		// GET: api/UsuarioRol
		[HttpGet("[action]")]
		public IEnumerable<UsuarioRol> ConsultarUsuarioRol()
		{
			return objUsuarioRol.ConsultarUsuarioRol();
		}

		// GET: api/UsuarioRol/5
		[HttpGet("{id0,id1}", Name = "BuscarUsuarioRol")]
		public UsuarioRol BuscarUsuarioRol(System.String idusuario,System.Int32 idrolempresa)
		{
			return objUsuarioRol.BuscarUsuarioRol(idusuario,idrolempresa);
		}

		// POST: api/UsuarioRol
		[HttpPost]
		public ActionResult InsertarUsuarioRol([FromBody] UsuarioRol data)
		{
			return objUsuarioRol.InsertarUsuarioRol(data);
		}

		// PUT: api/UsuarioRol
		[HttpPut]
		public ActionResult ActualizarUsuarioRol([FromBody] UsuarioRol data)
		{
			return objUsuarioRol.ActualizarUsuarioRol(data);
		}

		// DELETE: api/UsuarioRol
		[HttpDelete]
		public ActionResult EliminarUsuarioRol([FromBody] UsuarioRol data)
		{
			return objUsuarioRol.EliminarUsuarioRol(data);
		}
	}
}
