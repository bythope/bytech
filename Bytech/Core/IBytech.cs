using EcsRx.Collections.Database;
using EcsRx.Events;
using EcsRx.Executor;
using EcsRx.Infrastructure.Dependencies;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Bythope.Bytech.Core {
    public interface IBytech {
        IGameScheduler GameScheduler { get; }
        GraphicsDeviceManager Graphics { get; }
        GameComponentCollection Components { get; }
        ContentManager Content { get; }
        GameServiceContainer Services { get; }
        GameWindow Window { get; }
        LaunchParameters Parameters { get; }
        IDependencyContainer Container { get; }
        IEntityDatabase EntityDatabase { get; }
        IEventSystem EventSystem { get; }
        ISystemExecutor SystemExecutor { get; }
        bool IsMouseVisible { get; set; }
        bool IsActive { get; }
        bool IsFixedTimeStep { get; }
        void Exit();
    }
}
