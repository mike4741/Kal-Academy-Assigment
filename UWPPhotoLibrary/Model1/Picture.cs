using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPPhotoLibrary.Model1
{
  public enum  PictureCategory
    {
        Cooking,
        Family,
        Holidays,
        Vacations
    }
  public class Picture
    {
        public string Name { get; set; }
        public PictureCategory Category { get; set; }
        public string AudioFile { get; set; }
        public string PictureFile { get; set; }
        public string PictureDescription { get; set; }
      

        public Picture( string name , PictureCategory category, string pictureDescription)
        {
            Name = name;
            Category = category;
            PictureDescription = pictureDescription;
            //AudioFile = $"/Assets/Audio/{Category}/{Name}.wav";
            PictureFile = $"/Assets/Pictures/{Category}/{Name}.png";
            
              
        }

    }
}
