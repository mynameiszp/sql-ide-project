using System;
using System.Collections.Generic;

namespace Sql_ide_wpf.Services.Customization
{
    public interface IAppCustomizer
    {
        public void Update(List<Uri> data);
    }
}
