using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPPhotoLibrary.Model1;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
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
        private ObservableCollection<Picture> pic2;
        // private List<Picture> pic2;
        public MainPage()
        {
            this.InitializeComponent();
            pic = new ObservableCollection<Picture>();
            pic2 = new ObservableCollection<Picture>();
            PictureManager.GetAllPicture(pic);
            PictureManager.GetAllCategory(pic2);

            // pic2 = new List<Picture>();

        }
        
        private void photoalbem_Navigating(object sender, NavigatingCancelEventArgs e)
        {

        }

        private void photoalbem_Navigated(object sender, NavigationEventArgs e)
        {
            
        }
        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof(BlankPage2));
        }

        private void AllPicButton_Click(object sender, RoutedEventArgs e)
        {
           

            if (HeaderText.Text != "ALL Albums")
            {
                AllPicButton.Content = "Show By Category";
                HeaderText.Text = " ALL Albums ";
                PictureManager.GetAllPicture(pic);

            }
             else 
            { 
                AllPicButton.Content = "Show All Picture";
               // HeaderText.Text = " My ****Albums ";
                
            }
            
        }

        private void PhotoCategory_ItemClick(object sender, ItemClickEventArgs e)

        {
            var val = (Picture)e.ClickedItem;
            this.Frame.Navigate(typeof(SinglePhotos),val.Name);
            //var val = e.ClickedItem;
          //val  var val = (Picture)e.ClickedItem;
            SinglePhotos s = new SinglePhotos();
           // s.getSinglePic(val);
            // PictureManager.GetSinglePictures(pic, val.Category, val.Name);

            //HeaderText.Text = $"My {val.Category} Album";
            AllPicButton.Content = "Show All Picture";
          

        }

        private void a_ItemClick(object sender, ItemClickEventArgs e)
        {
           var val =  (Picture)e.ClickedItem;
            PictureManager.GetPicturesByCategory(pic, val.Category);
            HeaderText.Text = $"My {val.Category} Album";
            AllPicButton.Content = "Show All Picture";
        }
    }
}
