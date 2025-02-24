using Raylib_cs;

namespace Engine.Core.Components
{
    ///<Summary>
    /// AnimatedSprite2D takes a sprite and animates it based on parameters that are passed in.
    /// This is a simpler animator than the more complex ones added later on, as it only works horizontally.
    ///</Summary> 
    internal class AnimatedSprite2D : Component, IEquatable<AnimatedSprite2D>
    {
        internal Texture2D texture;
        internal int currentFrame;
        //Max frames is exactly how many frames there are, it gets -1 when used because frames starts at 0.
        internal int maxFrame;

        internal int framesPerSecond;
        internal int frameTimer;

        internal int rows;
        internal int cols;

        internal Rectangle frameRec;

        public AnimatedSprite2D(Texture2D texture, int FrameCount, int FPS, int rows = 1, int cols = 1)
        {
            this.texture = texture;
            this.maxFrame = FrameCount;
            this.framesPerSecond = FPS;

            //These are used if we have multiple rows of an animation, so the animator will know to go down a row, if needed.
            //Animated texture sheets must only have the one single animation in one row. Can not have multiple animations per sheet.
            this.rows = rows;
            this.cols = cols;

            frameRec = new(0f, 0f, (float)texture.Width / FrameCount, (float)texture.Height / rows);

            AnimatedSprite2DSystem.Register(this);
        }

        internal override void Update(float DeltaTime)
        {
            Transform t = entity.GetComponent<Transform>();

            frameTimer++;
            if(frameTimer >= (60 / framesPerSecond))
            {
                frameTimer = 0;
                currentFrame++;

                if(currentFrame > maxFrame - 1)
                {
                    currentFrame = 0;
                }

                frameRec.X = (float)currentFrame * texture.Width / maxFrame;
            }

            Raylib.DrawTextureRec(texture, frameRec, t.position, Color.White);
        }

        public bool Equals(AnimatedSprite2D? other)
        {
            if (other is AnimatedSprite2D)
                return true;
            else
                return false;
        }
    }
}
