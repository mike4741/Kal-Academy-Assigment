using System;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPPhotoLibrary
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SinglePhotos : Page
    {
        private ObservableCollection<Picture> singlepic;
        private  static string vax;

        public SinglePhotos()
        {
            this.InitializeComponent();
            singlepic = new ObservableCollection<Picture>();
      
            //PictureManager.GetPictureToSecondPage(singlepic, vax);
        }

        private void SinglePhotoHomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));

        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            if (e.Parameter is string && !string.IsNullOrWhiteSpace((string)e.Parameter))
            {
                 vax = e.Parameter.ToString();
                  greeting.Text = vax;
                PictureManager.GetPictureToSecondPage(singlepic, vax);

            }
            else
            {
                greeting.Text = "Hi!";
            }
            base.OnNavigatedTo(e);
        }
        //protected override void GetSinglePic(NavigationEventArgs e, Picture pic)
        //{ 
        //    var val = pic;
        //    PictureManager.GetSinglePictures(singlepic, val.Category, val.Name);
        //    //this.Frame.Navigate(typeof(Single), val);
        //    //HeaderText.Text = $"My {val.Category} Album";
        //    AllPicButton.Content = "Show All Picture";
        //}

    }
}
