using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using UWPPhotoLibrary.Model1;



// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPPhotoLibrary
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SinglePhotoPage : Page
    {
        public Picture ReplaceCoverPhotoWith { get; set; }

        private ObservableCollection<Picture> singlepic;
        private static string vax;
        public SinglePhotoPage()
        {
            this.InitializeComponent();
            singlepic = new ObservableCollection<Picture>();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            if (e.Parameter is string && !string.IsNullOrWhiteSpace((string)e.Parameter))
            {
                vax = e.Parameter.ToString();
                PictureManager.GetPictureToSecondPage(singlepic, vax);

            }
            else
            {
                //greeting.Text = "Hi!";
            }
            base.OnNavigatedTo(e);
        }

   

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void ChangeCoverPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            //ReplaceCoverPhotoWith = new Picture("Cooking2", PictureCategory.Cooking);
            //coverPhoto = singlepic;
            
            
        }
    }
}
