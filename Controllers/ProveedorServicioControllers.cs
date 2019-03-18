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
	
	public class ProveedorServicioController : Controller
	{
		ProveedorServicioDataAccess objProveedorServicio = new ProveedorServicioDataAccess();

		// GET: api/ProveedorServicio
		[HttpGet("[action]")]
		public IEnumerable<ProveedorServicio> ConsultarProveedorServicio()
		{
			return objProveedorServicio.ConsultarProveedorServicio();
		}

		// GET: api/ProveedorServicio/5
		[HttpGet("{id0,id1}", Name = "BuscarProveedorServicio")]
		public ProveedorServicio BuscarProveedorServicio(System.Int32 idservicio,System.Int32 idproveedor)
		{
			return objProveedorServicio.BuscarProveedorServicio(idservicio,idproveedor);
		}

		// POST: api/ProveedorServicio
		[HttpPost]
		public ActionResult InsertarProveedorServicio([FromBody] ProveedorServicio data)
		{
			return objProveedorServicio.InsertarProveedorServicio(data);
		}

		// PUT: api/ProveedorServicio
		[HttpPut]
		public ActionResult ActualizarProveedorServicio([FromBody] ProveedorServicio data)
		{
			return objProveedorServicio.ActualizarProveedorServicio(data);
		}

		// DELETE: api/ProveedorServicio
		[HttpDelete]
		public ActionResult EliminarProveedorServicio([FromBody] ProveedorServicio data)
		{
			return objProveedorServicio.EliminarProveedorServicio(data);
		}
	}
}
