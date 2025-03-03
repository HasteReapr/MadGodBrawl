using Engine.Core.Components;

namespace Engine.Core.Systems
{
    internal class BaseSystem<T> where T : Component
    {
        protected static List<T> components = new List<T>();

        internal static void Register(T component)
        {
            components.Add(component);
        }

        internal static void Initialize()
        {
            foreach (T component in components)
            {
                component.Initialize();
            }
        }

        internal static void PreUpdate(float deltaTime)
        {
            foreach(T component in components)
            {
                component.PreUpdate(deltaTime);
            }
        }

        internal static void Update(float deltaTime)
        {
            foreach (T component in components)
            {
                component.Update(deltaTime);
            }
        }
    }
}
