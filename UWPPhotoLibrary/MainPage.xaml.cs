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
        //private ObservableCollection<Picture> pictures;
        private List<MenuItem> menuItems;
        private ObservableCollection<Picture> CoverPicture;
        public ObservableCollection<Picture> PictureList;
        public ObservableCollection<Picture> DisplayPictures;
        

        public MainPage()
        {
            this.InitializeComponent();
            //pictures = new ObservableCollection<Picture>();    
            //PictureManager.GetAllPictures(pictures);

            DisplayPictures = new ObservableCollection<Picture>();

            CoverPicture = new ObservableCollection<Picture>();
            PictureManager.GetCoverPictures(CoverPicture);

            menuItems = new List<MenuItem>();
            menuItems.Add(new MenuItem { IconFile = "Assets/Icons/Cooking.png", Category = PictureCategory.Cooking });
            menuItems.Add(new MenuItem { IconFile = "Assets/Icons/Family.png", Category = PictureCategory.Family });
            menuItems.Add(new MenuItem { IconFile = "Assets/Icons/Holidays.png", Category = PictureCategory.Holidays });
            menuItems.Add(new MenuItem { IconFile = "Assets/Icons/Vacations.png", Category = PictureCategory.Vacations });

            BackButton.Visibility = Visibility.Collapsed;

            PictureList = new ObservableCollection<Picture>();
            
            PictureList.Add(new Picture("Cooking1", PictureCategory.Cooking, null));
            PictureList.Add(new Picture("Cooking2", PictureCategory.Cooking, null));
            PictureList.Add(new Picture("Cooking3", PictureCategory.Cooking, null));
            PictureList.Add(new Picture("Cooking4", PictureCategory.Cooking, null));
            PictureList.Add(new Picture("Cooking5", PictureCategory.Cooking, null));

            PictureList.Add(new Picture("Family1", PictureCategory.Family, null));
            PictureList.Add(new Picture("Family2", PictureCategory.Family, null));
            PictureList.Add(new Picture("Family3", PictureCategory.Family, null));
            PictureList.Add(new Picture("Family4", PictureCategory.Family, null));
            PictureList.Add(new Picture("Family5", PictureCategory.Family, null));

            PictureList.Add(new Picture("Holiday1", PictureCategory.Holidays, null));
            PictureList.Add(new Picture("Holiday2", PictureCategory.Holidays, null));
            PictureList.Add(new Picture("Holiday3", PictureCategory.Holidays, null));
            PictureList.Add(new Picture("Holiday4", PictureCategory.Holidays, null));
            PictureList.Add(new Picture("Holiday5", PictureCategory.Holidays, null));

            PictureList.Add(new Picture("Vacation1", PictureCategory.Vacations, null));
            PictureList.Add(new Picture("Vacation2", PictureCategory.Vacations, null));
            PictureList.Add(new Picture("Vacation3", PictureCategory.Vacations, null));
            PictureList.Add(new Picture("Vacation4", PictureCategory.Vacations, null));
            PictureList.Add(new Picture("Vacation5", PictureCategory.Vacations, null));

            for (int i = 0; i < PictureList.Count; i++)
            {
                DisplayPictures.Add(PictureList[i]);
            }

        }

      

        private void MenuItemsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            //var menuItem = (MenuItem)e.ClickedItem;
            //CategoryTextBlock.Text = menuItem.Category.ToString();
            //PictureManager.GetPicturesByCategory(pictures, menuItem.Category);
            //BackButton.Visibility = Visibility.Visible;


            var menuItem = (MenuItem)e.ClickedItem;
            CategoryTextBlock.Text = menuItem.Category.ToString();
            PictureManager.GetPicturesByCategory(PictureList, menuItem.Category, DisplayPictures);
            BackButton.Visibility = Visibility.Visible;

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            //PictureManager.GetAllPictures(pictures);
            //DisplayPictures = PictureList;
            //SOMETHING needs to change here but I'm not sure what. When I tried the above code the home button disappeared upon click.
            for (int i = 0; i < PictureList.Count; i++)
            {
                DisplayPictures.Add(PictureList[i]);
            }
            CategoryTextBlock.Text = "My Photo Album";
            MenuItemsListView.SelectedItem = null;
            BackButton.Visibility = Visibility.Collapsed;

        }

        private void PictureGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var val = (Picture)e.ClickedItem;
            //This is where val.Name is passed to SinglePhotoPage

            this.Frame.Navigate(typeof(SinglePhotoPage), val.Name);

            //this.Frame.Navigate(typeof(SinglePhotoPage), PictureList);


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
