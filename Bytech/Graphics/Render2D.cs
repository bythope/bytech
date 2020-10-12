using Bythope.Bytech.Core;
using EcsRx.Scheduling;
using System.Reactive.Linq;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Bythope.Bytech.Graphics {
    public class Render2D : IRender {

        private IBytech _bytech;
        private IGameScheduler _gameScheduler;
        private SpriteBatch _batch;
        private Color _clearColor = new Color(1, 1, 1, 1);

        public void Initialize(IBytech bytech, IGameScheduler gameScheduler) {
            _bytech = bytech;
            _gameScheduler = gameScheduler;
            _gameScheduler.OnPreRender.Subscribe(x => PreRender(x));
            _gameScheduler.OnRender.Subscribe(x => Render(x));
            _gameScheduler.OnPostRender.Subscribe(x => PostRender(x));
            _batch = new SpriteBatch(_bytech.GraphicsDeviceManager.GraphicsDevice);

        }

        private void PreRender(ElapsedTime elapsedTime) {
            _bytech.GraphicsDeviceManager.GraphicsDevice.Clear(_clearColor);
        }

        private void Render(ElapsedTime elapsedTime) {
            
        }

        private void PostRender(ElapsedTime elapsedTime) {

        }

        public void Dispose() {

        }
    }
}
