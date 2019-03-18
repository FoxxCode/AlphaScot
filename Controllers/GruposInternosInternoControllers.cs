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
	
	public class GruposInternosInternoController : Controller
	{
		GruposInternosInternoDataAccess objGruposInternosInterno = new GruposInternosInternoDataAccess();

		// GET: api/GruposInternosInterno
		[HttpGet("[action]")]
		public IEnumerable<GruposInternosInterno> ConsultarGruposInternosInterno()
		{
			return objGruposInternosInterno.ConsultarGruposInternosInterno();
		}

		// GET: api/GruposInternosInterno/5
		[HttpGet("{id0,id1,id2}", Name = "BuscarGruposInternosInterno")]
		public GruposInternosInterno BuscarGruposInternosInterno(System.String idinterno,System.Int32 idcentral,System.Int32 idgrupo)
		{
			return objGruposInternosInterno.BuscarGruposInternosInterno(idinterno,idcentral,idgrupo);
		}

		// POST: api/GruposInternosInterno
		[HttpPost]
		public ActionResult InsertarGruposInternosInterno([FromBody] GruposInternosInterno data)
		{
			return objGruposInternosInterno.InsertarGruposInternosInterno(data);
		}

		// PUT: api/GruposInternosInterno
		[HttpPut]
		public ActionResult ActualizarGruposInternosInterno([FromBody] GruposInternosInterno data)
		{
			return objGruposInternosInterno.ActualizarGruposInternosInterno(data);
		}

		// DELETE: api/GruposInternosInterno
		[HttpDelete]
		public ActionResult EliminarGruposInternosInterno([FromBody] GruposInternosInterno data)
		{
			return objGruposInternosInterno.EliminarGruposInternosInterno(data);
		}
	}
}
