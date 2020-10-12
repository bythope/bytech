using EcsRx.Scheduling;
using System;
using System.Reactive;

namespace Bythope.Bytech.Core {
    public interface IGameScheduler : IUpdateScheduler {
        IObservable<ElapsedTime> OnPreRender { get; }
        IObservable<ElapsedTime> OnRender { get; }
        IObservable<ElapsedTime> OnPostRender { get; }
        IObservable<Unit> OnFocus { get; }
        IObservable<Unit> OnUnfocus { get; }
        IObservable<Unit> OnLoading { get; }
        IObservable<Unit> OnUnloading { get; }
    }
}
