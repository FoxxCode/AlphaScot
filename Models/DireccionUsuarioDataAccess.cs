using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class DireccionUsuarioDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<DireccionUsuario> ConsultarDireccionUsuario()
		{
			List<DireccionUsuario> lstDireccionUsuario = new List<DireccionUsuario>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_DireccionUsuario_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					DireccionUsuario _DireccionUsuario= new DireccionUsuario();
					_DireccionUsuario.iddireccion = (System.Int32)rdr["iddireccion"];
					_DireccionUsuario.idusuario = (System.String)rdr["idusuario"];
					_DireccionUsuario.idzona = (System.String)rdr["idzona"];
					_DireccionUsuario.idciudad = (System.Int32)rdr["idciudad"];
					_DireccionUsuario.idpais = (System.Int32)rdr["idpais"];
					_DireccionUsuario.descripcion = !rdr.IsDBNull(5) ? (System.String)rdr["descripcion"] : "";
					_DireccionUsuario.numero = !rdr.IsDBNull(6) ? (System.Int32)rdr["numero"] : (System.Int32)0;
					_DireccionUsuario.pordefecto = (System.Boolean)rdr["pordefecto"];
					lstDireccionUsuario.Add(_DireccionUsuario);
				}
				Base.CerrarConexion(SqlCnn);
				return lstDireccionUsuario;
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
				return lstDireccionUsuario;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public DireccionUsuario BuscarDireccionUsuario(System.Int32 iddireccion,System.String idusuario)
		{
			DireccionUsuario _DireccionUsuario= new DireccionUsuario();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_DireccionUsuario_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@iddireccion", iddireccion);
				SqlCmd.Parameters.AddWithValue("@idusuario", idusuario);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_DireccionUsuario.iddireccion = (System.Int32)rdr["iddireccion"];
					_DireccionUsuario.idusuario = (System.String)rdr["idusuario"];
					_DireccionUsuario.idzona = (System.String)rdr["idzona"];
					_DireccionUsuario.idciudad = (System.Int32)rdr["idciudad"];
					_DireccionUsuario.idpais = (System.Int32)rdr["idpais"];
					_DireccionUsuario.descripcion = !rdr.IsDBNull(5) ? (System.String)rdr["descripcion"] : "";
					_DireccionUsuario.numero = !rdr.IsDBNull(6) ? (System.Int32)rdr["numero"] : (System.Int32)0;
					_DireccionUsuario.pordefecto = (System.Boolean)rdr["pordefecto"];
				}
				Base.CerrarConexion(SqlCnn);
				return _DireccionUsuario;
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
				return _DireccionUsuario;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarDireccionUsuario(DireccionUsuario _DireccionUsuario)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_DireccionUsuario_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDDireccion = new SqlParameter();
				pIDDireccion.ParameterName = "@IDDireccion";
				pIDDireccion.Value = 0;
				SqlCmd.Parameters.Add(pIDDireccion);
				pIDDireccion.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@idusuario", _DireccionUsuario.idusuario);
				SqlCmd.Parameters.AddWithValue("@idzona", _DireccionUsuario.idzona);
				SqlCmd.Parameters.AddWithValue("@idciudad", _DireccionUsuario.idciudad);
				SqlCmd.Parameters.AddWithValue("@idpais", _DireccionUsuario.idpais);
				SqlCmd.Parameters.AddWithValue("@descripcion", _DireccionUsuario.descripcion);
				SqlCmd.Parameters.AddWithValue("@numero", _DireccionUsuario.numero);
				SqlCmd.Parameters.AddWithValue("@pordefecto", _DireccionUsuario.pordefecto);

				SqlCmd.ExecuteNonQuery();
				_DireccionUsuario.iddireccion = (System.Int32)pIDDireccion.Value;
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
		public ActionResult ActualizarDireccionUsuario(DireccionUsuario _DireccionUsuario)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_DireccionUsuario_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@iddireccion", _DireccionUsuario.iddireccion);
				SqlCmd.Parameters.AddWithValue("@idusuario", _DireccionUsuario.idusuario);
				SqlCmd.Parameters.AddWithValue("@idzona", _DireccionUsuario.idzona);
				SqlCmd.Parameters.AddWithValue("@idciudad", _DireccionUsuario.idciudad);
				SqlCmd.Parameters.AddWithValue("@idpais", _DireccionUsuario.idpais);
				SqlCmd.Parameters.AddWithValue("@descripcion", _DireccionUsuario.descripcion);
				SqlCmd.Parameters.AddWithValue("@numero", _DireccionUsuario.numero);
				SqlCmd.Parameters.AddWithValue("@pordefecto", _DireccionUsuario.pordefecto);

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
		public ActionResult EliminarDireccionUsuario(DireccionUsuario _DireccionUsuario)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_DireccionUsuario_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@iddireccion", _DireccionUsuario.iddireccion);
				SqlCmd.Parameters.AddWithValue("@idusuario", _DireccionUsuario.idusuario);

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
