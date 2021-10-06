using Surveys.Core.Clases;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Surveys.Core.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class vwEncuestas : ContentPage
    {
        public vwEncuestas()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<EncuestasVM>(this, Mensajes.NuevaEncuesta, async (sender) =>
            {
                await Navigation.PushAsync(new vwDetalleEncuesta());
            });

            
        }


    }
}