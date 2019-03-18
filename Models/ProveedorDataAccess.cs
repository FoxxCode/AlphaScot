using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class ProveedorDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<Proveedor> ConsultarProveedor()
		{
			List<Proveedor> lstProveedor = new List<Proveedor>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Proveedor_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					Proveedor _Proveedor= new Proveedor();
					_Proveedor.idproveedor = (System.Int32)rdr["idproveedor"];
					_Proveedor.idtipo = (System.Int32)rdr["idtipo"];
					_Proveedor.etiqueta = !rdr.IsDBNull(2) ? (System.String)rdr["etiqueta"] : "";
					_Proveedor.idciudad = (System.Int32)rdr["idciudad"];
					_Proveedor.idpais = !rdr.IsDBNull(4) ? (System.Int32)rdr["idpais"] : (System.Int32)0;
					_Proveedor.descripcion = !rdr.IsDBNull(5) ? (System.String)rdr["descripcion"] : "";
					lstProveedor.Add(_Proveedor);
				}
				Base.CerrarConexion(SqlCnn);
				return lstProveedor;
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
				return lstProveedor;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public Proveedor BuscarProveedor(System.Int32 idproveedor)
		{
			Proveedor _Proveedor= new Proveedor();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Proveedor_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idproveedor", idproveedor);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_Proveedor.idproveedor = (System.Int32)rdr["idproveedor"];
					_Proveedor.idtipo = (System.Int32)rdr["idtipo"];
					_Proveedor.etiqueta = !rdr.IsDBNull(2) ? (System.String)rdr["etiqueta"] : "";
					_Proveedor.idciudad = (System.Int32)rdr["idciudad"];
					_Proveedor.idpais = !rdr.IsDBNull(4) ? (System.Int32)rdr["idpais"] : (System.Int32)0;
					_Proveedor.descripcion = !rdr.IsDBNull(5) ? (System.String)rdr["descripcion"] : "";
				}
				Base.CerrarConexion(SqlCnn);
				return _Proveedor;
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
				return _Proveedor;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarProveedor(Proveedor _Proveedor)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Proveedor_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idproveedor", _Proveedor.idproveedor);
				SqlCmd.Parameters.AddWithValue("@idtipo", _Proveedor.idtipo);
				SqlCmd.Parameters.AddWithValue("@etiqueta", _Proveedor.etiqueta);
				SqlCmd.Parameters.AddWithValue("@idciudad", _Proveedor.idciudad);
				SqlCmd.Parameters.AddWithValue("@idpais", _Proveedor.idpais);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Proveedor.descripcion);

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
		public ActionResult ActualizarProveedor(Proveedor _Proveedor)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Proveedor_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idproveedor", _Proveedor.idproveedor);
				SqlCmd.Parameters.AddWithValue("@idtipo", _Proveedor.idtipo);
				SqlCmd.Parameters.AddWithValue("@etiqueta", _Proveedor.etiqueta);
				SqlCmd.Parameters.AddWithValue("@idciudad", _Proveedor.idciudad);
				SqlCmd.Parameters.AddWithValue("@idpais", _Proveedor.idpais);
				SqlCmd.Parameters.AddWithValue("@descripcion", _Proveedor.descripcion);

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
		public ActionResult EliminarProveedor(Proveedor _Proveedor)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_Proveedor_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idproveedor", _Proveedor.idproveedor);

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
