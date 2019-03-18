using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Proyecto.Models
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	
	public class PaisesController : Controller
	{
		PaisesDataAccess objPaises = new PaisesDataAccess();

		// GET: api/Paises
		[HttpGet("[action]")]
		public IEnumerable<Paises> ConsultarPaises()
		{
			return objPaises.ConsultarPaises();
		}

		// GET: api/Paises/5
		[HttpGet("{id0}", Name = "BuscarPaises")]
		public Paises BuscarPaises(System.Int16 idpais)
		{
			return objPaises.BuscarPaises(idpais);
		}

		// POST: api/Paises
		[HttpPost]
		public void InsertarPaises([FromBody] Paises data)
		{
			objPaises.InsertarPaises(data);
		}

		// PUT: api/Paises
		[HttpPut]
		public void ActualizarPaises([FromBody] Paises data)
		{
			objPaises.ActualizarPaises(data);
		}

		// DELETE: api/Paises
		[HttpDelete]
		public void EliminarPaises([FromBody] Paises data)
		{
			objPaises.EliminarPaises(data);
		}
	}
}
