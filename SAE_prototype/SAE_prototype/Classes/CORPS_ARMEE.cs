using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SAE_prototype
{
public class CORPS_ARMEE : Crud<CORPS_ARMEE>
    {
        public CORPS_ARMEE()
        {

        }
        public CORPS_ARMEE(string libelleCorpsArmee)
        {
            this.LibelleCorpsArmee = libelleCorpsArmee;
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

            DataAccess access = new DataAccess();
            SqlDataReader reader;
            try
            {
                if (access.openConnection())
                {
                    reader = access.getData("DELETE FROM CORPS_ARMEE WHERE LIBELLECORPSARMEE = '"+ this.LibelleCorpsArmee + "';");
                    reader.Read();
                    reader.Close();
                    access.closeConnection();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Important Message");
            }

            
        }
        public List<CORPS_ARMEE> FindAll()
        {
            List<CORPS_ARMEE> listeGroupes = new List<CORPS_ARMEE>();
            DataAccess access = new DataAccess();
            SqlDataReader reader;
            try
            {
                if (access.openConnection())
                {
                    reader = access.getData("select * from CORPS_ARMEE;");
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            CORPS_ARMEE unGroupe = new CORPS_ARMEE();
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
        public List<CORPS_ARMEE> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }
    }
}
