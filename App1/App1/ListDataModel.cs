using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App1
{
    public class ListDataModel
    {
        public string User { get; set; } = "Naveen Karamchetti";
        public string Text { get; set; }
        public string IconUri { get; set; }
        
        public static ObservableCollection<ListDataModel> MockUserData(int userCount = 20)
        {
            var dataModel = new ObservableCollection<ListDataModel>();

            for (int i = 0; i <= userCount; i++)
            {
                dataModel.Add(new ListDataModel() { IconUri = "swastika.png",
                    User = "Lord Kubera",
                    Text = string.Format("{0}", DateTime.UtcNow.Ticks) });
            }

            return dataModel;
        }
    }
}
