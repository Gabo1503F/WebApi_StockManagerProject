namespace WebApi_StockManagerProject.Entidades
{
    public class PedidoHerramienta
    {
        public int HerramientaId { get; set; }
        public int PedidoId { get; set; }
        public int CantidadRetirada { get; set; }
        public Herramienta Herramienta { get; set; }
        public Pedido Pedido { get; set; }
    }
}
