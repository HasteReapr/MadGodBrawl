using Raylib_cs;

namespace Engine.Core.Components
{
    internal class Sprite2D : Component, IEquatable<Sprite2D>
    {
        internal Texture2D texture;

        public Sprite2D(Texture2D texture)
        {
            this.texture = texture;
            Sprite2DSystem.Register(this);
        }

        internal override void Update(float DeltaTime)
        {
            Transform t = entity.GetComponent<Transform>();
            Raylib.DrawTextureV(texture, t.position, Color.White);
        }

        public bool Equals(Sprite2D? other)
        {
            if (other is Sprite2D)
                return true;
            else
                return false;
        }
    }
}
