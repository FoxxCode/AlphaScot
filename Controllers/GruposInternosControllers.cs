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
	
	public class GruposInternosController : Controller
	{
		GruposInternosDataAccess objGruposInternos = new GruposInternosDataAccess();

		// GET: api/GruposInternos
		[HttpGet("[action]")]
		public IEnumerable<GruposInternos> ConsultarGruposInternos()
		{
			return objGruposInternos.ConsultarGruposInternos();
		}

		// GET: api/GruposInternos/5
		[HttpGet("{id0}", Name = "BuscarGruposInternos")]
		public GruposInternos BuscarGruposInternos(System.Int32 idgrupo)
		{
			return objGruposInternos.BuscarGruposInternos(idgrupo);
		}

		// POST: api/GruposInternos
		[HttpPost]
		public ActionResult InsertarGruposInternos([FromBody] GruposInternos data)
		{
			return objGruposInternos.InsertarGruposInternos(data);
		}

		// PUT: api/GruposInternos
		[HttpPut]
		public ActionResult ActualizarGruposInternos([FromBody] GruposInternos data)
		{
			return objGruposInternos.ActualizarGruposInternos(data);
		}

		// DELETE: api/GruposInternos
		[HttpDelete]
		public ActionResult EliminarGruposInternos([FromBody] GruposInternos data)
		{
			return objGruposInternos.EliminarGruposInternos(data);
		}
	}
}
