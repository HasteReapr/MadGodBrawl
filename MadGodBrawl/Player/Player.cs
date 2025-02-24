using Raylib_cs;
using Engine.Core;
using Engine.Core.Components;
using System.Numerics;

using Transform = Engine.Core.Components.Transform;

namespace Engine
{
    internal class Player : Entity
    {
        //The player needs to be drawn, read the inputs from the player, translate said inputs into movement.
        //The player also needs to be on a draw layer that is high enough to not be drawn over by everything, but lower than things like clouds.
        public override string name { get => "PlayerEntity"; }

        internal Player()
        {
            Transform trans = new Transform();
            //TODO 11/28/24
            // Make an actual randomized spawn point, which would have to be done in a world generation file that the Main loop passes the player
            //  information into, so we don't spawn a large distance away from the actual origin of the world, so things can be offset properly.
            // -Don't rely too much on explicitly offsetting stuff from (0, 0) as this is bad practice and doesn't allow for easy expansion.
            trans.position = new Vector2(Program.ScreenW/2, Program.ScreenH/2);
            AddComponent(trans);

            //TODO 11/28/24
            //Make some sort of AnimationHandler for the player, so the sprite can be changed. This won't necessarily need to be done.
            //However for stuff like crops with animations per stage, we would want to have a more in depth AnimatedSprite2D component.
            //Something that would allow for animating down Column0, Column1, Column2 etc. so we can have multiple growth stages on one
            //sprite sheet, instead of spreading it out along multiple textures.
            AnimatedSprite2D sprite = new AnimatedSprite2D(Raylib.LoadTexture("Textures/Player/Player_Anim/Player-Idle.png"), 6, 3, 3);
            AddComponent(sprite);

            InputBank inputBank = new InputBank();
            //AddComponent(inputBank);

            BasicMovement baseMove = new BasicMovement(0.6f);
            AddComponent(baseMove);
        }
    }
}