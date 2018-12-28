using App1.Models;
using FreshMvvm;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App1.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MarketplaceFeedViewModel : FreshBasePageModel
    {
        public ObservableCollection<MarketplaceFeedModel> MarketplaceFeed { get; set; }

        public override void Init(object initData)
        {
            base.Init(initData);
            MarketplaceFeed = MarketplaceFeedModel.MockUserData(10);
        }
        
    }
}
