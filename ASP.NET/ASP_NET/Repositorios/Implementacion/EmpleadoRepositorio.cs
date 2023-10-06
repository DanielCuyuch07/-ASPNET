using ASP_NET.Models;
using ASP_NET.Repositorios.Contrato;
using System.Data;
using System.Data.SqlClient;

namespace ASP_NET.Repositorios.Implementacion
{
    public class EmpleadoRepositorio : IGenericRepositorio<Empleado>
    {
        private readonly string _cadenaSQL = "";

        public EmpleadoRepositorio(IConfiguration configuration)
        {
            _cadenaSQL = configuration.GetConnectionString("cadenaSQL");
        }


        public async Task<List<Empleado>> Lista()
        {
            List<Empleado> _lista = new List<Empleado>();
            using (var conexion = new SqlConnection(_cadenaSQL))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListaEmpleados", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        _lista.Add(new Empleado
                        {
                            idEmpleado = Convert.ToInt32(dr["idEmpleado"]),
                            nombreCompleto = dr["nombreCompleto"].ToString()
                        });
                    }
                }
            }
            return _lista;
        }

        public Task<bool> Guardar(Empleado modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Editar(Empleado modelo)
        {
            throw new NotImplementedException();
        }



    }
}
