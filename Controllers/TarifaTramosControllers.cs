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
	
	public class TarifaTramosController : Controller
	{
		TarifaTramosDataAccess objTarifaTramos = new TarifaTramosDataAccess();

		// GET: api/TarifaTramos
		[HttpGet("[action]")]
		public IEnumerable<TarifaTramos> ConsultarTarifaTramos()
		{
			return objTarifaTramos.ConsultarTarifaTramos();
		}

		// GET: api/TarifaTramos/5
		[HttpGet("{id0}", Name = "BuscarTarifaTramos")]
		public TarifaTramos BuscarTarifaTramos(System.Int32 idtramo)
		{
			return objTarifaTramos.BuscarTarifaTramos(idtramo);
		}

		// POST: api/TarifaTramos
		[HttpPost]
		public ActionResult InsertarTarifaTramos([FromBody] TarifaTramos data)
		{
			return objTarifaTramos.InsertarTarifaTramos(data);
		}

		// PUT: api/TarifaTramos
		[HttpPut]
		public ActionResult ActualizarTarifaTramos([FromBody] TarifaTramos data)
		{
			return objTarifaTramos.ActualizarTarifaTramos(data);
		}

		// DELETE: api/TarifaTramos
		[HttpDelete]
		public ActionResult EliminarTarifaTramos([FromBody] TarifaTramos data)
		{
			return objTarifaTramos.EliminarTarifaTramos(data);
		}
	}
}
