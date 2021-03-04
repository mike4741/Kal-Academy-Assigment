using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using UWPPhotoLibrary.Model1;
using System.Diagnostics;
using Windows.UI.Xaml.Data;


namespace UWPPhotoLibrary
{

    public sealed partial class SinglePhotoPage : Page 
    {

        private ObservableCollection<Picture> singlepic;
        public ObservableCollection<Picture> NextPicture;
        private static string photoname;
        public PictureInfoPass passedpictureinfo;
        public ObservableCollection<Picture> PassedPictureList;
        public string nextName;

        public SinglePhotoPage()
        {
            this.InitializeComponent();
            singlepic = new ObservableCollection<Picture>();

            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
             passedpictureinfo = (PictureInfoPass)e.Parameter;
             photoname = passedpictureinfo.SinglePhotoName;
             PassedPictureList = passedpictureinfo.PassingPhotoList;
             PictureManager.GetPictureToSecondPage(singlepic, PassedPictureList, photoname);

             base.OnNavigatedTo(e);
        }

        private void SinglePhotoHomeButton_Click(object sender, RoutedEventArgs e)
        {
            PictureInfoPass pictureInfoPass = new PictureInfoPass(null, PassedPictureList);
            this.Frame.Navigate(typeof(MainPage), pictureInfoPass);
        }

        private void SinglGrid_ItemClick(object sender, ItemClickEventArgs e)
        {

            for (int i = 0; i < PassedPictureList.Count; i++)
            {

                if (PassedPictureList[i].Name == singlepic[0].Name)
                {
                    if (i == PassedPictureList.Count - 1)
                    {
                        i = 0;
                        nextName = PassedPictureList[i].Name;
                        break;
                    }
                    else
                    {
                        nextName = PassedPictureList[i + 1].Name;
                        break;
                    }
                }

            }

            PictureManager.GetPictureToSecondPage(singlepic, PassedPictureList, nextName);

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            singlepic[0].PictureDescription = PictureDescription.Text;
            for (int i = 0; i < PassedPictureList.Count; i++)
            {
                if (singlepic[0].Name == PassedPictureList[i].Name)
                {
                    PassedPictureList[i].PictureDescription = singlepic[0].PictureDescription;
                }
            }

            PictureDescription.Text = string.Empty;

        }

    }
}
