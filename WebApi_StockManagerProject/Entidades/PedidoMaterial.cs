namespace WebApi_StockManagerProject.Entidades
{
    public class PedidoMaterial
    {
        public int MaterialId { get; set; }
        public int PedidoId { get; set; }
        public int CantidadRetirada { get; set; }
        public Material Material { get; set; }
        public Pedido Pedido { get; set; }
    }
}
