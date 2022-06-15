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

        public List<CORPS_ARMEE> listeGroupes
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
            //EstNote unEstNote = new EstNote();
            //listeEleves = unEleve.FindAll();
            //listeProfesseurs = unProfesseur.FindAll();
            listeGroupes = unCORPS_ARMEE.FindAll();
            //listeEstNotes = unEstNote.FindAll();
            //mapping des relations en mode déconnecté
            //relation bi-directionnelle entre eleve et groupe
            //relation eleve -> note
            //relation note -> professeur
        }
    }
}
