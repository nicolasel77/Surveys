using Surveys.Core.Clases;
using System;

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
            //MessagingCenter.Subscribe<ContentPage, Encuesta>(this, Mensajes.NuevaEncuestaCompleta, (sender, args) =>
            //{
            //    //Lista_Encuestas.re
            //    //{
            //    //    Text = args.ToString()
            //    //});
            //});
        }

        private async void AddSurveyButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new vwDetalleEncuesta());
        }
    }
}