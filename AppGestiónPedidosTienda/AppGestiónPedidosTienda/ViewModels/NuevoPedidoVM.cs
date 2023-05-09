using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppGestiónPedidosTienda.Models;

namespace AppGestiónPedidosTienda.ViewModels
{
    // ViewModel para crear un nuevo pedido
    public class NuevoPedidoVM
    {
        public DateTime FechaDePedidos { get; set; }
        public int IdClientes { get; set; }
        public int IdProductos { get; set; }
        public float Cantidad { get; set; }
        public decimal Total { get; set; }
        public List<NuevoDetallePedidoVM> DetallesPedido { get; set; }
    }
}