using IPlatoCodeChallenge.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;
using IPlatoCodeChallenge;

namespace IPlatoCodeChallenge.ViewModel
{

    public class PersonViewModel
    {
        public GenericICommand DeleteCommand { get; set; }

        public PersonViewModel()
        {
            LoadPeople();
            DeleteCommand = new GenericICommand(OnDelete, CanDelete);
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
    }
}
