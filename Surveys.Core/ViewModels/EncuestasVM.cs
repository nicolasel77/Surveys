using Personas.Clases;
using Surveys.Core.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Surveys.Core.Clases
{
    /// <summary>
    /// Se hereda la clase Notificable para poder usar el evento OnPropertyChanged
    /// </summary>
    public class EncuestasVM : Notificable
    {
        /// <summary>
        /// Coleccion Observable para los datos
        /// </summary>
        private ObservableCollection<Encuesta> encuestas;
        public ICommand NuevaEncuesta { get; set; }

        public EncuestasVM()
        {
            Encuestas = new ObservableCollection<Encuesta>();

            NuevaEncuesta = new Command(NuevaEncuestaCommmandExecute);
                                    
            MessagingCenter.Subscribe<DetalleEncuestaVM, Encuesta>(this, Mensajes.NuevaEncuestaCompleta, (sender, args) => { encuestas.Add(args); });
        }

        private void NuevaEncuestaCommmandExecute()
        {
            MessagingCenter.Send(this, Mensajes.NuevaEncuesta);
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