using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class SMDROrigenDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<SMDROrigen> ConsultarSMDROrigen()
		{
			List<SMDROrigen> lstSMDROrigen = new List<SMDROrigen>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_SMDROrigen_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					SMDROrigen _SMDROrigen= new SMDROrigen();
					_SMDROrigen.idllamada = (System.Guid)rdr["idllamada"];
					_SMDROrigen.idestado = (System.Int32)rdr["idestado"];
					_SMDROrigen.trama = !rdr.IsDBNull(2) ? (System.String)rdr["trama"] : "";
					lstSMDROrigen.Add(_SMDROrigen);
				}
				Base.CerrarConexion(SqlCnn);
				return lstSMDROrigen;
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
				return lstSMDROrigen;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public SMDROrigen BuscarSMDROrigen(System.Guid idllamada)
		{
			SMDROrigen _SMDROrigen= new SMDROrigen();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_SMDROrigen_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idllamada", idllamada);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_SMDROrigen.idllamada = (System.Guid)rdr["idllamada"];
					_SMDROrigen.idestado = (System.Int32)rdr["idestado"];
					_SMDROrigen.trama = !rdr.IsDBNull(2) ? (System.String)rdr["trama"] : "";
				}
				Base.CerrarConexion(SqlCnn);
				return _SMDROrigen;
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
				return _SMDROrigen;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarSMDROrigen(SMDROrigen _SMDROrigen)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_SMDROrigen_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idllamada", _SMDROrigen.idllamada);
				SqlCmd.Parameters.AddWithValue("@idestado", _SMDROrigen.idestado);
				SqlCmd.Parameters.AddWithValue("@trama", _SMDROrigen.trama);

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
		public ActionResult ActualizarSMDROrigen(SMDROrigen _SMDROrigen)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_SMDROrigen_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idllamada", _SMDROrigen.idllamada);
				SqlCmd.Parameters.AddWithValue("@idestado", _SMDROrigen.idestado);
				SqlCmd.Parameters.AddWithValue("@trama", _SMDROrigen.trama);

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
		public ActionResult EliminarSMDROrigen(SMDROrigen _SMDROrigen)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_SMDROrigen_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idllamada", _SMDROrigen.idllamada);

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
