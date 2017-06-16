using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charly_Pedidos.Models
{
    public class ClientePedido
    {
        public int PedidoId { get; set; }
        public string Cliente { get; set; }
        public string Descripcion { get; set; }
        public string Total { get; set; }
    }
}
