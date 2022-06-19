using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SAE_prototype

{   /// <summary>
    /// Cette classe permet de créer et stocker une affectation ses paramètres sont une Division, une Mission, une Date et un commentaire
    /// </summary>
    public class Affectation : Crud<Affectation>
    {
        /// <summary>
        /// Constructeur vide de AFFECTATION
        /// </summary>
        public Affectation()
        {
            this.UneDivision = new Division();
            this.UneMission = new Mission();

        }
        /// <summary>
        /// Constructeur d'Affectation sans commentaire (division, mission, date)
        /// </summary>
        /// <param name="uneDivision"></param>
        /// <param name="uneMission"></param>
        /// <param name="dateMission"></param>

        public Affectation(Division uneDivision, Mission uneMission, DateTime dateMission)
        {
            this.UneMission = uneMission;
            this.UneDivision = uneDivision;
            this.DateMission = dateMission;
        }
        /// <summary>
        /// Constructeur d'Affectation avec commentaire (division, mission, date, commentaire)
        /// </summary>
        /// <param name="uneDivision"></param>
        /// <param name="uneMission"></param>
        /// <param name="dateMission"></param>
        /// <param name="commentaire"></param>
        public Affectation(Division uneDivision, Mission uneMission, DateTime dateMission, string commentaire)
        {
            this.UneMission = uneMission;
            this.UneDivision = uneDivision;
            this.DateMission = dateMission;
            this.Commentaire = commentaire;
        }
        /// <summary>
        /// Propriété de la mission
        /// </summary>
        public Mission UneMission
        {
            get; set;
        }
        /// <summary>
        /// Propriété de la division
        /// </summary>
        public Division UneDivision
        {
            get; set;
        }
        /// <summary>
        /// Propriété de la datemission
        /// </summary>
        public DateTime DateMission
        {
            get; set;

        }
        /// <summary>
        /// Propriété du commentaire de l'affectation
        /// </summary>
        public string Commentaire
        {
            get; set;

        }

        /// <summary>
        /// Méthode pour modifer une affectation
        /// </summary>
        public void Update()
        {
            List<Affectation> listeGroupes = new List<Affectation>();
            DataAccess access = new DataAccess();
            SqlDataReader reader;
            try
            {
                if (access.openConnection())
                {

                    reader = access.getData("Update EST_AFFECTE " +
                                            "set commentaire = '" + this.Commentaire + "', datemission = '" + this.DateMission + "'" +
                                            "WHERE codedivision = " + this.UneDivision.CodeDivision + "and codemission = " + this.UneMission.CodeMission + ";");

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

        /// <summary>
        /// Méthode pour créer une affectation
        /// </summary>
        public void Create()
        {
            List<Mission> listeGroupes = new List<Mission>();
            DataAccess access = new DataAccess();
            SqlDataReader reader;
            try
            {
                if (access.openConnection())
                {
                    reader = access.getData("Insert into EST_AFFECTE " +
                                            "(codedivision,codemission,datemission,commentaire) " +
                                            "values (" + this.UneDivision.CodeDivision + "," + this.UneMission.CodeMission + ",'" + this.DateMission + "','" + this.Commentaire + "');");

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

        /// <summary>
        /// Méthode pour supprimer une affectation
        /// </summary>
        public void Delete()
        {
            List<Affectation> listeGroupes = new List<Affectation>();
            DataAccess access = new DataAccess();
            SqlDataReader reader;
            try
            {
                if (access.openConnection())
                {
                    reader = access.getData("Delete from EST_AFFECTE " +
                                            "WHERE codedivision = " + this.UneDivision.CodeDivision + "and codemission = " + this.UneMission.CodeMission + ";");

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

        /// <summary>
        /// Méthode pour récupérer toutes les affectations de la base de donnée
        /// </summary>
        /// <returns></returns>
        public List<Affectation> FindAll()
        {
            List<Affectation> listeAffectations = new List<Affectation>();
            DataAccess access = new DataAccess();
            SqlDataReader reader;
            try
            {
                if (access.openConnection())
                {
                    reader = access.getData("select d.libelledivision, m.libellemission, e.DateMission, e.Commentaire, d.codedivision, m.codemission from EST_AFFECTE e Join mission m on m.codemission = e.codemission Join division d on d.codedivision = e.codedivision");
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Affectation uneAffectation = new Affectation();
                            
                            uneAffectation.UneDivision.LibelleCDivision = reader.GetString(0);
                            uneAffectation.UneMission.LibelleMission = reader.GetString(1);
                            uneAffectation.DateMission = reader.GetDateTime(2);
                            if (reader.GetString(3) != null)
                                uneAffectation.Commentaire = reader.GetString(3);
                            uneAffectation.UneDivision.CodeDivision = reader.GetInt32(4);
                            uneAffectation.UneMission.CodeMission = reader.GetInt32(5);

                            listeAffectations.Add(uneAffectation);
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
            return listeAffectations;
        }

        /// <summary>
        /// Méthode pour récupérer les affectations de la base de donnée avec un paramètre
        /// </summary>
        /// <param name="criteres"></param>
        /// <returns></returns>
        public List<Affectation> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Méthode pour lire une affectation
        /// </summary>
        public void Read()
        {
            throw new NotImplementedException();
        }


    }
}
