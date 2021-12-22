namespace WebApi_StockManagerProject.DTOs
{
    public class MaterialCreacionDTO //revisar despues por si funciona con herencia
    {
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public int Costo { get; set; }
        public int CantidadTotal { get; set; }
    }
}
