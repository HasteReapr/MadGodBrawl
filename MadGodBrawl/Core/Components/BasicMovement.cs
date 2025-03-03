using System.Numerics;
using static Engine.Core.Components.InputBank;
using static Raylib_cs.Raylib;

namespace Engine.Core.Components
{
    /// <summary>
    /// This Component is a basic movement component, it does not care about acceleration, or any sort of friction,
    /// it will always add directly to the position.
    /// This is good for something like a simple projectile, that doesn't necessarily need to be doing much more than moving in a straight line.
    /// </summary>
    /// 
    /// <param>
    /// float moveSpeed
    /// The speed at which something will move.
    /// </param>
    /// <param>
    /// Vector2 moveDir
    /// This is a vector used to point where we want to move, it gets normalized so diagonals don't get moved more.
    /// Since Transform will be directly added to, and its a Vector2 we can use this to add onto our movement.
    /// </param>

    internal class BasicMovement : Component, IEquatable<BasicMovement>
    {
        private float moveSpeed;
        private Vector3 moveDir;
        internal BasicMovement(float moveSpeed)
        {
            this.moveSpeed = moveSpeed;
            moveDir = Vector3.Zero;
            BasicMovementSystem.Register(this);
        }

        internal override void PreUpdate(float DeltaTime)
        {
            if (entity.GetComponent<InputBank>() == null)
                throw new NullReferenceException($"{entity} BasicMovement Component needs the InputBank Component to function!");
                //Console.Error.WriteLine($"Null Reference Exception on {entity}: BasicMovement Component needs the Transform Component to function!");

            base.PreUpdate(DeltaTime);
        }

        internal override void Update(float DeltaTime)
        {
            //We grab our transform which lets us calculate our direction based on inputs, and then we move the position.
            Transform t = entity.GetComponent<Transform>();
            InputBank input = entity.GetComponent<InputBank>();

            moveDir = t.CalculateDirection(input.inputReader);

            Vector3 moveVec = moveDir * moveSpeed; //We multiply our speed by the movement direction, so we can move.
            Vector3.Normalize(moveVec);

            t.position += moveVec;
        }

        public bool Equals(BasicMovement? other)
        {
            if (other is BasicMovement)
                return true;
            else
                return false;
        }
    }
}
