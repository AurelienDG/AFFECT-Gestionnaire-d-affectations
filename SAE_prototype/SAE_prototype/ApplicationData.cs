using System;
using System.Collections.Generic;
using System.Text;

namespace SAE_prototype
{
    public class ApplicationData
    {
        public ApplicationData()
        {
            this.loadApplicationData();
        }

        public List<CORPS_ARMEE> listeCorpsArmee
        {
            get;
            set;
        }
        public List<MISSION> listeMissions
        {
            get;
            set;
        }
        public List<DIVISION> listeDivisions
        {
            get;
            set;
        }

        public void loadApplicationData()
        {
            //chargement des tables
            //Eleve unEleve = new Eleve();
            //Professeur unProfesseur = new Professeur();
            CORPS_ARMEE unCORPS_ARMEE = new CORPS_ARMEE();
            listeCorpsArmee = unCORPS_ARMEE.FindAll();

            MISSION uneMISSION = new MISSION();
            listeMissions = uneMISSION.FindAll();

            DIVISION uneDIVISION = new DIVISION();
            listeDivisions = uneDIVISION.FindAll();

            
            //mapping des relations en mode déconnecté
            //relation bi-directionnelle entre eleve et groupe
            //relation eleve -> note
            //relation note -> professeur
        }
    }
}
