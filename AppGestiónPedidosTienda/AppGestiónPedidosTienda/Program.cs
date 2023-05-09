// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppGestiónPedidosTienda.Models;
// Inicializar la instancia de DbContext
var dbContext = new AppGestiónPedidosTiendaContext();

bool Continuar = true;
while (Continuar)
{

    // Mostrar un menú para que el usuario seleccione una opción 
    Console.WriteLine("Gestión de Pedidos de Tienda de Alimentos\n");
    Console.WriteLine("1. Registrar un nuevo cliente");
    Console.WriteLine("2. Registrar un nuevo pedido");
    Console.WriteLine("3. Ver todos los clientes");
    Console.WriteLine("4. Ver todos los productos");
    Console.WriteLine("5. Salir\n");

    Console.Write("Seleccione una opción: ");
    int opcion = int.Parse(Console.ReadLine());

    switch (opcion)
    {
        case 1:
            // Registrar un nuevo cliente
            Console.Write("Ingrese el nombre del cliente: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese la dirección del cliente: ");
            string direccion = Console.ReadLine();

            Console.Write("Ingrese el teléfono del cliente: ");
            int telefono = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el nombre de usuario del cliente: ");
            string nombreUs = Console.ReadLine();

            Console.Write("Ingrese la contraseña del cliente: ");
            string contraseña = Console.ReadLine();

            // Crear un objeto Cliente y agregarlo a la base de datos
            var nuevoCliente = new Cliente
            {
                Nombre = nombre,
                Dirección = direccion,
                Telefono = telefono,
                NombreUs = nombreUs,
                Contraseña = contraseña
            };
            dbContext.Clientes.Add(nuevoCliente);
            dbContext.SaveChanges();

            Console.WriteLine("El cliente se ha registrado correctamente");

            break;

        case 2:
            // Mostrar los IDs y nombres de los clientes disponibles
            Console.WriteLine("IDs y nombres de los clientes disponibles:");
            var clientes = dbContext.Clientes.ToList();
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"ID: {cliente.IdClientes}, Nombre: {cliente.Nombre}");
            }

            // Mostrar los productos y precios disponibles
            Console.WriteLine("Productos y precios disponibles:");
            var productos = dbContext.Productos.ToList();
            foreach (var producto in productos)
            {
                Console.WriteLine($"ID: {producto.IdProductos}, Nombre: {producto.Nombre}, Precio: {producto.Precio}");
            }

            Console.Write("Ingrese la fecha del pedido (AÑO-MES-DIA): ");
            string fecha = Console.ReadLine();

            Console.Write("Ingrese el ID del cliente que realizó el pedido: ");
            int idCliente = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el ID del producto que desea comprar: ");
            int idProducto = int.Parse(Console.ReadLine());

            Console.Write("Ingrese la cantidad del producto que desea comprar: ");
            float cantidad = float.Parse(Console.ReadLine());

            // Obtener el cliente seleccionado
            Cliente clienteSeleccionado = dbContext.Clientes.FirstOrDefault(c => c.IdClientes == idCliente);

            // Obtener el producto seleccionado
            Producto productoSeleccionado = dbContext.Productos.FirstOrDefault(p => p.IdProductos == idProducto);

            // Calcular el total del pedido
            decimal total = (decimal)(productoSeleccionado.Precio * cantidad);

            // Crear un objeto Pedido y agregarlo a la base de datos
            var nuevoPedido = new Pedido
            {
                FechaDePedidos = DateTime.Parse(fecha),
                IdClientes = idCliente,
                IdProductos = idProducto,
                Cantidad = cantidad,
                Total = total
            };
            dbContext.Pedidos.Add(nuevoPedido);
            dbContext.SaveChanges();

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("El pedido se ha registrado correctamente");
            Console.WriteLine("------------------------------------------");

            // Mostrar los detalles del pedido registrado
            Console.WriteLine("Detalles del pedido:");
            Console.WriteLine($"ID del pedido: {nuevoPedido.IdPedidos}");
            Console.WriteLine($"ID del cliente: {nuevoPedido.IdClientes}");
            Console.WriteLine($"Nombre del cliente: {clienteSeleccionado.Nombre}");
            Console.WriteLine($"Nombre del producto: {productoSeleccionado.Nombre}");
            Console.WriteLine($"Cantidad del producto: {nuevoPedido.Cantidad}");
            Console.WriteLine($"Total a pagar: {nuevoPedido.Total}");
            Console.WriteLine("------------------------------------------");


            // Mostrar los clientes que han realizado pedidos
            Console.WriteLine("Clientes que han realizado pedidos:");
            var idsClientesPedidos = dbContext.Pedidos.Select(p => p.IdClientes).Distinct().ToList();
            foreach (int id in idsClientesPedidos)
            {
                Cliente cliente = dbContext.Clientes.FirstOrDefault(c => c.IdClientes == id);
                Console.WriteLine($"Id: {cliente.IdClientes}, Nombre: {cliente.Nombre}");
            }
            break;



        case 3:
            // Ver todos los clientes
            var listaClientes = dbContext.Clientes.ToList();
            foreach (var cliente in listaClientes)
            {
                Console.WriteLine($"ID: {cliente.IdClientes}, Nombre: {cliente.Nombre}, Dirección: {cliente.Dirección}, Teléfono: {cliente.Telefono}, Usuario: {cliente.NombreUs}, Contraseña: {cliente.Contraseña}");
            }
            break;


        case 4:
            // Ver todos los productos
            var listaproductos = dbContext.Productos.ToList();
            foreach (var producto in listaproductos)
            {
                Console.WriteLine($"ID: {producto.IdProductos}, Nombre: {producto.Nombre}, Descripción: {producto.Descripción}, Precio: {producto.Precio}");
            }
            break;

        case 5:
            // Salir
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine("Opción inválida, por favor seleccione una opción válida");
            break;
    }

}

Console.WriteLine("Desea continuar ?");
var cont = Console.ReadLine();
if (cont.Equals("N"))
{
    Continuar = false;
}

// Cerrar la conexión con la base de datos
dbContext.Dispose();
