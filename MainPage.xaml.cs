using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Text.RegularExpressions;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace GPA_Calculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Calculate_Btn_Click(object sender, RoutedEventArgs e)
        {
           

            // TODO: Handle no input. If you leave any of the textbox blank you're fucked. 
            #region Declare and retrieve class credits for classes 1-6
            int class1Credits;
            int class2Credits;
            int class3Credits;
            int class4Credits;
            int class5Credits;
            int class6Credits;
            if (validateCreditsInput(class1CreditsTxtBox.Text))
                class1Credits = Convert.ToInt32(class1CreditsTxtBox.Text);
            else
            {
                class1CreditsTxtBox.Text = ""; 
                class1Credits = 0;
            }

            if (validateCreditsInput(class2CreditsTxtBox.Text))
                class2Credits = Convert.ToInt32(class2CreditsTxtBox.Text);
            else
            {
                class2CreditsTxtBox.Text = ""; 
                class2Credits = 0;
            }

            if (validateCreditsInput(class3CreditsTxtBox.Text))
                class3Credits = Convert.ToInt32(class3CreditsTxtBox.Text);
            else
            {
                class3CreditsTxtBox.Text = "";
                class3Credits = 0;
            }

            if (validateCreditsInput(class4CreditsTxtBox.Text))
                class4Credits = Convert.ToInt32(class4CreditsTxtBox.Text);
            else
            {
                class4CreditsTxtBox.Text = "";
                class4Credits = 0;
            }

            if (validateCreditsInput(class5CreditsTxtBox.Text))
                class5Credits = Convert.ToInt32(class5CreditsTxtBox.Text);
            else
            {
                class5CreditsTxtBox.Text = "";
                class5Credits = 0;
            }

            if (validateCreditsInput(class6CreditsTxtBox.Text))
                class6Credits = Convert.ToInt32(class6CreditsTxtBox.Text);
            else
            {
                class6CreditsTxtBox.Text = "";
                class6Credits = 0;
            }
            #endregion

            #region Declare and retrieve class grades for classes 1-6
            string class1Grade;
            string class2Grade;
            string class3Grade;
            string class4Grade;
            string class5Grade;
            string class6Grade;

            if (validateGradesInput(class1GradeTxtBox.Text))
                class1Grade = class1GradeTxtBox.Text.ToUpper();
            else
            {
                class1GradeTxtBox.Text = ""; 
                class1Grade = "";
            }

            if (validateGradesInput(class2GradeTxtBox.Text))
                class2Grade = class2GradeTxtBox.Text.ToUpper();
            else
            {
                class2GradeTxtBox.Text = "";
                class2Grade = "";
            }

            if (validateGradesInput(class3GradeTxtBox.Text))
                class3Grade = class3GradeTxtBox.Text.ToUpper();
            else
            {
                class3GradeTxtBox.Text = "";
                class3Grade = "";
            }

            if (validateGradesInput(class4GradeTxtBox.Text))
                class4Grade = class4GradeTxtBox.Text.ToUpper();
            else
            {
                class4GradeTxtBox.Text = "";
                class4Grade = "";
            }

            if (validateGradesInput(class5GradeTxtBox.Text))
                class5Grade = class5GradeTxtBox.Text.ToUpper();
            else
            {
                class5GradeTxtBox.Text = "";
                class5Grade = "";
            }

            if (validateGradesInput(class6GradeTxtBox.Text))
                class6Grade = class6GradeTxtBox.Text.ToUpper();
            else
            {
                class6GradeTxtBox.Text = "";
                class6Grade = "";
            } 
            #endregion

            #region Put all of the classes into Class objects & put them in the array
            Class class1 = new Class() { credits = class1Credits, grade = class1Grade };

            Class class2 = new Class() { credits = class2Credits, grade = class2Grade };

            Class class3 = new Class() { credits = class3Credits, grade = class3Grade };

            Class class4 = new Class() { credits = class4Credits, grade = class4Grade };

            Class class5 = new Class() { credits = class5Credits, grade = class5Grade };

            Class class6 = new Class() { credits = class6Credits, grade = class6Grade };
            #endregion

            Class[] classes = { class1, class2, class3, class4, class5, class6 };  // an array of Class objects. Effectively, a class schedule. 

            #region Iterate through class schedule and calculate GPA
            int totalCredits = 0;
            double totalGPAPoints = 0;
            double letterGradeAsDouble = 0;

            foreach (Class cl in classes)
            {
                // Calculate the total GPA credits for the class by credits*grade
                switch (cl.grade)
                {
                    case "A":
                        letterGradeAsDouble = 4.0;
                        break;
                    case "A-":
                        letterGradeAsDouble = 3.67;
                        break;
                    case "B+":
                        letterGradeAsDouble = 3.33;
                        break;
                    case "B":
                        letterGradeAsDouble = 3.0;
                        break;
                    case "B-":
                        letterGradeAsDouble = 2.67;
                        break;
                    case "C+":
                        letterGradeAsDouble = 2.33;
                        break;
                    case "C-":
                        letterGradeAsDouble = 2.0;
                        break;
                    case "D+":
                        letterGradeAsDouble = 1.33;
                        break;
                    case "D":
                        letterGradeAsDouble = 1.0;
                        break;
                    case "D-":
                        letterGradeAsDouble = .67;
                        break;
                    case "F":
                        letterGradeAsDouble = 0.0;
                        break;
                    default:
                        letterGradeAsDouble = 0.0;
                        break;
                }

                totalGPAPoints += (letterGradeAsDouble) * (cl.credits);
                totalCredits += cl.credits;

            }

            double GPA = totalGPAPoints / totalCredits;
            gpaTxtBlock.Text = "GPA: " + GPA;
            #endregion
        }

        private void TextBlock_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            // Drop down a textbox allowing user to edit class name
            (sender as TextBlock).Text = "New name";    // Dumbie Proof of Concept line
        }

        public bool validateCreditsInput(string input)
        {
            // return True if valid integer 1-9
            string numbers = "[1-9]";
            int inputAsInt = 0;
            if(input != "")
                inputAsInt = Convert.ToInt32(input); 
            Match match = Regex.Match(input, numbers, RegexOptions.IgnoreCase);
            if (match.Success && inputAsInt < 10)
                return true; 

            return false; 
        }

        public bool validateGradesInput(string input)
        {
            // return True if valid grade A-F including +/- grades
            // This code is ugly and inefficient, but hey it works 
            input = input.ToUpper();    // convert to upper case
            if (input == "A" ||
                input == "A-" ||
                input == "B+" ||
                input == "B" ||
                input == "B-" ||
                input == "C+" ||
                input == "C" ||
                input == "C-" ||
                input == "D+" ||
                input == "D" ||
                input == "D-" ||
                input == "F")
                return true; 
            return false; 
        }
    
    }
}
