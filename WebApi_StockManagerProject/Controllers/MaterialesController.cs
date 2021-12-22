using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_StockManagerProject.DTOs;
using WebApi_StockManagerProject.Entidades;

namespace WebApi_StockManagerProject.Controllers
{
    [ApiController]
    [Route("api/materiales")]
    public class MaterialesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public MaterialesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /*
         *Obtiene los datos de la tabla Materials, los mapea hacia una clase DTO y los retorna
         */
        [HttpGet]
        public async Task<List<MaterialDTO>> Get()
        {
            var Materiales = await context.Materials.ToListAsync();

            return mapper.Map<List<MaterialDTO>>(Materiales);
        }

        /*
         *Recibe los datos de una clase DTO, mapea cada resultado a una instancia de la clase 
         *Material y lo guarda en la base de datos 
         */
        [HttpPost]
        public async Task<IActionResult> Post(List<MaterialCreacionDTO> materialCreacionDTO)
        {
            foreach (MaterialCreacionDTO materialDto in materialCreacionDTO)
            {
                var material = mapper.Map<Material>(materialDto);
                context.Add(material);
            }
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
