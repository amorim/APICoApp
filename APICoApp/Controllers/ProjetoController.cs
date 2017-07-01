using APIFlooder.DBAccess;
using APIFlooder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace APIFlooder.Controllers
{
    public class ProjetoController : ApiController
    {
        [Route("projects")]
        [HttpGet]
        public IEnumerable<Projeto> GetProjects()
        {
            return Acessa.getAllProjects();
        }
        [Route("destaques")]
        [HttpGet]
        public IEnumerable<Projeto> GetDestaques()
        {
            return Acessa.getTop10();
        }
        [Route("projects/{idUsu}")]
        [HttpGet]
        public IEnumerable<Projeto> GetProjectsUsu(int idUsu)
        {
            List<Projeto> lista =  Acessa.getAllProjects();
            bool outerBreak = false;
            foreach (Projeto p in lista)
            {
                if (outerBreak)
                    break;
                foreach(Usuario u in p.usuarios)
                {
                    if (u.id == idUsu)
                    {
                        Usuario usu = new Usuario();
                        usu.id = u.id;
                        usu.interesses = u.interesses;
                        Projeto.userAtual = usu;
                        outerBreak = true;
                        break;
                    }
                }
            }
            lista.Sort();
            return lista.Take(20);
        }
        [Route("createProject")]
        [HttpPost]
        public Status CreateProject(Projeto p)
        {
            Acessa.createProject(p);
            return new Status()
            {
                id = 1,
                desc = "Sucesso"
            };
        }
        [Route("publishContent")]
        [HttpPost]
        public Status PublishContent(Conteudo c)
        {
            Acessa.publishContent(c);
            return new Status()
            {
                id = 1,
                desc = "Sucesso"
            };
        }
        [Route("addUserToProject/{idUser}/{idProject}")]
        [HttpGet]
        public Status AddUserToProject(int idUser, int idProject)
        {
            Acessa.addUserToProject(new Usuario() { id = idUser }, new Projeto() { id = idProject });
            return new Status()
            {
                id = 1,
                desc = "Sucesso"
            };
        }
        [Route("createUser")]
        [HttpPost]
        public Status CreateUser(Usuario u)
        {
            Acessa.createUser(u);
            return new Status()
            {
                id = 1,
                desc = "Sucesso"
            };
        }
        [Route("login/{email}/{senha}")]
        [HttpGet]
        public Status Login(string email, string senha)
        {
            if (Acessa.Login(email, senha))
            {
                return new Status()
                {
                    id = 1,
                    desc = "Sucesso"
                };
            }
            return new Status()
            {
                id = 2,
                desc = "Erro de Login"
            };
        }
        [Route("conteudo")]
        [HttpGet]
        public IEnumerable<Conteudo> GetContent()
        {
            return Acessa.getContents();   
        }

        [Route("user/{id}")]
        [HttpGet]
        public Usuario GetUser(int id)
        {
            return Acessa.getUser(id);
        } 
        [Route("tags")]
        [HttpGet]
        public List<Interesse> GetTags()
        {
            return Acessa.getTags();
        }
    }
}