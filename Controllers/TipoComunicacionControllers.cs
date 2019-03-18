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
	
	public class TipoComunicacionController : Controller
	{
		TipoComunicacionDataAccess objTipoComunicacion = new TipoComunicacionDataAccess();

		// GET: api/TipoComunicacion
		[HttpGet("[action]")]
		public IEnumerable<TipoComunicacion> ConsultarTipoComunicacion()
		{
			return objTipoComunicacion.ConsultarTipoComunicacion();
		}

		// GET: api/TipoComunicacion/5
		[HttpGet("{id0}", Name = "BuscarTipoComunicacion")]
		public TipoComunicacion BuscarTipoComunicacion(System.String idtipocomunicacion)
		{
			return objTipoComunicacion.BuscarTipoComunicacion(idtipocomunicacion);
		}

		// POST: api/TipoComunicacion
		[HttpPost]
		public ActionResult InsertarTipoComunicacion([FromBody] TipoComunicacion data)
		{
			return objTipoComunicacion.InsertarTipoComunicacion(data);
		}

		// PUT: api/TipoComunicacion
		[HttpPut]
		public ActionResult ActualizarTipoComunicacion([FromBody] TipoComunicacion data)
		{
			return objTipoComunicacion.ActualizarTipoComunicacion(data);
		}

		// DELETE: api/TipoComunicacion
		[HttpDelete]
		public ActionResult EliminarTipoComunicacion([FromBody] TipoComunicacion data)
		{
			return objTipoComunicacion.EliminarTipoComunicacion(data);
		}
	}
}
