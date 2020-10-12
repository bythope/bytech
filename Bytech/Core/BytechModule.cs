using EcsRx.Infrastructure.Dependencies;
using EcsRx.Infrastructure.Extensions;
using EcsRx.Scheduling;

namespace Bythope.Bytech.Core {
    class BytechModule : IDependencyModule {

        private readonly Boot _boot;

        public BytechModule(Boot boot) {
            _boot = boot;
        }
        public void Setup(IDependencyContainer container) {

            var sceneManager = new SceneManager(container);

            container.Unbind<IUpdateScheduler>();
            container.Bind<IUpdateScheduler>(x => x.ToInstance(_boot.GameContext));
            container.Bind<IGameScheduler>(x => x.ToInstance(_boot.GameContext));
            container.Bind<IBytech>(x => x.ToInstance(_boot.Bytech));
            container.Bind<ISceneManager>(x => x.ToInstance(sceneManager));
        }
    }
}
