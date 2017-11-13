using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace CodingDojo3.Converter
{//wird benötigt für den Converter aus XAML --> Dieser Ruft die Methode Convert auf, wenn sich das Binding (Mode) ändert.
    //Folgendes muss in der XAML Zeile des Objekts, welches den Converter einbindet eingetragen werden:
    //Fill="{Binding Mode, Converter={StaticResource con}}

    // in der Window zeile oben muss folgendes eingetragen werden (hier wird auch diese Klasse angeknüpft):
    //<Window.Resources>
    //    <converters:StringToBrushConverter x:Key="con"/>
    //</Window.Resources>
    public class StringToBrushConverter : IValueConverter           
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string temp = (string)value;
            if (temp.Equals("Enabled"))
            {
                return new SolidColorBrush(Colors.Green);
            }
            else
            {
                return new SolidColorBrush(Colors.Red);

            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
