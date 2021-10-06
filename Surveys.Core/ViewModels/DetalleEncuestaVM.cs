using Personas.Clases;
using Surveys.Core.Clases;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Surveys.Core.ViewModels
{
    public class DetalleEncuestaVM : Notificable
    {
        private string nombre;
        private DateTime fecha_Nacimiento;
        private string equipo_Favorito;
        private ObservableCollection<string> equipos;
        public DetalleEncuestaVM()
        {
            Equipos = new ObservableCollection<string>(new[]
                {
                    "Boca Juniors",
                    "Riber Plate",
                    "San Lorenzo",
                    "Ferrocarril Oeste",
                    "Banfield",
                    "Racing"
                });

            EquipoSeleccionadoCommand = new Command(EquipoSeleccionadoCommandExecute);
            FinEncuestaSeleccionadaCommand = new MyCommand(FinEncuestaExecute, FinEncuestaCanExecute);

            MessagingCenter.Subscribe<ContentPage, string>(this, Mensajes.EquipoSeleccionado, (sender, args) =>
             {
                 Equipo_Favorito = args;
             });

            PropertyChanged += DetalleEncuestaVM_PropiedadCambiada;
        }

        private void EquipoSeleccionadoCommandExecute(object obj)
        {
            MessagingCenter.Send(this, Mensajes.EquipoSeleccionado, equipos.ToArray());
        }

        public string Nombre
        {
            get => nombre; set
            {
                if (value == nombre) { return; }
                nombre = value;
                OnPropertyChanged();
            }
        }
        public DateTime Fecha_Nacimiento
        {
            get => fecha_Nacimiento; set
            {
                if (value == fecha_Nacimiento) { return; }
                fecha_Nacimiento = value;
                OnPropertyChanged();
            }
        }
        public string Equipo_Favorito
        {
            get => equipo_Favorito; set
            {
                if (value == equipo_Favorito) { return; }
                equipo_Favorito = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> Equipos
        {
            get => equipos; set
            {
                if (value == equipos) { return; }
                equipos = value;
                OnPropertyChanged();
            }
        }

        public ICommand EquipoSeleccionadoCommand { get; set; }

        public ICommand FinEncuestaSeleccionadaCommand { get; set; }

        private bool FinEncuestaCanExecute()
        {
            return !string.IsNullOrWhiteSpace(Nombre) && !string.IsNullOrWhiteSpace(Equipo_Favorito);
        }
        private void FinEncuestaExecute()
        {
            Encuesta nEncuesta = new Encuesta()
            {
                Nombre = this.Nombre,
                Fecha_Nacimiento = this.Fecha_Nacimiento,
                Equipo_Favorito = this.Equipo_Favorito
            };
            MessagingCenter.Send(this, Mensajes.NuevaEncuestaCompleta, nEncuesta);
        }


        private void DetalleEncuestaVM_PropiedadCambiada(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Nombre) || e.PropertyName == nameof(Equipo_Favorito)){ (FinEncuestaSeleccionadaCommand as Command)?.ChangeCanExecute(); }
        }
    }
}