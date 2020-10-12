using EcsRx.Infrastructure.Dependencies;
using EcsRx.Infrastructure.Extensions;
using System;

namespace Bythope.Bytech.Core {
    public class SceneManager : ISceneManager {

        private readonly IDependencyContainer _container;
        private IScene currentScene;

        public SceneManager(IDependencyContainer container) {
            _container = container;
        }
        
        public void SetScene<T>() {
            var scene = _container.Resolve<T>();
            if (currentScene != null) {
                currentScene.Dispose();
            }
            currentScene = (IScene)scene;
            currentScene.Initialize();
        }
    }
}