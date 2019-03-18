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
	
	public class UsuarioDeptoController : Controller
	{
		UsuarioDeptoDataAccess objUsuarioDepto = new UsuarioDeptoDataAccess();

		// GET: api/UsuarioDepto
		[HttpGet("[action]")]
		public IEnumerable<UsuarioDepto> ConsultarUsuarioDepto()
		{
			return objUsuarioDepto.ConsultarUsuarioDepto();
		}

		// GET: api/UsuarioDepto/5
		[HttpGet("{id0}", Name = "BuscarUsuarioDepto")]
		public UsuarioDepto BuscarUsuarioDepto(System.Int32 idusuariodepto)
		{
			return objUsuarioDepto.BuscarUsuarioDepto(idusuariodepto);
		}

		// POST: api/UsuarioDepto
		[HttpPost]
		public ActionResult InsertarUsuarioDepto([FromBody] UsuarioDepto data)
		{
			return objUsuarioDepto.InsertarUsuarioDepto(data);
		}

		// PUT: api/UsuarioDepto
		[HttpPut]
		public ActionResult ActualizarUsuarioDepto([FromBody] UsuarioDepto data)
		{
			return objUsuarioDepto.ActualizarUsuarioDepto(data);
		}

		// DELETE: api/UsuarioDepto
		[HttpDelete]
		public ActionResult EliminarUsuarioDepto([FromBody] UsuarioDepto data)
		{
			return objUsuarioDepto.EliminarUsuarioDepto(data);
		}
	}
}
