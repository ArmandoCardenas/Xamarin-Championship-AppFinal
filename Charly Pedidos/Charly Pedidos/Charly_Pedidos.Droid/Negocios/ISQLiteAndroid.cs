using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CharlyApp.Negocios;
using Charly_Pedidos.Clases.BD;
using Xamarin.Forms;
using SQLite;

[assembly: Dependency(typeof(ISQLiteAndroid))]
namespace CharlyApp.Negocios
{
    public class ISQLiteAndroid : ISQLite
    {
        #region ISQLite implementation
        SQLiteConnection ISQLite.GetConnection()
        {
            var fileName = "CharlyDB.db3";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = System.IO.Path.Combine(documentsPath, fileName);

            var conn = new SQLite.SQLiteConnection(path);

            return conn;
        }

        #endregion
    }
}