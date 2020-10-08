using EcsRx.Groups;
using EcsRx.Infrastructure.Dependencies;
using EcsRx.Infrastructure.Extensions;
using EcsRx.Scheduling;
using System;

namespace Bythope.Bytech.Core {
    class BytechModule : IDependencyModule {

        private readonly IGameContext _gameContext;

        public BytechModule(IGameContext gameContext) {
            _gameContext = gameContext;
        }
        public void Setup(IDependencyContainer container) {

            container.Unbind<IUpdateScheduler>();
            container.Bind<IUpdateScheduler>(x => x.ToInstance(_gameContext));
            container.Bind<IGameScheduler>(x => x.ToInstance(_gameContext));
            container.Bind<IBytech>(x => x.ToInstance(_gameContext.Bytech));
            
        }
    }
}
