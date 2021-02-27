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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPPhotoLibrary
{
    /// <summary> final  001
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Picture> pictures;
        private List<MenuItem> menuItems;
        private ObservableCollection<Picture> CoverPicture;
        

        public MainPage()
        {
            this.InitializeComponent();
            pictures = new ObservableCollection<Picture>();    
            PictureManager.GetAllPictures(pictures);

            CoverPicture = new ObservableCollection<Picture>();
            PictureManager.GetCoverPictures(CoverPicture);

            menuItems = new List<MenuItem>();
            menuItems.Add(new MenuItem { IconFile = "Assets/Icons/Cooking.png", Category = PictureCategory.Cooking });
            menuItems.Add(new MenuItem { IconFile = "Assets/Icons/Family.png", Category = PictureCategory.Family });
            menuItems.Add(new MenuItem { IconFile = "Assets/Icons/Holidays.png", Category = PictureCategory.Holidays });
            menuItems.Add(new MenuItem { IconFile = "Assets/Icons/Vacations.png", Category = PictureCategory.Vacations });

            BackButton.Visibility = Visibility.Collapsed;
        }

      

        private void MenuItemsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = (MenuItem)e.ClickedItem;
            CategoryTextBlock.Text = menuItem.Category.ToString();
            PictureManager.GetPicturesByCategory(pictures, menuItem.Category);
            BackButton.Visibility = Visibility.Visible;

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            PictureManager.GetAllPictures(pictures);
            CategoryTextBlock.Text = "My Photo Album";
            MenuItemsListView.SelectedItem = null;
            BackButton.Visibility = Visibility.Collapsed;

        }

        private void PictureGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var val = (Picture)e.ClickedItem;
            this.Frame.Navigate(typeof(SinglePhotoPage), val.Name);
            

        }

     
      
        private void PictureGridView_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            var ReplaceCoverPhotoWith = (e.OriginalSource as FrameworkElement).DataContext as Picture;
            var name = ReplaceCoverPhotoWith.Name;
           // ttt.Text = name;
            PictureManager.ChangeCoverPhoto(CoverPicture, name);

        }
    }
}
