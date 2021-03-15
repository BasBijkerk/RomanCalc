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

namespace RomanCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 



    public partial class MainWindow : Window
    {
        public List<string> RomanInput1 = new List<string>();
        public List<string> RomanInput2 = new List<string>();
        public List<int> RomanValues = new List<int>();
        public List<string> RomanChars = new List<string>();
        public string RomVal1 = "";
        public string RomVal2 = "";
        public int val1 = 0;
        public int val2 = 0;
        public bool HasFirstValue = false;

        public bool doPlus = false;
        public bool doMin = false;
        public bool doMulti = false;
        public bool doDiv = false;

        public bool Euro = false;
        public bool Pct = false;


        public string ActualValue;

        public MainWindow()
        {
            InitializeComponent();
            RomanValues.Add(1);     RomanChars.Add("I");
            RomanValues.Add(5);     RomanChars.Add("V");
            RomanValues.Add(10);    RomanChars.Add("X");
            RomanValues.Add(50);    RomanChars.Add("L");
            RomanValues.Add(100);   RomanChars.Add("C");
            RomanValues.Add(500);   RomanChars.Add("D");
            RomanValues.Add(1000);  RomanChars.Add("M");
        }






        private void Button_Click_Min(object sender, RoutedEventArgs e)
        {
            CalculateRoman(ValueIO.Text, true, false);   
            doMin = true;
        }

        private void Button_Click_Plus(object sender, RoutedEventArgs e)
        {

            CalculateRoman(ValueIO.Text, true, false);
            doPlus = true;
        }
        private void Button_Click_Multiply(object sender, RoutedEventArgs e)
        {

            CalculateRoman(ValueIO.Text, true, false);
            doMulti = true;
        }

        private void Button_Click_Divide(object sender, RoutedEventArgs e)
        {

            CalculateRoman(ValueIO.Text, true, false);
            doDiv = true;
        }
        private void Button_Click_Equals(object sender, RoutedEventArgs e)
        {
            CalculateRoman(ValueIO.Text, false, false);
            CalculateRoman(ValueIO.Text, false, true);

        }


        private void Clear()
        {
            numval.Content = "V: ";
            numval2.Content = "";
            RomanInput1.Clear();
            RomanInput2.Clear();
            RomVal1 = "";
            RomVal2 = "";
            val1 = 0;
            val2 = 0;
            ValueIO.Text = "";
            ValueIn.Content = "";


            HasFirstValue = false;

            doPlus = false;
            doMin = false;
            doMulti = false;
            doDiv = false;
        }
        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            Clear();
        }




        // Value Input Buttons 0 to 9



        private void CalculateRoman(string romanval, bool firstvalue, bool fromto)
        {
            numval2.Content = "";
            if (firstvalue && !fromto)
            {
                RomanInput1.Clear();
                foreach (Char roman in romanval)
                {
                    RomanInput1.Add(roman.ToString());
                }
                ValueIO.Text = "";
                if(RomanInput1.Count == romanval.Length)
                {

                
                    for (int i = 0; i < RomanInput1.Count; i++)
                    {
                        if(val1 != 0)
                        {
                            if (!HasFirstValue && i < RomanInput1.Count - 1 && RomanValues[RomanChars.IndexOf(RomanInput1[i])] < RomanValues[RomanChars.IndexOf(RomanInput1[i + 1])])
                            {
                                val1 += RomanValues[RomanChars.IndexOf(RomanInput1[i + 1])] - RomanValues[RomanChars.IndexOf(RomanInput1[i])];
                                i++;
                                HasFirstValue = true;
                            }
                            if (!HasFirstValue && i < RomanInput1.Count - 1 && RomanValues[RomanChars.IndexOf(RomanInput1[i])] > RomanValues[RomanChars.IndexOf(RomanInput1[i + 1])])
                            {
                                val1 += RomanValues[RomanChars.IndexOf(RomanInput1[i])] + RomanValues[RomanChars.IndexOf(RomanInput1[i + 1])];
                                i++;
                                HasFirstValue = true;
                            }
                            if (!HasFirstValue && i < RomanInput1.Count - 1 && RomanInput1[i] != null)
                            {
                                val1 += RomanValues[RomanChars.IndexOf(RomanInput1[i])];
                                HasFirstValue = true;
                            }
                            if (!HasFirstValue && i == RomanInput1.Count - 1 && RomanInput1[i] != null)
                            {
                                val1 += RomanValues[RomanChars.IndexOf(RomanInput1[i])];
                                HasFirstValue = true;
                            }
                            HasFirstValue = false;
                        }
                        if (val1 == 0)
                        {
                            if (!HasFirstValue)
                            {
                                val1 += RomanValues[RomanChars.IndexOf(RomanInput1[i])];
                                //i++;
                                //HasFirstValue = true;

                            }
                            
                        }
                        numval.Content = "V: " + val1;
                        
                    }
                    
                }

            }
            if (!firstvalue && !fromto)
            {
                RomanInput2.Clear();
                val2 = 0;
                foreach (Char roman in romanval)
                {
                    RomanInput2.Add(roman.ToString());
                }
                ValueIO.Text = "";
                if (RomanInput2.Count == romanval.Length)
                {


                    for (int i = 0; i < RomanInput2.Count; i++)
                    {
                        if (val2 != 0)
                        {
                            if (!HasFirstValue && i < RomanInput2.Count - 1 && RomanValues[RomanChars.IndexOf(RomanInput2[i])] < RomanValues[RomanChars.IndexOf(RomanInput2[i + 1])])
                            {
                                val2 += RomanValues[RomanChars.IndexOf(RomanInput2[i + 1])] - RomanValues[RomanChars.IndexOf(RomanInput2[i])];
                                i++;
                                HasFirstValue = true;
                            }
                            if (!HasFirstValue && i < RomanInput2.Count - 1 && RomanValues[RomanChars.IndexOf(RomanInput2[i])] > RomanValues[RomanChars.IndexOf(RomanInput2[i + 1])])
                            {
                                val2 += RomanValues[RomanChars.IndexOf(RomanInput2[i])] + RomanValues[RomanChars.IndexOf(RomanInput2[i + 1])];
                                i++;
                                HasFirstValue = true;
                            }
                            if (!HasFirstValue && i < RomanInput2.Count - 1 && RomanInput2[i] != null)
                            {
                                val2 += RomanValues[RomanChars.IndexOf(RomanInput2[i])];
                                HasFirstValue = true;
                            }
                            if (!HasFirstValue && i == RomanInput2.Count - 1 && RomanInput2[i] != null)
                            {
                                val2 += RomanValues[RomanChars.IndexOf(RomanInput2[i])];
                                HasFirstValue = true;
                            }
                            HasFirstValue = false;
                        }
                        if (val2 == 0)
                        {
                            if (!HasFirstValue)
                            {
                                val2 += RomanValues[RomanChars.IndexOf(RomanInput2[i])];
                                //i++;
                                
                            }
                        }
                        numval.Content = "V: " + val1 + " - V2: " + val2;
                        
                    }

                }

            }
            if (fromto)
            {
                if (doMin)
                {
                    val1 = val1 - val2;
                    doMin = !doMin;


                }
                if (doPlus)
                {
                    val1 = val1 + val2;
                    doPlus = !doPlus;
                }
                if (doDiv)
                {
                    val1 = val1 / val2;
                    doDiv = !doDiv;
                }
                if (doMulti)
                {
                    val1 = val1 * val2;
                    doMulti = !doMulti;
                }
                val2 = 0;
                //valhodler = val1;
                ValueIO.Text = "";
                numval.Content = "V: " + val1;
                if (val1 >= 1000 && val1 <= 6000)
                {
                    for(int i = 0; val1 >= 1000; i++)
                    {
                        val1 -= 1000;
                        ValueIO.Text += RomanChars[RomanValues.IndexOf(1000)];
                    }
                }
                if (val1 >= 900 && val1 < 1000)
                {
                    for (int i = 0; val1 >= 900; i++)
                    {
                        val1 -= 900;
                        ValueIO.Text += RomanChars[RomanValues.IndexOf(100)] + RomanChars[RomanValues.IndexOf(1000)];
                    }
                }
                if (val1 >= 500 && val1 < 1000)
                {
                    for (int i = 0; val1 >= 500; i++)
                    {
                        val1 -= 500;
                        ValueIO.Text += RomanChars[RomanValues.IndexOf(500)];
                    }
                }
                if (val1 >= 400 && val1 < 500)
                {
                    for (int i = 0; val1 >= 400; i++)
                    {
                        val1 -= 400;
                        ValueIO.Text += RomanChars[RomanValues.IndexOf(100)] + RomanChars[RomanValues.IndexOf(500)];
                    }
                }
                if (val1 >= 100 && val1 < 400)
                {
                    for (int i = 0; val1 >= 100; i++)
                    {
                        val1 -= 100;
                        ValueIO.Text += RomanChars[RomanValues.IndexOf(100)];
                    }
                }
                if (val1 >= 90 && val1 < 100)
                {
                    for (int i = 0; val1 >= 90; i++)
                    {
                        val1 -= 90;
                        ValueIO.Text += RomanChars[RomanValues.IndexOf(10)] + RomanChars[RomanValues.IndexOf(100)];
                    }
                }
                if (val1 >= 50 && val1 < 90)
                {
                    for (int i = 0; val1 >= 50; i++)
                    {
                        val1 -= 50;
                        ValueIO.Text += RomanChars[RomanValues.IndexOf(50)];
                    }
                }
                if (val1 >= 10 && val1 < 50)
                {
                    for (int i = 0; val1 >= 10; i++)
                    {
                        val1 -= 10;
                        ValueIO.Text += RomanChars[RomanValues.IndexOf(10)];
                    }
                }
                if (val1 >= 9 && val1 < 10)
                {
                    for (int i = 0; val1 >= 9; i++)
                    {
                        val1 -= 9;
                        ValueIO.Text += RomanChars[RomanValues.IndexOf(1)] + RomanChars[RomanValues.IndexOf(10)];
                    }
                }
                if (val1 >= 5 && val1 < 9)
                {
                    for (int i = 0; val1 >= 5; i++)
                    {
                        val1 -= 5;
                        ValueIO.Text += RomanChars[RomanValues.IndexOf(5)];
                    }
                }
                if (val1 >= 1 && val1 < 5)
                {
                    for (int i = 0; val1 >= 1; i++)
                    {
                        val1 -= 1;
                        ValueIO.Text += RomanChars[RomanValues.IndexOf(1)];
                    }
                }
                if (val1 > 6000)
                {
                    numval.Content = "Error Cannot Display: " + val1 + " ";
                    numval2.Content = "Value Too High!";
                }
                
                //val1 = valhodler;
              
            }



        }
        private void Button_Click_0(object sender, RoutedEventArgs e)
        {
            ValueIO.Text += "I";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ValueIO.Text += "V";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ValueIO.Text += "X";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ValueIO.Text += "L";
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            ValueIO.Text += "C";
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            ValueIO.Text += "D";
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            ValueIO.Text += "M";
        }
    }
}
