using Projectile.Model;
using Projectile.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectile.ViewModel
{
    public class BoardPageViewModel : ViewModelBase
    {
        public ObservableCollection<FakeBoard> FakeBoards { get; set; }

        public BoardPageViewModel() 
        {
            FakeBoards = new ObservableCollection<FakeBoard>
            {
                new FakeBoard("Доска 1"),
                new FakeBoard("Доска 2"),
                new FakeBoard("Доска 3")
            };
        }

        private FakeBoard fakeboard;

        public FakeBoard fakeBoard
        {
            get { return fakeboard; }
            set 
            { 
                fakeboard = value; 
                OnPropertyChanged(nameof(FakeBoard));
            }
        }

    }
}
