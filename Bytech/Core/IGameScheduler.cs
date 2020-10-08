using EcsRx.Scheduling;
using System;

namespace Bythope.Bytech.Core {
    public interface IGameScheduler : IUpdateScheduler {
        IObservable<ElapsedTime> OnPreRender { get; }
        IObservable<ElapsedTime> OnRender { get; }
        IObservable<ElapsedTime> OnPostRender { get; }
    }
}
