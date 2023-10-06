using ASP_NET.Models;
using ASP_NET.Repositorios.Contrato;
using System.Data;
using System.Data.SqlClient;

namespace ASP_NET.Repositorios.Implementacion
{   /*Implementar Interfaz : Nos trae todos los metodos que trae esa interfaz */

    public class DepartamentoRepositorio : IGenericRepositorio<Departamento>
    {
        private readonly string _cadenaSQL = "";

        // Obteniendo la cadena de conexion 
        public DepartamentoRepositorio(IConfiguration configuration)
        {
            _cadenaSQL = configuration.GetConnectionString("cadenaSQL");
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Editar(Departamento modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Guardar(Departamento modelo)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Departamento>> Lista()
        {
            List<Departamento> _lista = new List<Departamento>();
            using (var conexion = new SqlConnection(_cadenaSQL))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListaDepartamentos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using(var dr = await cmd.ExecuteReaderAsync())
                {
                    while(await dr.ReadAsync()){
                        _lista.Add(new Departamento
                        {
                             idDepartamento = Convert.ToInt32(dr["idDepartamento"]),
                             nombre = dr["nombre"].ToString()
                        });
                    }
                }
            }
            return _lista;  
        }
    }
}
