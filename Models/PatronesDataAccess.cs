using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class PatronesDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<Patrones> ConsultarPatrones()
		{
			List<Patrones> lstPatrones = new List<Patrones>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Patrones_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Patrones _Patrones= new Patrones();
					_Patrones.idpatron = (System.String)rdr["idpatron"];
					_Patrones.descripcion = (System.String)rdr["descripcion"];
					lstPatrones.Add(_Patrones);
				}
				Base.CerrarConexion(SqlCnn);
				return lstPatrones;
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
				return lstPatrones;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public Patrones BuscarPatrones(System.String idpatron)
		{
			Patrones _Patrones= new Patrones();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Patrones_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idpatron", idpatron);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_Patrones.idpatron = (System.String)rdr["idpatron"];
					_Patrones.descripcion = (System.String)rdr["descripcion"];
				}
				Base.CerrarConexion(SqlCnn);
				return _Patrones;
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
				return _Patrones;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarPatrones(Patrones _Patrones)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Patrones_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idpatron", _Patrones.idpatron);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Patrones.descripcion);

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
		public ActionResult ActualizarPatrones(Patrones _Patrones)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Patrones_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idpatron", _Patrones.idpatron);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Patrones.descripcion);

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
		public ActionResult EliminarPatrones(Patrones _Patrones)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Patrones_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idpatron", _Patrones.idpatron);

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
