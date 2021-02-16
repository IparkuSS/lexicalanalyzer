using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
namespace lexicalanalyzer
{
    public partial class MainWindow : Window
    {
        public List<Expression> list = new List<Expression>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
           ChekOper();
        }

        public void ChekOper()
        {
            Expression expression = new Expression();
            List<object> listError = new List<object>();
            List<object> listErrorCheck = new List<object>();
            expression.EpresId = ChekIndex(ref listError, ref listErrorCheck);
            expression.Epres16 = Chek16(ref listError, ref listErrorCheck);
           
            if (ChekEroor(ref listError, ref listErrorCheck) == true)
            {

                for (int i = 0; i < InputTextBox.Text.Length; i++)
                {
                    if (InputTextBox.Text[i] == '+') expression.EpresPLus++;
                    if (InputTextBox.Text[i] == '-') expression.EpresMinus++;
                    if (InputTextBox.Text[i] == '/') expression.EpresDel++;
                    if (InputTextBox.Text[i] == '*') expression.EpresUmn++;
                    if (InputTextBox.Text[i] == '=') expression.EpresPrs++;
                    if (InputTextBox.Text[i] == '(') expression.EpresParantOpen++;
                    if (InputTextBox.Text[i] == ')') expression.EpresParantClouse++;
                }
                if (CheckEroorInSm() == true)
                {
                    if (expression.EpresParantOpen == expression.EpresParantClouse && expression.EpresPrs != 0)
                    {
                        list.Add(expression);
                        Grid.ItemsSource = list;
                        TBEr.Visibility = Visibility.Collapsed;
                        TBSc.Visibility = Visibility.Visible;
                    }
                    else { TBEr.Visibility = Visibility.Visible; TBSc.Visibility = Visibility.Collapsed; }
                }
                else { TBEr.Visibility = Visibility.Visible; TBSc.Visibility = Visibility.Collapsed; }
            }
            else { TBEr.Visibility = Visibility.Visible; TBSc.Visibility = Visibility.Collapsed; }

        }

        public bool CheckEroorInSm()
        {

            List<bool> listBool = new List<bool>();


            foreach (Match match in Regex.Matches
                (InputTextBox.Text, @"\w+\D[-+*/]\w+")) listBool.Add(match.Success);


            foreach (Match match in Regex.Matches
              (InputTextBox.Text, @"\w+\D[=]\w+")) listBool.Add(match.Success);


            foreach (Match match in Regex.Matches
            (InputTextBox.Text, @"[^0-9-+*/()=A-Za-z; ]+")) listBool.Add(match.Success);

            for (int i = 0; i < listBool.Count; i++)
                if (listBool[i] == true) return false;

            return true;

        }
        public bool ChekEroor(ref List<object> listError, ref List<object> listError1)
        {
            foreach (Match match in Regex.Matches(InputTextBox.Text, @"\b\w+\b")) 
                listError.Add(match.Groups);



            if (listError.Count == listError1.Count) return true;
            return false;
        }


        public string ChekIndex(ref List<object> listError, ref List<object> listErrorCheck)
        {
            string Temp = default;
            foreach (Match match in Regex.Matches(InputTextBox.Text,
                  @"\b([A-Za-z]{1}\w+)\b"))
            {
                Temp += $"{ match.Value};";
                listErrorCheck.Add(match.Groups);
            }
            return Temp;
        }
        public string Chek16(ref List<object> listError, ref List<object> listErrorCheck)
        {
            string Temp = default;
            foreach (Match match in Regex.Matches(InputTextBox.Text.ToString(),
                @"\b([0-9]{1}[A-Fa-f0-9]{0,1}[A-Fa-f]{0,2})\b"))
            {
                Temp += $"{ match.Value};";
                listErrorCheck.Add(match.Groups);
            }
            return Temp;
        }

    }
}
