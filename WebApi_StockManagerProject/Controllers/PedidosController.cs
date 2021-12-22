using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_StockManagerProject.DTOs;
using WebApi_StockManagerProject.Entidades;

namespace WebApi_StockManagerProject.Controllers
{
    [ApiController]
    [Route("api/proyectos/{idP:int}/pedidos")]
    public class PedidosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PedidosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /*
         *Recupera los datos de la tabla pedidos en la base de datos, los mapea a una clase DTO y los retorna 
         */
        [HttpGet]
        public async Task<List<PedidoDTO>> GetConId(int idP)
        {
            var pedido = await context.Pedidos
                .Where(x => x.ProyectoId == idP)
                .ToListAsync();
            return mapper.Map<List<PedidoDTO>>(pedido);
        }

        /*
         *Recupera los datos de un pedido de la tabla pedidos en la base de datos segun su id
         * y el id del proyecto al que pertenece, los mapea a una clase DTO y los retorna 
         */
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PedidoDTO>> GetPedido(int id, int idP)
        {
            var pedido = await context.Pedidos
                .Include(pedidoDB => pedidoDB.PedidoHerramientas)
                .ThenInclude(ph => ph.Herramienta)
                .Include(pedidoDB => pedidoDB.PedidoMateriales)
                .ThenInclude(pm => pm.Material)
                .FirstOrDefaultAsync(x => x.Id == id && x.ProyectoId == idP);

            return mapper.Map<PedidoDTO>(pedido);
        }

        /*
         * Recibe los datos de una clase DTO, los mapea hacia la entidad Pedido y define algunas de sus propiedades.
         * tambien valida que el pedido contenga al menos datos de herramientas o materiales y si existe el
         * proyecto al cual se le quiere asociar.
         * Tambien actualiza CantidadTotal y CantidadOcupada en la tabla herramientas y CantidadTotal en materials
         * Los resultados son guardados en la base de datos
         */
        [HttpPost]
        public async Task<ActionResult> Post (int idP, PedidoCreacionDTO pedidoCreacionDTO)
        {
            {
                if (pedidoCreacionDTO.herramientaCreacionPedidos == null && pedidoCreacionDTO.materialCreacionPedidos == null)
                {
                    return BadRequest("Tanto herramientas como materiales vienen vacios");
                }

                var existeProyecto = await context.Proyectos.AnyAsync(proyectoBD => proyectoBD.Id == idP);
                if (!existeProyecto)
                {
                    return NotFound($"No existe el proyecto con id: {idP}");
                }
            }

            var pedido = mapper.Map<Pedido>(pedidoCreacionDTO);
            pedido.Fecha = DateTime.Now;
            pedido.ProyectoId = idP;

            if (pedidoCreacionDTO.herramientaCreacionPedidos != null)
            {
                foreach (HerramientaCreacionPedido herramienta in pedidoCreacionDTO.herramientaCreacionPedidos)
                {
                    var herramientaBD = await context.Herramientas.FirstOrDefaultAsync(x => x.Id == herramienta.Id);
                    herramientaBD.CantidadTotal -= herramienta.CantidadRetirada;
                    herramientaBD.CantidadOcupada += herramienta.CantidadRetirada;
                    context.Update(herramientaBD);
                }
            }

            if (pedidoCreacionDTO.materialCreacionPedidos != null)
            {
                foreach (MaterialCreacionPedido material in pedidoCreacionDTO.materialCreacionPedidos)
                {
                    var materialBD = await context.Materials.FirstOrDefaultAsync(x => x.Id == material.Id);
                    materialBD.CantidadTotal -= material.CantidadRetirada;
                    context.Update(materialBD);
                }
            }

            context.Add(pedido);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
