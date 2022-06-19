using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SAE_prototype
{
    public class Affectation : Crud<Affectation>
    {
        public Affectation()
        {
            this.UneDivision = new Division();
            this.UneMission = new Mission();

        }
        public Affectation(Division UneDivision, Mission UneMission, DateTime DateMission)
        {
            this.UneMission = UneMission;
            this.UneDivision = UneDivision;
            this.DateMission = DateMission;
        }
        public Affectation(Division UneDivision, Mission UneMission, DateTime DateMission, string commentaire)
        {
            this.UneMission = UneMission;
            this.UneDivision = UneDivision;
            this.DateMission = DateMission;
            this.Commentaire = commentaire;
        }
        public Mission UneMission
        {
            get; set;
        }
        public Division UneDivision
        {
            get; set;
        }
        public DateTime DateMission
        {
            get; set;

        }
        public string Commentaire
        {
            get; set;

        }
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

        public List<Affectation> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }


    }
}
