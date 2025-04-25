using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Bricks;

namespace Tetris
{
    class TetrominoeQueue
    {
        private Tetrominoe[] bricks = new Tetrominoe[]
        {
            new IBrick(),
            new JBrick(),
            new LBrick(),
            new OBrick(),
            new SBrick(),
            new TBrick(),
            new ZBrick()
        };

        private Random random = new Random();

        private Tetrominoe NextInLine { get; set; }

        public TetrominoeQueue()
        {
            NextInLine = Randomblock();
        }
        private Tetrominoe Randomblock()
        {
            return bricks[random.Next(bricks.Length)];
        }

        public Tetrominoe GetBlockAndQueNext()
        {
            Tetrominoe returnBrick = NextInLine;

            do
            {
                NextInLine = Randomblock();
            } while (returnBrick.Type == NextInLine.Type);

            return returnBrick;
        }
    }
}
