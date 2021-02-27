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

        private ObservableCollection<Picture> singlepic;
        private static string vax;


        public SinglePhotoPage()
        {
            this.InitializeComponent();
            singlepic = new ObservableCollection<Picture>();
            //FlipView flipView1 = new FlipView();
            //flipView1.Items.Add(singlepic);
            //flipView1.Items.Add("Family2");
            //stackone.Children.Add(flipView1);
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            if (e.Parameter is string && !string.IsNullOrWhiteSpace((string)e.Parameter))
            {
                vax = e.Parameter.ToString();
                //  greeting.Text = vax;
                PictureManager.GetPictureToSecondPage(singlepic, vax);

            }

            base.OnNavigatedTo(e);
        }



        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void backwardrdbtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void forwardbtn_Click(object sender, RoutedEventArgs e)
        {
            //var note = 
            //int u = singlepic.IndexOf(note);

            //var name = singlepic[u + 1].Name;
            //this.Frame.Navigate(typeof(SinglePhotoPage), name);
            //var _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData))
        }



        private void SinglePhotoHomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        //private void PhotoCatexgory_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    var pic = (Picture)e.ClickedItem;
        //    var name = pic.Name;
        //    var category = pic.Category;
        //    //string xx = PictureManager.GetNextPicture(singlepic, name, category);
        //    FlipView flipView1 = new FlipView();
        //    flipView1.Items.Add("Family1");
        //    flipView1.Items.Add("Family1");
        //    grone.Children.Add(flipView1);
        //    this.Frame.Navigate(typeof(SinglePhotoPage));


        //    // this.Frame.Navigate(typeof(SinglePhotoPage));
        //}

        private void Image_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            //FlipView flipView1 = new FlipView();
            //flipView1.Items.Add(new Picture() { Name= });
            //flipView1.Items.Add("Family1");
            //stackone.Children.Add(flipView1);
        }

        private void SinglGrid_ItemClick(object sender, ItemClickEventArgs e)
        {

           // var val = (Picture)e.ClickedItem;
            var pic = (Picture)e.ClickedItem;
            var name = pic.Name;
            //var category = pic.Category;
            PictureManager.GetNextPicture(singlepic, name);
          

        }

       
    }
}
