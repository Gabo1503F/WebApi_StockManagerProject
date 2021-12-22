namespace WebApi_StockManagerProject.DTOs
{
    public class PedidoCreacionDTO
    {
        public string Trabajador { get; set; }
        public List<HerramientaCreacionPedido> herramientaCreacionPedidos { get; set; }
        public List<MaterialCreacionPedido> materialCreacionPedidos { get; set; }
    }
}
