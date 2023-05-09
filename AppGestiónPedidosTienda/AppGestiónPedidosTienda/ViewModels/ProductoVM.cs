using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppGestiónPedidosTienda.Models;

namespace AppGestiónPedidosTienda.ViewModels
{
    // ViewModel para mostrar los detalles de un producto
    using AppGestiónPedidosTienda.ViewModels;
    public class ProductoVM
    {
        public int IdProductos { get; set; }
        public string Nombre { get; set; }
        public string Descripción { get; set; }
        public decimal Precio { get; set; }
        public List<DetallePedidoVM> DetallesPedido { get; set; }
    }
}
