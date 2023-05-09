using AppGestiónPedidosTienda.DAO;
using AppGestiónPedidosTienda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestiónPedidosTienda.Negocio
{
    public class PedidoService
    {
        private readonly PedidoDAO pedidoDAO;

        public PedidoService()
        {
            pedidoDAO = new PedidoDAO();
        }

        public void AgregarPedido(Pedido ParametroPedido)
        {
            pedidoDAO.AgregarPedido(ParametroPedido);
        }

        public Pedido ObtenerPedido(int IdPedidos)
        {
            return pedidoDAO.PedidoIndividual(IdPedidos);
        }

        public void ActualizarPedido(Pedido ParametrosPedido, int Lector)
        {
            pedidoDAO.ActualizarPedido(ParametrosPedido, Lector);
        }

        public string EliminarPedido(int IdPedidos)
        {
            return pedidoDAO.EliminarPedido(IdPedidos);
        }

        public List<Pedido> ListarPedido()
        {
            return pedidoDAO.ListarPedido();
        }

        public bool AutenticarCliente(string nombreUs, string contraseña)
        {
            Cliente cliente = new Cliente { NombreUs = nombreUs, Contraseña = contraseña };
            return pedidoDAO.Acceso(cliente);
        }

        public async Task<List<Pedido>> ObtenerTodosPedido()
        {
            return await pedidoDAO.ObtenerTodosPedido();
        }

        public List<Pedido> ObtenerTodasLasPedidos()
        {
            return pedidoDAO.GetAllPedido();
        }
    }
}
