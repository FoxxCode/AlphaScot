using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class SericioAreaPaisDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<SericioAreaPais> ConsultarSericioAreaPais()
		{
			List<SericioAreaPais> lstSericioAreaPais = new List<SericioAreaPais>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_SericioAreaPais_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					SericioAreaPais _SericioAreaPais= new SericioAreaPais();
					_SericioAreaPais.idareapais = (System.Int32)rdr["idareapais"];
					_SericioAreaPais.idservicio = (System.Int32)rdr["idservicio"];
					_SericioAreaPais.idarea = (System.Int32)rdr["idarea"];
					_SericioAreaPais.idpais = (System.Int32)rdr["idpais"];
					_SericioAreaPais.fecharegistro = !rdr.IsDBNull(4) ? (System.DateTime)rdr["fecharegistro"] : System.DateTime.Now;
					lstSericioAreaPais.Add(_SericioAreaPais);
				}
				Base.CerrarConexion(SqlCnn);
				return lstSericioAreaPais;
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
				return lstSericioAreaPais;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public SericioAreaPais BuscarSericioAreaPais(System.Int32 idareapais,System.Int32 idservicio)
		{
			SericioAreaPais _SericioAreaPais= new SericioAreaPais();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_SericioAreaPais_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idareapais", idareapais);
				SqlCmd.Parameters.AddWithValue("@idservicio", idservicio);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_SericioAreaPais.idareapais = (System.Int32)rdr["idareapais"];
					_SericioAreaPais.idservicio = (System.Int32)rdr["idservicio"];
					_SericioAreaPais.idarea = (System.Int32)rdr["idarea"];
					_SericioAreaPais.idpais = (System.Int32)rdr["idpais"];
					_SericioAreaPais.fecharegistro = !rdr.IsDBNull(4) ? (System.DateTime)rdr["fecharegistro"] : System.DateTime.Now;
				}
				Base.CerrarConexion(SqlCnn);
				return _SericioAreaPais;
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
				return _SericioAreaPais;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarSericioAreaPais(SericioAreaPais _SericioAreaPais)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_SericioAreaPais_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDAreaPais = new SqlParameter();
				pIDAreaPais.ParameterName = "@IDAreaPais";
				pIDAreaPais.Value = 0;
				SqlCmd.Parameters.Add(pIDAreaPais);
				pIDAreaPais.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@idservicio", _SericioAreaPais.idservicio);
				SqlCmd.Parameters.AddWithValue("@idarea", _SericioAreaPais.idarea);
				SqlCmd.Parameters.AddWithValue("@idpais", _SericioAreaPais.idpais);
				SqlCmd.Parameters.AddWithValue("@fecharegistro", _SericioAreaPais.fecharegistro);

				SqlCmd.ExecuteNonQuery();
				_SericioAreaPais.idareapais = (System.Int32)pIDAreaPais.Value;
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
		public ActionResult ActualizarSericioAreaPais(SericioAreaPais _SericioAreaPais)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_SericioAreaPais_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idareapais", _SericioAreaPais.idareapais);
				SqlCmd.Parameters.AddWithValue("@idservicio", _SericioAreaPais.idservicio);
				SqlCmd.Parameters.AddWithValue("@idarea", _SericioAreaPais.idarea);
				SqlCmd.Parameters.AddWithValue("@idpais", _SericioAreaPais.idpais);
				SqlCmd.Parameters.AddWithValue("@fecharegistro", _SericioAreaPais.fecharegistro);

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
		public ActionResult EliminarSericioAreaPais(SericioAreaPais _SericioAreaPais)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_SericioAreaPais_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idareapais", _SericioAreaPais.idareapais);
				SqlCmd.Parameters.AddWithValue("@idservicio", _SericioAreaPais.idservicio);

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
