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
	
	public class CostoInterNacionalController : Controller
	{
		CostoInterNacionalDataAccess objCostoInterNacional = new CostoInterNacionalDataAccess();

		// GET: api/CostoInterNacional
		[HttpGet("[action]")]
		public IEnumerable<CostoInterNacional> ConsultarCostoInterNacional()
		{
			return objCostoInterNacional.ConsultarCostoInterNacional();
		}

		// GET: api/CostoInterNacional/5
		[HttpGet("{id0,id1,id2,id3,id4}", Name = "BuscarCostoInterNacional")]
		public CostoInterNacional BuscarCostoInterNacional(System.Int32 iddia,System.Int32 idtramo,System.Int32 idtarifa,System.Int32 idservicio,System.Int32 idareapais)
		{
			return objCostoInterNacional.BuscarCostoInterNacional(iddia,idtramo,idtarifa,idservicio,idareapais);
		}

		// POST: api/CostoInterNacional
		[HttpPost]
		public ActionResult InsertarCostoInterNacional([FromBody] CostoInterNacional data)
		{
			return objCostoInterNacional.InsertarCostoInterNacional(data);
		}

		// PUT: api/CostoInterNacional
		[HttpPut]
		public ActionResult ActualizarCostoInterNacional([FromBody] CostoInterNacional data)
		{
			return objCostoInterNacional.ActualizarCostoInterNacional(data);
		}

		// DELETE: api/CostoInterNacional
		[HttpDelete]
		public ActionResult EliminarCostoInterNacional([FromBody] CostoInterNacional data)
		{
			return objCostoInterNacional.EliminarCostoInterNacional(data);
		}
	}
}
