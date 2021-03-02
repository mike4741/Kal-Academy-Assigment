using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
  public class Picture : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public PictureCategory Category { get; set; }
        public string AudioFile { get; set; }
        public string PictureFile { get; set; }
        private string picturedescription = String.Empty;
        public string PictureDescription 
        { get
            {
                return this.picturedescription;
            }

          set
            {
                if (value != this.picturedescription)
                {
                    this.picturedescription = value;
                    NotifyPropertyChanged();
                }
            }

        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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
