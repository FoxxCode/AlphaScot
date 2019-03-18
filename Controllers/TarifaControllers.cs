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
	
	public class TarifaController : Controller
	{
		TarifaDataAccess objTarifa = new TarifaDataAccess();

		// GET: api/Tarifa
		[HttpGet("[action]")]
		public IEnumerable<Tarifa> ConsultarTarifa()
		{
			return objTarifa.ConsultarTarifa();
		}

		// GET: api/Tarifa/5
		[HttpGet("{id0}", Name = "BuscarTarifa")]
		public Tarifa BuscarTarifa(System.Int32 idtarifa)
		{
			return objTarifa.BuscarTarifa(idtarifa);
		}

		// POST: api/Tarifa
		[HttpPost]
		public ActionResult InsertarTarifa([FromBody] Tarifa data)
		{
			return objTarifa.InsertarTarifa(data);
		}

		// PUT: api/Tarifa
		[HttpPut]
		public ActionResult ActualizarTarifa([FromBody] Tarifa data)
		{
			return objTarifa.ActualizarTarifa(data);
		}

		// DELETE: api/Tarifa
		[HttpDelete]
		public ActionResult EliminarTarifa([FromBody] Tarifa data)
		{
			return objTarifa.EliminarTarifa(data);
		}
	}
}
