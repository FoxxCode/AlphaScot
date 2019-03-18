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
	
	public class SMDROrigenController : Controller
	{
		SMDROrigenDataAccess objSMDROrigen = new SMDROrigenDataAccess();

		// GET: api/SMDROrigen
		[HttpGet("[action]")]
		public IEnumerable<SMDROrigen> ConsultarSMDROrigen()
		{
			return objSMDROrigen.ConsultarSMDROrigen();
		}

		// GET: api/SMDROrigen/5
		[HttpGet("{id0}", Name = "BuscarSMDROrigen")]
		public SMDROrigen BuscarSMDROrigen(System.Guid idllamada)
		{
			return objSMDROrigen.BuscarSMDROrigen(idllamada);
		}

		// POST: api/SMDROrigen
		[HttpPost]
		public ActionResult InsertarSMDROrigen([FromBody] SMDROrigen data)
		{
			return objSMDROrigen.InsertarSMDROrigen(data);
		}

		// PUT: api/SMDROrigen
		[HttpPut]
		public ActionResult ActualizarSMDROrigen([FromBody] SMDROrigen data)
		{
			return objSMDROrigen.ActualizarSMDROrigen(data);
		}

		// DELETE: api/SMDROrigen
		[HttpDelete]
		public ActionResult EliminarSMDROrigen([FromBody] SMDROrigen data)
		{
			return objSMDROrigen.EliminarSMDROrigen(data);
		}
	}
}
