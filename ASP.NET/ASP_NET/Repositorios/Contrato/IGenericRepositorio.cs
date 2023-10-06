namespace ASP_NET.Repositorios.Contrato
{
    // Especificamos que T es una clase
    public interface IGenericRepositorio<T> where T : class
    {
        /*Crearemos los metodos que vamos a usar para nuestro empleado y departamento*/
        Task<List<T>> Lista();
        Task<bool> Guardar(T modelo);
        Task<bool> Editar(T modelo);
        Task<bool> Delete(int id);
    }
}
