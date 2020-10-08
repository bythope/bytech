using EcsRx.Infrastructure;
using EcsRx.Infrastructure.Dependencies;
using EcsRx.Infrastructure.Ninject;
using EcsRx.MicroRx.Subjects;
using EcsRx.Plugins.ReactiveSystems;
using EcsRx.Plugins.ReactiveSystems.Extensions;
using System;
using System.Reactive;
using System.Reactive.Linq;

namespace Bythope.Bytech.Core {
    public class Runtime : EcsRxApplication, IDisposable {

        public override IDependencyContainer Container { get; } = new NinjectDependencyContainer();
        public IObservable<Unit> OnRun => _onRun;
        public IObservable<Unit> OnExit => _onExit;
        private readonly IGameContext _gameContext;
        private readonly Subject<Unit> _onRun, _onExit;

        public Runtime() {
            _onRun = new Subject<Unit>();
            _onExit = new Subject<Unit>();
            _gameContext = new GameContext();
        }

        public void Setup() {
            _gameContext.OnLoading.FirstAsync().Subscribe(x => StartApplication());
            _gameContext.OnUnloading.FirstAsync().Subscribe(x => _onExit.OnNext(Unit.Default));
            _gameContext.Run();
        }

        protected override void LoadPlugins() {
            base.LoadPlugins();
            RegisterPlugin(new ReactiveSystemsPlugin());
        }

        protected override void LoadModules() {
            base.LoadModules();
            Container.LoadModule(new BytechModule(_gameContext));
            // LOAD MODULES
        }

        protected override void StartSystems() {
            this.StartAllBoundReactiveSystems();
        }

        protected override void ApplicationStarted() {
            _onRun.OnNext(Unit.Default);
        }

        public void Dispose() {
            _gameContext.Dispose();
        }
    }
}
