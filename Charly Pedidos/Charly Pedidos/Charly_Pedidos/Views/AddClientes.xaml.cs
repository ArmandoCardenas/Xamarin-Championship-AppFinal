using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Charly_Pedidos.Clases.BD;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Charly_Pedidos.Views
{
    public partial class AddClientes : PopupPage
    {
        DbManager database = new DbManager();
        public AddClientes()
        {
            InitializeComponent();
            btnAddCliente.Clicked += BtnAddCliente_Clicked;
        }

        private void BtnAddCliente_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                Clases.Tablas.Clientes cliente = new Clases.Tablas.Clientes { Nombre = txtNombre.Text };
                database.AddCliente(cliente);
            }
            else
            {
                DisplayAlert("¡Quiubo!", "Échame la mano, y escribe el nombre o apodo", "OK");
            }
        }

        private void OnClose(object sender, EventArgs e)
        {
            PopupNavigation.PopAsync();
        }
    }
}
