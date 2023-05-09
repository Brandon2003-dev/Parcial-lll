using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppGestiónPedidosTienda.Models;

namespace AppGestiónPedidosTienda.ViewModels
{
    // ViewModel para mostrar la lista de clientes
    public class ListaClientesVM
    {
        public List<ClienteVM> Clientes { get; set; }
    }
}