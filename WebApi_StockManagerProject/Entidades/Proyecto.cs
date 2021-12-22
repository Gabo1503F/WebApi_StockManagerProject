namespace WebApi_StockManagerProject.Entidades
{
    public class Proyecto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string JefeProyecto { get; set; }
        public DateTime Fecha { get; set; }
        public List<Pedido> Pedido { get; set; }
    }
}
