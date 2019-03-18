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
	
	public class ZonaController : Controller
	{
		ZonaDataAccess objZona = new ZonaDataAccess();

		// GET: api/Zona
		[HttpGet("[action]")]
		public IEnumerable<Zona> ConsultarZona()
		{
			return objZona.ConsultarZona();
		}

		// GET: api/Zona/5
		[HttpGet("{id0}", Name = "BuscarZona")]
		public Zona BuscarZona(System.String idzona)
		{
			return objZona.BuscarZona(idzona);
		}

		// POST: api/Zona
		[HttpPost]
		public ActionResult InsertarZona([FromBody] Zona data)
		{
			return objZona.InsertarZona(data);
		}

		// PUT: api/Zona
		[HttpPut]
		public ActionResult ActualizarZona([FromBody] Zona data)
		{
			return objZona.ActualizarZona(data);
		}

		// DELETE: api/Zona
		[HttpDelete]
		public ActionResult EliminarZona([FromBody] Zona data)
		{
			return objZona.EliminarZona(data);
		}
	}
}
