using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SAE_prototype
{
    /// <summary>
    /// Cette classe permet de créer et stocker un corps d'armée ses paramètres sont une CodeCorpsArmee et un LibelleCorpsArmee.
    /// </summary>
    public class Corps_Armee : Crud<Corps_Armee>
    {
        /// <summary>
        /// Constructeur vide de Corps_Armee
        /// </summary>
        public Corps_Armee()
        {

        }
        /// <summary>
        /// Propriété du CodeCorpsArmee
        /// </summary>
        public int CodeCorpsArmee
        {
            get; set;
        }
        /// <summary>
        /// Propriété du LibelleCorpsArmee
        /// </summary>
        public string LibelleCorpsArmee
        {
            get; set;
        }
        /// <summary>
        /// Méthode pour créer un corps d'armée
        /// </summary>
        public void Create()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Méthode pour lire un corps d'armée
        /// </summary>
        public void Read()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Méthode pour modifier un corps d'armée
        /// </summary>
        public void Update()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Méthode pour supprimer un corps d'armée
        /// </summary>
        public void Delete()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Méthode pour récupérer toutes les corps d'armée de la base de donnée
        /// </summary>
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
        /// <summary>
        /// Méthode pour récupérer les corps d'armée de la base de donnée avec un paramètre
        /// </summary>
        /// <param name="criteres"></param>
        /// <returns></returns>
        public List<Corps_Armee> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }
    }
}
