using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class ComunicacionUsuarioDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<ComunicacionUsuario> ConsultarComunicacionUsuario()
		{
			List<ComunicacionUsuario> lstComunicacionUsuario = new List<ComunicacionUsuario>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_ComunicacionUsuario_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					ComunicacionUsuario _ComunicacionUsuario= new ComunicacionUsuario();
					_ComunicacionUsuario.idcomunicacion = (System.Int32)rdr["idcomunicacion"];
					_ComunicacionUsuario.idtipocomunicacion = (System.String)rdr["idtipocomunicacion"];
					_ComunicacionUsuario.valor = !rdr.IsDBNull(2) ? (System.String)rdr["valor"] : "";
					_ComunicacionUsuario.pordefecto = !rdr.IsDBNull(3) ? (System.Boolean)rdr["pordefecto"] : true;
					lstComunicacionUsuario.Add(_ComunicacionUsuario);
				}
				Base.CerrarConexion(SqlCnn);
				return lstComunicacionUsuario;
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
				return lstComunicacionUsuario;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ComunicacionUsuario BuscarComunicacionUsuario(System.Int32 idcomunicacion)
		{
			ComunicacionUsuario _ComunicacionUsuario= new ComunicacionUsuario();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_ComunicacionUsuario_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idcomunicacion", idcomunicacion);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_ComunicacionUsuario.idcomunicacion = (System.Int32)rdr["idcomunicacion"];
					_ComunicacionUsuario.idtipocomunicacion = (System.String)rdr["idtipocomunicacion"];
					_ComunicacionUsuario.valor = !rdr.IsDBNull(2) ? (System.String)rdr["valor"] : "";
					_ComunicacionUsuario.pordefecto = !rdr.IsDBNull(3) ? (System.Boolean)rdr["pordefecto"] : true;
				}
				Base.CerrarConexion(SqlCnn);
				return _ComunicacionUsuario;
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
				return _ComunicacionUsuario;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarComunicacionUsuario(ComunicacionUsuario _ComunicacionUsuario)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_ComunicacionUsuario_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDComunicacion = new SqlParameter();
				pIDComunicacion.ParameterName = "@IDComunicacion";
				pIDComunicacion.Value = 0;
				SqlCmd.Parameters.Add(pIDComunicacion);
				pIDComunicacion.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@idtipocomunicacion", _ComunicacionUsuario.idtipocomunicacion);
				SqlCmd.Parameters.AddWithValue("@valor", _ComunicacionUsuario.valor);
				SqlCmd.Parameters.AddWithValue("@pordefecto", _ComunicacionUsuario.pordefecto);

				SqlCmd.ExecuteNonQuery();
				_ComunicacionUsuario.idcomunicacion = (System.Int32)pIDComunicacion.Value;
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
		public ActionResult ActualizarComunicacionUsuario(ComunicacionUsuario _ComunicacionUsuario)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_ComunicacionUsuario_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idcomunicacion", _ComunicacionUsuario.idcomunicacion);
				SqlCmd.Parameters.AddWithValue("@idtipocomunicacion", _ComunicacionUsuario.idtipocomunicacion);
				SqlCmd.Parameters.AddWithValue("@valor", _ComunicacionUsuario.valor);
				SqlCmd.Parameters.AddWithValue("@pordefecto", _ComunicacionUsuario.pordefecto);

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
		public ActionResult EliminarComunicacionUsuario(ComunicacionUsuario _ComunicacionUsuario)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_ComunicacionUsuario_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idcomunicacion", _ComunicacionUsuario.idcomunicacion);

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
