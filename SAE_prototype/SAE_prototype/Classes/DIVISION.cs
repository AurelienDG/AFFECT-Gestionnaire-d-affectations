using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SAE_prototype
{
    public class Division : Crud<Division>
    {
        public Division()
        {
            this.UncorpsArmee = new Corps_Armee();
        }
        public int CodeDivision
        {
            get; set;
        }
        public Corps_Armee UncorpsArmee
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

        public List<Division> FindAll()
        {
            List<Division> listeGroupes = new List<Division>();
            DataAccess access = new DataAccess();
            SqlDataReader reader;
            try
            {
                if (access.openConnection())
                {
                    reader = access.getData("select * from Division;");
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Division unGroupe = new Division();
                            unGroupe.CodeDivision = reader.GetInt32(0);
                            unGroupe.UncorpsArmee.CodeCorpsArmee = reader.GetInt32(1);
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

        public List<Division> FindBySelection(string criteres)
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
