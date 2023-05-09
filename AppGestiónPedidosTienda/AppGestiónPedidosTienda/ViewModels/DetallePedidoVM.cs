using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppGestiónPedidosTienda.Models;

namespace AppGestiónPedidosTienda.ViewModels
{
    // ViewModel para mostrar los detalles de un detalle de pedido
    public class DetallePedidoVM
    {
        public int IdDetallesPedido { get; set; }
        public float Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public ProductoVM Producto { get; set; }
        public PedidoVM Pedido { get; set; }
    }
}