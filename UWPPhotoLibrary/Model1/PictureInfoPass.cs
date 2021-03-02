using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using UWPPhotoLibrary.Model1;

namespace UWPPhotoLibrary
{
    public class PictureInfoPass
    {
        public string SinglePhotoName { get; set; }
        public ObservableCollection<Picture> PassingPhotoList { get; set; }

        public PictureInfoPass(string singlephotoname, ObservableCollection<Picture> passingphotolist)
        {
            SinglePhotoName = singlephotoname;
            PassingPhotoList = passingphotolist;
        }


    }
}
