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
        public ObservableCollection<CORPS_ARMEE> LesCorpsArmee { get; set; }
        private ApplicationData applicationData;
        public MainWindow()
        {
            LesCorpsArmee = new ObservableCollection<CORPS_ARMEE>();
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
                ((AFFECTATION)this.lvAffectations.SelectedItem).Commentaire = this.textBoxCommentaire.Text;
                ((AFFECTATION)this.lvAffectations.SelectedItem).DateMission = this.CalendarAffectation.SelectedDate.Value;
                ((AFFECTATION)this.lvAffectations.SelectedItem).Update();

                Actualise();
            }
        }
        private void lvAffectations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.lvAffectations.SelectedItems.Count == 1)
            {
                this.textBoxCommentaire.Text = ((AFFECTATION)this.lvAffectations.SelectedItem).Commentaire;
                this.CalendarAffectation.SelectedDate = ((AFFECTATION)this.lvAffectations.SelectedItem).DateMission;
                this.LabelDate.Content = ((AFFECTATION)this.lvAffectations.SelectedItem).DateMission;
            }
        }

        private void BoutonSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (this.lvAffectations.SelectedItems.Count == 1)
            {
                ((AFFECTATION)this.lvAffectations.SelectedItem).Delete();
            }
            Actualise();
        }

       

        private void BoutonAjouterAffectation_Click(object sender, RoutedEventArgs e)
        {
            AFFECTATION a = new AFFECTATION();
            if (this.ComboBoxDivision.SelectedItem == null || this.ComboBoxMission.SelectedItem == null || this.CalendarNouvelleAffectation.SelectedDate.Value == null)
                MessageBox.Show("Veuillez sélectionner un code division, un code mission et une date", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

            else
            {

                if (this.textBoxNouveauCommentaire.Text == null || this.textBoxNouveauCommentaire.Text == "Commentaire")
                    a = new AFFECTATION((DIVISION)this.ComboBoxDivision.SelectedItem ,(MISSION)this.ComboBoxMission.SelectedItem, this.CalendarNouvelleAffectation.SelectedDate.Value);
                else
                    a = new AFFECTATION((DIVISION)this.ComboBoxDivision.SelectedItem, (MISSION)this.ComboBoxMission.SelectedItem, this.CalendarNouvelleAffectation.SelectedDate.Value, this.textBoxNouveauCommentaire.Text);
                a.Create();
                Actualise();
                MainTabControl.SelectedItem = this.TB3;
            }

            this.Image4.Visibility = Visibility.Hidden;
        }

        private void ComboBoxDivision_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.ComboBoxDivision.SelectedItem != null)
            {
                this.Prout.Content = ((DIVISION)this.ComboBoxDivision.SelectedItem).CodeDivision;

                if (((DIVISION)this.ComboBoxDivision.SelectedItem).UncorpsArmee.CodeCorpsArmee == 16)
                {
                    this.Image1.Visibility = Visibility.Visible;
                    this.Image2.Visibility = Visibility.Hidden;
                    this.Image3.Visibility = Visibility.Hidden;
                    this.Image4.Visibility = Visibility.Hidden;
                }
                else if (((DIVISION)this.ComboBoxDivision.SelectedItem).UncorpsArmee.CodeCorpsArmee == 17)
                {
                    this.Image1.Visibility = Visibility.Hidden;
                    this.Image2.Visibility = Visibility.Visible;
                    this.Image3.Visibility = Visibility.Hidden;
                    this.Image4.Visibility = Visibility.Hidden;
                }
                else if (((DIVISION)this.ComboBoxDivision.SelectedItem).UncorpsArmee.CodeCorpsArmee == 18)
                {
                    this.Image1.Visibility = Visibility.Hidden;
                    this.Image2.Visibility = Visibility.Hidden;
                    this.Image3.Visibility = Visibility.Visible;
                    this.Image4.Visibility = Visibility.Hidden;
                }
                else if (((DIVISION)this.ComboBoxDivision.SelectedItem).UncorpsArmee.CodeCorpsArmee == 19)
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
    }
}
