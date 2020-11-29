using System;
using System.Collections.Generic;
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

namespace Calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static List<double> calculate = new List<double>();
        public static List<string> method = new List<string>();
        string value = "";
        double resultShow = 1;
        double result = 0;


        public MainWindow()
        {
            InitializeComponent();
            Screen.FontSize = 40;
            Screen.TextAlignment = (TextAlignment)1;

        }

        private void Ce_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = string.Empty; 
            calculate.Clear();
            method.Clear();
            value = "";
        } // tar bort allt

        private void Sqrt_Click(object sender, RoutedEventArgs e)
        {
            remResult();
            Screen.Text += "√"; // skriver ut roten ut tecken
            method.Add("√"); // lägger in roten ur i en lista
           
        } // roten ur

        private void Sqr_Click(object sender, RoutedEventArgs e)
        {
            if (checkNumber()) // kollar att ett tal har tryckts innan
            {
                Screen.Text += "^";
                method.Add("^");
            }
        }  // hupphöjt med

        private void Div_Click(object sender, RoutedEventArgs e)
        {
            if (checkNumber())
            {
                Screen.Text += "/";
                method.Add("/");
            }
        } // dividerar

        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            remResult(); // tar bort resultatet från screen
            Screen.Text += "7";
            value += "7";
        } // skriver ut en sjua

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            remResult();
            Screen.Text += "8";
            value += "8";
        } // skriver ut en åtta

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            remResult();
            Screen.Text += "9";
            value += "9";
        } // skriver ut en nia

        private void Multi_Click(object sender, RoutedEventArgs e)
        {
            if (checkNumber())
            {
                Screen.Text += "*";
                method.Add("*");
                value = "";
            }
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            remResult();
            Screen.Text += "4";
            value += "4";
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            remResult();
            Screen.Text += "5";
            value += "5";
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            remResult();
            Screen.Text += "6";
            value += "6";
        }

        private void Neg_Click(object sender, RoutedEventArgs e)
        {
            if (checkNumber())
            {
                Screen.Text += "-";
                method.Add("-");
            }
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            remResult();
            Screen.Text += "1";
            value += "1";
        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            remResult();
            Screen.Text += "2";
            value += "2";
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            remResult();
            Screen.Text += "3";
            value += "3";
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            if (checkNumber())
            {
                Screen.Text += "+";
                method.Add("+");
            }

        }

        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            remResult();
            Screen.Text += 0;
            value += "0";
        }

        private void Com_Click(object sender, RoutedEventArgs e)
        {
            if (checkNumber())
            {
                Screen.Text += ",";
                value += ",";
            }
        } // skriver ut comma

        private void Answer_Click(object sender, RoutedEventArgs e)
        {
            remResult();
            Screen.Text += result;
            value += result;
        } // skriver ut resultatet igen

        private void Exe_Click(object sender, RoutedEventArgs e)
        {
            result = 0;
            if (!(calculate.Count == 0) || method.Contains("√")) // kollar att det finns något att räkna ut
            {
                checkMultiple(); // kollar så att det finns mer än ett tal
                remResult();
                double valueSqrt = Convert.ToDouble(value); // gör om value till en dubbel

                if (method.Contains("√")) // räknar ut roten ur
                {
                    for (int i = 0; i < 1; i++)
                    {
                        result = Math.Sqrt(valueSqrt);
                    }
                }

                calculate.Add(valueSqrt);

                value = "";
                Screen.Text = string.Empty;

                if (method.Contains("+"))
                {
                    for (int i = 0; i < calculate.Count; i++)
                    {
                        result = calculate[i] + result;
                    }
                } // räknar ut plus
                else if (method.Contains("*"))
                {
                    result = 1;
                    for (int i = 0; i < calculate.Count; i++)
                    {
                        result = calculate[i] * result;
                    }
                } // räknar ut multiplikation
                else if (method.Contains("-"))
                {
                        result = calculate[0] - calculate[1];
                    
                } // räknar ut suptration
                else if (method.Contains("/"))
                {
                    result = calculate[0] / calculate[1];
                } // räknar ut division
                else if (method.Contains("^"))
                {
                    for (int i = 0; i < 1; i++)
                    {
                        result = Math.Pow(calculate[i], calculate[i + 1]);
                    }
                } // räknar ut upphöjd med
               
                calculate.Clear(); // tar bort allt från calculate listan
                method.Clear(); // tar bort allt från method listan
                resultShow = result; // säger att talen är samma

                if (result == 69) // kollar om resultatet är 69
                {
                    Screen.Text += "Nice"; // Nice
                }
                else
                {
                    Screen.Text += result; // skriver ut resultatet
                }
            }
        }

        private void checkMultiple() // Kollar om man har skrivit två tal
        {
                if (value == string.Empty)
                {
                    if (method.Contains("+") || method.Contains("-") || method.Contains("√"))
                    {
                        value += 0; // skriver ut 0 om man inte har skrivit ut ett tal
                    }
                    else if (method.Contains("*") || method.Contains("^"))
                    {
                        value += 1;
                    } 
                }
        }

        private bool checkNumber()
        {
            bool y;

            if (value == "") // kollar om man har skrivit ett tal innan en metod
            {
                y = false;
            }
            else
            {
                y = true;
                calculate.Add(Convert.ToDouble(value));
                value = "";

            }

            return y;
        }

        private void remResult()
        {
            if (result == resultShow  && !(method.Contains("√"))) // kollar om resultatet står vid skärmen och vid sånna fall tar bort talet
            {
                Screen.Text = string.Empty;
                if (result == 1) // gör om talet till 0 om resultaten inte är ett
                {
                    resultShow = 0;
                }
                else
                {
                    resultShow = 1; // gör om talet till 1 om resultatet är 0
                }
            }
        }
    }
}
