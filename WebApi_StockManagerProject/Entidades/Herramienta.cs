namespace WebApi_StockManagerProject.Entidades
{
    public class Herramienta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public int Costo { get; set; }
        public int CantidadTotal { get; set; }
        public int CantidadOcupada { get; set; }
        public List<PedidoHerramienta> PedidoHerramientas { get; set; } // propiedad de navegacion
    }
}
