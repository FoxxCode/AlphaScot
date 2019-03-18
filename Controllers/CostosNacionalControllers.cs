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
	
	public class CostosNacionalController : Controller
	{
		CostosNacionalDataAccess objCostosNacional = new CostosNacionalDataAccess();

		// GET: api/CostosNacional
		[HttpGet("[action]")]
		public IEnumerable<CostosNacional> ConsultarCostosNacional()
		{
			return objCostosNacional.ConsultarCostosNacional();
		}

		// GET: api/CostosNacional/5
		[HttpGet("{id0,id1,id2,id3,id4}", Name = "BuscarCostosNacional")]
		public CostosNacional BuscarCostosNacional(System.Int32 iddia,System.Int32 idtramo,System.Int32 idtarifa,System.Int32 idservicio,System.Int32 idrango)
		{
			return objCostosNacional.BuscarCostosNacional(iddia,idtramo,idtarifa,idservicio,idrango);
		}

		// POST: api/CostosNacional
		[HttpPost]
		public ActionResult InsertarCostosNacional([FromBody] CostosNacional data)
		{
			return objCostosNacional.InsertarCostosNacional(data);
		}

		// PUT: api/CostosNacional
		[HttpPut]
		public ActionResult ActualizarCostosNacional([FromBody] CostosNacional data)
		{
			return objCostosNacional.ActualizarCostosNacional(data);
		}

		// DELETE: api/CostosNacional
		[HttpDelete]
		public ActionResult EliminarCostosNacional([FromBody] CostosNacional data)
		{
			return objCostosNacional.EliminarCostosNacional(data);
		}
	}
}
