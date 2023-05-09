using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppGestiónPedidosTienda.Models;

namespace AppGestiónPedidosTienda.ViewModels
{
    // ViewModel para mostrar la lista de productos
    public class ListaProductosVM
    {
        public List<ProductoVM> Productos { get; set; }
    }
}