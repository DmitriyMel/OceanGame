using Game.GameElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoProject
{
    class VisitorImplemention : IVisitor
    {
        private List<int> cells = new List<int>();
        public VisitorImplemention()
        {

        }
        public void Visit(Cell cell)
        {
            if (cells.Contains(cell.GetHashCode()))
            {
                return;
            }
            cells.Add(cell.GetHashCode());

            cell.Process();
        }
    }
}
