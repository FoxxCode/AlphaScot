using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class FormaAccessoDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<FormaAccesso> ConsultarFormaAccesso()
		{
			List<FormaAccesso> lstFormaAccesso = new List<FormaAccesso>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_FormaAccesso_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					FormaAccesso _FormaAccesso= new FormaAccesso();
					_FormaAccesso.idrol = (System.Int32)rdr["idrol"];
					_FormaAccesso.idforma = (System.Int32)rdr["idforma"];
					_FormaAccesso.acceso = !rdr.IsDBNull(2) ? (System.Boolean)rdr["acceso"] : true;
					_FormaAccesso.insercion = !rdr.IsDBNull(3) ? (System.Boolean)rdr["insercion"] : true;
					_FormaAccesso.modificacion = !rdr.IsDBNull(4) ? (System.Boolean)rdr["modificacion"] : true;
					_FormaAccesso.eliminacion = !rdr.IsDBNull(5) ? (System.Boolean)rdr["eliminacion"] : true;
					_FormaAccesso.consulta = !rdr.IsDBNull(6) ? (System.Boolean)rdr["consulta"] : true;
					_FormaAccesso.impresion = !rdr.IsDBNull(7) ? (System.Boolean)rdr["impresion"] : true;
					_FormaAccesso.operacion = !rdr.IsDBNull(8) ? (System.Boolean)rdr["operacion"] : true;
					lstFormaAccesso.Add(_FormaAccesso);
				}
				Base.CerrarConexion(SqlCnn);
				return lstFormaAccesso;
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
				return lstFormaAccesso;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public FormaAccesso BuscarFormaAccesso(System.Int32 idrol,System.Int32 idforma)
		{
			FormaAccesso _FormaAccesso= new FormaAccesso();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_FormaAccesso_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idrol", idrol);
				SqlCmd.Parameters.AddWithValue("@idforma", idforma);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_FormaAccesso.idrol = (System.Int32)rdr["idrol"];
					_FormaAccesso.idforma = (System.Int32)rdr["idforma"];
					_FormaAccesso.acceso = !rdr.IsDBNull(2) ? (System.Boolean)rdr["acceso"] : true;
					_FormaAccesso.insercion = !rdr.IsDBNull(3) ? (System.Boolean)rdr["insercion"] : true;
					_FormaAccesso.modificacion = !rdr.IsDBNull(4) ? (System.Boolean)rdr["modificacion"] : true;
					_FormaAccesso.eliminacion = !rdr.IsDBNull(5) ? (System.Boolean)rdr["eliminacion"] : true;
					_FormaAccesso.consulta = !rdr.IsDBNull(6) ? (System.Boolean)rdr["consulta"] : true;
					_FormaAccesso.impresion = !rdr.IsDBNull(7) ? (System.Boolean)rdr["impresion"] : true;
					_FormaAccesso.operacion = !rdr.IsDBNull(8) ? (System.Boolean)rdr["operacion"] : true;
				}
				Base.CerrarConexion(SqlCnn);
				return _FormaAccesso;
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
				return _FormaAccesso;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarFormaAccesso(FormaAccesso _FormaAccesso)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_FormaAccesso_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idrol", _FormaAccesso.idrol);
				SqlCmd.Parameters.AddWithValue("@idforma", _FormaAccesso.idforma);
				SqlCmd.Parameters.AddWithValue("@acceso", _FormaAccesso.acceso);
				SqlCmd.Parameters.AddWithValue("@insercion", _FormaAccesso.insercion);
				SqlCmd.Parameters.AddWithValue("@modificacion", _FormaAccesso.modificacion);
				SqlCmd.Parameters.AddWithValue("@eliminacion", _FormaAccesso.eliminacion);
				SqlCmd.Parameters.AddWithValue("@consulta", _FormaAccesso.consulta);
				SqlCmd.Parameters.AddWithValue("@impresion", _FormaAccesso.impresion);
				SqlCmd.Parameters.AddWithValue("@operacion", _FormaAccesso.operacion);

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
		public ActionResult ActualizarFormaAccesso(FormaAccesso _FormaAccesso)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_FormaAccesso_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idrol", _FormaAccesso.idrol);
				SqlCmd.Parameters.AddWithValue("@idforma", _FormaAccesso.idforma);
				SqlCmd.Parameters.AddWithValue("@acceso", _FormaAccesso.acceso);
				SqlCmd.Parameters.AddWithValue("@insercion", _FormaAccesso.insercion);
				SqlCmd.Parameters.AddWithValue("@modificacion", _FormaAccesso.modificacion);
				SqlCmd.Parameters.AddWithValue("@eliminacion", _FormaAccesso.eliminacion);
				SqlCmd.Parameters.AddWithValue("@consulta", _FormaAccesso.consulta);
				SqlCmd.Parameters.AddWithValue("@impresion", _FormaAccesso.impresion);
				SqlCmd.Parameters.AddWithValue("@operacion", _FormaAccesso.operacion);

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
		public ActionResult EliminarFormaAccesso(FormaAccesso _FormaAccesso)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_FormaAccesso_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idrol", _FormaAccesso.idrol);
				SqlCmd.Parameters.AddWithValue("@idforma", _FormaAccesso.idforma);

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
