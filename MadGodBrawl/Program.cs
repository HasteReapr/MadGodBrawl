using Engine.Core.Components;
using Engine.Core.Systems;
using Raylib_cs;
using static Raylib_cs.Raylib;
using Engine.Core;
using System.Runtime.CompilerServices;
using Transform = Engine.Core.Components.Transform;
using System.Numerics;

namespace Engine
{
    internal class TransformSystem : BaseSystem<Transform> { };
    internal class InputBankSystem : BaseSystem<InputBank> { };
    internal class BasicMovementSystem : BaseSystem<BasicMovement> { };
    internal class ModelRendererSystem : BaseSystem<ModelRenderer> { };

    internal enum GameStates : int
    {
        MAIN_MENU = 0,
        MATCH = 1,
    };


    internal class Program
    {
        internal static float deltaTime; // Keep in mind that deltaTime will always have a one frame delay, due to how its calculated.

        internal static int Current_State = (int)GameStates.MAIN_MENU;

        internal static readonly int ScreenH = 1200;
        internal static readonly int ScreenW = 1600;

        internal static Camera3D camera;

        internal static Player player;

        internal static ResourceManager resourceManager;

        internal static bool gamePaused = false;

        public static void Main()
        {
            //This must be the first thing that happens, otherwise the sprites and the like will be unable to draw properly.
            InitWindow(ScreenW, ScreenH, "Mad God Brawl!");

            Initialize();

            while (!WindowShouldClose())
            {
                deltaTime = GetFrameTime();

                Draw();
            }

            CloseWindow();
        }

        public static void Initialize()
        {
            //Since we are going to be locking the FPS
            SetTargetFPS(60);

            player = new Player();

            camera = new Camera3D();
            camera.Position = new Vector3(0f, 20, 200);
            camera.Target = new Vector3(0f, 0f, 0f);
            camera.Up = new Vector3(0f, 1f, 0f);
            camera.FovY = 15;
            camera.Projection = CameraProjection.Perspective;

            TransformSystem.Initialize();
            InputBankSystem.Initialize();
            BasicMovementSystem.Initialize();
            ModelRendererSystem.Initialize();
        }

        //This exists to kind of pull the drawing stuff outside of the main loop, so it's a bit easier to comprehend.
        public static void Draw()
        {
            BeginDrawing();

            ClearBackground(Color.RayWhite);

            //Start working within world space.
            BeginMode3D(camera);

            //DrawCube(new Vector3(-24, 3, 3), 6, 6, 6, Color.Gold);

            ModelRendererSystem.Update(deltaTime);

            //DrawCube(new Vector3(24, 3, 3), 6, 6, 6, Color.Red);

            DrawGrid(180, 1);

            //Anything after this happens in screen space, instead of the world space, which means its all 2D instead of 3D.
            EndMode3D();

            DrawFPS(20, 20);

            EndDrawing();
        }
    }
}
