using APIFlooder.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace APIFlooder.DBAccess
{
    public class Acessa
    {

        public static List<Projeto> getAllProjects()
        {
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.conex))
            {
                con.Open();
                var ds = new DataSet();
                string strSQL = "select * from projeto order by nome";
                SqlDataAdapter adapter = new SqlDataAdapter(strSQL, con);
                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];
                List<Projeto> projs = new List<Projeto>();
                foreach (DataRow dr in dt.Rows)
                {
                    Projeto proj = new Projeto();
                    proj.id = int.Parse(dr[0].ToString());
                    proj.name = dr[1].ToString();
                    proj.description = dr[2].ToString();
                    proj.image = dr[3].ToString();
                    proj.views = int.Parse(dr[5].ToString());
                    string strsqlusu =  "select * from usuario where id in (select idUsuario from projetos_usuarios where idProjeto = " + proj.id + ")";
                    string strsqlinter = "select * from interesse where id in (select idInteresse from interesses_projetos where idProjeto = " + proj.id + ")";
                    
                    SqlDataAdapter adapter2 = new SqlDataAdapter(strsqlusu, con);
                    var ds2 = new DataSet();
                    adapter2.Fill(ds2);
                    DataTable dtusers = ds2.Tables[0];
                    List<Usuario> usulist = new List<Usuario>();
                    foreach (DataRow d in dtusers.Rows)
                    {
                        Usuario user = new Usuario();
                        user.id = int.Parse(d[0].ToString());
                        user.name = d[1].ToString();
                        user.photo = d[2].ToString();
                        user.bgPhoto = d[3].ToString();
                        user.email = d[4].ToString();
                        user.password = null;
                        string strsqlinterusu = "select * from interesse where id in (select idInteresse from interesses_usuarios where idUsuario = " + user.id + ")";
                        SqlDataAdapter adapter4 = new SqlDataAdapter(strsqlinterusu, con);
                        var ds4 = new DataSet();
                        adapter4.Fill(ds4);
                        DataTable dtuser = ds4.Tables[0];
                        List<Interesse> interesses = new List<Interesse>();
                        foreach (DataRow drr in dtuser.Rows)
                        {
                            Interesse inter = new Interesse();
                            inter.id = int.Parse(drr[0].ToString());
                            inter.description = drr[1].ToString();
                            interesses.Add(inter);
                        }
                        user.interesses = interesses;
                        usulist.Add(user);
                        if (user.id == int.Parse(dr[4].ToString()))
                            proj.criador = user;
                    }
                    proj.usuarios = usulist;
                    proj.usersOnProject = usulist.Count;
                    
                    SqlDataAdapter adapter3 = new SqlDataAdapter(strsqlinter, con);
                    var ds3 = new DataSet();
                    adapter3.Fill(ds3);
                    DataTable dtinter = ds3.Tables[0];
                    List<Interesse> interlist = new List<Interesse>();
                    foreach (DataRow drr in dtinter.Rows)
                    {
                        Interesse inter = new Interesse();
                        inter.id = int.Parse(drr[0].ToString());
                        inter.description = drr[1].ToString();
                        interlist.Add(inter);
                    }
                    proj.interesses = interlist;
                    projs.Add(proj);
                }
                con.Close();
                return projs;

            }
        }
        public static Usuario getUser(int id)
        {
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.conex))
            {
                con.Open();
                string strsqlusu = "select * from usuario where id = " + id;

                SqlDataAdapter adapter2 = new SqlDataAdapter(strsqlusu, con);
                var ds2 = new DataSet();
                adapter2.Fill(ds2);
                DataTable dtusers = ds2.Tables[0];
                DataRow d = dtusers.Rows[0];
                    Usuario user = new Usuario();
                    user.id = int.Parse(d[0].ToString());
                    user.name = d[1].ToString();
                    user.photo = d[2].ToString();
                    user.bgPhoto = d[3].ToString();
                    user.email = d[4].ToString();
                    user.password = null;
                    string strsqlinterusu = "select * from interesse where id in (select idInteresse from interesses_usuarios where idUsuario = " + user.id + ")";
                    SqlDataAdapter adapter4 = new SqlDataAdapter(strsqlinterusu, con);
                    var ds4 = new DataSet();
                    adapter4.Fill(ds4);
                    DataTable dtuser = ds4.Tables[0];
                    List<Interesse> interesses = new List<Interesse>();
                    foreach (DataRow drr in dtuser.Rows)
                    {
                        Interesse inter = new Interesse();
                        inter.id = int.Parse(drr[0].ToString());
                        inter.description = drr[1].ToString();
                        interesses.Add(inter);
                    }
                    user.interesses = interesses;
                return user;
            }
        }
        public static List<Conteudo> getContents()
        {
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.conex))
            {
                con.Open();
                var ds = new DataSet();
                string strSQL = "select * from conteudo order by id DESC";
                SqlDataAdapter adapter = new SqlDataAdapter(strSQL, con);
                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];
                List<Conteudo> list = new List<Conteudo>();
                foreach (DataRow dr in dt.Rows)
                {
                    Conteudo cont = new Conteudo();
                    cont.id = int.Parse(dr[0].ToString());
                    string strsqlusu = "select * from usuario where id = " + dr[3].ToString();
                    SqlDataAdapter adapter2 = new SqlDataAdapter(strsqlusu, con);
                    var ds2 = new DataSet();
                    adapter2.Fill(ds2);
                    DataTable dtusers = ds2.Tables[0];
                    DataRow d = dtusers.Rows[0];
                    Usuario user = new Usuario();
                    user.id = int.Parse(d[0].ToString());
                    user.name = d[1].ToString();
                    user.photo = d[2].ToString();
                    user.bgPhoto = d[3].ToString();
                    user.email = d[4].ToString();
                    user.password = null;
                    string strsqlinterusu = "select * from interesse where id in (select idInteresse from interesses_usuarios where idUsuario = " + user.id + ")";
                    SqlDataAdapter adapter4 = new SqlDataAdapter(strsqlinterusu, con);
                    var ds4 = new DataSet();
                    adapter4.Fill(ds4);
                    DataTable dtuser = ds4.Tables[0];
                    List<Interesse> interesses = new List<Interesse>();
                    foreach (DataRow drr in dtuser.Rows)
                    {
                        Interesse inter = new Interesse();
                        inter.id = int.Parse(drr[0].ToString());
                        inter.description = drr[1].ToString();
                        interesses.Add(inter);
                    }
                    user.interesses = interesses;
                    cont.criador = user;
                    cont.nome = dr[1].ToString();
                    cont.uri = dr[2].ToString();
                    list.Add(cont);
                }
                return list;
            }
        }
        public static List<Projeto> getTop10()
        {
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.conex))
            {
                con.Open();
                var ds = new DataSet();
                string strSQL = "select top 20 * from projeto order by cliques DESC, nome";
                SqlDataAdapter adapter = new SqlDataAdapter(strSQL, con);
                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];
                List<Projeto> projs = new List<Projeto>();
                foreach (DataRow dr in dt.Rows)
                {
                    Projeto proj = new Projeto();
                    proj.id = int.Parse(dr[0].ToString());
                    proj.name = dr[1].ToString();
                    proj.description = dr[2].ToString();
                    proj.image = dr[3].ToString();
                    proj.views = int.Parse(dr[5].ToString());
                    string strsqlusu = "select * from usuario where id in (select idUsuario from projetos_usuarios where idProjeto = " + proj.id + ")";
                    SqlDataAdapter adapter2 = new SqlDataAdapter(strsqlusu, con);
                    var ds2 = new DataSet();
                    adapter2.Fill(ds2);
                    DataTable dtusers = ds2.Tables[0];
                    List<Usuario> usulist = new List<Usuario>();
                    foreach (DataRow d in dtusers.Rows)
                    {
                        Usuario user = new Usuario();
                        user.id = int.Parse(d[0].ToString());
                        user.name = d[1].ToString();
                        user.photo = d[2].ToString();
                        user.bgPhoto = d[3].ToString();
                        user.email = d[4].ToString();
                        user.password = null;
                        usulist.Add(user);
                        if (user.id == int.Parse(dr[4].ToString()))
                            proj.criador = user;
                    }
                    proj.usuarios = usulist;
                    proj.usersOnProject = usulist.Count;
                    string strsqlinter = "select * from interesse where id in (select idInteresse from interesses_projetos where idProjeto = " + proj.id + ")";
                    SqlDataAdapter adapter3 = new SqlDataAdapter(strsqlinter, con);
                    var ds3 = new DataSet();
                    adapter3.Fill(ds3);
                    DataTable dtinter = ds3.Tables[0];
                    List<Interesse> interlist = new List<Interesse>();
                    foreach (DataRow drr in dtinter.Rows)
                    {
                        Interesse inter = new Interesse();
                        inter.id = int.Parse(drr[0].ToString());
                        inter.description = drr[1].ToString();
                        interlist.Add(inter);
                    }
                    proj.interesses = interlist;
                    projs.Add(proj);
                }
                con.Close();
                return projs;

            }
        }
        public static List<Interesse> getTags()
        {
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.conex))
            {
                con.Open();
                string strsqlinter = "select * from interesse";
                SqlDataAdapter adapter3 = new SqlDataAdapter(strsqlinter, con);
                var ds3 = new DataSet();
                adapter3.Fill(ds3);
                DataTable dtinter = ds3.Tables[0];
                List<Interesse> interlist = new List<Interesse>();
                foreach (DataRow drr in dtinter.Rows)
                {
                    Interesse inter = new Interesse();
                    inter.id = int.Parse(drr[0].ToString());
                    inter.description = drr[1].ToString();
                    interlist.Add(inter);
                }
                return interlist;
            }
        }
        public static void createProject(Projeto p)
        {
            string strSQL = "insert projeto output INSERTED.id values (@nome, @desc, @img, @userID, 0)";
            SqlConnection con = new SqlConnection(Properties.Settings.Default.conex);
            SqlCommand com = new SqlCommand(strSQL, con);
            com.Parameters.AddWithValue("@nome", p.name);
            com.Parameters.AddWithValue("@desc", p.description);
            com.Parameters.AddWithValue("@img", p.image);
            com.Parameters.AddWithValue("@userID", p.criador.id);
            con.Open();
            int id = (int)com.ExecuteScalar();
            strSQL = "insert interesses_projetos values (@proj, @int)";
            foreach (Interesse i in p.interesses)
            {                
                com = new SqlCommand(strSQL, con);
                com.Parameters.AddWithValue("@proj", id);
                com.Parameters.AddWithValue("@int", i.id);
                com.ExecuteNonQuery();
            }
            strSQL = "insert projetos_usuarios values (@usu, @proj)";
            com = new SqlCommand(strSQL, con);
            com.Parameters.AddWithValue("@proj", id);
            com.Parameters.AddWithValue("@usu", p.criador.id);
            com.ExecuteNonQuery();
            con.Close();
        }
        public static void publishContent(Conteudo c)
        {
            string strSQL = "insert conteudo values (@nome, @uri, @criador)";
            SqlConnection con = new SqlConnection(Properties.Settings.Default.conex);
            SqlCommand com = new SqlCommand(strSQL, con);
            com.Parameters.AddWithValue("@nome", c.nome);
            com.Parameters.AddWithValue("@uri", c.uri);
            if (c.criador != null)
                com.Parameters.AddWithValue("@criador", c.criador.id);
            else
                com.Parameters.AddWithValue("@criador", "null");
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public static void addUserToProject(Usuario u, Projeto p)
        {
            string strSQL = "insert projetos_usuarios values (@usu, @proj)";
            SqlConnection con = new SqlConnection(Properties.Settings.Default.conex);
            SqlCommand com = new SqlCommand(strSQL, con);
            com.Parameters.AddWithValue("@usu", u.id);
            com.Parameters.AddWithValue("@proj", p.id);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public static void createUser(Usuario u)
        {
            string strSQL = "insert usuario OUTPUT INSERTED.id values (@nome, @photo, @bgPhoto, @email, @senha)";
            SqlConnection con = new SqlConnection(Properties.Settings.Default.conex);
            SqlCommand com = new SqlCommand(strSQL, con);
            com.Parameters.AddWithValue("@nome", u.name);
            com.Parameters.AddWithValue("@photo", u.photo);
            com.Parameters.AddWithValue("@bgPhoto", u.bgPhoto);
            com.Parameters.AddWithValue("@email", u.email);
            com.Parameters.AddWithValue("@senha", u.password);
            con.Open();
            int id = (int)com.ExecuteScalar();
            strSQL = "insert interesses_usuarios values (@usu, @int)";
            foreach (Interesse i in u.interesses)
            {
                com = new SqlCommand(strSQL, con);
                com.Parameters.AddWithValue("@usu", id);
                com.Parameters.AddWithValue("@int", i.id);
                com.ExecuteNonQuery();
            }
            
            con.Close();
        }
        public static bool Login(string email, string pass)
        {
            string strSQL = "select count(*) from usuario where email like @email COLLATE Latin1_General_CS_AS and senha like @senha COLLATE Latin1_General_CS_AS";
            SqlConnection con = new SqlConnection(Properties.Settings.Default.conex);
            SqlCommand com = new SqlCommand(strSQL, con);
            com.Parameters.AddWithValue("@email", email);
            com.Parameters.AddWithValue("@senha", pass);
            con.Open();
            if ((int)com.ExecuteScalar() == 1)
            {
                con.Close();
                return true;
            }
            con.Close();
            return false;
        }
       
    }
}