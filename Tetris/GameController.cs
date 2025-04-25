using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Bricks;

namespace Tetris
{
    class GameController
    {
        private Tetrominoe currentBrick;

        public Tetrominoe CurrentBrick
        {
            get
            {
                return currentBrick;
            }

            private set
            {
                currentBrick = value;
                currentBrick.ResetPosition();
            }
        }

        public Playfield Grid { get; }
        public TetrominoeQueue BrickQue { get; }
        public bool GameOver { get; private set; }

        public GameController()
        {
            Grid = new Playfield(22, 10);
            BrickQue = new TetrominoeQueue();
            CurrentBrick = BrickQue.GetBlockAndQueNext();
        }

        private bool BrickFits()
        {
            foreach (Cell cell in CurrentBrick.CellPositionsOnGrid())
            {
                if (!Grid.cellIsEmpty(cell.Row, cell.Column))
                    return false;
            }

            return true;
        }

        public void RotateBrickCW()
        {
            CurrentBrick.RotateClockwise();
            if(!BrickFits())
                CurrentBrick.RotateClockwise();
        }

        public void RotateBrickAntiCW()
        {
            CurrentBrick.RotateAntiClockwise();
            if (!BrickFits())
                CurrentBrick.RotateAntiClockwise();
        }

        public void MoveBrickLeft()
        {
            CurrentBrick.Move(0, -1);

            if (!BrickFits())
                CurrentBrick.Move(0, 1);
        }
        public void MoveBrickRight()
        {
            CurrentBrick.Move(0, 1);

            if (!BrickFits())
                CurrentBrick.Move(0, -1);
        }

        private bool IsGameOver()
        {
            return !(Grid.RowIsEmpty(0) && Grid.RowIsEmpty(1));
        }

        private void setBlock()
        {
            foreach (Cell cell in CurrentBrick.CellPositionsOnGrid())
            {
                Grid[cell.Row, cell.Column] = (int)CurrentBrick.Type;
            }

            Grid.ClearFullRows();
            if (IsGameOver())
            {
                GameOver = true;
            }else
            {
                CurrentBrick = BrickQue.GetBlockAndQueNext();
            }
        }

        public void MoveBrickDown()
        {
            CurrentBrick.Move(1, 0);

            if (!BrickFits())
            {
                CurrentBrick.Move(-1, 0);
                setBlock();
            }   
        }
    }
}
