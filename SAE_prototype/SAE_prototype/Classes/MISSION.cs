using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SAE_prototype
{
    public class MISSION : Crud<MISSION>
    {
        public MISSION()
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

        public List<MISSION> FindAll()
        {
            List<MISSION> listeGroupes = new List<MISSION>();
            DataAccess access = new DataAccess();
            SqlDataReader reader;
            try
            {
                if (access.openConnection())
                {
                    reader = access.getData("select* from MISSION ");
                                            
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            MISSION unGroupe = new MISSION();
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

        public List<MISSION> FindBySelection(string criteres)
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
