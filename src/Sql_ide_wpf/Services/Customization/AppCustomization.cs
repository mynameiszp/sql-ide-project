using System;
using System.Collections.Generic;
using System.Windows;

namespace Sql_ide_wpf.Services.Customization
{
    public class AppCustomization
    {
        private List<IAppCustomizer> subscribers = new List<IAppCustomizer>();

        public void Subscribe(IAppCustomizer subscriber)
        {
            subscribers.Add(subscriber);
        }
        public void Unsubscribe(IAppCustomizer subscriber)
        {
            subscribers.Remove(subscriber);
        }

        public void NotifyAll(List<Uri> data)
        {
            Application.Current.Resources.Clear();
            foreach (var subscriber in subscribers)
            {
                subscriber.Update(data);
            }
        }
    }
}
