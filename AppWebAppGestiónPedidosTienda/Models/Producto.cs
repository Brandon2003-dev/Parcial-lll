using System;
using System.Collections.Generic;

namespace AppWebAppGestiónPedidosTienda.Models;

public partial class Producto
{
    public int IdProductos { get; set; }

    public string? Nombre { get; set; }

    public double? Precio { get; set; }

    public string? Descripción { get; set; }

    public virtual ICollection<DetalleDePedido> DetalleDePedidos { get; set; } = new List<DetalleDePedido>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
