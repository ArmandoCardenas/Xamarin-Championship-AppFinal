using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Charly_Pedidos.Clases.Tablas;
using SQLite;
using Xamarin.Forms;
using Charly_Pedidos.Models;
using System.Globalization;

namespace Charly_Pedidos.Clases.BD
{
    public class DbManager
    {
        private SQLiteConnection _connection;

        public DbManager()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<Pedido>();
            _connection.CreateTable<Clientes>();
        }

        #region Pedidos
        public IEnumerable<Pedido> GetPedidos()
        {
            return (from t in _connection.Table<Pedido>()
                    orderby t.Fecha descending
                    select t).ToList();
        }

        public Pedido GetPedido(int id)
        {
            return _connection.Table<Pedido>().FirstOrDefault(t => t.PedidoId == id);
        }

        public void DeletePedido(int id)
        {
            _connection.Delete<Pedido>(id);
        }

        public void AddPedido(Pedido pedido)
        {
            _connection.Insert(pedido);
        }

        public void UpdatePedido(Pedido pedido)
        {
            _connection.Update(pedido);
        }
        #endregion

        #region Clientes
        public IEnumerable<Clientes> GetClientes()
        {
            return (from t in _connection.Table<Clientes>()
                    select t).ToList();
        }

        public Clientes GetCliente(int id)
        {
            return _connection.Table<Clientes>().FirstOrDefault(t => t.IdCliente == id);
        }

        public void DeleteCliente(int id)
        {
            _connection.Delete<Clientes>(id);
        }

        public void AddCliente(Clientes cliente)
        {
            _connection.Insert(cliente);
        }
        #endregion

        #region
        public IEnumerable<ClientePedido> GetClientePedidos()
        {
            var clientePedidos = (from t in _connection.Table<Pedido>()
                                  orderby t.Fecha descending
                                  select t).ToList();
            List<ClientePedido> clientesPedidos = new List<ClientePedido>();
            foreach (var item in clientePedidos)
            {
                string fuePagado = (item.Pagado) ? "Pagado" : "Apunte $" + item.Apunte;
                DateTimeFormatInfo usDtfi = new CultureInfo("es-ES").DateTimeFormat;
                ClientePedido clientePedido = new ClientePedido()
                {
                    PedidoId = item.PedidoId,
                    Cliente = item.Cliente + "  " + item.Fecha.ToString("dd/MMMM/yyyy", usDtfi),
                    Descripcion = item.PedidoCompleto,
                    Total = fuePagado.ToUpper()
                };
                clientesPedidos.Add(clientePedido);
            }
            return clientesPedidos;
        }
        #endregion
    }
}
