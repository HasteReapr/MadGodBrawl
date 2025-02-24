using Engine;
using System.Numerics;
using static Engine.Core.Components.InputBank;

namespace Engine.Core.Components
{
    internal class Transform : Component, IEquatable<Transform>
    {
        internal Vector2 position = Vector2.Zero;
        internal Vector2 scale = Vector2.Zero;
        internal float layer = 0;
        internal float rotation = 0;

        public Transform()
        {
            TransformSystem.Register(this);
        }

        internal Vector2 CalculateDirection(InputBank.INPUTS input)
        {
            Vector2 output = Vector2.Zero;
            int leftRight = 0;
            int upDown = 0;
            if ((input & INPUTS.KB_RIGHT) != 0)
                leftRight += 1;

            if ((input & INPUTS.KB_LEFT) != 0)
                leftRight -= 1;

            if ((input & INPUTS.KB_DOWN) != 0)
                upDown += 1;

            if ((input & INPUTS.KB_UP) != 0)
                upDown -= 1;

            output.X += leftRight;
            output.Y += upDown;

            return output;
        }

        public bool Equals(Transform? other)
        {
            if (other is Transform)
                return true;
            else
                return false;
        }
    }
}
