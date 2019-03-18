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
	
	public class TramosController : Controller
	{
		TramosDataAccess objTramos = new TramosDataAccess();

		// GET: api/Tramos
		[HttpGet("[action]")]
		public IEnumerable<Tramos> ConsultarTramos()
		{
			return objTramos.ConsultarTramos();
		}

		// GET: api/Tramos/5
		[HttpGet("{id0}", Name = "BuscarTramos")]
		public Tramos BuscarTramos(System.Int32 idtramo)
		{
			return objTramos.BuscarTramos(idtramo);
		}

		// POST: api/Tramos
		[HttpPost]
		public ActionResult InsertarTramos([FromBody] Tramos data)
		{
			return objTramos.InsertarTramos(data);
		}

		// PUT: api/Tramos
		[HttpPut]
		public ActionResult ActualizarTramos([FromBody] Tramos data)
		{
			return objTramos.ActualizarTramos(data);
		}

		// DELETE: api/Tramos
		[HttpDelete]
		public ActionResult EliminarTramos([FromBody] Tramos data)
		{
			return objTramos.EliminarTramos(data);
		}
	}
}
