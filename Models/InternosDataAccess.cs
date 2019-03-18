using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class InternosDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<Internos> ConsultarInternos()
		{
			List<Internos> lstInternos = new List<Internos>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Internos_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Internos _Internos= new Internos();
					_Internos.idinterno = (System.String)rdr["idinterno"];
					_Internos.idcentral = (System.Int32)rdr["idcentral"];
					_Internos.descripcion = (System.String)rdr["descripcion"];
					_Internos.etiqueta = !rdr.IsDBNull(3) ? (System.String)rdr["etiqueta"] : "";
					lstInternos.Add(_Internos);
				}
				Base.CerrarConexion(SqlCnn);
				return lstInternos;
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
				return lstInternos;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public Internos BuscarInternos(System.String idinterno,System.Int32 idcentral)
		{
			Internos _Internos= new Internos();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Internos_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idinterno", idinterno);
				SqlCmd.Parameters.AddWithValue("@idcentral", idcentral);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_Internos.idinterno = (System.String)rdr["idinterno"];
					_Internos.idcentral = (System.Int32)rdr["idcentral"];
					_Internos.descripcion = (System.String)rdr["descripcion"];
					_Internos.etiqueta = !rdr.IsDBNull(3) ? (System.String)rdr["etiqueta"] : "";
				}
				Base.CerrarConexion(SqlCnn);
				return _Internos;
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
				return _Internos;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarInternos(Internos _Internos)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Internos_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idinterno", _Internos.idinterno);
				SqlCmd.Parameters.AddWithValue("@idcentral", _Internos.idcentral);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Internos.descripcion);
				SqlCmd.Parameters.AddWithValue("@etiqueta", _Internos.etiqueta);

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
		public ActionResult ActualizarInternos(Internos _Internos)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Internos_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idinterno", _Internos.idinterno);
				SqlCmd.Parameters.AddWithValue("@idcentral", _Internos.idcentral);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Internos.descripcion);
				SqlCmd.Parameters.AddWithValue("@etiqueta", _Internos.etiqueta);

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
		public ActionResult EliminarInternos(Internos _Internos)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Internos_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idinterno", _Internos.idinterno);
				SqlCmd.Parameters.AddWithValue("@idcentral", _Internos.idcentral);

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
