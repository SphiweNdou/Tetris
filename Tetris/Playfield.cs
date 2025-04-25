namespace Tetris
{
    class Playfield
    {
        //used fixed array instead of jaggerred 
        //save memory space and increase efficiency
        private int[,] grid;
        public int Rows { get; }
        public int Columns { get; }

        public int this[int row, int column]
        {
            get {
                return grid[row, column];
            }
            set {
                grid[row, column] = value;
            }
        }

        public Playfield(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            grid = new int[rows, columns];
        }

        public bool IndexExists(int row, int column)
        {
            return ((row >= 0 && row < Rows) && (column >= 0 && column < Columns));
        }

        public bool cellIsEmpty(int row, int column)
        {
            return IndexExists(row, column) && grid[row, column] == 0;
        }

        public bool RowIsFull(int row)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[row, c] == 0)
                    return false;
            }

            return true;
        }

        public bool RowIsEmpty(int row)
        {
            for (int column = 0; column < Columns; column++)
            {
                if (grid[row, column] != 0)
                    return false;
            }

            return true;
        }

        private void ClearRow(int row)
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[row, c] = 0;
            }
        }

        private void MoveRowDown(int row, int numberOfRows)
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[row + numberOfRows, c] = grid[row, c];
                grid[row, c] = 0;
            }
        }

        public int ClearFullRows()
        {
            int clearedRows = 0;

            for (int row = Rows-1; row >= 0 ; row--)
            {
                if (RowIsFull(row))
                {
                    ClearRow(row);
                    clearedRows++;
                } else if (clearedRows > 0)
                {
                    MoveRowDown(row, clearedRows);
                }
            }

            return clearedRows;
        }
    }
}
