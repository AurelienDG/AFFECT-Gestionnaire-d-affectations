using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SAE_prototype
{
    public class MISSION : Crud<MISSION>
    {
        public int CodeMission
        {
            get; set;
        }
        public string LibelleMission
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
            List<MISSION> listeGroupes = new List<MISSION>();
            DataAccess access = new DataAccess();
            SqlDataReader reader;
            try
            {
                if (access.openConnection())
                {
                    
                    reader = access.getData("Update MISSION " +
                                            "set libellemission = '" + this.LibelleMission + "'" +
                                            "WHERE codemission = '" + this.CodeMission + "';" +
                                            "Update EST_AFFECTE " +
                                            "set datemission = '" + this.DateMission + "', " +
                                            "commentaire = '" + this.Commentaire + "'" +
                                            "WHERE codemission = '" + this.CodeMission + "';");
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
                    reader = access.getData("Insert into MISSION (libellemission) " +
                                            "values (" + this.LibelleMission + ");" +
                                            "Insert into EST_AFFECTE (codedivision,codemission,datemission,commentaire) " +
                                            "values (" + this.CodeDivision + "," + this.CodeMission + "" + this.DateMission + "" + this.Commentaire + ");");
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
            List<MISSION> listeGroupes = new List<MISSION>();
            DataAccess access = new DataAccess();
            SqlDataReader reader;
            try
            {
                if (access.openConnection())
                {
                    reader = access.getData("DELETE FROM MISSION " +
                                            "WHERE codemission =  '" + this.CodeMission + "';" +
                                            "DELETE FROM EST_AFFECTE " +
                                            "WHERE codemission =  '" + this.CodeMission + "';");


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

        public List<MISSION> FindAll()
        {
            List<MISSION> listeGroupes = new List<MISSION>();
            DataAccess access = new DataAccess();
            SqlDataReader reader;
            try
            {
                if (access.openConnection())
                {
                    reader = access.getData("select m.CODEMISSION,LIBELLEMISSION,CODEDIVISION,DATEMISSION,COMMENTAIRE " +
                                            "from MISSION m " +
                                            "Join EST_AFFECTE e on m.CODEMISSION = e.CODEMISSION");
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            MISSION unGroupe = new MISSION();
                            unGroupe.CodeMission = reader.GetInt32(0);
                            unGroupe.LibelleMission = reader.GetString(1);
                            unGroupe.CodeDivision = reader.GetInt32(2);
                            unGroupe.DateMission = reader.GetDateTime(3);
                            unGroupe.Commentaire = reader.GetString(4);
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

        public List<MISSION> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }


    }
}
