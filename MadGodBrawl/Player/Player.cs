using Raylib_cs;
using Engine.Core;
using Engine.Core.Components;
using System.Numerics;

using Transform = Engine.Core.Components.Transform;

namespace Engine
{
    internal class Player : Entity
    {
        // The player and the characters are 2 different things. The player entity is what keeps track of info the player needs such as meter, hitstun, health etc.
        // Characters are the actual meat and butter of the game, as they are what is being controlled on screen. This theoretically allows there to be a ghost player that recieves inputs from network.
        
        // This works by taking the inputs and stuff in the player entity, checking if they can be forwarded (i.e. are we stunned, are we in an attack etc) then forwarding these inputs into the character the player controls. 
        public override string name { get => "PlayerEntity"; }

        [Flags] //Currently this is an 8byte thing holding the player states. Could bump it up higher though.
        internal enum CHARACTERSTATES
        {
            IDLE        = 0,
            MOVING      = (1 << 0),
            JUMPING     = (1 << 1),
            LANDING     = (1 << 2),
            BLOCKING    = (1 << 3),
            BLOCKSTUN   = (1 << 4),
            STRIKING    = (1 << 5),
            HITSTUN     = (1 << 6),
            PARRY       = (1 << 7),
        }

        //we check the flags with ((input & CHARACTERSTATES.IDLE) != 0)

        internal Player()
        {
            Transform trans = new Transform();
            trans.position = new Vector3(0, 0, 0);
            AddComponent(trans);

            InputBank inputBank = new InputBank();
            AddComponent(inputBank);

            BasicMovement baseMove = new BasicMovement(0.6f);
            AddComponent(baseMove);

            ModelRenderer model = new ModelRenderer(new Vector3(0, 3, 0));
            AddComponent(model);
        }
    }
}