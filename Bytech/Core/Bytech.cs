using Microsoft.Xna.Framework;

namespace Bythope.Bytech.Core {
    class Bytech : IBytech {

        public GraphicsDeviceManager GraphicsDeviceManager { get; }

        public Bytech(IGameContext gameContext) {
            var game = (Game)gameContext;
            GraphicsDeviceManager = new GraphicsDeviceManager(game);
        }
    }
}
