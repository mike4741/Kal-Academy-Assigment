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
        // final one 
        internal static void ChangeCoverPhoto(ObservableCollection<Picture> coverPicture, string name)
        {
            var allpics = getPictures();
            var filteredPictures = allpics.Where(pic => pic.Name == name ).ToList();
            coverPicture.Clear();
            filteredPictures.ForEach(pic => coverPicture.Add(pic));
        }

        public static void GetAllPictures(ObservableCollection<Picture> pictures)
        {
            var allPictures = getPictures();
            pictures.Clear();
            allPictures.ForEach(picture => pictures.Add(picture));
        }

        public static void GetPicturesByCategory(ObservableCollection<Picture> originalpictures, PictureCategory category, ObservableCollection<Picture> changingpictures)
        {
            //var allPictures = getPictures();
            //var filteredPictures = allPictures.Where(picture => picture.Category == category).ToList();
            //pictures.Clear();
            //filteredPictures.ForEach(picture => pictures.Add(picture));

            //var allPictures = getPictures();
            var filteredPictures = originalpictures.Where(picture => picture.Category == category).ToList();
            changingpictures.Clear();
            //ObservableCollection<Picture> displaypictures = new ObservableCollection<Picture>();
            filteredPictures.ForEach(picture => changingpictures.Add(picture));

        }

        internal static void GetCoverPictures(ObservableCollection<Picture> CoverPicture)
        {
            var allPictures = getPictures();
            var filteredPictures = allPictures.Where(picture => picture.Name == "Family3" ).ToList();

            CoverPicture.Clear();
            filteredPictures.ForEach(picture => CoverPicture.Add(picture));
        }

        public static void GetSinglePictures(ObservableCollection<Picture> pictures, PictureCategory category, string picname)
        {
            var allpics = getPictures();
            var filteredPictures = allpics.Where(pic => pic.Category == category && pic.Name == picname).ToList();
            pictures.Clear();
            filteredPictures.ForEach(pic => pictures.Add(pic));
        }
        public static void GetPictureToSecondPage(ObservableCollection<Picture> pictures, string picname)
        {
            var allpics = getPictures();
            var filteredPictures = allpics.Where(pic => pic.Name == picname).ToList();
            pictures.Clear();
            filteredPictures.ForEach(pic => pictures.Add(pic));

        }
        public static void GetNextPicture(ObservableCollection<Picture> pictures,
                                            string name)
        {

            var allPictures = getPictures();
            var filteredPictures = allPictures.ToList();
            pictures.Clear();
            filteredPictures.ForEach(pic => pictures.Add(pic));
            string nextName =name;
            for (int i = 0; i < pictures.Count; i++)
            { 
               
                if (pictures[i].Name == name)
                {
                    if (i == pictures.Count-1)
                    {
                        i = 0;
                        nextName = pictures[i].Name;
                        break;
                    }else
                    {
                        nextName = pictures[i+1].Name;
                        break;
                    }
                }
               
            }
            filteredPictures = allPictures.Where(pic => pic.Name == nextName).ToList();
            pictures.Clear();
            filteredPictures.ForEach(pic => pictures.Add(pic));
        }

     

        private static List<Picture> getPictures()
        {
            var pictures = new List<Picture>();
            pictures.Add(new Picture("Cooking1", PictureCategory.Cooking, null));
            pictures.Add(new Picture("Cooking2", PictureCategory.Cooking, null));
            pictures.Add(new Picture("Cooking3", PictureCategory.Cooking, null));
            pictures.Add(new Picture("Cooking4", PictureCategory.Cooking, null));
            pictures.Add(new Picture("Cooking5", PictureCategory.Cooking, null));
                 
            pictures.Add(new Picture("Family1", PictureCategory.Family, null));
            pictures.Add(new Picture("Family2", PictureCategory.Family, null));
            pictures.Add(new Picture("Family3", PictureCategory.Family, null));
            pictures.Add(new Picture("Family4", PictureCategory.Family, null));
            pictures.Add(new Picture("Family5", PictureCategory.Family, null));


            pictures.Add(new Picture("Holiday1", PictureCategory.Holidays, null));
            pictures.Add(new Picture("Holiday2", PictureCategory.Holidays, null));
            pictures.Add(new Picture("Holiday3", PictureCategory.Holidays, null));
            pictures.Add(new Picture("Holiday4", PictureCategory.Holidays, null));
            pictures.Add(new Picture("Holiday5", PictureCategory.Holidays, null));


            pictures.Add(new Picture("Vacation1", PictureCategory.Vacations, null));
            pictures.Add(new Picture("Vacation2", PictureCategory.Vacations, null));
            pictures.Add(new Picture("Vacation3", PictureCategory.Vacations, null));
            pictures.Add(new Picture("Vacation4", PictureCategory.Vacations, null));
            pictures.Add(new Picture("Vacation5", PictureCategory.Vacations, null));

            return pictures;
        }

      
    }
}
