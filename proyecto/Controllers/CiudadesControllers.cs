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
	
	public class CiudadesController : Controller
	{
		CiudadesDataAccess objCiudades = new CiudadesDataAccess();

		// GET: api/Ciudades
		[HttpGet("[action]")]
		public IEnumerable<Ciudades> ConsultarCiudades()
		{
			return objCiudades.ConsultarCiudades();
		}

		// GET: api/Ciudades/5
		[HttpGet("{id0}", Name = "BuscarCiudades")]
		public Ciudades BuscarCiudades(System.Int16 idciudad)
		{
			return objCiudades.BuscarCiudades(idciudad);
		}

		// POST: api/Ciudades
		[HttpPost]
		public void InsertarCiudades([FromBody] Ciudades data)
		{
			objCiudades.InsertarCiudades(data);
		}

		// PUT: api/Ciudades
		[HttpPut]
		public void ActualizarCiudades([FromBody] Ciudades data)
		{
			objCiudades.ActualizarCiudades(data);
		}

		// DELETE: api/Ciudades
		[HttpDelete]
		public void EliminarCiudades([FromBody] Ciudades data)
		{
			objCiudades.EliminarCiudades(data);
		}
	}
}
