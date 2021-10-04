using Surveys.Core.Clases;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Surveys.Core.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class vwDetalleEncuesta : ContentPage
    {
        private readonly string[] equipos =
        {
            "Boca Juniors",
            "Riber Plate",
            "San Lorenzo",
            "Ferrocarril Oeste",
            "Banfield",
            "Racing"
        };


        public vwDetalleEncuesta()
        {
            InitializeComponent();
        }

        private async void EquipoButton_Clicked(object sender, EventArgs e)
        {
            string equipoFavorito = await DisplayActionSheet(Literals.TituloEquipoFavorito, null, null, equipos);

            if (!string.IsNullOrWhiteSpace(equipoFavorito))
            {
                lblEquipo.Text = equipoFavorito;
            }
        }

        private async void AceptarButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(lblEquipo.Text))
            {
                return;
            }
            Encuesta nEncuesta = new Encuesta()
            {
                Nombre = txtNombre.Text,
                Fecha_Nacimiento = dtFecha.Date,
                Equipo_Favorito = lblEquipo.Text
            };
            MessagingCenter.Send((ContentPage)this, Mensajes.NuevaEncuestaCompleta, nEncuesta);
            await Navigation.PopAsync();
        }
    }
}