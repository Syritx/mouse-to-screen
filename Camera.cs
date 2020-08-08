using System;
using OpenTK.Input;

namespace VertexClick
{
    public class Camera
    {
        int rate = 10;
        int rateTime;
        Game game;

        public Camera(Game game)
        {
            this.game = game;
            game.MouseDown += mouseDown;
        }

        private void mouseDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Mouse Pos {0}, {1}",e.X,e.Y);
            game.ReceiveNewVertex(e.X, e.Y);
        }
    }
}
