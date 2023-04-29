using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PracticaMVC.Models;

namespace PracticaMVC.Controllers
{
    public class equiposController : Controller
    {
        private readonly equiposDbContext _equiposDbContext;

        public equiposController(equiposDbContext equiposDbContext)
        {
            _equiposDbContext= equiposDbContext;
        }
        public IActionResult Index()
        {
           
            var listadoTipEquipo = (from te in _equiposDbContext.tipo_equipo
                                    select te).ToList();
            ViewData["listadoTequipos"] = new SelectList(listadoTipEquipo, "id_tipo_equipo", "descripcion");

            var listaDeMarcas = (from m in _equiposDbContext.marcas
                                 select m).ToList();
            ViewData["listadoDeMarcas"] = new SelectList(listaDeMarcas, "id_marcas", "nombre_marca");

            var listadoEequipo = (from ee in _equiposDbContext.Estados_equipo select ee).ToList();
            ViewData["EstadosEquipo"] = new SelectList(listadoEequipo, "id_estados_equipo", "descripcion");

            var listadodeEquipos = (from e in _equiposDbContext.equipos 
                                    join m in _equiposDbContext.marcas on e.marca_id equals m.id_marcas
                                    select new
                                    {
                                        nombre = e.nombre,
                                        descripcion = e.descripcion,
                                        marca_id = e.marca_id,
                                        marca_nombre = m.nombre_marca
                                    }).ToList();
            ViewData["litadoEquipos"] = listadodeEquipos;
            
            return View();
        }

        public IActionResult CrearEquipos(equipos nuevoEquipo)
        {
            if (nuevoEquipo.estado == "false")
            {
                nuevoEquipo.estado = "A";
            }
            else
            {
                nuevoEquipo.estado = "I";
            }
            _equiposDbContext.Add(nuevoEquipo);
            _equiposDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
