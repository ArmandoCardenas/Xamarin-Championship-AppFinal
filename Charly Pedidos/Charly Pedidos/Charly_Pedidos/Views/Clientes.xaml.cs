using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Charly_Pedidos.Clases.BD;
using Charly_Pedidos.Views.Popups_informativos;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;
using Charly_Pedidos.ViewModel;

namespace Charly_Pedidos.Views
{
    public partial class Clientes : ContentPage
    {
        #region Declaraciones
        DbManager _database = new DbManager();
        #endregion

        #region Metodos
        public Clientes()
        {
            InitializeComponent();
            BindingContext = new ClienteViewModel();
            listaClientes.RefreshCommand = new Command(ActualizarClientes);

            var toolbarItem = new ToolbarItem
            {
                Name = "Agregar",
                Command = new Command(() => Navigation.PushPopupAsync(new AddClientes()))
            };

            ToolbarItems.Add(toolbarItem);
        }
        private void ActualizarClientes()
        {
            listaClientes.ItemsSource = _database.GetClientes();
            listaClientes.IsRefreshing = false;
        }
        #endregion        
    }
}
