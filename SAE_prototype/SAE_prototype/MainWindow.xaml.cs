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
            else
            {
                MessageBox.Show("Veuillez sélectionnez une mission à supprimer !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Actualise();
        }
        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            MISSION g = new MISSION();
            if (this.TextBoxCreate.Text != null && this.CommentaireCreate.Text == null || this.CommentaireCreate.Text == "Commentaire")
            {
                g = new MISSION(this.TextBoxCreate.Text, ((DIVISION)this.ComboBoxCreate.SelectedItem).CodeDivision, this.CalendrierCreate.DisplayDate); 
            }
            if (this.TextBoxCreate.Text != null && this.CommentaireCreate.Text != null && this.CommentaireCreate.Text != "Commentaire")
            {
                g = new MISSION(this.TextBoxCreate.Text, ((DIVISION)this.ComboBoxCreate.SelectedItem).CodeDivision, this.CalendrierCreate.DisplayDate,this.CommentaireCreate.Text);
            }
            else
            {
                MessageBox.Show("Veuillez indiquer un libellé, un code de division et une date valide !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            g.Create();
            Actualise();
            this.TextBoxCreate.Clear();
            this.CalendrierCreate.SelectedDate = DateTime.Now;
            this.CommentaireCreate.Text = "Commentaire";

        }
        private void NomTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            this.TextBoxCreate.Clear();
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
