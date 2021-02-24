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
        private ObservableCollection<Picture> coverPhotos;
        public string NameFromButton { get; set; }
        //public Picture ReplaceCoverPhotoWith { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            pictures = new ObservableCollection<Picture>();
            PictureManager.GetAllPictures(pictures);
            


            //coverPhotos should be a list of data type Picture not data type MenuItem
            //menuItems = new List<MenuItem>();
            //menuItems.Add(new MenuItem { IconFile = "Assets/Icons/Cooking.png", Category = PictureCategory.Cooking });
            //menuItems.Add(new MenuItem { IconFile = "Assets/Icons/Family.png", Category = PictureCategory.Family });
            //menuItems.Add(new MenuItem { IconFile = "Assets/Icons/Holidays.png", Category = PictureCategory.Holidays });
            //menuItems.Add(new MenuItem { IconFile = "Assets/Icons/Vacations.png", Category = PictureCategory.Vacations });

            coverPhotos = new ObservableCollection<Picture>();
            coverPhotos.Add(new Picture("Cooking1", PictureCategory.Cooking));
            coverPhotos.Add(new Picture("Family1", PictureCategory.Family));
            coverPhotos.Add(new Picture("Holiday1", PictureCategory.Holidays));
            coverPhotos.Add(new Picture("Vacation1", PictureCategory.Vacations));


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
            //var menuItem = (MenuItem)e.ClickedItem;
            //CategoryTextBlock.Text = menuItem.Category.ToString();
            //PictureManager.GetPicturesByCategory(pictures, menuItem.Category);
            //BackButton.Visibility = Visibility.Visible;

            Picture coverPhoto = (Picture)e.ClickedItem;
            CategoryTextBlock.Text = coverPhoto.Category.ToString();
            PictureManager.GetPicturesByCategory(pictures, coverPhoto.Category);
            BackButton.Visibility = Visibility.Visible;

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


        public void ChangeCoverPhoto(Picture NewCoverPhoto)
        {
            for (int i = 0; i < 4; i++)
            {
                if (coverPhotos[i].Category == NewCoverPhoto.Category)
                {
                    coverPhotos[i] = NewCoverPhoto;
                }

            }
        }

    }
}
