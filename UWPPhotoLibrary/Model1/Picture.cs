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
        Vacations,
        Holiday
    }
  public class Picture
    {
        public string Name { get; set; }
        public PictureCategory Category { get; set; }
        public string PictureFile { get; set; }

        public Picture( string name , PictureCategory category)
        {
            Name = name;
            Category = category;
            PictureFile = $"/Assets/Pictures/{Category}/{Name}.png";
        
        }

    }
}
