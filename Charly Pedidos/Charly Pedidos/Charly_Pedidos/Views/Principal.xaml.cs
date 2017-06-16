using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Charly_Pedidos.MenuItems;
using Charly_Pedidos.Views.Reportes;
using Xamarin.Forms;
using Rg.Plugins.Popup;
using Rg.Plugins.Popup.Extensions;

namespace Charly_Pedidos.Views
{
    public partial class Principal : MasterDetailPage
    {
        public List<MasterPageItem> MenuList { get; set; }

        public Principal()
        {

            InitializeComponent();

            MenuList = new List<MasterPageItem>();

            // Creating our pages for menu navigation
            // Here you can define title for item, 
            // icon on the left side, and page that you want to open after selection
            var page1 = new MasterPageItem() { Title = "Inicio", Icon = "home.png", TargetType = typeof(Inicio) };
            var page2 = new MasterPageItem() { Title = "Reportes", Icon = "reportes.png", TargetType = typeof(ReporteBarrasView) };
            var page3 = new MasterPageItem() { Title = "Clientes", Icon = "clientes.png", TargetType = typeof(Clientes) };
            var page4 = new MasterPageItem() { Title = "Pedidos", Icon = "pedidos.png", TargetType = typeof(ClientePedido) };
            //var page5 = new MasterPageItem() { Title = "Item 5", Icon = "itemIcon5.png", TargetType = typeof(TestPage2) };
            //var page6 = new MasterPageItem() { Title = "Item 6", Icon = "itemIcon6.png", TargetType = typeof(TestPage3) };
            //var page7 = new MasterPageItem() { Title = "Item 7", Icon = "itemIcon7.png", TargetType = typeof(TestPage1) };
            //var page8 = new MasterPageItem() { Title = "Item 8", Icon = "itemIcon8.png", TargetType = typeof(TestPage2) };
            //var page9 = new MasterPageItem() { Title = "Item 9", Icon = "itemIcon9.png", TargetType = typeof(TestPage3) };

            // Adding menu items to menuList
            MenuList.Add(page1);
            MenuList.Add(page2);
            MenuList.Add(page3);
            MenuList.Add(page4);
            //menuList.Add(page5);
            //menuList.Add(page6);
            //menuList.Add(page7);
            //menuList.Add(page8);
            //menuList.Add(page9);

            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = MenuList;
            navigationDrawerList.Footer = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.Center,
                Padding = new Thickness(0, 15, 0, 0),
                Children =
                {
                    new Label() { Text = "¡¡En la camara de fresco!!"}
                }
            };

            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage(new Inicio());
        }

        // Event for Menu Item selection, here we are going to handle navigation based
        // on user selection in menu ListView
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;

        }
    }
}
