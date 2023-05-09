using System;
using System.Collections.Generic;

namespace AppGestiónPedidosTienda.Models;

public partial class Pedido
{
    public int IdPedidos { get; set; }

    public DateTime? FechaDePedidos { get; set; }

    public int IdClientes { get; set; }

    public int IdProductos { get; set; }

    public double? Cantidad { get; set; }

    public decimal? Total { get; set; }

    public virtual ICollection<DetalleDePedido> DetalleDePedidos { get; set; } = new List<DetalleDePedido>();

    public virtual Cliente IdClientesNavigation { get; set; } = null!;

    public virtual Producto IdProductosNavigation { get; set; } = null!;
}
