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
        public DelegateCommand UpdateCommand { get; set; }
        public DelegateCommand NewCommand { get; set; }

        public PersonViewModel()
        {
            LoadPeople();
            //DeleteCommand = new RelayCommand(OnDelete, CanDelete);
            DeleteCommand = new DelegateCommand(DeleteButtonClick);
            UpdateCommand = new DelegateCommand(UpdateButtonClick);
            NewCommand = new DelegateCommand(NewButtonClick);
        }

        private void NewButtonClick()
        {
            if (SelectedPerson == null)
            {
                var newPerson = new Person();
                People.Add(newPerson);
                SelectedPerson = newPerson;
                SelectedPerson.FirstName = "";
                SelectedPerson.LastName = "";
                SelectedPerson.DOB = "";
                SelectedPerson.Profession = "";
            }
            else
            {
                var currentSelectedPerson = SelectedPerson;

                //People.Add(currentSelectedPerson);
                var newPerson = new Person();
                newPerson.FirstName = "";
                SelectedPerson = newPerson;
                People.Add(newPerson);
                SelectedPerson.FirstName = "";
                SelectedPerson.LastName = "";
                SelectedPerson.DOB = "";
                SelectedPerson.Profession = "";
            }

        }

        private void UpdateButtonClick()
        {

            //throw new NotImplementedException();
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
            people.Add(new Person { FirstName = "John", LastName = "Wayne", DOB = "04/10/1972", Profession = "Brick Layer" });
            people.Add(new Person { FirstName = "Tony", LastName = "Goron", DOB = "10/06/2002", Profession = "Comedian" });
            people.Add(new Person { FirstName = "Sarah", LastName = "Evens", DOB = "22/07/1984", Profession = "Gardener" });

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
