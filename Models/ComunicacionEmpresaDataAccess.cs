using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class ComunicacionEmpresaDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<ComunicacionEmpresa> ConsultarComunicacionEmpresa()
		{
			List<ComunicacionEmpresa> lstComunicacionEmpresa = new List<ComunicacionEmpresa>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_ComunicacionEmpresa_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					ComunicacionEmpresa _ComunicacionEmpresa= new ComunicacionEmpresa();
					_ComunicacionEmpresa.idcomunicacion = (System.Int32)rdr["idcomunicacion"];
					_ComunicacionEmpresa.idempresa = (System.Int32)rdr["idempresa"];
					_ComunicacionEmpresa.idtipocomunicacion = (System.String)rdr["idtipocomunicacion"];
					_ComunicacionEmpresa.valor = !rdr.IsDBNull(3) ? (System.String)rdr["valor"] : "";
					_ComunicacionEmpresa.pordefecto = !rdr.IsDBNull(4) ? (System.Boolean)rdr["pordefecto"] : true;
					lstComunicacionEmpresa.Add(_ComunicacionEmpresa);
				}
				Base.CerrarConexion(SqlCnn);
				return lstComunicacionEmpresa;
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
				return lstComunicacionEmpresa;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ComunicacionEmpresa BuscarComunicacionEmpresa(System.Int32 idcomunicacion,System.Int32 idempresa)
		{
			ComunicacionEmpresa _ComunicacionEmpresa= new ComunicacionEmpresa();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_ComunicacionEmpresa_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idcomunicacion", idcomunicacion);
				SqlCmd.Parameters.AddWithValue("@idempresa", idempresa);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_ComunicacionEmpresa.idcomunicacion = (System.Int32)rdr["idcomunicacion"];
					_ComunicacionEmpresa.idempresa = (System.Int32)rdr["idempresa"];
					_ComunicacionEmpresa.idtipocomunicacion = (System.String)rdr["idtipocomunicacion"];
					_ComunicacionEmpresa.valor = !rdr.IsDBNull(3) ? (System.String)rdr["valor"] : "";
					_ComunicacionEmpresa.pordefecto = !rdr.IsDBNull(4) ? (System.Boolean)rdr["pordefecto"] : true;
				}
				Base.CerrarConexion(SqlCnn);
				return _ComunicacionEmpresa;
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
				return _ComunicacionEmpresa;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarComunicacionEmpresa(ComunicacionEmpresa _ComunicacionEmpresa)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_ComunicacionEmpresa_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDComunicacion = new SqlParameter();
				pIDComunicacion.ParameterName = "@IDComunicacion";
				pIDComunicacion.Value = 0;
				SqlCmd.Parameters.Add(pIDComunicacion);
				pIDComunicacion.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@idempresa", _ComunicacionEmpresa.idempresa);
				SqlCmd.Parameters.AddWithValue("@idtipocomunicacion", _ComunicacionEmpresa.idtipocomunicacion);
				SqlCmd.Parameters.AddWithValue("@valor", _ComunicacionEmpresa.valor);
				SqlCmd.Parameters.AddWithValue("@pordefecto", _ComunicacionEmpresa.pordefecto);

				SqlCmd.ExecuteNonQuery();
				_ComunicacionEmpresa.idcomunicacion = (System.Int32)pIDComunicacion.Value;
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
		public ActionResult ActualizarComunicacionEmpresa(ComunicacionEmpresa _ComunicacionEmpresa)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_ComunicacionEmpresa_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idcomunicacion", _ComunicacionEmpresa.idcomunicacion);
				SqlCmd.Parameters.AddWithValue("@idempresa", _ComunicacionEmpresa.idempresa);
				SqlCmd.Parameters.AddWithValue("@idtipocomunicacion", _ComunicacionEmpresa.idtipocomunicacion);
				SqlCmd.Parameters.AddWithValue("@valor", _ComunicacionEmpresa.valor);
				SqlCmd.Parameters.AddWithValue("@pordefecto", _ComunicacionEmpresa.pordefecto);

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
		public ActionResult EliminarComunicacionEmpresa(ComunicacionEmpresa _ComunicacionEmpresa)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_ComunicacionEmpresa_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idcomunicacion", _ComunicacionEmpresa.idcomunicacion);
				SqlCmd.Parameters.AddWithValue("@idempresa", _ComunicacionEmpresa.idempresa);

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
