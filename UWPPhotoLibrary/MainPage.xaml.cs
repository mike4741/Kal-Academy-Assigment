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
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Picture> pictures;
        private List<MenuItem> menuItems;
        public ObservableCollection<Picture> coverPhoto;
        public string NameFromButton { get; set; }
        public Picture ReplaceCoverPhotoWith { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            pictures = new ObservableCollection<Picture>();
            PictureManager.GetAllPictures(pictures);
            

            menuItems = new List<MenuItem>();
            menuItems.Add(new MenuItem { IconFile = "Assets/Icons/Cooking.png", Category = PictureCategory.Cooking });
            menuItems.Add(new MenuItem { IconFile = "Assets/Icons/Family.png", Category = PictureCategory.Family });
            menuItems.Add(new MenuItem { IconFile = "Assets/Icons/Holidays.png", Category = PictureCategory.Holidays });
            menuItems.Add(new MenuItem { IconFile = "Assets/Icons/Vacations.png", Category = PictureCategory.Vacations });

            coverPhoto = new ObservableCollection<Picture>();
            coverPhoto.Add(new Picture("Cooking1", PictureCategory.Cooking));
            //coverPhoto.Add(new Picture("Family1", PictureCategory.Family));
            //coverPhoto.Add(new Picture("Holiday1", PictureCategory.Holidays));
            //coverPhoto.Add(new Picture("Vacation1", PictureCategory.Vacations));


            BackButton.Visibility = Visibility.Collapsed;

            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;

            if (String.IsNullOrEmpty(nameInput.Text))
            {
                if (String.IsNullOrEmpty(NameFromButton))
                {
                    NameButtonOutput.Text = "Please enter your name.";
                }

                else
                {
                    NameButtonOutput.Text = NameFromButton + "'s Photo Gallery!";
                }
            }

            else
            {
                NameButtonOutput.Text = nameInput.Text + "'s Photo Gallery!";
                NameFromButton = nameInput.Text;
            }

        }

        private void NameButton_Click(object sender, RoutedEventArgs e)
        {
            //NameFromButton = nameInput.Text;
            //NameButtonOutput.Text = "This is " + NameFromButton + "'s Photo Gallery!";

            if (String.IsNullOrEmpty(nameInput.Text))
            {
                if (String.IsNullOrEmpty(NameFromButton))
                {
                    NameButtonOutput.Text = "Please enter your name.";
                }

                else
                {
                    NameButtonOutput.Text = NameFromButton + "'s Photo Gallery!";
                    CategoryTextBlock.Text = NameFromButton + "'s Photo Gallery!";
                }
            }

            else
            {
                NameButtonOutput.Text = nameInput.Text + "'s Photo Gallery!";
                CategoryTextBlock.Text = nameInput.Text + "'s Photo Gallery!";
                NameFromButton = nameInput.Text;
            }


        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void MenuItemsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = (MenuItem)e.ClickedItem;
            CategoryTextBlock.Text = menuItem.Category.ToString();
            PictureManager.GetPicturesByCategory(pictures, menuItem.Category);
            BackButton.Visibility = Visibility.Visible;

            //Picture menuItem = (Picture)e.ClickedItem;
            //CategoryTextBlock.Text = menuItem.Category.ToString();
            //PictureManager.GetPicturesByCategory(pictures, menuItem.Category);
            //BackButton.Visibility = Visibility.Visible;

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            PictureManager.GetAllPictures(pictures);
            CategoryTextBlock.Text = NameFromButton + "'s Photo Gallery!";
            MenuItemsListView.SelectedItem = null;
            BackButton.Visibility = Visibility.Collapsed;

        }

        private void PictureGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var val = (Picture)e.ClickedItem;
            this.Frame.Navigate(typeof(SinglePhotoPage), val.Name);


            //var val = e.ClickedItem;
            //val  var val = (Picture)e.ClickedItem;
            SinglePhotoPage s = new SinglePhotoPage();
            // s.getSinglePic(val);
            // PictureManager.GetSinglePictures(pic, val.Category, val.Name);

            //HeaderText.Text = $"My {val.Category} Album";
            //AllPicButton.Content = "Show All Picture";

        }

        private void PictureGridView_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            //Picture picture = (sender as Grid).DataContext as Picture;
            //ReplaceCoverPhotoWith = picture;
            //ChangeCoverPhoto(ReplaceCoverPhotoWith);
        }

        public void ChangeCoverPhoto(Picture NewCoverPhoto)
        {
            for (int i = 0; i < 1; i++)
            {

                coverPhoto[i] = NewCoverPhoto;

            }
        }




        private void Grid_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            ReplaceCoverPhotoWith = (e.OriginalSource as FrameworkElement).DataContext as Picture;
            ChangeCoverPhoto(ReplaceCoverPhotoWith);



        }



    }
}
