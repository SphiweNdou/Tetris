using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Enums;

namespace Tetris.Bricks
{
    class IBrick : Tetrominoe
    {
        private readonly Cell[][] originalTiles = new Cell[][]
        {
            new Cell[] { new Cell(1,0), new Cell(1,1), new Cell(1,2), new Cell(1,3) },
            new Cell[] { new Cell(0,2), new Cell(1,2), new Cell(2,2), new Cell(3,2) },
            new Cell[] { new Cell(2,0), new Cell(2,1), new Cell(2,2), new Cell(2,3) },
            new Cell[] { new Cell(0,1), new Cell(1,1), new Cell(2,1), new Cell(3,1) }
        };

        protected override Cell[][] BlueprintTiles => originalTiles;
        protected override Cell StartOffset => new Cell(-1, 3);
        public override TetrominoeShape Type => TetrominoeShape.I;
    }
}
