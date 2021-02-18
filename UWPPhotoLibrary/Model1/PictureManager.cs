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

        public static List<Picture> SelectedCategoryPicture(List<Picture> picture, PictureCategory category, string name)
        {
            var allPic = getAllPicture();
            var filpic = allPic.Where(pic1 => pic1.Category == category ).ToList();
            picture.Clear();
            filpic.ForEach(pic => picture.Add(pic));
            return picture;

        }
        public static List<Picture> SelectedPicture(List<Picture> picture , PictureCategory category ,string name)
        {
            var allPic = getAllPicture();
            var filpic = allPic.Where(pic1 => pic1.Category == category && pic1.Name == name).ToList();
            picture.Clear();
            filpic.ForEach(pic => picture.Add(pic));
            return picture;

        }
        public static void GetAllPicture(ObservableCollection<Picture> picture)
        {
            var allpic = getAllPicture();
            picture.Clear();
            //foreach(var pic in allpic)
            //{
            //    picture.Add(pic);
            //}
             allpic.ForEach (pic => picture.Add(pic)) ;
            

        }
        private  static List<Picture>   getAllPicture()
        {
            var picture = new List<Picture>();
            picture.Add(new Picture("Cooking1", PictureCategory.Cooking));
            picture.Add(new Picture("Cooking2", PictureCategory.Cooking));
            picture.Add(new Picture("Cooking3", PictureCategory.Cooking));
            picture.Add(new Picture("Cooking4", PictureCategory.Cooking));
            picture.Add(new Picture("Cooking5", PictureCategory.Cooking));

            picture.Add(new Picture("Family1", PictureCategory.Family));
            picture.Add(new Picture("Family2", PictureCategory.Family));
            picture.Add(new Picture("Family3", PictureCategory.Family));
            picture.Add(new Picture("Family4", PictureCategory.Family));
            picture.Add(new Picture("Family5", PictureCategory.Family));


            picture.Add(new Picture("Holiday1", PictureCategory.Holidays));
            picture.Add(new Picture("Holiday2", PictureCategory.Holidays));
            picture.Add(new Picture("Holiday3", PictureCategory.Holidays));
            picture.Add(new Picture("Holiday4", PictureCategory.Holidays));
            picture.Add(new Picture("Holiday5", PictureCategory.Holidays));


            picture.Add(new Picture("Vacation1", PictureCategory.Vacations));
            picture.Add(new Picture("Vacation2", PictureCategory.Vacations));
            picture.Add(new Picture("Vacation3", PictureCategory.Vacations));
            picture.Add(new Picture("Vacation4", PictureCategory.Vacations));
            picture.Add(new Picture("Vacation5", PictureCategory.Vacations));



            return picture;
        }

      
    }
}
