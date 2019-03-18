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
	
	public class EstadoController : Controller
	{
		EstadoDataAccess objEstado = new EstadoDataAccess();

		// GET: api/Estado
		[HttpGet("[action]")]
		public IEnumerable<Estado> ConsultarEstado()
		{
			return objEstado.ConsultarEstado();
		}

		// GET: api/Estado/5
		[HttpGet("{id0}", Name = "BuscarEstado")]
		public Estado BuscarEstado(System.Int32 idestado)
		{
			return objEstado.BuscarEstado(idestado);
		}

		// POST: api/Estado
		[HttpPost]
		public ActionResult InsertarEstado([FromBody] Estado data)
		{
			return objEstado.InsertarEstado(data);
		}

		// PUT: api/Estado
		[HttpPut]
		public ActionResult ActualizarEstado([FromBody] Estado data)
		{
			return objEstado.ActualizarEstado(data);
		}

		// DELETE: api/Estado
		[HttpDelete]
		public ActionResult EliminarEstado([FromBody] Estado data)
		{
			return objEstado.EliminarEstado(data);
		}
	}
}
