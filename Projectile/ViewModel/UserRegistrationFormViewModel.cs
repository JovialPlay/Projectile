using BLL;
using DAL.Repository;
using DTO;
using Projectile.MVVM;
using Projectile.Navigation;
using Projectile.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Projectile.ViewModel
{
    public class UserRegistrationFormViewModel : ViewModelBase
    {
        DbReposSQL db;
        public NavigationStore Store { get; set; }
        public UserService userService { get; set; }
        public List<TakeUser> users { get; set; }

        private UserRegistration RegistrationForm;

        private TakeUser userdata;

        public TakeUser Userdata
        {
            get { return userdata; }
            set
            {
                userdata = value;
                OnPropertyChanged(nameof(Userdata));
            }
        }
        public RelayCommand CheckUserInput => new RelayCommand(execute => UserCheck());
        public UserRegistrationFormViewModel(UserRegistration current) 
        {
            db = new DbReposSQL();
            Store= new NavigationStore();
            users= new List<TakeUser>();
            userService = new UserService(db);
            Userdata=new TakeUser();
            Userdata.Login = "login";
            users =userService.GetAllUsers();
            RegistrationForm = current;
        }

        public void UserCheck()
        {
            userdata.Password=RegistrationForm.PasswordBox.Password;
            foreach (var user in users) 
            { 
                if ((user.Login==userdata.Login)&&(user.Password==userdata.Password))
                {
                    MainWindow mainWindow = new MainWindow(user.Id);
                    mainWindow.Show();
                    RegistrationForm.Close();
                    break;
                }
            }
        }
    }
}
