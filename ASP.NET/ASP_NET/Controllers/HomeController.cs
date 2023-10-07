using ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ASP_NET.Repositorios.Contrato;
using ASP_NET.Repositorios.Implementacion;

namespace ASP_NET.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGenericRepositorio<Departamento> _departamentoRepository;
        private readonly IGenericRepositorio<Empleado> _empleadoRepository;

        public HomeController(ILogger<HomeController> logger,
                 IGenericRepositorio<Departamento> departamentoRepository,
                 IGenericRepositorio<Empleado> empleadoRepository)

        {
            _logger = logger;
            _departamentoRepository = departamentoRepository;
            _empleadoRepository = empleadoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> listaDepartamento()
        {
            List<Departamento> _lista = await _departamentoRepository.Lista();
            return StatusCode(StatusCodes.Status200OK, _lista);
        }
        [HttpGet]
        public async Task<IActionResult> listaEmpleado()
        {
            List<Empleado> _lista = await _empleadoRepository.Lista();
            return StatusCode(StatusCodes.Status200OK, _lista);
        }


        [HttpPost]
        public async Task<IActionResult> saveEmpleado([FromBody] Empleado modelo)
        {
            bool _resultado = await _empleadoRepository.Guardar(modelo);
            if (_resultado) {
                return StatusCode(StatusCodes.Status200OK, new {valor = _resultado, msg = "ok"});
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { valor = _resultado, msg = "error" });
            }
        }


        [HttpPut]
        public async Task<IActionResult> editEmpleado([FromBody] Empleado modelo)
        {
            bool _resultado = await _empleadoRepository.Editar(modelo);
            if (_resultado)
            {
                return StatusCode(StatusCodes.Status200OK, new { valor = _resultado, msg = "ok" });
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { valor = _resultado, msg = "error" });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> eliminarEmpleado(int idEmpleado)
        {
            bool _resultado = await _empleadoRepository.Delete(idEmpleado);
            if (_resultado)
            {
                return StatusCode(StatusCodes.Status200OK, new { valor = _resultado, msg = "ok" });
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { valor = _resultado, msg = "error" });
            }
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}