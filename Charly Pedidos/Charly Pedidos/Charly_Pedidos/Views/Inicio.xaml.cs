using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Charly_Pedidos.Clases.BD;
using Charly_Pedidos.Clases.Tablas;
using Charly_Pedidos.Views.Popups_informativos;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace Charly_Pedidos.Views
{
    public partial class Inicio : ContentPage
    {
        DbManager _database = new DbManager();
        bool esActualizacion=true;
        int pedidoId = 0;
        #region Métodos
        public Inicio(Pedido pedido)
        {
            InitializeComponent();
           
            this.Title = "Resumen";
            lblTitulo.Text = "Pedido de " + pedido.Cliente;
            txtApunte.Text = pedido.Apunte.ToString();
            txtPedido.Text = pedido.PedidoCompleto;
            Switch.IsToggled = pedido.Pagado;
            lstClientes.Items.Add(pedido.Cliente);
            lstClientes.SelectedIndex = 0;
            pedidoId = pedido.PedidoId;
            lstClientes.IsEnabled = false;

            var toolbarItem = new ToolbarItem
            {
                Icon = "save.png",
                Command = new Command(GuardarPedido)
            };
            ToolbarItems.Add(toolbarItem);
            if (pedido.Pagado)
            {
                txtApunte.IsEnabled = false;
                txtApunte.Text = "$" + pedido.Apunte;
                txtPedido.IsEnabled = false;
                lstClientes.IsEnabled = false;
                Switch.IsEnabled = false;
                esActualizacion = false;
                pedidoId = 0;
                ToolbarItems.Clear();
            }
        }

        public Inicio()
        {
            InitializeComponent();
            esActualizacion = false;
            foreach (var item in _database.GetClientes())
            {
                lstClientes.Items.Add(item.Nombre);
            }

            var toolbarItem = new ToolbarItem
            {
                Icon = "save.png",
                Command = new Command(GuardarPedido)
            };
            ToolbarItems.Add(toolbarItem);
        }

        private void GuardarPedido()
        {            
            if (lstClientes.SelectedIndex==-1 && string.IsNullOrWhiteSpace(lstClientes.Title))
            {
                DisplayAlert("¡Épale!", "No seleccionaste cliente :(", "OK");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPedido.Text))
            {
                DisplayAlert("¡Épale!", "Ni siquiera has escrito el pedido vato", "OK");
                return;
            }
            if (Switch.IsToggled && string.IsNullOrWhiteSpace(txtApunte.Text))
            {
                DisplayAlert("¡Épale!", "No pusiste cuanto te liquidaron del chole pedido", "OK");
                return;
            }
            if (!Switch.IsToggled && string.IsNullOrWhiteSpace(txtApunte.Text))
            {
                DisplayAlert("¡Épale!", "O te dieron apunte o te pagaron todo :p", "OK");
                return;
            }
            if (esActualizacion)
            {
                Pedido pedidoUpdate;
                pedidoUpdate = _database.GetPedido(pedidoId);
                pedidoUpdate.Apunte = (txtApunte.Text == null) ? 0 : Convert.ToDouble(txtApunte.Text);
                pedidoUpdate.Pagado = Switch.IsToggled;
                pedidoUpdate.PedidoCompleto = txtPedido.Text;
                _database.UpdatePedido(pedidoUpdate);
                DisplayAlert("Aviso", "¡Se actualizó el pedido!", "OK");
            }
            else
            {
                _database.AddPedido(new Pedido
                {
                    Cliente = lstClientes.Items.ElementAt(lstClientes.SelectedIndex),
                    PedidoCompleto = txtPedido.Text,
                    Apunte = (txtApunte.Text == null) ? 0 : Convert.ToDouble(txtApunte.Text),
                    Fecha = DateTime.Now,
                    Pagado = Switch.IsToggled
                });
                DisplayAlert("Registro éxitoso", "¡Un pedido más para Chole!", "OK");
LimpiarControles();
            }            
        }

        private void LimpiarControles()
        {
            txtApunte.Text = "$0.0";
            txtPedido.Text = "";
            Switch.IsToggled = false;
            lstClientes.SelectedIndex=-1;
        }

        #endregion
    }
}
