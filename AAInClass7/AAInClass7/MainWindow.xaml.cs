using System;
using System.IO;
using System.Windows;

namespace AAInClass7
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ReadFileButton_Click(object sender, RoutedEventArgs e)
        {
            string sourceFilePath = "source.txt"; // Source file name indicated to match
            string studentName = StudentNameTextBox.Text.Trim(); // Get the input from the text box

            // Check if the student name is provided
            if (string.IsNullOrWhiteSpace(studentName))
            {
                StatusTextBlock.Text = "Please enter a valid student name.";
                return;
            }

            // Combine to create the student folder using the provided name
            string studentFolder = Path.Combine(Directory.GetCurrentDirectory(), studentName);
            string destinationFilePath = Path.Combine(studentFolder, "copiedFile.txt");

            try
            {
                // Check if source file exists
                if (!File.Exists(sourceFilePath))
                {
                    StatusTextBlock.Text = $"Source file '{sourceFilePath}' not found.";
                    return;
                }

                // Create the subfolder if it doesn't exist
                if (!Directory.Exists(studentFolder))
                {
                    Directory.CreateDirectory(studentFolder);
                }

                // Read the contents of the source file
                string fileContents = File.ReadAllText(sourceFilePath);
                ContentTextBox.Text = fileContents; // To display contents in the TextBox

                // Write to the new file in the student folder
                File.WriteAllText(destinationFilePath, fileContents);
                StatusTextBlock.Text = $"File copied successfully to '{destinationFilePath}'.";
            }
            catch (Exception ex)
            {
                StatusTextBlock.Text = $"An error occurred: {ex.Message}";
            }
        }
    }
}