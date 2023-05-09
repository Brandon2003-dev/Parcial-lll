using AppGestiónPedidosTienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AppGestiónPedidosTienda.DAO
{
    public class PedidoDAO
    {
        public void AgregarPedido(Pedido ParametroPedido)
        {
            using (AppGestiónPedidosTiendaContext db = new AppGestiónPedidosTiendaContext())
            {
                db.Add(ParametroPedido);
                db.SaveChanges();
            }
        }

        public Pedido PedidoIndividual(int IdPedidos)
        {
            using (AppGestiónPedidosTiendaContext bd = new AppGestiónPedidosTiendaContext())
            {
                return bd.Pedidos.FirstOrDefault(x => x.IdPedidos == IdPedidos) ?? throw new Exception("No se encontró el pedido especificado.");

            }
        }

        public void ActualizarPedido(Pedido ParametrosPedido, int Lector)
        {
            using (AppGestiónPedidosTiendaContext db = new AppGestiónPedidosTiendaContext())
            {
                var buscar = PedidoIndividual(ParametrosPedido.IdPedidos);
                if (buscar == null)
                {
                    Console.WriteLine("El pedido es inexistente");
                }
                else
                {
                    if (Lector == 1)
                    {
                        buscar.IdPedidos = ParametrosPedido.IdPedidos;
                    }
                    else
                    {
                        buscar.IdClientes = ParametrosPedido.IdClientes;
                    }
                    db.Update(buscar);
                    db.SaveChanges();
                }
            }
        }

        public string EliminarPedido(int IdPedidos)
        {
            using (AppGestiónPedidosTiendaContext db = new AppGestiónPedidosTiendaContext())
            {
                var buscar = PedidoIndividual(IdPedidos);
                if (buscar == null)
                {
                    return "El pedido es inexistente";
                }
                else
                {
                    db.Pedidos.Remove(buscar);
                    db.SaveChanges();
                    return "El pedido fue eliminada con éxito";
                }
            }
        }

        public List<Pedido> ListarPedido()
        {
            using (AppGestiónPedidosTiendaContext db = new AppGestiónPedidosTiendaContext())
            {
                return db.Pedidos.ToList();
            }
        }

        public bool Acceso(Cliente cliente)
        {
            using (AppGestiónPedidosTiendaContext db = new AppGestiónPedidosTiendaContext())
            {
                return db.Clientes.Any(x => x.NombreUs == cliente.NombreUs && x.Contraseña == cliente.Contraseña);
            }
        }

        public async Task<List<Pedido>> ObtenerTodosPedido()
        {
            using (AppGestiónPedidosTiendaContext db = new AppGestiónPedidosTiendaContext())
            {
                return await db.Pedidos.ToListAsync();
            }
        }

        public List<Pedido> GetAllPedido()
        {
            using (AppGestiónPedidosTiendaContext db = new AppGestiónPedidosTiendaContext())
            {
                return db.Pedidos.ToList();
            }
        }
    }
}