using Bythope.Bytech.Core;
using Bythope.Bytech.Graphics;
using EcsRx.Infrastructure.Extensions;

namespace Bythope.Bytech.Demo {
    public class DemoApplication : BytechApplication {

        protected override void OnRun(Runtime runtime) {
            IGraphics graphics = runtime.Container.Resolve<IGraphics>();
            graphics.SetRender(new Render2D());
        }

        protected override void OnExit() {
            
        }
    }
}
