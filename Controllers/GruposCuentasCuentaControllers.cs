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
	
	public class GruposCuentasCuentaController : Controller
	{
		GruposCuentasCuentaDataAccess objGruposCuentasCuenta = new GruposCuentasCuentaDataAccess();

		// GET: api/GruposCuentasCuenta
		[HttpGet("[action]")]
		public IEnumerable<GruposCuentasCuenta> ConsultarGruposCuentasCuenta()
		{
			return objGruposCuentasCuenta.ConsultarGruposCuentasCuenta();
		}

		// GET: api/GruposCuentasCuenta/5
		[HttpGet("{id0,id1,id2}", Name = "BuscarGruposCuentasCuenta")]
		public GruposCuentasCuenta BuscarGruposCuentasCuenta(System.String idcuenta,System.Int32 idcentral,System.Int32 idgrupo)
		{
			return objGruposCuentasCuenta.BuscarGruposCuentasCuenta(idcuenta,idcentral,idgrupo);
		}

		// POST: api/GruposCuentasCuenta
		[HttpPost]
		public ActionResult InsertarGruposCuentasCuenta([FromBody] GruposCuentasCuenta data)
		{
			return objGruposCuentasCuenta.InsertarGruposCuentasCuenta(data);
		}

		// PUT: api/GruposCuentasCuenta
		[HttpPut]
		public ActionResult ActualizarGruposCuentasCuenta([FromBody] GruposCuentasCuenta data)
		{
			return objGruposCuentasCuenta.ActualizarGruposCuentasCuenta(data);
		}

		// DELETE: api/GruposCuentasCuenta
		[HttpDelete]
		public ActionResult EliminarGruposCuentasCuenta([FromBody] GruposCuentasCuenta data)
		{
			return objGruposCuentasCuenta.EliminarGruposCuentasCuenta(data);
		}
	}
}
