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
	
	public class FormaController : Controller
	{
		FormaDataAccess objForma = new FormaDataAccess();

		// GET: api/Forma
		[HttpGet("[action]")]
		public IEnumerable<Forma> ConsultarForma()
		{
			return objForma.ConsultarForma();
		}

		// GET: api/Forma/5
		[HttpGet("{id0}", Name = "BuscarForma")]
		public Forma BuscarForma(System.Int32 idforma)
		{
			return objForma.BuscarForma(idforma);
		}

		// POST: api/Forma
		[HttpPost]
		public ActionResult InsertarForma([FromBody] Forma data)
		{
			return objForma.InsertarForma(data);
		}

		// PUT: api/Forma
		[HttpPut]
		public ActionResult ActualizarForma([FromBody] Forma data)
		{
			return objForma.ActualizarForma(data);
		}

		// DELETE: api/Forma
		[HttpDelete]
		public ActionResult EliminarForma([FromBody] Forma data)
		{
			return objForma.EliminarForma(data);
		}
	}
}
