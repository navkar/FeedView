using App1.Models;
using FreshMvvm;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ChatPageViewModel : FreshBasePageModel
    {
        public bool ShowScrollTap { get; set; } = false;
        public bool LastMessageVisible { get; set; } = true;
        public int PendingMessageCount { get; set; } = 0;
        public bool PendingMessageCountVisible { get { return PendingMessageCount > 0; } }

        public Queue<ChatMessage> DelayedMessages { get; set; } = new Queue<ChatMessage>();
        public ObservableCollection<ChatMessage> Messages { get; set; } = new ObservableCollection<ChatMessage>();
        public string TextToSend { get; set; }
        public ICommand OnSendCommand { get; set; }
        public ICommand MessageAppearingCommand { get; set; }
        public ICommand MessageDisappearingCommand { get; set; }

        public ChatPageViewModel()
        {
            Messages.Insert(0, new ChatMessage() { Text = "Hi" });
            Messages.Insert(0, new ChatMessage() { Text = "How are you?", User = App.User });
            Messages.Insert(0, new ChatMessage() { Text = "What's new?" });
            Messages.Insert(0, new ChatMessage() { Text = "How is your family", User = App.User });
            Messages.Insert(0, new ChatMessage() { Text = "How is your dog?", User = App.User });
            Messages.Insert(0, new ChatMessage() { Text = "How is your cat?", User = App.User });
            Messages.Insert(0, new ChatMessage() { Text = "How is your sister?" });
            Messages.Insert(0, new ChatMessage() { Text = "When we are going to meet?" });
            Messages.Insert(0, new ChatMessage() { Text = "I want to buy a laptop" });
            Messages.Insert(0, new ChatMessage() { Text = "Where I can find a good one?" });
            Messages.Insert(0, new ChatMessage() { Text = "Also I'm testing this chat" });
            Messages.Insert(0, new ChatMessage() { Text = "Oh My God!" });
            Messages.Insert(0, new ChatMessage() { Text = " No Problem", User = App.User });
            Messages.Insert(0, new ChatMessage() { Text = "Hugs and Kisses", User = App.User });
            Messages.Insert(0, new ChatMessage() { Text = "When we are going to meet?" });
            Messages.Insert(0, new ChatMessage() { Text = "I want to buy a laptop" });
            Messages.Insert(0, new ChatMessage() { Text = "Where I can find a good one?" });
            Messages.Insert(0, new ChatMessage() { Text = "Also I'm testing this chat" });
            Messages.Insert(0, new ChatMessage() { Text = "Oh My God!" });
            Messages.Insert(0, new ChatMessage() { Text = " No Problem" });
            Messages.Insert(0, new ChatMessage() { Text = "Hugs and Kisses" });

            MessageAppearingCommand = new Command<ChatMessage>(OnMessageAppearing);
            MessageDisappearingCommand = new Command<ChatMessage>(OnMessageDisappearing);

            OnSendCommand = new Command(() =>
            {
                if (!string.IsNullOrEmpty(TextToSend))
                {
                    Messages.Insert(0, new ChatMessage() { Text = TextToSend, User = App.User });
                    TextToSend = string.Empty;
                }

            });

            
            Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                if (LastMessageVisible)
                {
                    Messages.Insert(0, new ChatMessage() { Text = "Hi @ " + System.DateTime.UtcNow.ToLocalTime().ToLongTimeString(), User = "Puza" });
                }
                else
                {
                    DelayedMessages.Enqueue(new ChatMessage() { Text = "Hi @ " + System.DateTime.UtcNow.ToLocalTime().ToLongTimeString(), User = "Puza" });
                    PendingMessageCount++;
                }
                return true;
            });



        }

        void OnMessageAppearing(ChatMessage message)
        {
            var idx = Messages.IndexOf(message);
            if (idx <= 6)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    while (DelayedMessages.Count > 0)
                    {
                        Messages.Insert(0, DelayedMessages.Dequeue());
                    }
                    ShowScrollTap = false;
                    LastMessageVisible = true;
                    PendingMessageCount = 0;
                });
            }
        }

        void OnMessageDisappearing(ChatMessage message)
        {
            var idx = Messages.IndexOf(message);
            if (idx >= 6)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    ShowScrollTap = true;
                    LastMessageVisible = false;
                });

            }
        }


        //public event PropertyChangedEventHandler PropertyChanged;
    }
}
