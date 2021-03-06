using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IPlatoCodeChallenge.Model
{
    public class PersonModel { }

    public class Person : INotifyPropertyChanged
    {
        private string firstName;
        private string lastName;
        private string dob;
        private string profession;

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    RaisePropertyChanged("FirstName");
                }
            }
        }

        public string LastName
        {
            get { return lastName; }

            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    RaisePropertyChanged("LastName");
                }
            }
        }

        public string DOB
        {
            get { return dob; }

            set
            {
                if (dob != value)
                {
                    dob = value;
                    RaisePropertyChanged("DOB");
                }
            }
        }

        public string Profession
        {
            get { return profession; }

            set
            {
                if (profession != value)
                {
                    profession = value;
                    RaisePropertyChanged("Profession");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }

        private object selectedPerson;

        public object SelectedPerson { get => selectedPerson; set => SetProperty(ref selectedPerson, value); }
    }
}
