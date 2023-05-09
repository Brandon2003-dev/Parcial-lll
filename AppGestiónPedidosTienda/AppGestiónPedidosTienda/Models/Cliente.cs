using System;
using System.Collections.Generic;

namespace AppGestiónPedidosTienda.Models;

public partial class Cliente
{
    public int IdClientes { get; set; }

    public string? Nombre { get; set; }

    public string? Dirección { get; set; }

    public int Telefono { get; set; }

    public string NombreUs { get; set; } = null!;

    public string? Contraseña { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
