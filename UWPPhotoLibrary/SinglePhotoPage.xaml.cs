using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using UWPPhotoLibrary.Model1;
using System.Diagnostics;



// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPPhotoLibrary
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SinglePhotoPage : Page
    {

        private ObservableCollection<Picture> singlepic;
        private static string photoname;
        public PictureInfoPass passedpictureinfo;
        public ObservableCollection<Picture> PassedPictureList;

        //public List<string> PictureDescriptions;


        public SinglePhotoPage()
        {
            this.InitializeComponent();
            singlepic = new ObservableCollection<Picture>();

            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            //FlipView flipView1 = new FlipView();
            //flipView1.Items.Add(singlepic);
            //flipView1.Items.Add("Family2");
            //stackone.Children.Add(flipView1);
        }


        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{

        //    if (e.Parameter is string && !string.IsNullOrWhiteSpace((string)e.Parameter))
        //    {
        //        vax = e.Parameter.ToString();
        //        //  greeting.Text = vax;
        //        PictureManager.GetPictureToSecondPage(singlepic, vax);

        //    }

        //    base.OnNavigatedTo(e);
        //}

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
             passedpictureinfo = (PictureInfoPass)e.Parameter;
             photoname = passedpictureinfo.SinglePhotoName;
             PassedPictureList = passedpictureinfo.PassingPhotoList;
             PictureManager.GetPictureToSecondPage(singlepic, PassedPictureList, photoname);

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

        //private void SinglGrid_ItemClick(object sender, ItemClickEventArgs e)
        //{

        //    // var val = (Picture)e.ClickedItem;
        //    var pic = (Picture)e.ClickedItem;
        //    var name = pic.Name;
        //    //var category = pic.Category;
        //    PictureManager.GetNextPicture(singlepic, name);


        //}

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            //singlepic[0].Name = PictureDescription.Text;
            DisplayPictureDescription.Text = PictureDescription.Text;
            singlepic[0].PictureDescription = PictureDescription.Text;
            for (int i = 0; i < PassedPictureList.Count; i++)
            {
                if (singlepic[0].Name == PassedPictureList[i].Name)
                {
                    PassedPictureList[i].PictureDescription = singlepic[0].PictureDescription;
                    //Debug.WriteLine(PassedPictureList[i].PictureDescription);
                }
            }

            PictureManager.GetPictureToSecondPage(singlepic, PassedPictureList, photoname);
            
            //Debug.WriteLine(singlepic[0].PictureDescription);

        }

        //private static List<Tuple<string, string>> PictureDescriptions() 
        //{
        //    var picturedescriptions = new List<Tuple<string , string>>();

        //    picturedescriptions.Add(new Tuple<string, string>("Cooking1", null));
        //    picturedescriptions.Add(new Tuple<string, string>("Cooking2", null));
        //    picturedescriptions.Add(new Tuple<string, string>("Cooking3", null));
        //    picturedescriptions.Add(new Tuple<string, string>("Cooking4", null));
        //    picturedescriptions.Add(new Tuple<string, string>("Cooking5", null));

        //    picturedescriptions.Add(new Tuple<string, string>("Family1", null));
        //    picturedescriptions.Add(new Tuple<string, string>("Family2", null));
        //    picturedescriptions.Add(new Tuple<string, string>("Family3", null));
        //    picturedescriptions.Add(new Tuple<string, string>("Family4", null));
        //    picturedescriptions.Add(new Tuple<string, string>("Family5", null));

        //    picturedescriptions.Add(new Tuple<string, string>("Holiday1", null));
        //    picturedescriptions.Add(new Tuple<string, string>("Holiday2", null));
        //    picturedescriptions.Add(new Tuple<string, string>("Holiday3", null));
        //    picturedescriptions.Add(new Tuple<string, string>("Holiday4", null));
        //    picturedescriptions.Add(new Tuple<string, string>("Holiday5", null));

        //    picturedescriptions.Add(new Tuple<string, string>("Vacation1", null));
        //    picturedescriptions.Add(new Tuple<string, string>("Vacation2", null));
        //    picturedescriptions.Add(new Tuple<string, string>("Vacation3", null));
        //    picturedescriptions.Add(new Tuple<string, string>("Vacation4", null));
        //    picturedescriptions.Add(new Tuple<string, string>("Vacation5", null));

        //    return picturedescriptions;

        //}
    }
}
