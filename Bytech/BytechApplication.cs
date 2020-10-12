using Bythope.Bytech.Core;
using System;
using System.Reactive.Linq;
using EcsRx.Infrastructure.Extensions;

namespace Bythope.Bytech {

    public abstract class BytechApplication : IDisposable {
        
        private Boot Boot { get; }

        public BytechApplication() {
            Boot = new Boot();
            Boot.OnRun.FirstAsync().Subscribe(x => {
                var sceneManager = Boot.Container.Resolve<ISceneManager>();
                OnRun(Boot.Bytech, sceneManager);
            });
            Boot.OnExit.FirstAsync().Subscribe(x => OnExit());
            Boot.Run();
        }

        protected abstract void OnRun(IBytech bytech, ISceneManager sceneManager);

        protected abstract void OnExit();
        
        public void Dispose() => Boot.Dispose();
    }
}
