using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Enums
{
    
        public enum TetrominoeShape
        {
           I = 1,
           J = 2,
           L = 3,
           O = 4,
           S = 5,
           T = 6,
           Z = 7
        }

        public enum RotationState
        {
            originalState =0,
            oneRotation = 1,
            secondRotation = 2,
            thirdRotation = 3
        }
    
}
