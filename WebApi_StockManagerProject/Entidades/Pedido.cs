namespace WebApi_StockManagerProject.Entidades
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Trabajador { get; set; }
        public int ProyectoId { get; set; }
        public Proyecto Proyecto { get; set; }
        public List<PedidoHerramienta> PedidoHerramientas { get; set; }
        public List<PedidoMaterial> PedidoMateriales { get; set; }
    }
}
 