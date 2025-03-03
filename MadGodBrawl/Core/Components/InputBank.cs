using Engine.Core.Systems;
using Raylib_cs;
using System.Reflection.Metadata;
using System.Collections;

namespace Engine.Core.Components
{
    /// <summary>
    /// Input bank is the buffer between the Player's input device to the actual actions done in game.
    /// The input bank can be used for an input device locally, and through the network.
    /// </summary>

    internal class InputBank : Component, IEquatable<InputBank>
    {

        [Flags] //Inputs are compacted into a single 9 byte thing this then gets decompacted
        internal enum INPUTS {
            NULL = 0,
            UP = (1 << 0),
            DOWN = (1 << 1),
            LEFT = (1 << 2),
            RIGHT = (1 << 3),

            A = (1 << 4),
            B = (1 << 5),
            C = (1 << 6),
            D = (1 << 7),
            E = (1 << 8),
        }

        internal struct INPUT_INFO
        {
            public INPUT_INFO(double timeStamp, INPUTS input )
            {
                this.input = input;
                this.timeStamp = timeStamp;
            }

            internal double timeStamp;
            internal INPUTS input;
        }

        internal INPUTS inputReader;
        internal INPUT_INFO[] inputBuffer;
        internal Queue<INPUT_INFO> inputQueue;

        internal InputBank()
        {
            inputReader = new INPUTS();

            InputBankSystem.Register(this);
        }

        //We want read the inputs before we run our Update() function, so we have the inputs stored to then be used as needed.
        internal override void PreUpdate(float DeltaTime)
        {
            //We use this to determine what inputs are being pressed.
            ReadInputs(DeltaTime);

            base.PreUpdate(DeltaTime);
        }

        private void ReadInputs(float DeltaTime)
        {
            //Expand this at some point so it isn't hard coded, so it will work with controllers and stuff
            inputReader = 0;
            if (Raylib.IsKeyDown(KeyboardKey.D))
                inputReader |= INPUTS.RIGHT;
            //Left
            if (Raylib.IsKeyDown(KeyboardKey.A))
                inputReader |= INPUTS.LEFT;
            //Up
            if (Raylib.IsKeyDown(KeyboardKey.W))
                inputReader |= INPUTS.UP;
            //Down
            if (Raylib.IsKeyDown(KeyboardKey.S))
                inputReader |= INPUTS.DOWN;

            INPUT_INFO info = new INPUT_INFO(Raylib.GetTime(), inputReader);

            AddInputToBuffer(info);
        }

        internal void AddInputToBuffer(INPUT_INFO info)
        {
            
        }

        internal void RemoveInputFromBuffer()
        {

        }

        public bool Equals(InputBank? other)
        {
            if (other is InputBank)
                return true;
            else
                return false;
        }
    }
}
