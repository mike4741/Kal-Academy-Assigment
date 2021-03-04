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

namespace UWPPhotoLibrary
{

    public sealed partial class MainPage : Page
    {
        private List<MenuItem> menuItems;
        public ObservableCollection<Picture> coverPhoto;
        public Picture ReplaceCoverPhotoWith { get; set; }
        public ObservableCollection<Picture> PictureList;
        public ObservableCollection<Picture> DisplayPictures;
        public PictureInfoPass passedpictureinfo;
        public ObservableCollection<Picture> PassedPictureList;


        public MainPage()
        {
            this.InitializeComponent();

            DisplayPictures = new ObservableCollection<Picture>();

            coverPhoto = new ObservableCollection<Picture>();
            coverPhoto.Add(new Picture("Cooking1", PictureCategory.Cooking, null));

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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!(e.Parameter is string))
            {
                passedpictureinfo = (PictureInfoPass)e.Parameter;
                PassedPictureList = passedpictureinfo.PassingPhotoList;
                PictureList.Clear();
                for (int i = 0; i < PassedPictureList.Count; i++)
                {
                    PictureList.Add(PassedPictureList[i]);
                }
            }

            base.OnNavigatedTo(e);
        }

        private void MenuItemsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = (MenuItem)e.ClickedItem;
            CategoryTextBlock.Text = menuItem.Category.ToString();
            PictureManager.GetPicturesByCategory(PictureList, menuItem.Category, DisplayPictures);
            BackButton.Visibility = Visibility.Visible;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayPictures.Clear();

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
            var clickedpicture = (Picture)e.ClickedItem;
            PictureInfoPass pictureInfoPass = new PictureInfoPass(clickedpicture.Name, PictureList);
            this.Frame.Navigate(typeof(SinglePhotoPage), pictureInfoPass);
        }

        public void ChangeCoverPhoto(Picture NewCoverPhoto)
        {
            for (int i = 0; i < 1; i++)
            {

                coverPhoto[i] = NewCoverPhoto;

            }
        }

        private void PictureGridView_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            ReplaceCoverPhotoWith = (e.OriginalSource as FrameworkElement).DataContext as Picture;
            ChangeCoverPhoto(ReplaceCoverPhotoWith);
        }
    }
}
