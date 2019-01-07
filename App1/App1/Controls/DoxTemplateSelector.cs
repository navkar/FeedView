using App1.Models;
using App1.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1.Controls
{
    public class DoxTemplateSelector : DataTemplateSelector
    {
        DataTemplate hasImageTemplate;
        DataTemplate hasTextTemplate;

        public DoxTemplateSelector()
        {
            this.hasImageTemplate = new DataTemplate(typeof(ImageOnlyViewCell));
            this.hasTextTemplate = new DataTemplate(typeof(TextOnlyViewCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var feed = item as MarketplaceFeedModel;
            if (feed == null)
                return null;
            return string.IsNullOrEmpty(feed.IconUri) ? hasTextTemplate : hasImageTemplate;
        }
    }
}
