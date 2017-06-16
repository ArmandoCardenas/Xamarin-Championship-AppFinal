using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Charly_Pedidos.Clases.BD;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace Charly_Pedidos.Clases.Reportes
{
    public class BarrasViewModel
    {
        #region Declaraciones
        private DbManager bdManager;
        private double totalLunes = 0, totalMartes = 0, totalMiercoles = 0, totalJueves = 0, totalViernes = 0, totalSabado = 0, totalDomingo = 0;
        #endregion

        #region Propiedades
        public PlotModel Modelo { get; set; }
        public string Lunes { get; set; }
        public string Martes { get; set; }
        public string Miercoles { get; set; }
        public string Jueves { get; set; }
        public string Viernes { get; set; }
        public string Sabado { get; set; }
        public string Domingo { get; set; }
        #endregion
     
        #region Metodos
        public BarrasViewModel()
        {
            BarSeries serie1 = new BarSeries() { Title = "Total ($) por día", FillColor = OxyColors.LightBlue, StrokeThickness = 1 };
            //Obtener los pedidos
            bdManager = new DbManager();
            DateTime fechaActual = DateTime.Now;
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(fechaActual);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                fechaActual = fechaActual.AddDays(3);
            }
            int numeroSemana = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(fechaActual, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            DateTime fechaInicio = FirstDateOfWeek(fechaActual.Year, numeroSemana, CultureInfo.CurrentCulture);
            DateTime fechaFin = fechaInicio.AddDays(6);
            var pedidos = bdManager.GetPedidos().Where(pedido => pedido.Fecha.Date >= fechaInicio.Date && pedido.Fecha.Date <= fechaFin.Date).ToList();
            foreach (var pedido in pedidos)
            {
                switch (pedido.Fecha.DayOfWeek)
                {
                    case DayOfWeek.Friday:
                        totalViernes += pedido.Apunte;
                        break;
                    case DayOfWeek.Monday:
                        totalLunes += pedido.Apunte;
                        break;
                    case DayOfWeek.Thursday:
                        totalJueves += pedido.Apunte;
                        break;
                    case DayOfWeek.Tuesday:
                        totalMartes += pedido.Apunte;
                        break;
                    case DayOfWeek.Wednesday:
                        totalMiercoles += pedido.Apunte;
                        break;
                    case DayOfWeek.Saturday:
                        totalSabado += pedido.Apunte;
                        break;
                    case DayOfWeek.Sunday:
                        totalDomingo += pedido.Apunte;
                        break;
                }
            }

            serie1.Items.Add(new BarItem { Value = totalDomingo });
            serie1.Items.Add(new BarItem { Value = totalSabado });
            serie1.Items.Add(new BarItem { Value = totalViernes });
            serie1.Items.Add(new BarItem { Value = totalJueves });
            serie1.Items.Add(new BarItem { Value = totalMiercoles });
            serie1.Items.Add(new BarItem { Value = totalMartes });
            serie1.Items.Add(new BarItem { Value = totalLunes });

            var ejeCategorias = new CategoryAxis { Position = CategoryAxisPosition() };
            ejeCategorias.Labels.Add("Domingo");
            ejeCategorias.Labels.Add("Sábado");
            ejeCategorias.Labels.Add("Viernes");
            ejeCategorias.Labels.Add("Jueves");
            ejeCategorias.Labels.Add("Miércoles");
            ejeCategorias.Labels.Add("Martes");
            ejeCategorias.Labels.Add("Lunes");


            Modelo = new PlotModel()
            {
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.BottomCenter,
                LegendOrientation = LegendOrientation.Horizontal,
                Subtitle = "Venta total por día"
            };

            var ejeValores = new LinearAxis { Position = ValueAxisPosition() };
            Modelo.Axes.Add(ejeCategorias);
            Modelo.Axes.Add(ejeValores);

            Modelo.Series.Add(serie1);

            Lunes = "Total del Lunes $" + totalLunes;
            Martes = "Total del Martes $" + totalMartes;
            Miercoles = "Total del Miércoles $" + totalMiercoles;
            Jueves = "Total del Jueves $" + totalJueves;
            Viernes = "Total del Viernes $" + totalViernes;
            Sabado = "Total del Sábado $" + totalSabado;
            Domingo = "Total del Domingo $" + totalDomingo;
        }
        private AxisPosition CategoryAxisPosition()
        {
            if (typeof(BarSeries) == typeof(ColumnSeries))
            {
                return AxisPosition.Bottom;
            }

            return AxisPosition.Left;
        }
        private AxisPosition ValueAxisPosition()
        {
            if (typeof(BarSeries) == typeof(ColumnSeries))
            {
                return AxisPosition.Left;
            }

            return AxisPosition.Bottom;
        }
        private static DateTime FirstDateOfWeek(int year, int weekOfYear, System.Globalization.CultureInfo ci)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = (int)DayOfWeek.Monday - (int)jan1.DayOfWeek;
            DateTime firstWeekDay = jan1.AddDays(daysOffset);
            int firstWeek = ci.Calendar.GetWeekOfYear(jan1, ci.DateTimeFormat.CalendarWeekRule, DayOfWeek.Monday);
            if ((firstWeek <= 1 || firstWeek >= 52) && daysOffset >= -3)
            {
                weekOfYear -= 1;
            }
            return firstWeekDay.AddDays(weekOfYear * 7);
        }
        #endregion
    }
}
