using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labo3
{
    /// <summary>
    /// Form1, contenant tout les composantes de ma fenetre
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initialisation des composantes
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        /// <summary>
        /// Méthode du bouton enregistrer, validation de chaque composante avant de rénitialiser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn1_Click(object sender, EventArgs e)
        {
            bool estValide = true;
            int compteur = 0;

            estValide = Validation_TxtBox1();
            if (estValide)
            {
                compteur++;
            }

            estValide = Validation_TxtBox2();
            if (estValide)
            {
                compteur++;
            }

            estValide = Validation_TxtBox3();
            if (estValide)
            {
                compteur++;
            }

            estValide = Validation_ComboBox1();
            if (estValide)
            {
                compteur++;
            }

            estValide = Validation_CheckedListBox1();
            if (estValide)
            {
                compteur++;
            }

            estValide = Validation_Pnl1();
            if (estValide)
            {
                compteur++;
            }

            if (compteur == 6)
            {
                //Renitialiser
                Renitialisation();
            }
        }

        /// <summary>
        /// Méthode pour la validation du TxtBox1
        /// </summary>
        /// <returns></returns>
        private bool Validation_TxtBox1()
        {
            ErrorProvider1.SetError(TxtBox1, "");
            bool estValide = true;

            TxtBox1.Text = TxtBox1.Text.Trim();
            if (String.IsNullOrEmpty(TxtBox1.Text))
            {
                estValide = false;
                ErrorProvider1.SetError(TxtBox1, "Le champ ne peut être vide");
            }


            foreach (char c in TxtBox1.Text)
            {
                if (!char.IsLetter(c))
                {
                    estValide = false;
                    ErrorProvider1.SetError(TxtBox1, "Le nom est composé seuleument de lettres.");
                }
            }
            return estValide;
        }


        /// <summary>
        /// Méthode pour la validation du TxtBox2
        /// </summary>
        /// <returns></returns>
        private bool Validation_TxtBox2()
        {
            ErrorProvider1.SetError(TxtBox2, "");
            bool estValide = true;
            TxtBox2.Text = TxtBox2.Text.Trim();

            if (String.IsNullOrEmpty(TxtBox2.Text))
            {
                estValide = false;
                ErrorProvider1.SetError(TxtBox2, "Le champ ne peut être vide");
            }

            foreach (char c in TxtBox2.Text)
            {
                if (!Char.IsDigit(c))
                {
                    estValide = false;
                    ErrorProvider1.SetError(TxtBox2, "Le numéro est composé de chiffres.");
                }
            }

            if (estValide)
            {
                if (int.Parse(TxtBox2.Text) > 809)
                {
                    estValide = false;
                    ErrorProvider1.SetError(TxtBox2, "Le maximum est de 809");
                }
            }

            return estValide;
        }


        /// <summary>
        /// Méthode pour la validation du TxtBox3
        /// </summary>
        /// <returns></returns>
        private bool Validation_TxtBox3()
        {
            ErrorProvider1.SetError(TxtBox3, "");
            bool estValide = true;
            TxtBox3.Text = TxtBox3.Text.Trim();

            if (TxtBox3.Enabled)/// Si le pokémon est attrapé
            {
                if (String.IsNullOrEmpty(TxtBox3.Text))
                {
                    estValide = false;
                    ErrorProvider1.SetError(TxtBox3, "Le champ ne peut être vide");
                }

                //Code défectueux
                //foreach (char c in TxtBox3.Text)
                //{
                //    if (!Char.IsLetter(c))
                //    {
                //        estValide = false;
                //        ErrorProvider1.SetError(TxtBox3, "Le nom du propriétaire est composé seuleument de lettres.");
                //    }
                //}
            }

            return estValide;
        }


        /// <summary>
        /// Méthode pour la validation du ComboBox1
        /// </summary>
        /// <returns></returns>
        private bool Validation_ComboBox1()
        {
            ErrorProvider1.SetError(ComboBox1, "");
            bool estValide = true;
            if (ComboBox1.SelectedIndex == -1)
            {
                estValide = false;
                ErrorProvider1.SetError(ComboBox1, "Veuillez sélectionner un élement");
            }

            return estValide;
        }


        /// <summary>
        /// Méthode pour la validation du CheckedListBox (élements)
        /// </summary>
        /// <returns></returns>
        private bool Validation_CheckedListBox1()
        {
            ErrorProvider1.SetError(CheckedListBox1, "");
            bool estValide = true;

            if (CheckedListBox1.CheckedItems.Count > 2)
            {
                estValide = false;
                ErrorProvider1.SetError(CheckedListBox1, "Le maximum est de 2");
            }

            if (CheckedListBox1.CheckedItems.Count < 1)
            {
                estValide = false;
                ErrorProvider1.SetError(CheckedListBox1, "Veuillez sélectionner au minimum 1 élement");
            }

            return estValide;
        }


        /// <summary>
        /// Méthode pour la validation du Pnl1, contenant les radio buttons
        /// </summary>
        /// <returns></returns>
        private bool Validation_Pnl1()
        {
            ErrorProvider1.SetError(Pnl1, "");
            bool estValide = true;

            if (!RadioBtn1.Checked && !RadioBtn2.Checked)
            {
                estValide = false;
                ErrorProvider1.SetError(Pnl1, "Veuillez sélectionner un genre");
            }

            return estValide;
        }


        /// <summary>
        /// Méthode de rénitialisation de la fenetre
        /// </summary>
        private void Renitialisation()
        {
            MessageBox.Show("Le pokémon " + TxtBox1.Text + " est enregistré avec succès. \n", "Enregistrement");

            //Rénitialiser le tout
            TxtBox1.Clear();
            TxtBox2.Clear();
            TxtBox3.Clear();
            ComboBox1.SelectedItem = null;
            CheckedListBox1.SelectedItem = null;
            RadioBtn1.Checked = false;
            RadioBtn2.Checked = false;
            CheckBox1.Checked = false;
            Lbl6.Enabled = false;
            TxtBox3.Enabled = false;

            foreach (int i in CheckedListBox1.CheckedIndices)
            {
                CheckedListBox1.SetItemCheckState(i, CheckState.Unchecked);
            }
        }


        /// <summary>
        /// Méthode pour l'activation du champ Nom du propriétaire si le pokémon est attrapé.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (CheckBox1.Checked)
            {
                Lbl6.Enabled = true;
                TxtBox3.Enabled = true;
            }
            else
            {
                Lbl6.Enabled = false;
                TxtBox3.Enabled = false;
            }
        }


        /// <summary>
        /// Méthode pour ajuster le CheckedBoxList (2 sélection maximum)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked && CheckedListBox1.CheckedItems.Count >= 2)
                e.NewValue = CheckState.Unchecked;
        }
    }
}
