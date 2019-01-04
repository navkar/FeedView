using App1.Models;
using App1.Views.Cells;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1.Controls
{
    public class ChatTemplateSelector : DataTemplateSelector
    {
        DataTemplate incomingDataTemplate;
        DataTemplate outgoingDataTemplate;

        public ChatTemplateSelector()
        {
            this.incomingDataTemplate = new DataTemplate(typeof(IncomingViewCell));
            this.outgoingDataTemplate = new DataTemplate(typeof(OutgoingViewCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var messageVm = item as ChatMessage;
            if (messageVm == null)
                return null;


            return (messageVm.User == App.User) ? outgoingDataTemplate : incomingDataTemplate;
        }
    }
}
