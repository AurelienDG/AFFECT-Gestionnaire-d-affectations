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

        }
        public AFFECTATION(int codeMission, int codeDivision, DateTime DateMission)
        {
            this.CodeMission = codeMission;
            this.CodeDivision = codeDivision;
            this.DateMission = DateMission;
        }
        public AFFECTATION(int codeMission, int codeDivision, DateTime DateMission, string commentaire)
        {
            this.CodeMission = codeMission;
            this.CodeDivision = codeDivision;
            this.DateMission = DateMission;
            this.Commentaire = commentaire;
        }
        public int CodeMission
        {
            get; set;
        }
        public int CodeDivision
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
                                            "set datemission = '" + this.DateMission + "'," +
                                            "commentaire = '" + this.Commentaire + "'" +
                                            "WHERE codeDivision = " + this.CodeDivision + "and codemission = " + this.CodeMission + ";");

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
                                            "values (" + this.CodeDivision + "," + this.CodeMission + ",'" + this.DateMission + "','" + this.Commentaire + "');");

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
                                            "WHERE codeDivision = " + this.CodeDivision + "and codemission = " + this.CodeMission + ";");

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
                    reader = access.getData("select * from EST_AFFECTE");
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            AFFECTATION uneAffectation = new AFFECTATION();
                            uneAffectation.CodeDivision = reader.GetInt32(0);
                            uneAffectation.CodeMission = reader.GetInt32(1);
                            uneAffectation.DateMission = reader.GetDateTime(2);
                            if (reader.GetString(3) != null)
                                uneAffectation.Commentaire = reader.GetString(3);

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
