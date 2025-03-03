using Engine;
using System.Numerics;
using static Engine.Core.Components.InputBank;

namespace Engine.Core.Components
{
    internal class Transform : Component, IEquatable<Transform>
    {
        internal Vector3 position = Vector3.Zero;
        internal Vector3 scale = Vector3.Zero;
        internal float layer = 0;
        internal float rotation = 0;

        public Transform()
        {
            TransformSystem.Register(this);
        }

        internal Vector3 CalculateDirection(InputBank.INPUTS input)
        {
            Vector3 output = Vector3.Zero;
            int leftRight = 0;
            int upDown = 0;
            if ((input & INPUTS.RIGHT) != 0)
                leftRight += 1;

            if ((input & INPUTS.LEFT) != 0)
                leftRight -= 1;

            if ((input & INPUTS.DOWN) != 0)
                upDown += 1;

            if ((input & INPUTS.UP) != 0)
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
