using AutoMapper;
using WebApi_StockManagerProject.DTOs;
using WebApi_StockManagerProject.Entidades;

namespace WebApi_StockManagerProject.Utilidades
{
    public class AutoMapperProfiles: Profile
    {
        /*
         *Esta clase permite "mapear" los datos del objeto de una clase a un objeto
         * DTO (Data Transfer Object) y viceversa.
         */
        public AutoMapperProfiles()
        {
            CreateMap<ProyectoCreacionDTO, Proyecto>();
            CreateMap<Proyecto, ProyectoDTO>();

            CreateMap<HerramientaCreacionDTO, Herramienta>();
            CreateMap<Herramienta, HerramientaDTO>();

            CreateMap<MaterialCreacionDTO, Material>();
            CreateMap<Material, MaterialDTO>();

            CreateMap<PedidoCreacionDTO, Pedido>()
                .ForMember(pedido => pedido.PedidoHerramientas, opciones => opciones.MapFrom(MapPedidoHerramientas))
                .ForMember(pedido => pedido.PedidoMateriales, opciones => opciones.MapFrom(MapPedidoMateriales));
            /*
             * caso especifico: Al realizar el mapeo ForMember() permite que un miembro del objeto de destino 
             * reciba un valor mas especifico.
             */

            CreateMap<Pedido, PedidoDTO>()
                .ForMember(pedidoDTO => pedidoDTO.Herramientas, opciones => opciones.MapFrom(MapPedidoDTOHerramienta))
                .ForMember(pedidoDTO => pedidoDTO.Materiales, opciones => opciones.MapFrom(MapPedidoDTOMateriales));
        }

        /*
         *Devuelve una lista de PedidoHerramienta para el mapeo desde una clase DTO a la entidad Pedido
         */
        private List<PedidoHerramienta> MapPedidoHerramientas(PedidoCreacionDTO pedidoCreacionDTO, Pedido pedido)
        {
            var resultado = new List<PedidoHerramienta>();

            if (pedidoCreacionDTO.herramientaCreacionPedidos == null) { return resultado; }

            foreach (HerramientaCreacionPedido hrDTO in pedidoCreacionDTO.herramientaCreacionPedidos)
            {
                resultado.Add(new PedidoHerramienta() 
                { 
                    HerramientaId = hrDTO.Id,  
                    CantidadRetirada = hrDTO.CantidadRetirada
                });
            }

            return resultado;
        }

        /*
         * Toma los datos de PedidoHerramienta y devuelve una lista de PedidoConHerramientasDTO
         */
        private List<HerramientasDelPedidoDTO> MapPedidoDTOHerramienta (Pedido pedido, PedidoDTO pedidoDTO)
        {
            var resultado = new List<HerramientasDelPedidoDTO>();

            if (pedido.PedidoHerramientas == null) { return resultado; }

            foreach (var ph in pedido.PedidoHerramientas)
            {
                resultado.Add(new HerramientasDelPedidoDTO()
                {
                    Id = ph.HerramientaId,
                    Nombre = ph.Herramienta.Nombre,
                    Marca = ph.Herramienta.Marca,
                    Costo = ph.Herramienta.Costo,
                    CantidadRetirada = ph.CantidadRetirada
                });
            }

            return resultado;
        }

        /*
         *Devuelve una lista de PedidoMaterial para el mapeo desde una clase DTO a la entidad Pedido
         */

        private List<PedidoMaterial> MapPedidoMateriales(PedidoCreacionDTO pedidoCreacionDTO, Pedido pedido)
        {
            var resultado = new List<PedidoMaterial>();

            if (pedidoCreacionDTO.materialCreacionPedidos == null) { return resultado; }

            foreach (MaterialCreacionPedido mcP in pedidoCreacionDTO.materialCreacionPedidos)
            {
                resultado.Add(new PedidoMaterial()
                {
                    MaterialId = mcP.Id,
                    CantidadRetirada = mcP.CantidadRetirada
                });
            }

            return resultado;
        }

        /*
         * Toma los datos de PedidoMaterial y devuelve una lista de PedidoConMaterialesDTO
         */
        private List<MaterialesDelPedidoDTO> MapPedidoDTOMateriales(Pedido pedido, PedidoDTO pedidoDTO)
        {
            var resultado = new List<MaterialesDelPedidoDTO>();

            if (pedido.PedidoMateriales == null) { return resultado; }

            foreach (var pm in pedido.PedidoMateriales)
            {
                resultado.Add(new MaterialesDelPedidoDTO()
                {
                    Id = pm.MaterialId,
                    Nombre = pm.Material.Nombre,
                    Marca = pm.Material.Marca,
                    Costo = pm.Material.Costo,
                    CantidadRetirada = pm.CantidadRetirada
                });
            }

            return resultado;
        }
    }

}
