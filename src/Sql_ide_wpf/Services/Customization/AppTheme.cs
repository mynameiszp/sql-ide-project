using System;
using System.Collections.Generic;
using System.Windows;

namespace Sql_ide_wpf.Services.Customization
{
    public class AppTheme : IAppCustomizer
    {
        public void Update(List<Uri> data)
        {
            foreach (Uri uri in data)
            {
                if (uri.ToString().Contains("/Themes/"))
                {
                    ResourceDictionary Theme = new ResourceDictionary() { Source = uri };
                    Application.Current.Resources.MergedDictionaries.Add(Theme);
                    break;
                }
            }
        }
    }
}
