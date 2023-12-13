using Projectile.MVVM;
using Projectile.View.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Projectile.Navigation
{
    public class NavigationCommand : RelayCommand
    {
        NavigationStore _navigationStore { get; set; }

        public NavigationCommand(Action<object> execute, Func<object, bool> canExecute = null) : base(execute, canExecute)
        {

        }
    }
}
