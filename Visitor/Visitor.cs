using Game.GameElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoProject
{
    internal interface IVisitor
    {
        void Visit(Cell cell);
    }
}
