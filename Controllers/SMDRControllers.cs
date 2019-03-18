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
	
	public class SMDRController : Controller
	{
		SMDRDataAccess objSMDR = new SMDRDataAccess();

		// GET: api/SMDR
		[HttpGet("[action]")]
		public IEnumerable<SMDR> ConsultarSMDR()
		{
			return objSMDR.ConsultarSMDR();
		}

		// GET: api/SMDR/5
		[HttpGet("{id0}", Name = "BuscarSMDR")]
		public SMDR BuscarSMDR(System.Guid idllamada)
		{
			return objSMDR.BuscarSMDR(idllamada);
		}

		// POST: api/SMDR
		[HttpPost]
		public ActionResult InsertarSMDR([FromBody] SMDR data)
		{
			return objSMDR.InsertarSMDR(data);
		}

		// PUT: api/SMDR
		[HttpPut]
		public ActionResult ActualizarSMDR([FromBody] SMDR data)
		{
			return objSMDR.ActualizarSMDR(data);
		}

		// DELETE: api/SMDR
		[HttpDelete]
		public ActionResult EliminarSMDR([FromBody] SMDR data)
		{
			return objSMDR.EliminarSMDR(data);
		}
	}
}
