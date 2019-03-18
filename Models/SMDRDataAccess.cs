using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class SMDRDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<SMDR> ConsultarSMDR()
		{
			List<SMDR> lstSMDR = new List<SMDR>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_SMDR_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					SMDR _SMDR= new SMDR();
					_SMDR.idllamada = (System.Guid)rdr["idllamada"];
					_SMDR.idestado = (System.Int32)rdr["idestado"];
					_SMDR.codigo = (System.String)rdr["codigo"];
					_SMDR.fecha = !rdr.IsDBNull(3) ? (System.String)rdr["fecha"] : "";
					_SMDR.hora = !rdr.IsDBNull(4) ? (System.String)rdr["hora"] : "";
					_SMDR.duracion = !rdr.IsDBNull(5) ? (System.String)rdr["duracion"] : "";
					_SMDR.linea = !rdr.IsDBNull(6) ? (System.String)rdr["linea"] : "";
					_SMDR.interno = !rdr.IsDBNull(7) ? (System.String)rdr["interno"] : "";
					_SMDR.cuenta = !rdr.IsDBNull(8) ? (System.String)rdr["cuenta"] : "";
					_SMDR.numero = !rdr.IsDBNull(9) ? (System.String)rdr["numero"] : "";
					lstSMDR.Add(_SMDR);
				}
				Base.CerrarConexion(SqlCnn);
				return lstSMDR;
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
				return lstSMDR;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public SMDR BuscarSMDR(System.Guid idllamada)
		{
			SMDR _SMDR= new SMDR();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_SMDR_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idllamada", idllamada);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_SMDR.idllamada = (System.Guid)rdr["idllamada"];
					_SMDR.idestado = (System.Int32)rdr["idestado"];
					_SMDR.codigo = (System.String)rdr["codigo"];
					_SMDR.fecha = !rdr.IsDBNull(3) ? (System.String)rdr["fecha"] : "";
					_SMDR.hora = !rdr.IsDBNull(4) ? (System.String)rdr["hora"] : "";
					_SMDR.duracion = !rdr.IsDBNull(5) ? (System.String)rdr["duracion"] : "";
					_SMDR.linea = !rdr.IsDBNull(6) ? (System.String)rdr["linea"] : "";
					_SMDR.interno = !rdr.IsDBNull(7) ? (System.String)rdr["interno"] : "";
					_SMDR.cuenta = !rdr.IsDBNull(8) ? (System.String)rdr["cuenta"] : "";
					_SMDR.numero = !rdr.IsDBNull(9) ? (System.String)rdr["numero"] : "";
				}
				Base.CerrarConexion(SqlCnn);
				return _SMDR;
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
				return _SMDR;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarSMDR(SMDR _SMDR)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_SMDR_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idllamada", _SMDR.idllamada);
				SqlCmd.Parameters.AddWithValue("@idestado", _SMDR.idestado);
				SqlCmd.Parameters.AddWithValue("@codigo", _SMDR.codigo);
				SqlCmd.Parameters.AddWithValue("@fecha", _SMDR.fecha);
				SqlCmd.Parameters.AddWithValue("@hora", _SMDR.hora);
				SqlCmd.Parameters.AddWithValue("@duracion", _SMDR.duracion);
				SqlCmd.Parameters.AddWithValue("@linea", _SMDR.linea);
				SqlCmd.Parameters.AddWithValue("@interno", _SMDR.interno);
				SqlCmd.Parameters.AddWithValue("@cuenta", _SMDR.cuenta);
				SqlCmd.Parameters.AddWithValue("@numero", _SMDR.numero);

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
		public ActionResult ActualizarSMDR(SMDR _SMDR)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_SMDR_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idllamada", _SMDR.idllamada);
				SqlCmd.Parameters.AddWithValue("@idestado", _SMDR.idestado);
				SqlCmd.Parameters.AddWithValue("@codigo", _SMDR.codigo);
				SqlCmd.Parameters.AddWithValue("@fecha", _SMDR.fecha);
				SqlCmd.Parameters.AddWithValue("@hora", _SMDR.hora);
				SqlCmd.Parameters.AddWithValue("@duracion", _SMDR.duracion);
				SqlCmd.Parameters.AddWithValue("@linea", _SMDR.linea);
				SqlCmd.Parameters.AddWithValue("@interno", _SMDR.interno);
				SqlCmd.Parameters.AddWithValue("@cuenta", _SMDR.cuenta);
				SqlCmd.Parameters.AddWithValue("@numero", _SMDR.numero);

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
		public ActionResult EliminarSMDR(SMDR _SMDR)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_SMDR_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idllamada", _SMDR.idllamada);

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
