using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_StockManagerProject.DTOs;
using WebApi_StockManagerProject.Entidades;

namespace WebApi_StockManagerProject.Controllers
{
    [ApiController]
    [Route("api/herramientas")]
    public class HerramientasController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public HerramientasController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /*
         *Obtiene los datos de la tabla Herramienta, los mapea hacia una clase DTO y los retorna
         */
        [HttpGet]
        public async Task<List<HerramientaDTO>> Get()
        {
            var herramientas = await context.Herramientas.ToListAsync();

            return mapper.Map<List<HerramientaDTO>>(herramientas);
        }

        /*
         *Obtiene los datos de la tabla Herramienta cuyos elementos con CantidadOcupada sean
         *distintos de 0, los mapea hacia una clase DTO y los retorna
         */
        [HttpGet("disponibles")]
        public async Task<List<HerramientaDTO>> GetDisponibles()
        {
            var herramientas = await context.Herramientas
                .Where(x => x.CantidadTotal - x.CantidadOcupada != 0)
                .ToListAsync();

            return mapper.Map<List<HerramientaDTO>>(herramientas);
        }

        /*[HttpPost("individual")]
        public async Task<IActionResult> Post(HerramientaCreacionDTO herramientaCreacionDTO)
        {
            var herramienta = mapper.Map<Herramienta>(herramientaCreacionDTO);
            herramienta.CantidadOcupada = 0;

            context.Add(herramienta);
            await context.SaveChangesAsync();
            return Ok();
        }*/

        /*
         *Recibe los datos de una clase DTO, mapea cada resultado a una instancia de la clase 
         *Herramienta y lo guarda en la base de datos 
         */
        [HttpPost]
        public async Task<IActionResult> Post(List<HerramientaCreacionDTO> herramientasCreacionDTOLista)
        {
            foreach (HerramientaCreacionDTO herramientaDto in herramientasCreacionDTOLista)
            {
                var herramienta = mapper.Map<Herramienta>(herramientaDto);
                herramienta.CantidadOcupada = 0;
                context.Add(herramienta);
            }

            await context.SaveChangesAsync();
            return Ok();
        }

        
    }
}
