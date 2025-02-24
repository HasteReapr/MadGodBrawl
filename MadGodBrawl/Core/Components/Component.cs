using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Core;

namespace Engine.Core.Components
{
    internal class Component
    {
        internal Entity entity;
        //PreUpdate is the Update function that is called just before the Update function. This will contain small things in it.
        internal virtual void PreUpdate(float DeltaTime) { Update(DeltaTime); }

        //TODO At some point, go through and make a solidified game tick count. Something like 30tps, so we can control events.
        //Update is called every game tick, which as of right now is every single frame that it can call things at.
        internal virtual void Update(float DeltaTime) { }

        //TODO This method is theoretical placeholder, it would be an update that would be called every 0.016(1/60) seconds. 
        internal virtual void TickedUpdate() { }
    }
}
