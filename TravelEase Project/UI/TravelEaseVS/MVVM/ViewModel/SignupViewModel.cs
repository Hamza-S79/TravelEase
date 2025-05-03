using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using TravelEaseVS.Core;
using System.Resources;

namespace TravelEaseVS.MVVM.ViewModel
{
    public class SignupViewModel : INotifyPropertyChanged
    {
        private string selectedForm;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SwitchFormCommand { get; private set; }

        public string SelectedForm
        {
            get => selectedForm;
            set
            {
                if (selectedForm != value)
                {
                    selectedForm = value;
                    OnPropertyChanged(nameof(SelectedForm));
                    UpdateButtonColors(); // Update the button colors when the form changes
                }
            }
        }

        // Define button colors based on selected form
        public string TravelerButtonColor { get; private set; }
        public string OperatorButtonColor { get; private set; }
        public string HotelButtonColor { get; private set; }




        private void UpdateButtonColors()
        {
            

            TravelerButtonColor = (SelectedForm == "Traveler") ? "#FF4081" : "#FFFFFF";
            OperatorButtonColor = (SelectedForm == "Operator") ? "#FF4081" : "#FFFFFF";
            HotelButtonColor = (SelectedForm == "Hotel") ? "#FF4081" : "#FFFFFF";

            OnPropertyChanged(nameof(TravelerButtonColor));
            OnPropertyChanged(nameof(OperatorButtonColor));
            OnPropertyChanged(nameof(HotelButtonColor));
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //current form logic

        private object currentForm;
        public object CurrentForm
        {
            get => currentForm;
            set
            {
                currentForm = value;
                OnPropertyChanged(nameof(CurrentForm));
            }
        }

        public SignupViewModel()
        {
            // Initialize default form to Traveler
            SelectedForm = "Traveler";

            // Initialize button colors
            TravelerButtonColor = "#FF4081"; // Example default color
            OperatorButtonColor = "#FFFFFF";
            HotelButtonColor = "#FFFFFF";

            // Initialize SwitchFormCommand
            SwitchFormCommand = new RelayCommand(param => SwitchForm(param.ToString()));

            // Initialize CurrentForm
            LoadCurrentForm();
        }

        private void SwitchForm(string form)
        {
            SelectedForm = form;

            // Update form colors based on the selected form
            UpdateButtonColors();

            // Load corresponding form
            LoadCurrentForm();
        }

        private void LoadCurrentForm()
        {
            switch (SelectedForm)
            {
                case "Traveler":
                    CurrentForm = new TravelEaseVS.MVVM.View.TravelerForm();
                    break;
                case "Operator":
                    CurrentForm = new TravelEaseVS.MVVM.View.OperatorForm();
                    break;
                case "Hotel":
                    CurrentForm = new TravelEaseVS.MVVM.View.HotelForm();
                    break;
                default:
                    CurrentForm = null;
                    break;
            }
        }

    }
}
