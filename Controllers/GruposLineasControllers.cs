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
	
	public class GruposLineasController : Controller
	{
		GruposLineasDataAccess objGruposLineas = new GruposLineasDataAccess();

		// GET: api/GruposLineas
		[HttpGet("[action]")]
		public IEnumerable<GruposLineas> ConsultarGruposLineas()
		{
			return objGruposLineas.ConsultarGruposLineas();
		}

		// GET: api/GruposLineas/5
		[HttpGet("{id0}", Name = "BuscarGruposLineas")]
		public GruposLineas BuscarGruposLineas(System.Int32 idgrupo)
		{
			return objGruposLineas.BuscarGruposLineas(idgrupo);
		}

		// POST: api/GruposLineas
		[HttpPost]
		public ActionResult InsertarGruposLineas([FromBody] GruposLineas data)
		{
			return objGruposLineas.InsertarGruposLineas(data);
		}

		// PUT: api/GruposLineas
		[HttpPut]
		public ActionResult ActualizarGruposLineas([FromBody] GruposLineas data)
		{
			return objGruposLineas.ActualizarGruposLineas(data);
		}

		// DELETE: api/GruposLineas
		[HttpDelete]
		public ActionResult EliminarGruposLineas([FromBody] GruposLineas data)
		{
			return objGruposLineas.EliminarGruposLineas(data);
		}
	}
}
