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
            if (this.lvMission.SelectedItem != null && this.lvMission.SelectedItems.Count == 1)
            {
                this.ChangeNom.Text = ((MISSION)this.lvMission.SelectedItem).LibelleMission;
            }
        }




        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            if (this.lvMission.SelectedItem != null)
            {
                foreach (MISSION m in this.lvMission.SelectedItems)
                {
                    m.Delete();
                }
            }
            Actualise();
        }
        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            MISSION g = new MISSION();
            g.Create();
            Actualise();
            videText();
        }
        private void NomTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            videText();
        }
        public void videText()
        {
            this.NomTextBox.Text = "";

        }

        

        private void ModifierButton_Click(object sender, RoutedEventArgs e)
        {

            if (this.lvMission.SelectedItem != null && this.lvMission.SelectedItems.Count == 1)
            {
                ((MISSION)this.lvMission.SelectedItem).LibelleMission = this.ChangeNom.Text;
                ((MISSION)this.lvMission.SelectedItem).Update();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionnez un seul corps d'armée à modifier", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Actualise();
        }
    }
}
