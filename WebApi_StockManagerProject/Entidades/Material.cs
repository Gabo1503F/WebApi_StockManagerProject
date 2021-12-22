namespace WebApi_StockManagerProject.Entidades
{
    public class Material
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public int Costo { get; set; }
        public int CantidadTotal { get; set; }
        public List<PedidoMaterial> PedidoMateriales { get; set; }
    }
}
