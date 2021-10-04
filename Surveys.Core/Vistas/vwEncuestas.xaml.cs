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
        }

        private async void AddSurveyButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new vwDetalleEncuesta());
        }
    }
}