using Entidades.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ApiRest.Repositorios
{
	public class CitaRepositorio
	{
		private readonly string _cadenaConexion;

		public CitaRepositorio(IConfiguration configuration)
		{
			_cadenaConexion = configuration.GetConnectionString("MiCadenaConexion");
		}

		public async Task<List<Cita>> ListarCita()
		{
			List<Cita> citas = new List<Cita>();
			SqlConnection conn = null;
			SqlCommand cmd = null;
			SqlDataReader dr = null;

			try
			{
				conn = new SqlConnection(_cadenaConexion);
				cmd = new SqlCommand("PD_ListarCitas", conn);
				cmd.CommandType = CommandType.StoredProcedure;
				//cmd.Parameters.AddWithValue("@personaId", 1);
				conn.Open();

				dr = cmd.ExecuteReader();

				while (dr.Read())
				{
					Cita cita = new Cita();
					cita.Id = Convert.ToInt32(dr["Id"]);
					cita.Fecha = Convert.ToDateTime(dr["Fecha"]);
					cita.Estado = Convert.ToBoolean(dr["Estado"]);
					cita.Observacion = Convert.ToString(dr["Observacion"]);
					cita.Medico = new Medico
					{
						Nombre = Convert.ToString(dr["NombreMedico"])
					};
					cita.Persona = new Persona
					{
						Nombres = Convert.ToString(dr["NombrePersona"])
					};

					citas.Add(cita);
				}

			}
			catch (Exception)
			{
				citas = new List<Cita>();
			}
			finally
			{
				await conn.CloseAsync();
			}
			return citas;
		}
	}
}
