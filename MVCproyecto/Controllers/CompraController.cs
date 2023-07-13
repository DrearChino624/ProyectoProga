using Microsoft.AspNetCore.Mvc;
using MVCproyecto.Models;

namespace MVCproyecto.Controllers
{
    public class CompraController : Controller
    {
        private readonly APIGateway _api;

        public CompraController(APIGateway api)
        {
            _api = api;
        }

        //Crear una lista de lo que ve
        public IActionResult Index()
        {
            List<Compra> compras;
            compras = _api.ListCompra();
            return View(compras);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Compra compra = new Compra();
            return View(compra);
        }

        [HttpPost]
        public IActionResult Create(Compra compra)
        {
            _api.CrearCompra(compra);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Compra compra;

            compra = _api.GetCompra(id);

            return View(compra);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Compra compra;
            compra = _api.GetCompra(id);
            return View(compra);
        }

        [HttpPost]
        public IActionResult Edit(Compra compra)
        {
            _api.ActualizarCompra(compra);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Compra compra;
            compra = _api.GetCompra(id);
            return View(compra);
        }

        [HttpPost]
        public IActionResult Delete(Compra compra)
        {
            _api.EliminarCompra(compra.id);
            return RedirectToAction("Index");
        }
    }
}
