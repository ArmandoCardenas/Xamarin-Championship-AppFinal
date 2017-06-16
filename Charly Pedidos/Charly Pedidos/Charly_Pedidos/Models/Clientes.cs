using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Charly_Pedidos.Clases.Tablas
{
    public class Clientes
    {
        [PrimaryKey, AutoIncrement]
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
    }
}
