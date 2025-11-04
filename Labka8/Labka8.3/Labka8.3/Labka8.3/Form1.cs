using System;
using System.Windows.Forms;

namespace QuizApp
{
    public partial class Form1 : Form
    {
        // Enum of clothing types
        enum ClothingType
        {
            Household,
            Casual,
            Ceremonial,
            Sports,
            Workwear,
            Stage,
            Uniform
        }

        public Form1()
        {
            InitializeComponent();
            cmbClothingType.DataSource = Enum.GetValues(typeof(ClothingType));
        }

        private void btnShowInfo_Click(object sender, EventArgs e)
        {
            if (cmbClothingType.SelectedItem == null)
            {
                MessageBox.Show("Please select a clothing type!", "Warning");
                return;
            }

            ClothingType selectedType = (ClothingType)cmbClothingType.SelectedItem;
            string result = GetClothingInfo(selectedType);
            txtOutput.Text = result;
        }

        private string GetClothingInfo(ClothingType type)
        {
            string info = "";
            switch (type)
            {
                case ClothingType.Household:
                    info = "Household clothing is worn at home.\n" +
                           "Events: watching TV, cooking, cleaning.";
                    break;

                case ClothingType.Casual:
                    info = "Casual clothing is for work, studying, or walking.\n" +
                           "Events: university, shopping, walks, exhibitions.";
                    break;

                case ClothingType.Ceremonial:
                    info = "Ceremonial clothing is for celebrations or receptions.\n" +
                           "Events: theater, weddings, parties.";
                    break;

                case ClothingType.Sports:
                    info = "Sportswear is used for physical activity.\n" +
                           "Events: gym, running, team sports.";
                    break;

                case ClothingType.Workwear:
                    info = "Workwear is used for industrial or medical jobs.\n" +
                           "Events: factory, construction site, hospital.";
                    break;

                case ClothingType.Stage:
                    info = "Stage clothing is used in performance arts.\n" +
                           "Events: theater, concerts, circus.";
                    break;

                case ClothingType.Uniform:
                    info = "Uniform defines affiliation with an organization.\n" +
                           "Events: military duty, fire department, police.";
                    break;

                default:
                    info = "Unknown clothing type.";
                    break;
            }
            return info;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();
            cmbClothingType.SelectedIndex = -1;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
