using System.Collections.Generic;

namespace Sql_ide_wpf.Services.QueryEditor.Commands
{
    public class CommandHistory
    {
        private List<ICommander> commanders = new List<ICommander>();
        public void push(ICommander commander)
        {
            commanders.Add(commander);
        }
        public void pop()
        {
            if (commanders.Count > 0)
            {
                commanders.RemoveAt(commanders.Count - 1);
            }
        }
    }
}
