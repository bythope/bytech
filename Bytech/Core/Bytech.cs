using EcsRx.Collections.Database;
using EcsRx.Events;
using EcsRx.Executor;
using EcsRx.Infrastructure.Dependencies;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Bythope.Bytech.Core {
    class Bytech : IBytech {

        public GraphicsDeviceManager Graphics { get; }
        public IGameScheduler GameScheduler { get; }
        public GameComponentCollection Components { get; }
        public ContentManager Content { get; }
        public GameServiceContainer Services { get; }
        public GameWindow Window { get; }
        public LaunchParameters Parameters { get; }
        public IDependencyContainer Container { get; private set; }
        public IEntityDatabase EntityDatabase { get; private set; }
        public IEventSystem EventSystem { get; private set; }
        public ISystemExecutor SystemExecutor { get; private set; }
        public bool IsMouseVisible { get => _game.IsMouseVisible; set => _game.IsMouseVisible = value; }
        public bool IsActive => _game.IsActive;
        public bool IsFixedTimeStep => _game.IsFixedTimeStep;

        private readonly Boot _boot;
        private readonly Game _game;

        public Bytech(Boot boot) {
            _boot = boot;
            _game = boot.GameContext;
            Graphics = new GraphicsDeviceManager(_game);
            GameScheduler = boot.GameContext;
            Components = _game.Components;
            Content = _game.Content;
            Services = _game.Services;
            Window = _game.Window;
            Parameters = _game.LaunchParameters;
        }

        public void Setup() {
            Container = _boot.Container;
            EntityDatabase = _boot.EntityDatabase;
            EventSystem = _boot.EventSystem;
            SystemExecutor = _boot.SystemExecutor;
        }

        public void Exit() => _game.Exit();
    }
}
