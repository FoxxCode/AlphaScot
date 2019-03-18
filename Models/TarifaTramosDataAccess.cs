using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class TarifaTramosDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<TarifaTramos> ConsultarTarifaTramos()
		{
			List<TarifaTramos> lstTarifaTramos = new List<TarifaTramos>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_TarifaTramos_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					TarifaTramos _TarifaTramos= new TarifaTramos();
					_TarifaTramos.idtramo = (System.Int32)rdr["idtramo"];
					_TarifaTramos.idtarifa = (System.Int32)rdr["idtarifa"];
					_TarifaTramos.etiqueta = (System.String)rdr["etiqueta"];
					_TarifaTramos.horainicio = (System.String)rdr["horainicio"];
					_TarifaTramos.horafinal = (System.String)rdr["horafinal"];
					lstTarifaTramos.Add(_TarifaTramos);
				}
				Base.CerrarConexion(SqlCnn);
				return lstTarifaTramos;
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
				return lstTarifaTramos;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public TarifaTramos BuscarTarifaTramos(System.Int32 idtramo)
		{
			TarifaTramos _TarifaTramos= new TarifaTramos();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_TarifaTramos_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idtramo", idtramo);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_TarifaTramos.idtramo = (System.Int32)rdr["idtramo"];
					_TarifaTramos.idtarifa = (System.Int32)rdr["idtarifa"];
					_TarifaTramos.etiqueta = (System.String)rdr["etiqueta"];
					_TarifaTramos.horainicio = (System.String)rdr["horainicio"];
					_TarifaTramos.horafinal = (System.String)rdr["horafinal"];
				}
				Base.CerrarConexion(SqlCnn);
				return _TarifaTramos;
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
				return _TarifaTramos;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarTarifaTramos(TarifaTramos _TarifaTramos)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_TarifaTramos_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDTramo = new SqlParameter();
				pIDTramo.ParameterName = "@IDTramo";
				pIDTramo.Value = 0;
				SqlCmd.Parameters.Add(pIDTramo);
				pIDTramo.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@idtarifa", _TarifaTramos.idtarifa);
				SqlCmd.Parameters.AddWithValue("@etiqueta", _TarifaTramos.etiqueta);
				SqlCmd.Parameters.AddWithValue("@horainicio", _TarifaTramos.horainicio);
				SqlCmd.Parameters.AddWithValue("@horafinal", _TarifaTramos.horafinal);

				SqlCmd.ExecuteNonQuery();
				_TarifaTramos.idtramo = (System.Int32)pIDTramo.Value;
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
		public ActionResult ActualizarTarifaTramos(TarifaTramos _TarifaTramos)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_TarifaTramos_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idtramo", _TarifaTramos.idtramo);
				SqlCmd.Parameters.AddWithValue("@idtarifa", _TarifaTramos.idtarifa);
				SqlCmd.Parameters.AddWithValue("@etiqueta", _TarifaTramos.etiqueta);
				SqlCmd.Parameters.AddWithValue("@horainicio", _TarifaTramos.horainicio);
				SqlCmd.Parameters.AddWithValue("@horafinal", _TarifaTramos.horafinal);

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
		public ActionResult EliminarTarifaTramos(TarifaTramos _TarifaTramos)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_TarifaTramos_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idtramo", _TarifaTramos.idtramo);

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
