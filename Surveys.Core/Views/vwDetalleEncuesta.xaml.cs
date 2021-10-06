using Surveys.Core.Clases;
using Surveys.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Surveys.Core.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class vwDetalleEncuesta : ContentPage
    {
        public vwDetalleEncuesta()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<DetalleEncuestaVM, string[]>(this, Mensajes.EquipoSeleccionado,
                async (sender, args) =>
                {
                    var equipoFavorito = await DisplayActionSheet(Literals.TituloEquipoFavorito, null, null, args);
                    if (!string.IsNullOrEmpty(equipoFavorito))
                    {
                        MessagingCenter.Send((ContentPage)this, Mensajes.EquipoSeleccionado, equipoFavorito);
                    }
                }
                );
            MessagingCenter.Subscribe<DetalleEncuestaVM, Encuesta>(this, Mensajes.NuevaEncuestaCompleta,
                async (sender, args) =>
                {
                    await Navigation.PopAsync();
                });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<DetalleEncuestaVM, string[]>(this, Mensajes.EquipoSeleccionado);
            MessagingCenter.Unsubscribe<DetalleEncuestaVM, Encuesta>(this, Mensajes.NuevaEncuestaCompleta);
        }
    }
}