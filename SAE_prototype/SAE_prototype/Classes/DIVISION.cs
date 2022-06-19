using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SAE_prototype
{
    /// <summary>
    /// Cette classe permet de créer et stocker une division ses paramètres sont une CodeDivision, un LibelleCDivision et un UncorpsArmee.
    /// </summary>
    public class Division : Crud<Division>
    {
        /// <summary>
        /// Constructeur vide de Division
        /// </summary>
        public Division()
        {
            this.UncorpsArmee = new Corps_Armee();
        }
        /// <summary>
        /// Propriété du CodeDivision
        /// </summary>
        public int CodeDivision
        {
            get; set;
        }
        /// <summary>
        /// Propriété du UncorpsArmee
        /// </summary>
        public Corps_Armee UncorpsArmee
        {
            get; set;
        }
        /// <summary>
        /// Propriété du LibelleCDivision
        /// </summary>
        public string LibelleCDivision
        {
            get; set;
        }
        /// <summary>
        /// Méthode pour créer une division
        /// </summary>
        public void Create()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Méthode pour supprimer une division
        /// </summary>
        public void Delete()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Méthode pour récupérer toutes les affectations de la base de donnée
        /// </summary>
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
        /// <summary>
        /// Méthode pour récupérer les affectations de la base de donnée avec un paramètre
        /// </summary>
        /// <param name="criteres"></param>
        /// <returns></returns>
        public List<Division> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Méthode pour lire une division
        /// </summary>
        public void Read()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Méthode pour modifier une division
        /// </summary>
        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
