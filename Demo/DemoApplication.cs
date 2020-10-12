using Bythope.Bytech.Core;
using Bythope.Bytech.Demo.Scenes;

namespace Bythope.Bytech.Demo {
    public class DemoApplication : BytechApplication {

        protected override void OnRun(IBytech bytech, ISceneManager sceneManager) {
            sceneManager.SetScene<FirstScene>();
        }

        protected override void OnExit() {
            
        }
    }
}
