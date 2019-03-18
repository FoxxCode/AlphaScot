using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Proyecto
{
	class cConexion
	{
		public SqlConnection AbrirConexion()
		{
			SqlConnection Cnn = new SqlConnection();
			try
			{
				Cnn.ConnectionString ="Password=demo;Persist Security Info=True;User ID=demo;Initial Catalog=demo;Data Source=(local);";
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
