using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace VertexClick
{
    public class Game : GameWindow
    {
        Vector3[] vertices;
        float zOffset;
        int count = 0;
        public int runTime = 0;

        Camera camera;

        public Game(int width, int height) : base(width,height,GraphicsMode.Default,"Vertex Click") 
        {
            vertices = new Vector3[10000];
            zOffset = -1;

            camera = new Camera(this);

            start();
        }

        void start()
        {
            RenderFrame += render;
            Resize += resize;
            Load += load;

            Run(60);
        }

        public void ReceiveNewVertex(float x, float y)
        {
            Console.WriteLine("SCREEN POS {0}, {1}",x,y)
        }

        private void render(object sender, FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            SwapBuffers();
        }

        private void resize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            GL.Ortho(0, Width, Height, 0, 0.1, 1000); // IMPORTANT
            GL.End();
        }

        private void load(object sender, EventArgs e)
        {
            GL.ClearColor(0, 0, 0, 0);
            GL.Enable(EnableCap.DepthTest);
        }
    }
}
