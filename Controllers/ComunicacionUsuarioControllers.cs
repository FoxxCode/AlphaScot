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
	
	public class ComunicacionUsuarioController : Controller
	{
		ComunicacionUsuarioDataAccess objComunicacionUsuario = new ComunicacionUsuarioDataAccess();

		// GET: api/ComunicacionUsuario
		[HttpGet("[action]")]
		public IEnumerable<ComunicacionUsuario> ConsultarComunicacionUsuario()
		{
			return objComunicacionUsuario.ConsultarComunicacionUsuario();
		}

		// GET: api/ComunicacionUsuario/5
		[HttpGet("{id0}", Name = "BuscarComunicacionUsuario")]
		public ComunicacionUsuario BuscarComunicacionUsuario(System.Int32 idcomunicacion)
		{
			return objComunicacionUsuario.BuscarComunicacionUsuario(idcomunicacion);
		}

		// POST: api/ComunicacionUsuario
		[HttpPost]
		public ActionResult InsertarComunicacionUsuario([FromBody] ComunicacionUsuario data)
		{
			return objComunicacionUsuario.InsertarComunicacionUsuario(data);
		}

		// PUT: api/ComunicacionUsuario
		[HttpPut]
		public ActionResult ActualizarComunicacionUsuario([FromBody] ComunicacionUsuario data)
		{
			return objComunicacionUsuario.ActualizarComunicacionUsuario(data);
		}

		// DELETE: api/ComunicacionUsuario
		[HttpDelete]
		public ActionResult EliminarComunicacionUsuario([FromBody] ComunicacionUsuario data)
		{
			return objComunicacionUsuario.EliminarComunicacionUsuario(data);
		}
	}
}
