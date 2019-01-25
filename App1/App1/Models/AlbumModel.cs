using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App1.Models
{
    [AddINotifyPropertyChangedInterface]
    public class AlbumModel
    {
        public static ObservableCollection<SongModel> MockAlbumData(int songCount = 10)
        {
            var dataModel = new ObservableCollection<SongModel>();

            for (int i = 0; i < songCount; i++)
            {
                dataModel.Add(new SongModel()
                {
                    AlbumArt = "namaste.png",
                    AlbumName = "Monk Mindfulness",
                    SongName = "Om Namo Narayana"
                });
            }
            return dataModel;
        }
    }
}
