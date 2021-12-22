using WebApi_StockManagerProject.Entidades;

namespace WebApi_StockManagerProject.DTOs
{
    public class PedidoDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Trabajador { get; set; }
        public List<HerramientasDelPedidoDTO> Herramientas { get; set; }
        public List<MaterialesDelPedidoDTO> Materiales { get; set; }
    }
}
