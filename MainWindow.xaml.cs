/*
 * Oliver Byl
 * April 17, 2020
 * Unit 2 Summative (Problem J3)
 */
using System;
using System.Windows;
using System.IO;

namespace Unit2J3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                StreamReader reader = new StreamReader("input.txt");

                // Find number of lines from input:
                int.TryParse(reader.ReadLine(), out int lines);

                // Loop through all the lines of input:
                for(int i = 0; i < lines; i++)
                {
                    // Represent each line of input as a char array.
                    char[] line = reader.ReadLine().ToCharArray();

                    // Keep track of the current character we're on.
                    // (initialized to the first character of the line)
                    char currentChar = line[0];
                    // Keep track of the # of characters we've read.
                    // (initialized to its lowest possible value, 1)
                    int currentCharCount = 1;

                    for(int j = 1; j < line.Length; j++)
                    {
                        if(line[j] != currentChar)
                        {
                            // Begin tracking a new character by updating output and resetting variables.
                            output.Content += currentCharCount + " " + currentChar + " ";
                            currentChar = line[j];
                            currentCharCount = 1;
                        }
                        else
                        {
                            currentCharCount++;
                        }
                    }

                    output.Content += currentCharCount + " " + currentChar + Environment.NewLine;
                }

                reader.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
