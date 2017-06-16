using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Charly_Pedidos.Clases.Tablas
{
    public class Pedido
    {
        [PrimaryKey, AutoIncrement]
        public int PedidoId { get; set; }
        public string Cliente { get; set; }
        public string PedidoCompleto { get; set; }
        public bool Pagado { get; set; }
        public double Apunte { get; set; }
        public DateTime Fecha { get; set; }

    }
}
