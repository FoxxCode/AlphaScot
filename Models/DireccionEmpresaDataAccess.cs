using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class DireccionEmpresaDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<DireccionEmpresa> ConsultarDireccionEmpresa()
		{
			List<DireccionEmpresa> lstDireccionEmpresa = new List<DireccionEmpresa>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_DireccionEmpresa_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					DireccionEmpresa _DireccionEmpresa= new DireccionEmpresa();
					_DireccionEmpresa.iddireccion = (System.Int32)rdr["iddireccion"];
					_DireccionEmpresa.idempresa = (System.Int32)rdr["idempresa"];
					_DireccionEmpresa.idzona = (System.String)rdr["idzona"];
					_DireccionEmpresa.idciudad = (System.Int32)rdr["idciudad"];
					_DireccionEmpresa.idpais = (System.Int32)rdr["idpais"];
					_DireccionEmpresa.descripcion = !rdr.IsDBNull(5) ? (System.String)rdr["descripcion"] : "";
					_DireccionEmpresa.numero = !rdr.IsDBNull(6) ? (System.Int32)rdr["numero"] : (System.Int32)0;
					_DireccionEmpresa.pordefecto = (System.Boolean)rdr["pordefecto"];
					lstDireccionEmpresa.Add(_DireccionEmpresa);
				}
				Base.CerrarConexion(SqlCnn);
				return lstDireccionEmpresa;
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
				return lstDireccionEmpresa;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public DireccionEmpresa BuscarDireccionEmpresa(System.Int32 iddireccion,System.Int32 idempresa)
		{
			DireccionEmpresa _DireccionEmpresa= new DireccionEmpresa();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_DireccionEmpresa_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@iddireccion", iddireccion);
				SqlCmd.Parameters.AddWithValue("@idempresa", idempresa);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_DireccionEmpresa.iddireccion = (System.Int32)rdr["iddireccion"];
					_DireccionEmpresa.idempresa = (System.Int32)rdr["idempresa"];
					_DireccionEmpresa.idzona = (System.String)rdr["idzona"];
					_DireccionEmpresa.idciudad = (System.Int32)rdr["idciudad"];
					_DireccionEmpresa.idpais = (System.Int32)rdr["idpais"];
					_DireccionEmpresa.descripcion = !rdr.IsDBNull(5) ? (System.String)rdr["descripcion"] : "";
					_DireccionEmpresa.numero = !rdr.IsDBNull(6) ? (System.Int32)rdr["numero"] : (System.Int32)0;
					_DireccionEmpresa.pordefecto = (System.Boolean)rdr["pordefecto"];
				}
				Base.CerrarConexion(SqlCnn);
				return _DireccionEmpresa;
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
				return _DireccionEmpresa;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarDireccionEmpresa(DireccionEmpresa _DireccionEmpresa)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_DireccionEmpresa_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDDireccion = new SqlParameter();
				pIDDireccion.ParameterName = "@IDDireccion";
				pIDDireccion.Value = 0;
				SqlCmd.Parameters.Add(pIDDireccion);
				pIDDireccion.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@idempresa", _DireccionEmpresa.idempresa);
				SqlCmd.Parameters.AddWithValue("@idzona", _DireccionEmpresa.idzona);
				SqlCmd.Parameters.AddWithValue("@idciudad", _DireccionEmpresa.idciudad);
				SqlCmd.Parameters.AddWithValue("@idpais", _DireccionEmpresa.idpais);
				SqlCmd.Parameters.AddWithValue("@descripcion", _DireccionEmpresa.descripcion);
				SqlCmd.Parameters.AddWithValue("@numero", _DireccionEmpresa.numero);
				SqlCmd.Parameters.AddWithValue("@pordefecto", _DireccionEmpresa.pordefecto);

				SqlCmd.ExecuteNonQuery();
				_DireccionEmpresa.iddireccion = (System.Int32)pIDDireccion.Value;
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
		public ActionResult ActualizarDireccionEmpresa(DireccionEmpresa _DireccionEmpresa)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_DireccionEmpresa_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@iddireccion", _DireccionEmpresa.iddireccion);
				SqlCmd.Parameters.AddWithValue("@idempresa", _DireccionEmpresa.idempresa);
				SqlCmd.Parameters.AddWithValue("@idzona", _DireccionEmpresa.idzona);
				SqlCmd.Parameters.AddWithValue("@idciudad", _DireccionEmpresa.idciudad);
				SqlCmd.Parameters.AddWithValue("@idpais", _DireccionEmpresa.idpais);
				SqlCmd.Parameters.AddWithValue("@descripcion", _DireccionEmpresa.descripcion);
				SqlCmd.Parameters.AddWithValue("@numero", _DireccionEmpresa.numero);
				SqlCmd.Parameters.AddWithValue("@pordefecto", _DireccionEmpresa.pordefecto);

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
		public ActionResult EliminarDireccionEmpresa(DireccionEmpresa _DireccionEmpresa)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_DireccionEmpresa_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@iddireccion", _DireccionEmpresa.iddireccion);
				SqlCmd.Parameters.AddWithValue("@idempresa", _DireccionEmpresa.idempresa);

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
