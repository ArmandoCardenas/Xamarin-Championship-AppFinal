using Charly_Pedidos.Clases.BD;
using Charly_Pedidos.Clases.Tablas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Charly_Pedidos.ViewModel
{
    public class ClienteViewModel : INotifyPropertyChanged
    {
        
        #region Propiedades
private ObservableCollection<Clientes> clientes;

        public ObservableCollection<Clientes> Clientes
        {
            get { return clientes; }
            set
            {
                clientes = value;
                OnPropertyChanged("Clientes");
            }
        }
        #endregion
        #region Metodos
  public ClienteViewModel()
        {
            clientes = new ObservableCollection<Clientes>();
            DbManager dbManager = new DbManager();
            foreach (var item in dbManager.GetClientes())
            {
                clientes.Add(item);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion      
    }
}
