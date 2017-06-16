using Charly_Pedidos.Clases.BD;
using Charly_Pedidos.Clases.Tablas;
using Charly_Pedidos.ViewModel;
using Charly_Pedidos.Models;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Charly_Pedidos.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientePedido : ContentPage
    {
        DbManager database = new DbManager();
        public ClientePedido()
        {
            InitializeComponent();
            BindingContext = new ClientePedidoViewModel();

            var toolbarItem = new ToolbarItem
            {
                Name = "Agregar",
                Command = new Command(() => Navigation.PushAsync(new Inicio()))
            };
            ToolbarItems.Add(toolbarItem);
            listaClientesPedidos.ItemSelected += LstPedidos_ItemSelected;
            listaClientesPedidos.RefreshCommand = new Command(ActualizarPedidosClientes);
        }

        private void LstPedidos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Models.ClientePedido clientePedido = (Models.ClientePedido)e.SelectedItem;
            var pedido = database.GetPedido(clientePedido.PedidoId);
            Navigation.PushAsync(new Inicio(pedido));
        }

        private void ActualizarPedidosClientes()
        {
            listaClientesPedidos.ItemsSource = database.GetClientePedidos();
            listaClientesPedidos.IsRefreshing = false;
        }
    }
}
