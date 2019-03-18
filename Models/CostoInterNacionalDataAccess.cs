using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class CostoInterNacionalDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<CostoInterNacional> ConsultarCostoInterNacional()
		{
			List<CostoInterNacional> lstCostoInterNacional = new List<CostoInterNacional>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_CostoInterNacional_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					CostoInterNacional _CostoInterNacional= new CostoInterNacional();
					_CostoInterNacional.iddia = (System.Int32)rdr["iddia"];
					_CostoInterNacional.idtramo = (System.Int32)rdr["idtramo"];
					_CostoInterNacional.idtarifa = (System.Int32)rdr["idtarifa"];
					_CostoInterNacional.idservicio = (System.Int32)rdr["idservicio"];
					_CostoInterNacional.idareapais = (System.Int32)rdr["idareapais"];
					_CostoInterNacional.costo = (System.Double)rdr["costo"];
					lstCostoInterNacional.Add(_CostoInterNacional);
				}
				Base.CerrarConexion(SqlCnn);
				return lstCostoInterNacional;
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
				return lstCostoInterNacional;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public CostoInterNacional BuscarCostoInterNacional(System.Int32 iddia,System.Int32 idtramo,System.Int32 idtarifa,System.Int32 idservicio,System.Int32 idareapais)
		{
			CostoInterNacional _CostoInterNacional= new CostoInterNacional();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_CostoInterNacional_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@iddia", iddia);
				SqlCmd.Parameters.AddWithValue("@idtramo", idtramo);
				SqlCmd.Parameters.AddWithValue("@idtarifa", idtarifa);
				SqlCmd.Parameters.AddWithValue("@idservicio", idservicio);
				SqlCmd.Parameters.AddWithValue("@idareapais", idareapais);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_CostoInterNacional.iddia = (System.Int32)rdr["iddia"];
					_CostoInterNacional.idtramo = (System.Int32)rdr["idtramo"];
					_CostoInterNacional.idtarifa = (System.Int32)rdr["idtarifa"];
					_CostoInterNacional.idservicio = (System.Int32)rdr["idservicio"];
					_CostoInterNacional.idareapais = (System.Int32)rdr["idareapais"];
					_CostoInterNacional.costo = (System.Double)rdr["costo"];
				}
				Base.CerrarConexion(SqlCnn);
				return _CostoInterNacional;
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
				return _CostoInterNacional;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarCostoInterNacional(CostoInterNacional _CostoInterNacional)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_CostoInterNacional_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@iddia", _CostoInterNacional.iddia);
				SqlCmd.Parameters.AddWithValue("@idtramo", _CostoInterNacional.idtramo);
				SqlCmd.Parameters.AddWithValue("@idtarifa", _CostoInterNacional.idtarifa);
				SqlCmd.Parameters.AddWithValue("@idservicio", _CostoInterNacional.idservicio);
				SqlCmd.Parameters.AddWithValue("@idareapais", _CostoInterNacional.idareapais);
				SqlCmd.Parameters.AddWithValue("@costo", _CostoInterNacional.costo);

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
		public ActionResult ActualizarCostoInterNacional(CostoInterNacional _CostoInterNacional)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_CostoInterNacional_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@iddia", _CostoInterNacional.iddia);
				SqlCmd.Parameters.AddWithValue("@idtramo", _CostoInterNacional.idtramo);
				SqlCmd.Parameters.AddWithValue("@idtarifa", _CostoInterNacional.idtarifa);
				SqlCmd.Parameters.AddWithValue("@idservicio", _CostoInterNacional.idservicio);
				SqlCmd.Parameters.AddWithValue("@idareapais", _CostoInterNacional.idareapais);
				SqlCmd.Parameters.AddWithValue("@costo", _CostoInterNacional.costo);

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
		public ActionResult EliminarCostoInterNacional(CostoInterNacional _CostoInterNacional)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_CostoInterNacional_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@iddia", _CostoInterNacional.iddia);
				SqlCmd.Parameters.AddWithValue("@idtramo", _CostoInterNacional.idtramo);
				SqlCmd.Parameters.AddWithValue("@idtarifa", _CostoInterNacional.idtarifa);
				SqlCmd.Parameters.AddWithValue("@idservicio", _CostoInterNacional.idservicio);
				SqlCmd.Parameters.AddWithValue("@idareapais", _CostoInterNacional.idareapais);

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
