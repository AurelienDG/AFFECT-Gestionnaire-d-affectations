using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SAE_prototype

{
    /// <summary>
    /// Cette classe permet de créer et stocker un corps d'armée ses paramètres sont une CodeMission et un LibelleMission.
    /// </summary>
    public class Mission : Crud<Mission>
    {
        /// <summary>
        /// Constructeur vide de la Mission
        /// </summary>
        public Mission()
        {

        }
        /// <summary>
        /// Propriété du CodeMission
        /// </summary>
        public int CodeMission
        {
            get; set;
        }
        /// <summary>
        /// Propriété du LibelleMission
        /// </summary>
        public string LibelleMission
        {
            get; set;
        }
        /// <summary>
        /// Méthode pour créer une mission
        /// </summary>
        public void Create()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Méthode pour supprimer une mission
        /// </summary>
        public void Delete()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Méthode pour récupérer toutes les missions de la base de donnée
        /// </summary>
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
        /// <summary>
        /// Méthode pour récupérer les mission de la base de donnée avec un paramètre
        /// </summary>
        /// <param name="criteres"></param>
        /// <returns></returns>
        public List<Mission> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Méthode pour lire une mission
        /// </summary>
        public void Read()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Méthode pour modifier une mission
        /// </summary>
        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
