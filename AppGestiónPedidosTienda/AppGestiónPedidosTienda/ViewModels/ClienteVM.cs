using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppGestiónPedidosTienda.Models;

namespace AppGestiónPedidosTienda.ViewModels
{
    // ViewModel para mostrar los detalles de un cliente
    public class ClienteVM
    {
        public int IdClientes { get; set; }
        public string Nombre { get; set; }
        public string Dirección { get; set; }
        public int Telefono { get; set; }
        public string NombreUs { get; set; }
        public string Contraseña { get; set; }
        public List<PedidoVM> Pedidos { get; set; }
    }
}