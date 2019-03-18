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
	
	public class CosteoController : Controller
	{
		CosteoDataAccess objCosteo = new CosteoDataAccess();

		// GET: api/Costeo
		[HttpGet("[action]")]
		public IEnumerable<Costeo> ConsultarCosteo()
		{
			return objCosteo.ConsultarCosteo();
		}

		// GET: api/Costeo/5
		[HttpGet("{id0}", Name = "BuscarCosteo")]
		public Costeo BuscarCosteo(System.Guid idllamada)
		{
			return objCosteo.BuscarCosteo(idllamada);
		}

		// POST: api/Costeo
		[HttpPost]
		public ActionResult InsertarCosteo([FromBody] Costeo data)
		{
			return objCosteo.InsertarCosteo(data);
		}

		// PUT: api/Costeo
		[HttpPut]
		public ActionResult ActualizarCosteo([FromBody] Costeo data)
		{
			return objCosteo.ActualizarCosteo(data);
		}

		// DELETE: api/Costeo
		[HttpDelete]
		public ActionResult EliminarCosteo([FromBody] Costeo data)
		{
			return objCosteo.EliminarCosteo(data);
		}
	}
}
