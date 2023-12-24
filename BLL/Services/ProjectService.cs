using DTO;
using DomainModel;
using System.Collections.Generic;
using System.Linq;
using Interfaces.Repository;
using Interfaces.Services;

namespace BLL
{
    public class ProjectService : IProjectService
    {
        private IDbRepos db;
        public ProjectService(IDbRepos repos)
        {
            db = repos;
        }

        public List<TakeProject> GetAllProjects()
        {
            return db.Projects.GetList().Select(i => new TakeProject(i)).ToList();
        }

        public TakeProject GetSingleProject(int Id)
        {
            return new TakeProject(db.Projects.GetItem(Id));
        }

        public void CreateProject(TakeProject p, int userid)
        {
            bool access;
            if (p.Access == "Публичный")
            {
                access = true;
            }
            else
            {
                access = false;
            }
            db.Projects.Create(new projects()
            {
                projectname = p.Name,
                projectdescription = p.Description,
                projectaccess = access,
                projectowner=userid

            });
            Save();
        }

        public void UpdateProject(TakeProject p, int userid)
        {
            projects pr = db.Projects.GetItem(p.Id);
            pr.projectname = p.Name;
            pr.projectdescription = p.Description;
            bool access;
            if (p.Access == "Публичный")
            {
                access = true;
            }
            else
            {
                access = false;
            }
            pr.projectaccess = access;
            pr.projectowner = userid;
            db.Projects.Update(pr);
            Save();
        }

        public void DeleteProject(int id)
        {
            projects p = db.Projects.GetItem(id);
            if (p != null)
            {
                db.Projects.Delete(p.id);
                Save();
            }
        }
        public bool Save()
        {
            if (db.Save() > 0) return true;
            return false;
        }

    }
}
