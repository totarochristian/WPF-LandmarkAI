﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace LandmarkAI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectImageButton_Click(object sender, RoutedEventArgs e)
        {
            //Initialize a dialog to choose a file from the pc and then open it
            OpenFileDialog dialog = new OpenFileDialog();
            //Set dialog filters of which type of file the user could select
            dialog.Filter = "Image files (*.png; *.jpg)|*.png;*.jpg;*.jpeg|All files (*.*)|*.*";
            //Set the initial directory of the file dialog as the "My Pictures" folder
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            //If user succesfully select a file
            if (dialog.ShowDialog() == true)
            {
                //Save the full path of the image selected by the user
                string fileName = dialog.FileName;
                //Set the selected image source using the file selected by the user
                selectedImage.Source = new BitmapImage(new Uri(fileName));

                MakePredictionAsync(fileName);
            }
        }

        private void MakePredictionAsync(string fileName)
        {
            string url = "https://northeurope.api.cognitive.microsoft.com/customvision/v3.0/Prediction/bb98deea-c9e0-45a7-bc96-ed3ddb9c0593/classify/iterations/LandmarkAI/image";
            string predictionKey = "cc120e31d3a344fa9cde535f0739fd39";
            string contentType = "application/octet-stream";
            var file = File.ReadAllBytes(fileName);
        }
    }
}
