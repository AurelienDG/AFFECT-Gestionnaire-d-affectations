using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SAE_prototype
{
    public class Corps_Armee : Crud<Corps_Armee>
    {
        public Corps_Armee()
        {

        }
        public int CodeCorpsArmee
        {
            get; set;
        }
        public string LibelleCorpsArmee
        {
            get; set;
        }
        public void Create()
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
        public void Delete()
        {
            throw new NotImplementedException();
        }
        public List<Corps_Armee> FindAll()
        {
            List<Corps_Armee> listeGroupes = new List<Corps_Armee>();
            DataAccess access = new DataAccess();
            SqlDataReader reader;
            try
            {
                if (access.openConnection())
                {
                    reader = access.getData("select * from Corps_Armee;");
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Corps_Armee unGroupe = new Corps_Armee();
                            unGroupe.CodeCorpsArmee = reader.GetInt32(0);
                            unGroupe.LibelleCorpsArmee = reader.GetString(1);
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
        public List<Corps_Armee> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }
    }
}
