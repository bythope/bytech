using Bythope.Bytech.Core;
using System;
using System.Reactive.Linq;

namespace Bythope.Bytech {

    public abstract class BytechApplication : IDisposable {
        
        private Runtime Runtime { get; }

        public BytechApplication() {
            Runtime = new Runtime();
            Runtime.OnRun.FirstAsync().Subscribe(x => OnRun(Runtime));
            Runtime.OnExit.FirstAsync().Subscribe(x => OnExit());
            Runtime.Setup();
        }

        protected abstract void OnRun(Runtime runtime);

        protected abstract void OnExit();
        
        public void Dispose() => Runtime.Dispose();
    }
}
