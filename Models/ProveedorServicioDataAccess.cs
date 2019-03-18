using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Models
{
	public class ProveedorServicioDataAccess: ControllerBase
	{
		private cConexion Base = new cConexion();
		public IEnumerable<ProveedorServicio> ConsultarProveedorServicio()
		{
			List<ProveedorServicio> lstProveedorServicio = new List<ProveedorServicio>();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_ProveedorServicio_Select", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					ProveedorServicio _ProveedorServicio= new ProveedorServicio();
					_ProveedorServicio.idservicio = (System.Int32)rdr["idservicio"];
					_ProveedorServicio.idproveedor = (System.Int32)rdr["idproveedor"];
					_ProveedorServicio.descripcion = (System.String)rdr["descripcion"];
					_ProveedorServicio.etiqueta = !rdr.IsDBNull(3) ? (System.String)rdr["etiqueta"] : "";
					lstProveedorServicio.Add(_ProveedorServicio);
				}
				Base.CerrarConexion(SqlCnn);
				return lstProveedorServicio;
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
				return lstProveedorServicio;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ProveedorServicio BuscarProveedorServicio(System.Int32 idservicio,System.Int32 idproveedor)
		{
			ProveedorServicio _ProveedorServicio= new ProveedorServicio();
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_ProveedorServicio_Search", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idservicio", idservicio);
				SqlCmd.Parameters.AddWithValue("@idproveedor", idproveedor);
				SqlDataReader rdr = SqlCmd.ExecuteReader();
				while (rdr.Read())
				{
					_ProveedorServicio.idservicio = (System.Int32)rdr["idservicio"];
					_ProveedorServicio.idproveedor = (System.Int32)rdr["idproveedor"];
					_ProveedorServicio.descripcion = (System.String)rdr["descripcion"];
					_ProveedorServicio.etiqueta = !rdr.IsDBNull(3) ? (System.String)rdr["etiqueta"] : "";
				}
				Base.CerrarConexion(SqlCnn);
				return _ProveedorServicio;
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
				return _ProveedorServicio;
			}
			catch (Exception Ex)
			{
				throw new Exception(Ex.Message);
			}
		}
		public ActionResult InsertarProveedorServicio(ProveedorServicio _ProveedorServicio)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_ProveedorServicio_Insert", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlParameter pIDServicio = new SqlParameter();
				pIDServicio.ParameterName = "@IDServicio";
				pIDServicio.Value = 0;
				SqlCmd.Parameters.Add(pIDServicio);
				pIDServicio.Direction = System.Data.ParameterDirection.Output;
				SqlCmd.Parameters.AddWithValue("@idproveedor", _ProveedorServicio.idproveedor);
				SqlCmd.Parameters.AddWithValue("@descripcion", _ProveedorServicio.descripcion);
				SqlCmd.Parameters.AddWithValue("@etiqueta", _ProveedorServicio.etiqueta);

				SqlCmd.ExecuteNonQuery();
				_ProveedorServicio.idservicio = (System.Int32)pIDServicio.Value;
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
		public ActionResult ActualizarProveedorServicio(ProveedorServicio _ProveedorServicio)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_ProveedorServicio_Update", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idservicio", _ProveedorServicio.idservicio);
				SqlCmd.Parameters.AddWithValue("@idproveedor", _ProveedorServicio.idproveedor);
				SqlCmd.Parameters.AddWithValue("@descripcion", _ProveedorServicio.descripcion);
				SqlCmd.Parameters.AddWithValue("@etiqueta", _ProveedorServicio.etiqueta);

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
		public ActionResult EliminarProveedorServicio(ProveedorServicio _ProveedorServicio)
		{
			try
			{
				SqlConnection SqlCnn;
				SqlCnn = Base.AbrirConexion();
				SqlCommand SqlCmd = new SqlCommand("Proc_ProveedorServicio_Delete", SqlCnn);
				SqlCmd.CommandType = CommandType.StoredProcedure;
				SqlCmd.Parameters.AddWithValue("@idservicio", _ProveedorServicio.idservicio);
				SqlCmd.Parameters.AddWithValue("@idproveedor", _ProveedorServicio.idproveedor);

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
