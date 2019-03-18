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
	
	public class InternosController : Controller
	{
		InternosDataAccess objInternos = new InternosDataAccess();

		// GET: api/Internos
		[HttpGet("[action]")]
		public IEnumerable<Internos> ConsultarInternos()
		{
			return objInternos.ConsultarInternos();
		}

		// GET: api/Internos/5
		[HttpGet("{id0,id1}", Name = "BuscarInternos")]
		public Internos BuscarInternos(System.String idinterno,System.Int32 idcentral)
		{
			return objInternos.BuscarInternos(idinterno,idcentral);
		}

		// POST: api/Internos
		[HttpPost]
		public ActionResult InsertarInternos([FromBody] Internos data)
		{
			return objInternos.InsertarInternos(data);
		}

		// PUT: api/Internos
		[HttpPut]
		public ActionResult ActualizarInternos([FromBody] Internos data)
		{
			return objInternos.ActualizarInternos(data);
		}

		// DELETE: api/Internos
		[HttpDelete]
		public ActionResult EliminarInternos([FromBody] Internos data)
		{
			return objInternos.EliminarInternos(data);
		}
	}
}
