using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class CodigosCentralDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<CodigosCentral> ConsultarCodigosCentral()
		{
			List<CodigosCentral> lstCodigosCentral = new List<CodigosCentral>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_CodigosCentral_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					CodigosCentral _CodigosCentral= new CodigosCentral();
					_CodigosCentral.idcodigo = (System.String)rdr["idcodigo"];
					_CodigosCentral.fecha = (System.DateTime)rdr["fecha"];
					_CodigosCentral.idcuenta = (System.String)rdr["idcuenta"];
					_CodigosCentral.idcentral = (System.Int32)rdr["idcentral"];
					lstCodigosCentral.Add(_CodigosCentral);
				}
				Base.CerrarConexion(SqlCnn);
				return lstCodigosCentral;
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
				return lstCodigosCentral;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public CodigosCentral BuscarCodigosCentral(System.String idcodigo,System.DateTime fecha,System.String idcuenta,System.Int32 idcentral)
		{
			CodigosCentral _CodigosCentral= new CodigosCentral();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_CodigosCentral_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idcodigo", idcodigo);
				SqlCmd.Parameters.AddWithValue("@fecha", fecha);
				SqlCmd.Parameters.AddWithValue("@idcuenta", idcuenta);
				SqlCmd.Parameters.AddWithValue("@idcentral", idcentral);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_CodigosCentral.idcodigo = (System.String)rdr["idcodigo"];
					_CodigosCentral.fecha = (System.DateTime)rdr["fecha"];
					_CodigosCentral.idcuenta = (System.String)rdr["idcuenta"];
					_CodigosCentral.idcentral = (System.Int32)rdr["idcentral"];
				}
				Base.CerrarConexion(SqlCnn);
				return _CodigosCentral;
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
				return _CodigosCentral;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarCodigosCentral(CodigosCentral _CodigosCentral)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_CodigosCentral_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idcodigo", _CodigosCentral.idcodigo);
				SqlCmd.Parameters.AddWithValue("@fecha", _CodigosCentral.fecha);
				SqlCmd.Parameters.AddWithValue("@idcuenta", _CodigosCentral.idcuenta);
				SqlCmd.Parameters.AddWithValue("@idcentral", _CodigosCentral.idcentral);

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
		public ActionResult ActualizarCodigosCentral(CodigosCentral _CodigosCentral)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_CodigosCentral_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idcodigo", _CodigosCentral.idcodigo);
				SqlCmd.Parameters.AddWithValue("@fecha", _CodigosCentral.fecha);
				SqlCmd.Parameters.AddWithValue("@idcuenta", _CodigosCentral.idcuenta);
				SqlCmd.Parameters.AddWithValue("@idcentral", _CodigosCentral.idcentral);

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
		public ActionResult EliminarCodigosCentral(CodigosCentral _CodigosCentral)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_CodigosCentral_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idcodigo", _CodigosCentral.idcodigo);
				SqlCmd.Parameters.AddWithValue("@fecha", _CodigosCentral.fecha);
				SqlCmd.Parameters.AddWithValue("@idcuenta", _CodigosCentral.idcuenta);
				SqlCmd.Parameters.AddWithValue("@idcentral", _CodigosCentral.idcentral);

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
