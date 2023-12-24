using Projectile.MVVM;
using Projectile.View.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Projectile.Navigation
{
    public class NavigationStore
    {
        public event Action CurrentPageChanged;
        public Page _currentPage;
        public Page CurrentPage
        {
            get => CurrentPage;
            set
            {
                _currentPage = value;
                OnCurrentPageChanged();
            }
        }
        private void OnCurrentPageChanged()
        {
            CurrentPageChanged?.Invoke();
        }

        public void ChangePage(Page page)
        {
            CurrentPage = page;
            OnCurrentPageChanged();
        }

        public void ClearHistory()
        {
            
        }
    }
}
