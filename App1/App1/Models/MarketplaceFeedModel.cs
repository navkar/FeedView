using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App1.Models
{
    [AddINotifyPropertyChangedInterface]
    public class MarketplaceFeedModel
    {
        public string FormattedDateTime { get; set; }
        public string User { get; set; }
        public string OrgName { get; set; }
        public string IconUri { get; set; }
        public string AdCaption { get; set; }
        public string AdText { get; set; }
        public List<string> AdImages { get; set; }
        public string HeaderImage { get; set; }

        public static ObservableCollection<MarketplaceFeedModel> MockUserData(int userCount = 10)
        {
            var dataModel = new ObservableCollection<MarketplaceFeedModel>();

            dataModel.Add(new MarketplaceFeedModel()
            {
                User = "John Worthinton",
                OrgName = "Passport",
                AdCaption = "Fire Sale! Must go today!",
                AdText = "This is a long text. This is a long text. This is a long text. This is a long text. This is a long text. This is a long text. This is a long text. This is a long text. This is a long text. This is a long text. This is a long text. This is a long text. This is a long text. This is a long text. This is a long text. This is a long text. This is a long text. This is a long text. ",
                HeaderImage = "people.jpeg",
                FormattedDateTime = DateTimeOffset.UtcNow.ToString("MMM.dd.yyyy hh:mm tt")
            });

            dataModel.Add(new MarketplaceFeedModel()
            {
                OrgName = "Drivers License (DL)",
                FormattedDateTime = DateTimeOffset.UtcNow.ToString("MMM.dd.yyyy hh:mm tt")
            });

            dataModel.Add(new MarketplaceFeedModel()
            {
                OrgName = "Identity Card (ID)",
                FormattedDateTime = DateTimeOffset.UtcNow.ToString("MMM.dd.yyyy hh:mm tt")
            });

            for (int i = 0; i < userCount; i++)
            {
                dataModel.Add(new MarketplaceFeedModel()
                {
                    IconUri = "people.jpeg",
                    User = "Drivers License",
                    OrgName = "Essential Consultants LLC",
                    AdCaption = "Fire Sale! Must go today!",
                    AdText = "This is a long text. This is a long text. This is a long text. This is a long text. This is a long text. This is a long text. This is a long text. This is a long text. This is a long text. This is a long text. This is a long text. This is a long text. This is a long text. This is a long text. This is a long text. This is a long text. This is a long text. This is a long text. ",
                    FormattedDateTime = DateTimeOffset.UtcNow.ToString("MMM.dd.yyyy hh:mm tt")
                });
            }



            return dataModel;
        }
    }
}
