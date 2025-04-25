using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Enums;

namespace Tetris
{
    public abstract class Tetrominoe
    {
        protected abstract Cell[][] BlueprintTiles { get; }
        protected abstract Cell StartOffset { get; }
        public abstract TetrominoeShape Type { get; }
        private RotationState rotationState;
        private readonly Cell offset;

        protected Tetrominoe()
        {
            offset = new Cell(StartOffset.Row, StartOffset.Column);
        }
        
        /* yield is cool new technique that makes it not neccesary to create a temp
         * variable and then return it in the end. also its more memory efficient
        */
        public IEnumerable<Cell> CellPositionsOnGrid()
        {
            var blah = (int)rotationState;
            foreach (Cell cell in BlueprintTiles[(int)rotationState])
            {
                yield return new Cell(cell.Row + offset.Row, cell.Column + offset.Column);
            }
        }

        public void RotateClockwise()
        {
            rotationState = (RotationState)( ( (int)rotationState +1 ) % BlueprintTiles.Length );
        }

        public void RotateAntiClockwise()
        {
            if (rotationState == RotationState.originalState)
                rotationState = (RotationState)BlueprintTiles.Length -1;
            else
                rotationState = (RotationState)(int)rotationState - 1;
        }

        public void Move(int rows, int columns)
        {
            offset.Row += rows;
            offset.Column += columns;
        }

        public void ResetPosition()
        {
            rotationState = RotationState.originalState;
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }
    }
}
