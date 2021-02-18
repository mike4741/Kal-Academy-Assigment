using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace UWPPhotoLibrary.Model1
{
   public static class PictureManager
    {

        public static void GetAllPicture(ObservableCollection<Picture> pictures)
        {
            var allpics = getAllPicture();
            pictures.Clear();
            allpics.ForEach (pic => pictures.Add(pic)) ;

        }

        public static void GetPicturesByCategory(ObservableCollection<Picture> pictures, PictureCategory category)
        {
            var allpics = getAllPicture();
            var filteredPictures = allpics.Where(pic => pic.Category == category).ToList();
            pictures.Clear();
            filteredPictures.ForEach(pic => pictures.Add(pic));
        }
        private  static List<Picture> getAllPicture()
        {
            var pictures = new List<Picture>();
            pictures.Add(new Picture("Cooking1", PictureCategory.Cooking));
            pictures.Add(new Picture("Cooking2", PictureCategory.Cooking));
            pictures.Add(new Picture("Cooking3", PictureCategory.Cooking));
            pictures.Add(new Picture("Cooking4", PictureCategory.Cooking));
            pictures.Add(new Picture("Cooking5", PictureCategory.Cooking));

            pictures.Add(new Picture("Family1", PictureCategory.Family));
            pictures.Add(new Picture("Family2", PictureCategory.Family));
            pictures.Add(new Picture("Family3", PictureCategory.Family));
            pictures.Add(new Picture("Family4", PictureCategory.Family));
            pictures.Add(new Picture("Family5", PictureCategory.Family));


            pictures.Add(new Picture("Holiday1", PictureCategory.Holidays));
            pictures.Add(new Picture("Holiday2", PictureCategory.Holidays));
            pictures.Add(new Picture("Holiday3", PictureCategory.Holidays));
            pictures.Add(new Picture("Holiday4", PictureCategory.Holidays));
            pictures.Add(new Picture("Holiday5", PictureCategory.Holidays));


            pictures.Add(new Picture("Vacation1", PictureCategory.Vacations));
            pictures.Add(new Picture("Vacation2", PictureCategory.Vacations));
            pictures.Add(new Picture("Vacation3", PictureCategory.Vacations));
            pictures.Add(new Picture("Vacation4", PictureCategory.Vacations));
            pictures.Add(new Picture("Vacation5", PictureCategory.Vacations));



            return pictures;
        }

      
    }
}
