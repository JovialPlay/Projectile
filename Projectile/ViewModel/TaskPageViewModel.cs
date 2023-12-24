using BLL.Services;
using DAL.Repository;
using DTO;
using Projectile.MVVM;
using Projectile.Navigation;
using Projectile.View.UpdateForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectile.ViewModel
{
    public class TaskPageViewModel:ViewModelBase
    {
        readonly NavigationStore Store;

        readonly DbReposSQL db;
        public  TakeBoard OwnerBoard { get; set; }

        public UpdateBoard updateBoard { get; set; }
        public List<TakeCard> Cards { get; set; }
        public List<TakeTask> Tasks { get; set; }

        public RelayCommand ChangeBoard => new RelayCommand(execute => ChangeBoardSettings());

        CardService cardService { get; set; }


        public TaskPageViewModel(NavigationStore store, DbReposSQL db, TakeBoard ownerBoard)
        {
            Store = store;
            this.db = db;
            OwnerBoard = ownerBoard;
            cardService = new CardService(db);
            Cards = cardService.GetBoardsCards(OwnerBoard.Id);

        }

        public void ChangeBoardSettings()
        {
            updateBoard=new UpdateBoard();
            updateBoard.Show();
        }
    }
}
