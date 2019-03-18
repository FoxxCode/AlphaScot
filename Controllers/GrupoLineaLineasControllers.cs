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
	
	public class GrupoLineaLineasController : Controller
	{
		GrupoLineaLineasDataAccess objGrupoLineaLineas = new GrupoLineaLineasDataAccess();

		// GET: api/GrupoLineaLineas
		[HttpGet("[action]")]
		public IEnumerable<GrupoLineaLineas> ConsultarGrupoLineaLineas()
		{
			return objGrupoLineaLineas.ConsultarGrupoLineaLineas();
		}

		// GET: api/GrupoLineaLineas/5
		[HttpGet("{id0,id1,id2}", Name = "BuscarGrupoLineaLineas")]
		public GrupoLineaLineas BuscarGrupoLineaLineas(System.Int32 idgrupo,System.String idlinea,System.Int32 idcentral)
		{
			return objGrupoLineaLineas.BuscarGrupoLineaLineas(idgrupo,idlinea,idcentral);
		}

		// POST: api/GrupoLineaLineas
		[HttpPost]
		public ActionResult InsertarGrupoLineaLineas([FromBody] GrupoLineaLineas data)
		{
			return objGrupoLineaLineas.InsertarGrupoLineaLineas(data);
		}

		// PUT: api/GrupoLineaLineas
		[HttpPut]
		public ActionResult ActualizarGrupoLineaLineas([FromBody] GrupoLineaLineas data)
		{
			return objGrupoLineaLineas.ActualizarGrupoLineaLineas(data);
		}

		// DELETE: api/GrupoLineaLineas
		[HttpDelete]
		public ActionResult EliminarGrupoLineaLineas([FromBody] GrupoLineaLineas data)
		{
			return objGrupoLineaLineas.EliminarGrupoLineaLineas(data);
		}
	}
}
