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

        public List<Corps_Armee> listeCorpsArmee
        {
            get;
            set;
        }
        public List<Mission> listeMissions
        {
            get;
            set;
        }
        public List<Division> listeDivisions
        {
            get;
            set;
        }
        public List<Affectation> listeAffectations
        {
            get;
            set;
        }

        public void loadApplicationData()
        {
            //chargement des tables
            //Eleve unEleve = new Eleve();
            //Professeur unProfesseur = new Professeur();
            Corps_Armee unCORPS_ARMEE = new Corps_Armee();
            listeCorpsArmee = unCORPS_ARMEE.FindAll();

            Mission uneMISSION = new Mission();
            listeMissions = uneMISSION.FindAll();

            Division uneDIVISION = new Division();
            listeDivisions = uneDIVISION.FindAll();

            Affectation uneAFFECTATION = new Affectation();
            listeAffectations = uneAFFECTATION.FindAll();

            //mapping des relations en mode déconnecté
            //relation bi-directionnelle entre eleve et groupe
            //relation eleve -> note
            //relation note -> professeur
        }
    }
}
