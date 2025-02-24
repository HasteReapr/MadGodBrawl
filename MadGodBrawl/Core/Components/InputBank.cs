using Engine.Core.Systems;
using Raylib_cs;
using System.Reflection.Metadata;

namespace Engine.Core.Components
{
    /// <summary>
    /// Input bank is the buffer between the Player's input device to the actual actions done in game.
    /// The input bank can be used for an input device locally, and through the network.
    /// </summary>

    internal class InputBank : Component, IEquatable<InputBank>
    {

        [Flags] 
        internal enum INPUTS {
            KB_NULL = 0,
            KB_UP = (1 << 0),
            KB_DOWN = (1 << 1),
            KB_LEFT = (1 << 2),
            KB_RIGHT = (1 << 3),
            KB_DASH = (1 << 4),
            KB_SPRINT = (1 << 5),
        }

        internal INPUTS inputReader;

        internal InputBank()
        {
            inputReader = new INPUTS();

            InputBankSystem.Register(this);
        }

        //We want read the inputs before we run our Update() function, so we have the inputs stored to then be used as needed.
        internal override void PreUpdate(float DeltaTime)
        {
            //We use this to determine what inputs are being pressed.
            ReadInputs();

            base.PreUpdate(DeltaTime);
        }

        private void ReadInputs()
        {
            //Expand this at some point so it isn't hard coded, so it will work with controllers and stuff
            inputReader = 0;
            if (Raylib.IsKeyDown(KeyboardKey.D))
                inputReader |= INPUTS.KB_RIGHT;
            //Left
            if (Raylib.IsKeyDown(KeyboardKey.A))
                inputReader |= INPUTS.KB_LEFT;
            //Up
            if (Raylib.IsKeyDown(KeyboardKey.W))
                inputReader |= INPUTS.KB_UP;
            //Down
            if (Raylib.IsKeyDown(KeyboardKey.S))
                inputReader |= INPUTS.KB_DOWN;
            //Dash
            if (Raylib.IsKeyDown(KeyboardKey.Space))
                inputReader |= INPUTS.KB_DASH;
            //Sprint
            if (Raylib.IsKeyDown(KeyboardKey.LeftShift))
                inputReader |= INPUTS.KB_SPRINT;
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
