using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppGestiónPedidosTienda.Models;

namespace AppGestiónPedidosTienda.ViewModels
{
    // ViewModel para crear un nuevo cliente
    public class NuevoClienteVM
    {
        public string Nombre { get; set; }
        public string Dirección { get; set; }
        public int Telefono { get; set; }
        public string NombreUs { get; set; }
        public string Contraseña { get; set; }
    }
}