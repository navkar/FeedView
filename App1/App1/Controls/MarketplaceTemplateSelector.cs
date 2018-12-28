using App1.Models;
using App1.ViewModels;
using System;
using Xamarin.Forms;

namespace App1.Controls
{
    public class MarketplaceTemplateSelector : DataTemplateSelector
    {
        private readonly DataTemplate TextTemplate;
        private readonly DataTemplate ImageTemplate;

        public MarketplaceTemplateSelector()
        {
            this.TextTemplate = new DataTemplate(typeof(MarketplaceTextViewCell));
            this.ImageTemplate = new DataTemplate(typeof(MarketplaceImageViewCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (!(item is MarketplaceFeedModel feedModel)) return null;
            return (!string.IsNullOrEmpty(feedModel.HeaderImage)) ? this.ImageTemplate : this.TextTemplate;
        }
    }
}
