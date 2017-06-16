using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Charly_Pedidos.Clases.Reportes;
using Xamarin.Forms;

namespace Charly_Pedidos.Views.Reportes
{
    public partial class ReporteBarrasView : ContentPage
    {
        public BarrasViewModel vm { get; set; }
        public ReporteBarrasView()
        {
            InitializeComponent();
            vm = new BarrasViewModel();
            BindingContext = vm;
        }
    }
}
