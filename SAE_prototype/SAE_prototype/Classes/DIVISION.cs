using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SAE_prototype
{
    public class DIVISION : Crud<DIVISION>
    {
        public int CodeDivision
        {
            get; set;
        }
        public int CodeCorpsArmee
        {
            get; set;
        }
        public string LibelleCDivision
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

        public List<DIVISION> FindAll()
        {
            List<DIVISION> listeGroupes = new List<DIVISION>();
            DataAccess access = new DataAccess();
            SqlDataReader reader;
            try
            {
                if (access.openConnection())
                {
                    reader = access.getData("select * from DIVISION;");
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DIVISION unGroupe = new DIVISION();
                            unGroupe.CodeDivision = reader.GetInt32(0);
                            unGroupe.CodeCorpsArmee = reader.GetInt32(1);
                            unGroupe.LibelleCDivision = reader.GetString(2);
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

        public List<DIVISION> FindBySelection(string criteres)
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
