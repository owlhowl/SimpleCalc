using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            if (isReady == true | textBox.Text == "0")
            {
                textBox.Text = "";
                isReady = false;
            }
                textBox.Text += ((Button)sender).Content;
        }

        private void Dot_Click(object sender, RoutedEventArgs e)
        {
            if (!textBox.Text.Contains(','))
                textBox.Text += ",";
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            textBox.Text = "0";
        }

        double n1;
        double n2;
        string op;
        bool isReady = false;

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            op = ((Button)sender).Content.ToString();
            if (textBox.Text != "0" & !textBox.Text.Contains(op))
            {
                double.TryParse(textBox.Text, out n1);
                textBox.Text += $"\n{op}";
                isReady = true;
            }
        }

        private void Solve_Click(object sender, RoutedEventArgs e)
        {
            if (isReady == false & textBox.Text != "0" & op != null)
            {
                double.TryParse(textBox.Text, out n2);
                switch (op)
                {
                    case "+":
                        n1 = n1 + n2;
                        break;
                    case "*":
                        n1 = n1 * n2;
                        break;
                    case "-":
                        n1 = n1 - n2;
                        break;
                    case "/":
                        n1 = n1 / n2;
                        break;
                    case "%":
                        n1 = n1 * n2 / 100;
                        break;
                }
                textBox.Text = n1.ToString();
                op = null;
                isReady = true;
            }
        }
    }
}