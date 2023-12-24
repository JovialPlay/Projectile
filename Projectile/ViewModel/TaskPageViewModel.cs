using BLL;
using BLL.Services;
using DAL.Repository;
using DTO;
using Interfaces.Services;
using Projectile.MVVM;
using Projectile.Navigation;
using Projectile.View.Pages;
using Projectile.View.UpdateForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Projectile.ViewModel
{
    public class TaskPageViewModel:ViewModelBase
    {
        readonly NavigationStore Store;

        readonly DbReposSQL db;
        public TakeBoard OwnerBoard { get; set; }
        public UserService userService { get; set; }

        public ProjectService projectService { get; set; }
        public BoardService boardService { get; set; }

        public TaskService taskService { get; set; }

        public Stat
        public string OwnerBoardString { get; set; }
        public UpdateBoard updateBoard { get; set; }
        public List<TakeCard> Cards { get; set; }
        public List<TakeTask> Tasks { get; set; }

        public RelayCommand SaveChanges => new RelayCommand(execute => SendCardsToDB());
        public RelayCommand ChangeBoard => new RelayCommand(execute => ChangeBoardSettings());
        public RelayCommand ChangeBoardInDB => new RelayCommand(execute => UpdateBoard());
        public RelayCommand DeleteBoardFromDB => new RelayCommand(execute => DeleteBoard());
        public RelayCommand Cancel => new RelayCommand(execute => DoNotSave());

        public RelayCommand CreateCardClick => new RelayCommand(execute => CreateCard());
        CardService cardService { get; set; }

        public RelayCommand AddTask => new RelayCommand(execute => CreateTask((TakeCard)execute));


        public TaskPageViewModel(NavigationStore store, DbReposSQL db, TakeBoard ownerBoard)
        {
            Store = store;
            this.db = db;
            OwnerBoard = ownerBoard;
            userService = new UserService(db);
            boardService = new BoardService(db);
            projectService = new ProjectService(db);
            foreach (int j in OwnerBoard.Users) 
            {
                string s = userService.GetSingleUser(j).Login + ";";
                OwnerBoardString += s;
            }
            cardService = new CardService(db);
            Cards = cardService.GetBoardsCards(OwnerBoard.Id);

        }

        public void ChangeBoardSettings()
        {
            updateBoard=new UpdateBoard(this);
            updateBoard.ShowDialog();
        }

        public void UpdateBoard()
        {
            int border = 0;
            string one;
            OwnerBoard.Users = new List<int>();
            if (OwnerBoardString != null)
            {
                for (int i = 0; i < OwnerBoardString.Length; i++)
                {
                    if (OwnerBoardString[i] == ';')
                    {
                        one = OwnerBoardString.Substring(border, i - border);
                        foreach (var j in userService.GetAllUsers())
                        {
                            if (j.Login == one)
                            {
                                OwnerBoard.Users.Add(j.Id);
                            }
                        }
                        border = i + 1;
                    }
                }
            }
            boardService.UpdateBoard(OwnerBoard, 1);
            updateBoard.Close();
        }
        public void DeleteBoard()
        {
            boardService.DeleteBoard(OwnerBoard.Id);
            Store.ChangePage(new BoardPage(Store, db,projectService.GetSingleProject((int)OwnerBoard.Project)));
            updateBoard.Close();
        }
        public void DoNotSave()
        {
            updateBoard.Close();
        }
        public void CreateCard()
        {
            TakeCard card = new TakeCard();
            card.Name = "Новая Карточка";
            card.Board = OwnerBoard;
            cardService.CreateCard(card, 1);
            Cards = cardService.GetBoardsCards(OwnerBoard.Id);
            Store.CurrentPage = new TaskPage(Store, db, OwnerBoard);
        }

        public void SendCardsToDB()
        {
            foreach (var card in Cards) 
            { 
                cardService.UpdateCard(card, 1);
            }
        }

        public void CreateTask(TakeCard card)
        {
            TakeTask task = new TakeTask();
            task.Card = card.Name;

        }

    }
}
