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
	
	public class LineasController : Controller
	{
		LineasDataAccess objLineas = new LineasDataAccess();

		// GET: api/Lineas
		[HttpGet("[action]")]
		public IEnumerable<Lineas> ConsultarLineas()
		{
			return objLineas.ConsultarLineas();
		}

		// GET: api/Lineas/5
		[HttpGet("{id0,id1}", Name = "BuscarLineas")]
		public Lineas BuscarLineas(System.String idlinea,System.Int32 idcentral)
		{
			return objLineas.BuscarLineas(idlinea,idcentral);
		}

		// POST: api/Lineas
		[HttpPost]
		public ActionResult InsertarLineas([FromBody] Lineas data)
		{
			return objLineas.InsertarLineas(data);
		}

		// PUT: api/Lineas
		[HttpPut]
		public ActionResult ActualizarLineas([FromBody] Lineas data)
		{
			return objLineas.ActualizarLineas(data);
		}

		// DELETE: api/Lineas
		[HttpDelete]
		public ActionResult EliminarLineas([FromBody] Lineas data)
		{
			return objLineas.EliminarLineas(data);
		}
	}
}
