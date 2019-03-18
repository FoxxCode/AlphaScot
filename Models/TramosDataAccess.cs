using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class TramosDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<Tramos> ConsultarTramos()
		{
			List<Tramos> lstTramos = new List<Tramos>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Tramos_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Tramos _Tramos= new Tramos();
					_Tramos.idtramo = (System.Int32)rdr["idtramo"];
					_Tramos.etiqueta = (System.String)rdr["etiqueta"];
					_Tramos.horainicio = (System.String)rdr["horainicio"];
					_Tramos.horafinal = (System.String)rdr["horafinal"];
					lstTramos.Add(_Tramos);
				}
				Base.CerrarConexion(SqlCnn);
				return lstTramos;
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
				return lstTramos;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public Tramos BuscarTramos(System.Int32 idtramo)
		{
			Tramos _Tramos= new Tramos();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Tramos_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idtramo", idtramo);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_Tramos.idtramo = (System.Int32)rdr["idtramo"];
					_Tramos.etiqueta = (System.String)rdr["etiqueta"];
					_Tramos.horainicio = (System.String)rdr["horainicio"];
					_Tramos.horafinal = (System.String)rdr["horafinal"];
				}
				Base.CerrarConexion(SqlCnn);
				return _Tramos;
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
				return _Tramos;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarTramos(Tramos _Tramos)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Tramos_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDTramo = new SqlParameter();
				pIDTramo.ParameterName = "@IDTramo";
				pIDTramo.Value = 0;
				SqlCmd.Parameters.Add(pIDTramo);
				pIDTramo.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@etiqueta", _Tramos.etiqueta);
				SqlCmd.Parameters.AddWithValue("@horainicio", _Tramos.horainicio);
				SqlCmd.Parameters.AddWithValue("@horafinal", _Tramos.horafinal);

				SqlCmd.ExecuteNonQuery();
				_Tramos.idtramo = (System.Int32)pIDTramo.Value;
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
		public ActionResult ActualizarTramos(Tramos _Tramos)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Tramos_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idtramo", _Tramos.idtramo);
				SqlCmd.Parameters.AddWithValue("@etiqueta", _Tramos.etiqueta);
				SqlCmd.Parameters.AddWithValue("@horainicio", _Tramos.horainicio);
				SqlCmd.Parameters.AddWithValue("@horafinal", _Tramos.horafinal);

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
		public ActionResult EliminarTramos(Tramos _Tramos)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Tramos_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idtramo", _Tramos.idtramo);

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
