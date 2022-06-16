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

        private void DeleteCA_Click_1(object sender, RoutedEventArgs e)
        {
            if ((CORPS_ARMEE)this.lvCorpsArmee.SelectedItem != null)
            {
                foreach (CORPS_ARMEE g in this.lvCorpsArmee.SelectedItems)
                {
                    g.Delete();
                }
                Actualise();
            }
            else
            {
                MessageBox.Show("Selectionner un corps d'armée", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lvCorpsArmee.SelectAll();
        }

        public void Actualise()
        {
            this.applicationData = new ApplicationData();
            this.DataContext = applicationData;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        /*private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            if (this.lvAffectation.SelectedItem != null)
            {
                foreach (AFFECTATION a in this.lvAffectation.SelectedItems)
                {
                    a.Delete();
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionnez une mission à supprimer !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Actualise();
        }*/
        private void ModifierButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.lvAffectations.SelectedItems.Count == 1)
            {
                ((AFFECTATION)this.lvAffectations.SelectedItem).Commentaire = this.textBoxDate.Text;
                ((AFFECTATION)this.lvAffectations.SelectedItem).DateMission = this.CalendarAffectation.SelectedDate.Value;
                ((AFFECTATION)this.lvAffectations.SelectedItem).Update();

                Actualise();
            }
        }
        private void lvAffectations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.lvAffectations.SelectedItems.Count == 1)
            {
                this.textBoxDate.Text = ((AFFECTATION)this.lvAffectations.SelectedItem).Commentaire;
                this.CalendarAffectation.SelectedDate = ((AFFECTATION)this.lvAffectations.SelectedItem).DateMission;
                this.sexe.Content = ((AFFECTATION)this.lvAffectations.SelectedItem).DateMission;
            }
        }

        private void BoutonSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (this.lvAffectations.SelectedItems.Count == 1)
            {
                ((AFFECTATION)this.lvAffectations.SelectedItem).Delete();
            }

        }
    }
}
