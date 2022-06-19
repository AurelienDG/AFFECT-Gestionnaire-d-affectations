using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SAE_prototype
{
    public class Mission : Crud<Mission>
    {
        public Mission()
        {

        }
        public int CodeMission
        {
            get; set;
        }
        public string LibelleMission
        {
            get; set;
        }

        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public List<Mission> FindAll()
        {
            List<Mission> listeGroupes = new List<Mission>();
            DataAccess access = new DataAccess();
            SqlDataReader reader;
            try
            {
                if (access.openConnection())
                {
                    reader = access.getData("select* from Mission ");
                                            
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Mission unGroupe = new Mission();
                            unGroupe.CodeMission = reader.GetInt32(0);
                            unGroupe.LibelleMission = reader.GetString(1);
                            listeGroupes.Add(unGroupe);
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Il n'y a plus de données.", "Information", System.Windows.MessageBoxButton.OK);
                    }
                    reader.Close();
                    access.closeConnection();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Important Message");
            }
            return listeGroupes;
        }

        public List<Mission> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
