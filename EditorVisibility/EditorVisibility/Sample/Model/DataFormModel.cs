using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EditorVisibility
{
    public class DataFormModel : INotifyPropertyChanged
    {
        private string name;
        private string country;
        private string password;
        private string confirmPassword;
        private DateTime birthDate;
        private int? age;
        public DataFormModel()
        {
        }

        [Display(Prompt = "Enter your name", Name = "Name")]
        public string Name
        {
            get { return this.name; }
            set
            {
                if (value != name)
                {
                    this.name = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }

        [DataType(DataType.Password)]
        [Display(Prompt = "Enter your password", Name = "Password")]
        public string Password
        {
            get { return password; }
            set
            {
                if (value != password)
                {
                    password = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }

        [DataType(DataType.Password)]
        [Display(Prompt = "Confirm your password", Name = "Confirm Password")]
        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                if (value != confirmPassword)
                {
                    confirmPassword = value;
                    this.RaisePropertyChanged("ConfirmPassword");
                }
            }
        }

        [Display(Name = "Country")]
        public string Country
        {
            get { return country; }
            set
            {
                if (value != country)
                {
                    country = value;
                    this.RaisePropertyChanged("Country");
                }
            }
        }

        [Display(Name = "Birth date")]
        public DateTime BirthDate
        {
            get { return birthDate; }
            set
            {
                if (value != birthDate)
                {
                    birthDate = value;
                    this.RaisePropertyChanged("BirthDate");
                }
            }
        }

        [Display(Prompt = "Your Age", Name = "Age")]
        public int? Age
        {
            get { return age; }
            set
            {
                if (value != age)
                {
                    age = value;
                    this.RaisePropertyChanged("Age");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}