using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace UWPPhotoLibrary.Model1
{
    public static class PictureManager
    {

        public static void GetPicturesByCategory(ObservableCollection<Picture> originalpictures, PictureCategory category, ObservableCollection<Picture> changingpictures)
        {
            var filteredPictures = originalpictures.Where(picture => picture.Category == category).ToList();
            changingpictures.Clear();
            filteredPictures.ForEach(picture => changingpictures.Add(picture));
        }

        public static void GetPictureToSecondPage(ObservableCollection<Picture> singlepic, ObservableCollection<Picture> list, string picname)
        {
            var allpics = list;
            var filteredPictures = allpics.Where(pic => pic.Name == picname).ToList();
            singlepic.Clear();
            filteredPictures.ForEach(pic => singlepic.Add(pic));

        }

    }
}
