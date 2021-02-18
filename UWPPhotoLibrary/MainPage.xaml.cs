﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPPhotoLibrary.Model1;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPPhotoLibrary
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Picture> pic;
        private List<Picture> pic2;
        public MainPage()
        {
            this.InitializeComponent();
            pic = new ObservableCollection<Picture>();
            PictureManager.GetAllPicture(pic);

            pic2 = new List<Picture>();

        }

        private void photoalbem_Navigating(object sender, NavigatingCancelEventArgs e)
        {

        }

        private void photoalbem_Navigated(object sender, NavigationEventArgs e)
        {
            
        }

        private void AllPicButton_Click(object sender, RoutedEventArgs e)
        {
             if (AllPicButton.Content.ToString() == "Show All Picture")
            {
                AllPicButton.Content = "Show By Category";
                HeaderText.Text = " ALL Albums ";
            }
             else if (AllPicButton.Content.ToString() == "Show By Category")
            { 
                AllPicButton.Content = "Show All Picture";
                HeaderText.Text = " My ****Albums ";
                
            }
            
        }

        private void PhotoCategory_ItemClick(object sender, ItemClickEventArgs e)

        {
            var pics = (Picture)e.ClickedItem;
            //var name = pics.Name;
            //var cat = pics.Category;
            //pic2 = new List<Picture>();
            //var dat = PictureManager.SelectedPicture(pic2, cat, name);
            HeaderText.Text = pics.Name;
            //pictureCategotyImage.
            //ownerImage1.
            // HeaderText.source
           // pictureCategotyImage.Source = new Uri(BaseUri, pics.PictureFile);


        }

       
    }
}
