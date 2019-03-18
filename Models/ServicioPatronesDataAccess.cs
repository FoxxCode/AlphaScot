using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class ServicioPatronesDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<ServicioPatrones> ConsultarServicioPatrones()
		{
			List<ServicioPatrones> lstServicioPatrones = new List<ServicioPatrones>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_ServicioPatrones_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					ServicioPatrones _ServicioPatrones= new ServicioPatrones();
					_ServicioPatrones.idpatron = (System.String)rdr["idpatron"];
					_ServicioPatrones.idtarifa = (System.Int32)rdr["idtarifa"];
					_ServicioPatrones.descripcion = (System.String)rdr["descripcion"];
					lstServicioPatrones.Add(_ServicioPatrones);
				}
				Base.CerrarConexion(SqlCnn);
				return lstServicioPatrones;
			}
			catch(SqlException XcpSQL )
			{
				foreach(SqlError se in XcpSQL.Errors)
				{
					if(se.Number <= 50000)
						throw new Exception(se.Message);
					else
						throw new Exception("Error en Operacion de Consulta de Datos");
				}
				return lstServicioPatrones;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ServicioPatrones BuscarServicioPatrones(System.String idpatron)
		{
			ServicioPatrones _ServicioPatrones= new ServicioPatrones();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_ServicioPatrones_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idpatron", idpatron);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_ServicioPatrones.idpatron = (System.String)rdr["idpatron"];
					_ServicioPatrones.idtarifa = (System.Int32)rdr["idtarifa"];
					_ServicioPatrones.descripcion = (System.String)rdr["descripcion"];
				}
				Base.CerrarConexion(SqlCnn);
				return _ServicioPatrones;
			}
			catch(SqlException XcpSQL )
			{
				foreach(SqlError se in XcpSQL.Errors)
				{
					if(se.Number <= 50000)
						throw new Exception(se.Message);
					else
						throw new Exception("Error en Operacion en Busqueda de Datos");
				}
				return _ServicioPatrones;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarServicioPatrones(ServicioPatrones _ServicioPatrones)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_ServicioPatrones_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idpatron", _ServicioPatrones.idpatron);
				SqlCmd.Parameters.AddWithValue("@idtarifa", _ServicioPatrones.idtarifa);
				SqlCmd.Parameters.AddWithValue("@descripcion", _ServicioPatrones.descripcion);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				return Ok("Operacion realizada correctamente");
			}
			catch(SqlException XcpSQL )
			{
				foreach(SqlError se in XcpSQL.Errors)
				{
					if(se.Number <= 50000)
						return BadRequest(se.Message);
					else
						return BadRequest("Error en Operacion de Insercion de Datos");
				}
			}
			catch (Exception Ex)
			{
				return BadRequest(Ex.Message);
			}
			return Ok("");
		}
		public ActionResult ActualizarServicioPatrones(ServicioPatrones _ServicioPatrones)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_ServicioPatrones_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idpatron", _ServicioPatrones.idpatron);
				SqlCmd.Parameters.AddWithValue("@idtarifa", _ServicioPatrones.idtarifa);
				SqlCmd.Parameters.AddWithValue("@descripcion", _ServicioPatrones.descripcion);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				return Ok("Operacion realizada correctamente");
			}
			catch(SqlException XcpSQL )
			{
				foreach(SqlError se in XcpSQL.Errors)
				{
					if(se.Number <= 50000)
						return BadRequest(se.Message);
					else
						return BadRequest("Error en Operacion de Actualizacion de Datos");
				}
			}
			catch (Exception Ex)
			{
				return BadRequest(Ex.Message);
			}
			return Ok("");
		}
		public ActionResult EliminarServicioPatrones(ServicioPatrones _ServicioPatrones)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_ServicioPatrones_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idpatron", _ServicioPatrones.idpatron);

				SqlCmd.ExecuteNonQuery();
				Base.CerrarConexion(SqlCnn);
				return Ok("Operacion realizada correctamente");
			}
			catch(SqlException XcpSQL )
			{
				foreach(SqlError se in XcpSQL.Errors)
				{
					if(se.Number <= 50000)
						return BadRequest(se.Message);
					else
						return BadRequest("Error en Operacion de Eliminacion de Datos");
				}
			}
			catch (Exception Ex)
			{
				return BadRequest(Ex.Message);
			}
			return Ok("");
		}
	}
}
