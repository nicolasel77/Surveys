using Personas.Clases;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Surveys.Core.Clases
{
    /// <summary>
    /// Se hereda la clase Notificable para poder usar el evento OnPropertyChanged
    /// </summary>
    public class Datos : Notificable
    {
        /// <summary>
        /// Coleccion Observable para los datos
        /// </summary>
        private ObservableCollection<Encuesta> encuestas;

        public Datos()
        {
            Encuestas = new ObservableCollection<Encuesta>();
            
            //Nos subscribimos al "Centro de Mensajes" para poder estar al tanto de las encuestas nuevas que se vayan agregando.
            MessagingCenter.Subscribe<ContentPage, Encuesta>(this, Mensajes.NuevaEncuestaCompleta, (sender, args) => { encuestas.Add(args); });
        }

        public ObservableCollection<Encuesta> Encuestas
        {
            get { return encuestas; }
            set
            {
                if (value == encuestas) { return; }
                encuestas = value;
                OnPropertyChanged();
            }
        }

        private Encuesta encuesta_Seleccionada;

        public Encuesta Encuesta_Seleccionada
        {
            get => encuesta_Seleccionada; set
            {
                if (value == encuesta_Seleccionada) { return; }
                encuesta_Seleccionada = value;
                OnPropertyChanged();
            }
        }

    }
}