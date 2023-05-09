using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppGestiónPedidosTienda.Models;

namespace AppGestiónPedidosTienda.ViewModels
{
    // ViewModel para mostrar los detalles de un pedido
    public class PedidoVM
    {
        public int IdPedidos { get; set; }
        public DateTime FechaDePedidos { get; set; }
        public ClienteVM Cliente { get; set; }
        public int IdProductos { get; set; }
        public float Cantidad { get; set; }
        public decimal Total { get; set; }
        public List<DetallePedidoVM> DetallesPedido { get; set; }
    }
}
