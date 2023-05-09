using System;
using System.Collections.Generic;

namespace AppGestiónPedidosTienda.Models;

public partial class DetalleDePedido
{
    public int IdDetalleDePedidos { get; set; }

    public int IdPedidos { get; set; }

    public int IdProductos { get; set; }

    public int? Cantidad { get; set; }

    public virtual Pedido IdPedidosNavigation { get; set; } = null!;

    public virtual Producto IdProductosNavigation { get; set; } = null!;
}
