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
	
	public class AreasController : Controller
	{
		AreasDataAccess objAreas = new AreasDataAccess();

		// GET: api/Areas
		[HttpGet("[action]")]
		public IEnumerable<Areas> ConsultarAreas()
		{
			return objAreas.ConsultarAreas();
		}

		// GET: api/Areas/5
		[HttpGet("{id0}", Name = "BuscarAreas")]
		public Areas BuscarAreas(System.Int32 idarea)
		{
			return objAreas.BuscarAreas(idarea);
		}

		// POST: api/Areas
		[HttpPost]
		public ActionResult InsertarAreas([FromBody] Areas data)
		{
			return objAreas.InsertarAreas(data);
		}

		// PUT: api/Areas
		[HttpPut]
		public ActionResult ActualizarAreas([FromBody] Areas data)
		{
			return objAreas.ActualizarAreas(data);
		}

		// DELETE: api/Areas
		[HttpDelete]
		public ActionResult EliminarAreas([FromBody] Areas data)
		{
			return objAreas.EliminarAreas(data);
		}
	}
}
