using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class CostosNacionalDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<CostosNacional> ConsultarCostosNacional()
		{
			List<CostosNacional> lstCostosNacional = new List<CostosNacional>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_CostosNacional_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					CostosNacional _CostosNacional= new CostosNacional();
					_CostosNacional.iddia = (System.Int32)rdr["iddia"];
					_CostosNacional.idtramo = (System.Int32)rdr["idtramo"];
					_CostosNacional.idtarifa = (System.Int32)rdr["idtarifa"];
					_CostosNacional.idservicio = (System.Int32)rdr["idservicio"];
					_CostosNacional.idrango = (System.Int32)rdr["idrango"];
					_CostosNacional.costo = (System.Double)rdr["costo"];
					lstCostosNacional.Add(_CostosNacional);
				}
				Base.CerrarConexion(SqlCnn);
				return lstCostosNacional;
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
				return lstCostosNacional;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public CostosNacional BuscarCostosNacional(System.Int32 iddia,System.Int32 idtramo,System.Int32 idtarifa,System.Int32 idservicio,System.Int32 idrango)
		{
			CostosNacional _CostosNacional= new CostosNacional();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_CostosNacional_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@iddia", iddia);
				SqlCmd.Parameters.AddWithValue("@idtramo", idtramo);
				SqlCmd.Parameters.AddWithValue("@idtarifa", idtarifa);
				SqlCmd.Parameters.AddWithValue("@idservicio", idservicio);
				SqlCmd.Parameters.AddWithValue("@idrango", idrango);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_CostosNacional.iddia = (System.Int32)rdr["iddia"];
					_CostosNacional.idtramo = (System.Int32)rdr["idtramo"];
					_CostosNacional.idtarifa = (System.Int32)rdr["idtarifa"];
					_CostosNacional.idservicio = (System.Int32)rdr["idservicio"];
					_CostosNacional.idrango = (System.Int32)rdr["idrango"];
					_CostosNacional.costo = (System.Double)rdr["costo"];
				}
				Base.CerrarConexion(SqlCnn);
				return _CostosNacional;
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
				return _CostosNacional;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarCostosNacional(CostosNacional _CostosNacional)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_CostosNacional_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@iddia", _CostosNacional.iddia);
				SqlCmd.Parameters.AddWithValue("@idtramo", _CostosNacional.idtramo);
				SqlCmd.Parameters.AddWithValue("@idtarifa", _CostosNacional.idtarifa);
				SqlCmd.Parameters.AddWithValue("@idservicio", _CostosNacional.idservicio);
				SqlCmd.Parameters.AddWithValue("@idrango", _CostosNacional.idrango);
				SqlCmd.Parameters.AddWithValue("@costo", _CostosNacional.costo);

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
		public ActionResult ActualizarCostosNacional(CostosNacional _CostosNacional)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_CostosNacional_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@iddia", _CostosNacional.iddia);
				SqlCmd.Parameters.AddWithValue("@idtramo", _CostosNacional.idtramo);
				SqlCmd.Parameters.AddWithValue("@idtarifa", _CostosNacional.idtarifa);
				SqlCmd.Parameters.AddWithValue("@idservicio", _CostosNacional.idservicio);
				SqlCmd.Parameters.AddWithValue("@idrango", _CostosNacional.idrango);
				SqlCmd.Parameters.AddWithValue("@costo", _CostosNacional.costo);

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
		public ActionResult EliminarCostosNacional(CostosNacional _CostosNacional)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_CostosNacional_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@iddia", _CostosNacional.iddia);
				SqlCmd.Parameters.AddWithValue("@idtramo", _CostosNacional.idtramo);
				SqlCmd.Parameters.AddWithValue("@idtarifa", _CostosNacional.idtarifa);
				SqlCmd.Parameters.AddWithValue("@idservicio", _CostosNacional.idservicio);
				SqlCmd.Parameters.AddWithValue("@idrango", _CostosNacional.idrango);

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
