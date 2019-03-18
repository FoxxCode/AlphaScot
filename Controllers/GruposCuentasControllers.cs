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
	
	public class GruposCuentasController : Controller
	{
		GruposCuentasDataAccess objGruposCuentas = new GruposCuentasDataAccess();

		// GET: api/GruposCuentas
		[HttpGet("[action]")]
		public IEnumerable<GruposCuentas> ConsultarGruposCuentas()
		{
			return objGruposCuentas.ConsultarGruposCuentas();
		}

		// GET: api/GruposCuentas/5
		[HttpGet("{id0}", Name = "BuscarGruposCuentas")]
		public GruposCuentas BuscarGruposCuentas(System.Int32 idgrupo)
		{
			return objGruposCuentas.BuscarGruposCuentas(idgrupo);
		}

		// POST: api/GruposCuentas
		[HttpPost]
		public ActionResult InsertarGruposCuentas([FromBody] GruposCuentas data)
		{
			return objGruposCuentas.InsertarGruposCuentas(data);
		}

		// PUT: api/GruposCuentas
		[HttpPut]
		public ActionResult ActualizarGruposCuentas([FromBody] GruposCuentas data)
		{
			return objGruposCuentas.ActualizarGruposCuentas(data);
		}

		// DELETE: api/GruposCuentas
		[HttpDelete]
		public ActionResult EliminarGruposCuentas([FromBody] GruposCuentas data)
		{
			return objGruposCuentas.EliminarGruposCuentas(data);
		}
	}
}
