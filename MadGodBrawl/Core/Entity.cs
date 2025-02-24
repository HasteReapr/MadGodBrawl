using Raylib_cs;
using Engine.Core.Components;

namespace Engine.Core
{
    internal class Entity
    {
        public int ID { get; set; }
        public virtual String name { get; }

        internal List<Component> components = new List<Component>();

        //Simply does what it says on the tin, adds whatever component passed in onto the entity.
        internal void AddComponent(Component component)
        {
            components.Add(component);
            component.entity = this;
        }

        //Gets the component attached to the entity, and returns null if it doesn't exist.
        internal T GetComponent<T>() where T : Component
        {
            foreach (Component component in components)
            {
                if (component.GetType().Equals(typeof(T)))
                {
                    return (T)component;
                }
            }
            return null;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
