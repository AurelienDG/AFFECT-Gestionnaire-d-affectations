using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SAE_prototype
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ApplicationData applicationData;
        public MainWindow()
        {

            InitializeComponent();
            Actualise();
        }



        public void Actualise()
        {
            this.applicationData = new ApplicationData();
            this.DataContext = applicationData;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ModifierButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.lvAffectations.SelectedItems.Count == 1)
            {
                MessageBoxResult dialogResult = MessageBox.Show($"Valider la modification", "Modifier", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (dialogResult == MessageBoxResult.Yes)
                {
                    ((Affectation)this.lvAffectations.SelectedItem).Commentaire = RetireCharCommentaire(this.textBoxCommentaire.Text);
                    ((Affectation)this.lvAffectations.SelectedItem).DateMission = this.CalendarAffectation.SelectedDate.Value;
                    ((Affectation)this.lvAffectations.SelectedItem).Update();

                    Actualise();
                }
            }
            else
            {
                MessageBox.Show($"Selectionner une affectation pour modifier", "Modifier", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public string RetireCharCommentaire(string commentaire)
        {
            string[] charsToRemove = new string[] { "@", ",", ".", ";", "'" };
            foreach (var c in charsToRemove)
            {
                commentaire = commentaire.Replace(c, " ");
            }
            return commentaire;
        }
        private void LvAffectations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.lvAffectations.SelectedItems.Count == 1)
            {
                this.textBoxCommentaire.Text = ((Affectation)this.lvAffectations.SelectedItem).Commentaire;
                this.CalendarAffectation.SelectedDate = ((Affectation)this.lvAffectations.SelectedItem).DateMission;
                this.LabelDate.Content = ((Affectation)this.lvAffectations.SelectedItem).DateMission;
            }

            if (this.lvAffectations.SelectedItems.Count > 1)
            {
                MessageBox.Show("Veuillez sélectionner une seule affectation", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                this.lvAffectations.SelectedItems.Clear();
            }
        }

        private void BoutonSupprimer_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult dialogResult = MessageBox.Show($"Voulez vous vraiment supprimer l'affectation de la division {((Affectation)this.lvAffectations.SelectedItem).UneDivision.LibelleCDivision} à la mission {((Affectation)this.lvAffectations.SelectedItem).UneMission.LibelleMission}", "Supprimer", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (dialogResult == MessageBoxResult.Yes)
            {
                if (this.lvAffectations.SelectedItems.Count == 1)
                {
                    ((Affectation)this.lvAffectations.SelectedItem).Delete();
                }
            }
            Actualise();
        }



        private void BoutonAjouterAffectation_Click(object sender, RoutedEventArgs e)
        {
            Affectation a = new Affectation();
            if (this.ComboBoxDivision.SelectedItem == null || this.ComboBoxMission.SelectedItem == null || this.CalendarNouvelleAffectation.SelectedDate.Value == null)
                MessageBox.Show("Veuillez sélectionner un code division, un code mission et une date", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

            else
            {
                MessageBoxResult verification = MessageBox.Show($"Voulez vous vraiment ajouter l'affectation de la division {((Division)(this.ComboBoxDivision.SelectedItem)).LibelleCDivision} à la mission {((Mission)this.ComboBoxMission.SelectedItem).LibelleMission}", "Ajouter", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (verification == MessageBoxResult.Yes)
                {
                    if (this.textBoxNouveauCommentaire.Text == null || this.textBoxNouveauCommentaire.Text == "Commentaire")
                        a = new Affectation((Division)this.ComboBoxDivision.SelectedItem, (Mission)this.ComboBoxMission.SelectedItem, this.CalendarNouvelleAffectation.SelectedDate.Value);
                    else
                        a = new Affectation((Division)this.ComboBoxDivision.SelectedItem, (Mission)this.ComboBoxMission.SelectedItem, this.CalendarNouvelleAffectation.SelectedDate.Value, RetireCharCommentaire(this.textBoxNouveauCommentaire.Text));
                    a.Create();
                }
                Actualise();
                MainTabControl.SelectedItem = this.TB3;
            }

            this.Image4.Visibility = Visibility.Hidden;
        }

        private void ComboBoxDivision_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.ComboBoxDivision.SelectedItem != null)
            {
                this.IdImage.Content = ((Division)this.ComboBoxDivision.SelectedItem).CodeDivision;

                if (((Division)this.ComboBoxDivision.SelectedItem).UncorpsArmee.CodeCorpsArmee == 16)
                {
                    this.Image1.Visibility = Visibility.Visible;
                    this.Image2.Visibility = Visibility.Hidden;
                    this.Image3.Visibility = Visibility.Hidden;
                    this.Image4.Visibility = Visibility.Hidden;
                }
                else if (((Division)this.ComboBoxDivision.SelectedItem).UncorpsArmee.CodeCorpsArmee == 17)
                {
                    this.Image1.Visibility = Visibility.Hidden;
                    this.Image2.Visibility = Visibility.Visible;
                    this.Image3.Visibility = Visibility.Hidden;
                    this.Image4.Visibility = Visibility.Hidden;
                }
                else if (((Division)this.ComboBoxDivision.SelectedItem).UncorpsArmee.CodeCorpsArmee == 18)
                {
                    this.Image1.Visibility = Visibility.Hidden;
                    this.Image2.Visibility = Visibility.Hidden;
                    this.Image3.Visibility = Visibility.Visible;
                    this.Image4.Visibility = Visibility.Hidden;
                }
                else if (((Division)this.ComboBoxDivision.SelectedItem).UncorpsArmee.CodeCorpsArmee == 19)
                {
                    this.Image1.Visibility = Visibility.Hidden;
                    this.Image2.Visibility = Visibility.Hidden;
                    this.Image3.Visibility = Visibility.Hidden;
                    this.Image4.Visibility = Visibility.Visible;
                }
            }
        }

        private void BoutonTabModif_Click(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedItem = this.TB2;
        }

        private void BoutonTabCréa_Click(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedItem = this.TB3;
        }

        private void BoutonAccueil_Click(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedItem = this.TB1;
        }

        private void BoutonAjouter_Click(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedItem = this.TB3;
        }

        private void BoutonAccueil1_Click(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedItem = this.TB1;
        }

        private void BoutonModif_Click(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedItem = this.TB2;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            base.Close();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            window.WindowState = WindowState.Minimized;
        }
        private void Maximise_Click(object sender, RoutedEventArgs e)
        {
            switch (window.WindowState)
            {
                case WindowState.Normal:
                    window.WindowState = WindowState.Maximized;
                    break;
                case WindowState.Maximized:
                    window.WindowState = WindowState.Normal;
                    break;
            }
        }

        private void BoutonApropos_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Cette application a été réalisée par les étudiants en BUT Informatique : LADRETTE Irwin, MADMAR Mounir, DE GABAÏ Aurélien. Dans l'objectif de gérer des affectations à des missions humanitaires.", "A propos", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void ListView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            this.lvAffectRecherche.Items.Clear();
            foreach (Affectation a in this.lvAffectations.Items)
            {
                foreach (Division z in this.listeDivisions.SelectedItems)
                {
                    if (((Affectation)a).UneDivision.CodeDivision == ((Division)z).CodeDivision && !this.lvAffectRecherche.Items.Contains(a))
                    {
                        this.lvAffectRecherche.Items.Add((Affectation)a);
                    }
                }

                foreach (Mission w in this.listeMiss.SelectedItems)
                {
                    if (((Affectation)a).UneMission.CodeMission == ((Mission)w).CodeMission && !this.lvAffectRecherche.Items.Contains(a))
                    {
                        this.lvAffectRecherche.Items.Add((Affectation)a);
                    }
                }
            }
        }



        private void selectAll_Click(object sender, RoutedEventArgs e)
        {
            this.listeDivisions.SelectAll();

        }

        private void unSelectAll_Click(object sender, RoutedEventArgs e)
        {
            this.listeDivisions.UnselectAll();
        }

        private void selectAllM_Click(object sender, RoutedEventArgs e)
        {
            this.listeMiss.SelectAll();

        }

        private void unSelectAllM_Click(object sender, RoutedEventArgs e)
        {
            this.listeMiss.UnselectAll();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedItem = this.TB4;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedItem = this.TB2;

        }

        private void textBoxNouveauCommentaire_GotFocus(object sender, RoutedEventArgs e)
        {
            this.textBoxNouveauCommentaire.Text = "";
        }

        private void textBoxNouveauCommentaire_LostFocus(object sender, RoutedEventArgs e)
        {
            if(this.textBoxNouveauCommentaire.Text == "")
                this.textBoxNouveauCommentaire.Text = "Commentaire";
        }
    }
}
