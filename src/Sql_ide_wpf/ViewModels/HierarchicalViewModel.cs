using SQL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sql_ide_wpf.ViewModels
{
    public class HierarchicalViewModel: ViewModelBase
    {
        public DatabaseEntitiesViewModel DatabaseEntitiesViewModel { get; set; }
        public SchemeEntitiesViewModel SchemaEntitiesViewModel { get; set; }
        public TableEntitiesViewModel TableEntitiesViewModel { get; set; }
        public ColumnEntitiesViewModel ColumnEntitiesViewModel { get; set; }

        public HierarchicalViewModel()
        {
            DatabaseEntitiesViewModel = new DatabaseEntitiesViewModel();
            SchemaEntitiesViewModel = new SchemeEntitiesViewModel();
            TableEntitiesViewModel = new TableEntitiesViewModel();
            ColumnEntitiesViewModel = new ColumnEntitiesViewModel();
        }
    }
}
