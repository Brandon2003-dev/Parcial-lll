using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppGestiónPedidosTienda.Models;

namespace AppGestiónPedidosTienda.ViewModels
{
    // ViewModel para crear un nuevo detalle de pedido
    public class NuevoDetallePedidoVM
    {
        public int IdProductos { get; set; }
        public float Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}