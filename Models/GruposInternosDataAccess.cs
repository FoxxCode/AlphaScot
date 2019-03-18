using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class GruposInternosDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<GruposInternos> ConsultarGruposInternos()
		{
			List<GruposInternos> lstGruposInternos = new List<GruposInternos>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_GruposInternos_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					GruposInternos _GruposInternos= new GruposInternos();
					_GruposInternos.idgrupo = (System.Int32)rdr["idgrupo"];
					_GruposInternos.idcentral = (System.Int32)rdr["idcentral"];
					_GruposInternos.descripcion = !rdr.IsDBNull(2) ? (System.String)rdr["descripcion"] : "";
					lstGruposInternos.Add(_GruposInternos);
				}
				Base.CerrarConexion(SqlCnn);
				return lstGruposInternos;
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
				return lstGruposInternos;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public GruposInternos BuscarGruposInternos(System.Int32 idgrupo)
		{
			GruposInternos _GruposInternos= new GruposInternos();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_GruposInternos_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idgrupo", idgrupo);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_GruposInternos.idgrupo = (System.Int32)rdr["idgrupo"];
					_GruposInternos.idcentral = (System.Int32)rdr["idcentral"];
					_GruposInternos.descripcion = !rdr.IsDBNull(2) ? (System.String)rdr["descripcion"] : "";
				}
				Base.CerrarConexion(SqlCnn);
				return _GruposInternos;
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
				return _GruposInternos;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarGruposInternos(GruposInternos _GruposInternos)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_GruposInternos_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDGrupo = new SqlParameter();
				pIDGrupo.ParameterName = "@IDGrupo";
				pIDGrupo.Value = 0;
				SqlCmd.Parameters.Add(pIDGrupo);
				pIDGrupo.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@idcentral", _GruposInternos.idcentral);
				SqlCmd.Parameters.AddWithValue("@descripcion", _GruposInternos.descripcion);

				SqlCmd.ExecuteNonQuery();
				_GruposInternos.idgrupo = (System.Int32)pIDGrupo.Value;
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
		public ActionResult ActualizarGruposInternos(GruposInternos _GruposInternos)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_GruposInternos_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idgrupo", _GruposInternos.idgrupo);
				SqlCmd.Parameters.AddWithValue("@idcentral", _GruposInternos.idcentral);
				SqlCmd.Parameters.AddWithValue("@descripcion", _GruposInternos.descripcion);

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
		public ActionResult EliminarGruposInternos(GruposInternos _GruposInternos)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_GruposInternos_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idgrupo", _GruposInternos.idgrupo);

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
