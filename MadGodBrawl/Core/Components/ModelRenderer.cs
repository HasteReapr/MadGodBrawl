using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Engine.Core.Components
{
    internal class ModelRenderer : Component
    {
        internal Transform trans;
        internal Vector3? offset_amt;
        private bool isOffset = false;

        public ModelRenderer(Vector3? offset_amt = null)
        {
            if(offset_amt != null)
            {
                this.offset_amt = offset_amt;
                isOffset = true;
            }

            ModelRendererSystem.Register(this);
        }

        internal override void Initialize() 
        {
            base.Initialize();
            trans = entity.GetComponent<Transform>();
        }

        internal override void Update(float DeltaTime)
        {
            base.Update(DeltaTime);
            Draw(DeltaTime);
        }

        private void Draw(float DeltaTime)
        {
            Vector3 position = Vector3.Zero;

            if (isOffset)
            {
                position.X += offset_amt.Value.X;
                position.Y += offset_amt.Value.Y;
                position.Z += offset_amt.Value.Z;
            }

            DrawCube(position, 6, 6, 6, Color.Gold);
        }
    }
}