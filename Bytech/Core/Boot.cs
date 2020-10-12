using EcsRx.Infrastructure;
using EcsRx.Infrastructure.Dependencies;
using EcsRx.Infrastructure.Ninject;
using EcsRx.MicroRx.Subjects;
using EcsRx.Plugins.ReactiveSystems;
using EcsRx.Plugins.ReactiveSystems.Extensions;
using Microsoft.Xna.Framework;
using System;
using System.Reactive;
using System.Reactive.Linq;

namespace Bythope.Bytech.Core {
    public class Boot : EcsRxApplication, IDisposable {

        public override IDependencyContainer Container { get; } = new NinjectDependencyContainer();
        public IObservable<Unit> OnRun => _onRun;
        public IObservable<Unit> OnExit => _onExit;
        public IBytech Bytech { get; private set; }
        public GameContext GameContext { get; private set; }
        private readonly Subject<Unit> _onRun, _onExit;

        public Boot() {
            _onRun = new Subject<Unit>();
            _onExit = new Subject<Unit>();
            GameContext = new GameContext();
            Bytech = new Bytech(this);
        }

        public void Run() {
            GameContext.OnLoading.FirstAsync().Subscribe(x => StartApplication());
            GameContext.OnUnloading.FirstAsync().Subscribe(x => _onExit.OnNext(Unit.Default));
            GameContext.Run();
        }

        protected override void LoadPlugins() {
            base.LoadPlugins();
            RegisterPlugin(new ReactiveSystemsPlugin());
        }

        protected override void LoadModules() {
            base.LoadModules();
            Container.LoadModule(new BytechModule(this));
            // LOAD MODULES
        }

        protected override void StartSystems() {
            this.StartAllBoundReactiveSystems();
        }

        protected override void ApplicationStarted() {
            ((Bytech)Bytech).Setup();
            _onRun.OnNext(Unit.Default);
        }

        public void Dispose() {
            GameContext.Dispose();
        }
    }
}
