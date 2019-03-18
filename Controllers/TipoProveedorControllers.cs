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
	
	public class TipoProveedorController : Controller
	{
		TipoProveedorDataAccess objTipoProveedor = new TipoProveedorDataAccess();

		// GET: api/TipoProveedor
		[HttpGet("[action]")]
		public IEnumerable<TipoProveedor> ConsultarTipoProveedor()
		{
			return objTipoProveedor.ConsultarTipoProveedor();
		}

		// GET: api/TipoProveedor/5
		[HttpGet("{id0}", Name = "BuscarTipoProveedor")]
		public TipoProveedor BuscarTipoProveedor(System.Int32 idtipo)
		{
			return objTipoProveedor.BuscarTipoProveedor(idtipo);
		}

		// POST: api/TipoProveedor
		[HttpPost]
		public ActionResult InsertarTipoProveedor([FromBody] TipoProveedor data)
		{
			return objTipoProveedor.InsertarTipoProveedor(data);
		}

		// PUT: api/TipoProveedor
		[HttpPut]
		public ActionResult ActualizarTipoProveedor([FromBody] TipoProveedor data)
		{
			return objTipoProveedor.ActualizarTipoProveedor(data);
		}

		// DELETE: api/TipoProveedor
		[HttpDelete]
		public ActionResult EliminarTipoProveedor([FromBody] TipoProveedor data)
		{
			return objTipoProveedor.EliminarTipoProveedor(data);
		}
	}
}
