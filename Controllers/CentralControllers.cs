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
	
	public class CentralController : Controller
	{
		CentralDataAccess objCentral = new CentralDataAccess();

		// GET: api/Central
		[HttpGet("[action]")]
		public IEnumerable<Central> ConsultarCentral()
		{
			return objCentral.ConsultarCentral();
		}

		// GET: api/Central/5
		[HttpGet("{id0}", Name = "BuscarCentral")]
		public Central BuscarCentral(System.Int32 idcentral)
		{
			return objCentral.BuscarCentral(idcentral);
		}

		// POST: api/Central
		[HttpPost]
		public ActionResult InsertarCentral([FromBody] Central data)
		{
			return objCentral.InsertarCentral(data);
		}

		// PUT: api/Central
		[HttpPut]
		public ActionResult ActualizarCentral([FromBody] Central data)
		{
			return objCentral.ActualizarCentral(data);
		}

		// DELETE: api/Central
		[HttpDelete]
		public ActionResult EliminarCentral([FromBody] Central data)
		{
			return objCentral.EliminarCentral(data);
		}
	}
}
