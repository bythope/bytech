using Bythope.Bytech.Core;

namespace Bythope.Bytech.Graphics {
    public class GraphicsManager : IGraphics {

        private readonly IBytech _bytech;
        private readonly IGameScheduler _gameScheduler;
        private IRender _currentRender;

        public GraphicsManager(IBytech bytech, IGameScheduler gameScheduler) {
            _bytech = bytech;
            _gameScheduler = gameScheduler;
        }

        public void SetRender(IRender render) {
            if (_currentRender != null) {
                _currentRender.Dispose();
            }
            _currentRender = render;
            _currentRender.Initialize(_bytech, _gameScheduler);
        }
    }
}
