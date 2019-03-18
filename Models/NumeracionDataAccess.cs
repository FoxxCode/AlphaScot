using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class NumeracionDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<Numeracion> ConsultarNumeracion()
		{
			List<Numeracion> lstNumeracion = new List<Numeracion>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Numeracion_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Numeracion _Numeracion= new Numeracion();
					_Numeracion.idrango = (System.Int32)rdr["idrango"];
					_Numeracion.descripcion = (System.String)rdr["descripcion"];
					_Numeracion.etiqueta = !rdr.IsDBNull(2) ? (System.String)rdr["etiqueta"] : "";
					_Numeracion.numeroinicio = (System.String)rdr["numeroinicio"];
					_Numeracion.numerofinal = (System.String)rdr["numerofinal"];
					lstNumeracion.Add(_Numeracion);
				}
				Base.CerrarConexion(SqlCnn);
				return lstNumeracion;
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
				return lstNumeracion;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public Numeracion BuscarNumeracion(System.Int32 idrango)
		{
			Numeracion _Numeracion= new Numeracion();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Numeracion_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idrango", idrango);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_Numeracion.idrango = (System.Int32)rdr["idrango"];
					_Numeracion.descripcion = (System.String)rdr["descripcion"];
					_Numeracion.etiqueta = !rdr.IsDBNull(2) ? (System.String)rdr["etiqueta"] : "";
					_Numeracion.numeroinicio = (System.String)rdr["numeroinicio"];
					_Numeracion.numerofinal = (System.String)rdr["numerofinal"];
				}
				Base.CerrarConexion(SqlCnn);
				return _Numeracion;
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
				return _Numeracion;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarNumeracion(Numeracion _Numeracion)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Numeracion_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idrango", _Numeracion.idrango);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Numeracion.descripcion);
				SqlCmd.Parameters.AddWithValue("@etiqueta", _Numeracion.etiqueta);
				SqlCmd.Parameters.AddWithValue("@numeroinicio", _Numeracion.numeroinicio);
				SqlCmd.Parameters.AddWithValue("@numerofinal", _Numeracion.numerofinal);

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
		public ActionResult ActualizarNumeracion(Numeracion _Numeracion)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Numeracion_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idrango", _Numeracion.idrango);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Numeracion.descripcion);
				SqlCmd.Parameters.AddWithValue("@etiqueta", _Numeracion.etiqueta);
				SqlCmd.Parameters.AddWithValue("@numeroinicio", _Numeracion.numeroinicio);
				SqlCmd.Parameters.AddWithValue("@numerofinal", _Numeracion.numerofinal);

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
		public ActionResult EliminarNumeracion(Numeracion _Numeracion)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Numeracion_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idrango", _Numeracion.idrango);

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
