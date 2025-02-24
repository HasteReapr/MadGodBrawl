using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Engine.Core
{
    internal class ResourceManager
    {
        //As we need more information, we will expand this. For now this exists to store textures.
        internal static Dictionary<string, Texture2D> TextureDict;

        internal ResourceManager()
        {
            TextureDict = new Dictionary<string, Texture2D>();
        }

        // We need some way to query if this resource is already loaded, meaning we have to come up with some sort of 2D value that can be retrieved.
        // This value needs to be able to be stored in a list, so the list can be expanded.

        internal static Texture2D LoadOrRetrieveTexture(string filePoint, string identifier)
        {
            //If we have this identifier and texture stored, just return that.
            if (TextureDict.ContainsKey(identifier))
                return TextureDict[identifier];

            //Since we don't have the identifier and texture stored we will need to save the value in our dictionary.
            Texture2D loadedTexture = LoadTexture(filePoint);

            TextureDict.Add(identifier, loadedTexture);

            return loadedTexture;
        }

        //This won't ever need to be used, I don't think.
        internal static void DiscardTexture(string identifier)
        {
            TextureDict.Remove(identifier);
        }
    }
}
