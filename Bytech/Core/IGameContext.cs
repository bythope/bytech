using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;

namespace Bythope.Bytech.Core {
    public interface IGameContext : IGameScheduler {

        IBytech Bytech { get; }
        IObservable<Unit> OnLoading { get; }
        IObservable<Unit> OnUnloading { get; }
        LaunchParameters LaunchParameters { get; }
        GameComponentCollection Components { get; }
        TimeSpan InactiveSleepTime { get; }
        TimeSpan MaxElapsedTime { get; }
        bool IsActive { get; }
        bool IsMouseVisible { get; set; }
        TimeSpan TargetElapsedTime { get; }
        bool IsFixedTimeStep { get; set; }
        GameServiceContainer Services { get; }
        GameWindow Window { get; }
        void Exit();
        void ResetElapsedTime();
        void SuppressDraw();
        void RunOneFrame();
        void Run();
        void Run(GameRunBehavior runBehavior);
        void Tick();
        event EventHandler<EventArgs> Activated;
        event EventHandler<EventArgs> Deactivated;
        event EventHandler<EventArgs> Disposed;
        event EventHandler<EventArgs> Exiting;
    }
}
