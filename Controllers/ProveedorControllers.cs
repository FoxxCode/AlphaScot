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
	
	public class ProveedorController : Controller
	{
		ProveedorDataAccess objProveedor = new ProveedorDataAccess();

		// GET: api/Proveedor
		[HttpGet("[action]")]
		public IEnumerable<Proveedor> ConsultarProveedor()
		{
			return objProveedor.ConsultarProveedor();
		}

		// GET: api/Proveedor/5
		[HttpGet("{id0}", Name = "BuscarProveedor")]
		public Proveedor BuscarProveedor(System.Int32 idproveedor)
		{
			return objProveedor.BuscarProveedor(idproveedor);
		}

		// POST: api/Proveedor
		[HttpPost]
		public ActionResult InsertarProveedor([FromBody] Proveedor data)
		{
			return objProveedor.InsertarProveedor(data);
		}

		// PUT: api/Proveedor
		[HttpPut]
		public ActionResult ActualizarProveedor([FromBody] Proveedor data)
		{
			return objProveedor.ActualizarProveedor(data);
		}

		// DELETE: api/Proveedor
		[HttpDelete]
		public ActionResult EliminarProveedor([FromBody] Proveedor data)
		{
			return objProveedor.EliminarProveedor(data);
		}
	}
}
