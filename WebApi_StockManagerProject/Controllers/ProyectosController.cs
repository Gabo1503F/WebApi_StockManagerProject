using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_StockManagerProject.DTOs;
using WebApi_StockManagerProject.Entidades;

namespace WebApi_StockManagerProject.Controllers
{
    [ApiController]
    [Route("api/proyectos")]
    public class ProyectosController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProyectosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /*
         * Devuelve una lista de los procesos existentes.
         */
        [HttpGet]
        public async Task<List<ProyectoDTO>> Get()
        {
            var proyectos = await context.Proyectos.ToListAsync();
            return mapper.Map<List<ProyectoDTO>>(proyectos);
        }

        /*
         *Recibe un objeto DTO coyos datos son mapeados a un objeto Entidad y se ingresa
         *a la base de datos.
         */
        [HttpPost]
        public async Task<ActionResult> Post(ProyectoCreacionDTO proyectoCreacionDTO)
        {
            var proyecto = mapper.Map<Proyecto>(proyectoCreacionDTO);
            proyecto.Fecha = DateTime.Now;

            context.Add(proyecto);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
