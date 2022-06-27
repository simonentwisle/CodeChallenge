using IPlatoCodeChallenge.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;
using IPlatoCodeChallenge;
using Microsoft.VisualStudio.Utilities;
using Prism.Commands;

namespace IPlatoCodeChallenge.ViewModel
{

    public class PersonViewModel
    {
        public DelegateCommand DeleteCommand { get; set; }
        public DelegateCommand SelectCommand { get; set; }

        public PersonViewModel()
        {
            LoadPeople();
            //DeleteCommand = new RelayCommand(OnDelete, CanDelete);
            DeleteCommand = new DelegateCommand(DeleteButtonClick);
            SelectCommand = new DelegateCommand(SelectButtonClick);
        }

        private void SelectButtonClick()
        {
            //People.Remove(SelectedPerson);
        }

        private void DeleteButtonClick()
        {
            People.Remove(SelectedPerson);
        }

        public ObservableCollection<Person> People
        {
            get;
            set;
        }

        public void LoadPeople()
        {
            ObservableCollection<Person> people = new ObservableCollection<Person>();
            people.Add(new Person { FirstName = "Mark", LastName = "Allain", DOB = "04/10/1972", Profession = "Brick Layer" });
            people.Add(new Person { FirstName = "Allen", LastName = "Brown", DOB = "10/06/2002", Profession = "Comedian" });
            people.Add(new Person { FirstName = "Linda", LastName = "Hamerski", DOB = "22/07/1984", Profession = "Gardenner" });

            People = people;
        }

        private Person _selectedPerson;

        public Person SelectedPerson
        {
            get
            {
                return _selectedPerson;
            }

            set
            {
                _selectedPerson = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        private void OnDelete()
        {
           People.Remove(SelectedPerson);
        }

        private bool CanDelete()
        {
            return SelectedPerson != null;
        }

        public DelegateCommand InitializedCommand
        {
            get
            {

                return new DelegateCommand(delegate ()
                {
                    //Initializes command delegate
                });
            }
        }
    }
}
