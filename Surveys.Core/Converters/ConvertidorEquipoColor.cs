using System;
using System.Globalization;
using Xamarin.Forms;

namespace Surveys.Core.Clases
{
    public class ConvertidorEquipoColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) { return null; }
            var equipo = (string)value;
            var color = Color.Transparent;

            switch (equipo)
            {
                case "Boca Juniors":
                    color = Color.Blue;
                    break;
                case "Riber Plate":
                    color = Color.Red;
                    break;
                case "Ferrocarril Oeste":
                case "Banfield":
                    color = Color.Green;
                    break;
                case "Racing":
                    color = Color.LightSkyBlue;
                    break;
                case "San Lorenzo":
                    color = Color.BlueViolet;
                    break;
            }

            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}