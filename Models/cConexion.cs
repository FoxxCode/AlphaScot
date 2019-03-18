using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace proyecto
{
	class cConexion
	{
		public SqlConnection AbrirConexion()
		{
			SqlConnection Cnn = new SqlConnection();
			try
			{
				Cnn.ConnectionString = "Password=Alpha123!!;Persist Security Info=True;User ID=AlphaDesarrollo;Initial Catalog=SCOTNET;Data Source=10.1.4.191;";
				Cnn.Open();
				return Cnn;
			}
			catch
			{
				throw new Exception("Error al Abrir la Conexion");
			}
		}
		public void CerrarConexion(SqlConnection Cnn)
		{
			try
			{
				Cnn.Close();
			}
			catch
			{
				throw new Exception("Error al Cerrar la Conexion");
			}
		}
	}
}
