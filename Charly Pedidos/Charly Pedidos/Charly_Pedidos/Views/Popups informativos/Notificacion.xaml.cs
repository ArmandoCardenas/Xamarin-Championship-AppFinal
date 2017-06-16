using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Charly_Pedidos.Views.Popups_informativos
{
    public partial class Notificacion : PopupPage
    {
        public Notificacion(string encabezado, string mensaje)
        {
            InitializeComponent();
            lblEncabezado.Text = encabezado;
            lblMensaje.Text = mensaje;
        }
        private void OnClose(object sender, EventArgs e)
        {
            PopupNavigation.PopAsync();
        }
    }
}
