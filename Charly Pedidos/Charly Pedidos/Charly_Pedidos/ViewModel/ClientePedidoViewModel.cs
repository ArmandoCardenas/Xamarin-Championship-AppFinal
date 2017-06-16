using Charly_Pedidos.Clases.BD;
using Charly_Pedidos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Charly_Pedidos.ViewModel
{
    public class ClientePedidoViewModel : INotifyPropertyChanged
    {        
        #region Propiedades
private ObservableCollection<ClientePedido> clientepedido;

        public ObservableCollection<ClientePedido> clientePedido
        {
            get { return clientepedido; }
            set {
                clientepedido = value;
                OnPropertyChanged("clientePedido");
            }
        }
        #endregion
        #region Metodos
 public ClientePedidoViewModel()
        {
            clientePedido = new ObservableCollection<ClientePedido>();
            DbManager dbManager = new DbManager();
            foreach (var item in dbManager.GetClientePedidos())
            {
                clientePedido.Add(item);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion
       
    }
}
