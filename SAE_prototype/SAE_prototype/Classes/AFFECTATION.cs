using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SAE_prototype
{
    public class AFFECTATION : Crud<AFFECTATION>
    {
        public AFFECTATION()
        {
            this.UneDivision = new DIVISION();
            this.UneMission = new MISSION();

        }
        public AFFECTATION(DIVISION UneDivision, MISSION UneMission, DateTime DateMission)
        {
            this.UneMission = UneMission;
            this.UneDivision = UneDivision;
            this.DateMission = DateMission;
        }
        public AFFECTATION(DIVISION UneDivision, MISSION UneMission, DateTime DateMission, string commentaire)
        {
            this.UneMission = UneMission;
            this.UneDivision = UneDivision;
            this.DateMission = DateMission;
            this.Commentaire = commentaire;
        }
        public MISSION UneMission
        {
            get; set;
        }
        public DIVISION UneDivision
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
            List<AFFECTATION> listeGroupes = new List<AFFECTATION>();
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
            List<MISSION> listeGroupes = new List<MISSION>();
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
            List<AFFECTATION> listeGroupes = new List<AFFECTATION>();
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

        public List<AFFECTATION> FindAll()
        {
            List<AFFECTATION> listeAffectations = new List<AFFECTATION>();
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
                            AFFECTATION uneAffectation = new AFFECTATION();
                            
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

        public List<AFFECTATION> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }


    }
}
