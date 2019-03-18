using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class GruposInternosInternoDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<GruposInternosInterno> ConsultarGruposInternosInterno()
		{
			List<GruposInternosInterno> lstGruposInternosInterno = new List<GruposInternosInterno>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_GruposInternosInterno_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					GruposInternosInterno _GruposInternosInterno= new GruposInternosInterno();
					_GruposInternosInterno.idinterno = (System.String)rdr["idinterno"];
					_GruposInternosInterno.idcentral = (System.Int32)rdr["idcentral"];
					_GruposInternosInterno.idgrupo = (System.Int32)rdr["idgrupo"];
					_GruposInternosInterno.fecharegistro = (System.DateTime)rdr["fecharegistro"];
					lstGruposInternosInterno.Add(_GruposInternosInterno);
				}
				Base.CerrarConexion(SqlCnn);
				return lstGruposInternosInterno;
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
				return lstGruposInternosInterno;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public GruposInternosInterno BuscarGruposInternosInterno(System.String idinterno,System.Int32 idcentral,System.Int32 idgrupo)
		{
			GruposInternosInterno _GruposInternosInterno= new GruposInternosInterno();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_GruposInternosInterno_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idinterno", idinterno);
				SqlCmd.Parameters.AddWithValue("@idcentral", idcentral);
				SqlCmd.Parameters.AddWithValue("@idgrupo", idgrupo);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_GruposInternosInterno.idinterno = (System.String)rdr["idinterno"];
					_GruposInternosInterno.idcentral = (System.Int32)rdr["idcentral"];
					_GruposInternosInterno.idgrupo = (System.Int32)rdr["idgrupo"];
					_GruposInternosInterno.fecharegistro = (System.DateTime)rdr["fecharegistro"];
				}
				Base.CerrarConexion(SqlCnn);
				return _GruposInternosInterno;
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
				return _GruposInternosInterno;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarGruposInternosInterno(GruposInternosInterno _GruposInternosInterno)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_GruposInternosInterno_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idinterno", _GruposInternosInterno.idinterno);
				SqlCmd.Parameters.AddWithValue("@idcentral", _GruposInternosInterno.idcentral);
				SqlCmd.Parameters.AddWithValue("@idgrupo", _GruposInternosInterno.idgrupo);
				SqlCmd.Parameters.AddWithValue("@fecharegistro", _GruposInternosInterno.fecharegistro);

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
		public ActionResult ActualizarGruposInternosInterno(GruposInternosInterno _GruposInternosInterno)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_GruposInternosInterno_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idinterno", _GruposInternosInterno.idinterno);
				SqlCmd.Parameters.AddWithValue("@idcentral", _GruposInternosInterno.idcentral);
				SqlCmd.Parameters.AddWithValue("@idgrupo", _GruposInternosInterno.idgrupo);
				SqlCmd.Parameters.AddWithValue("@fecharegistro", _GruposInternosInterno.fecharegistro);

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
		public ActionResult EliminarGruposInternosInterno(GruposInternosInterno _GruposInternosInterno)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_GruposInternosInterno_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idinterno", _GruposInternosInterno.idinterno);
				SqlCmd.Parameters.AddWithValue("@idcentral", _GruposInternosInterno.idcentral);
				SqlCmd.Parameters.AddWithValue("@idgrupo", _GruposInternosInterno.idgrupo);

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
