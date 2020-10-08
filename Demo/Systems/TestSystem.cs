using Bythope.Bytech.Core;
using EcsRx.Groups;
using EcsRx.Groups.Observable;
using EcsRx.Systems;

namespace Bythope.Bytech.Demo.Game.Systems {
    class TestSystem : IManualSystem {
        public IGroup Group => new EmptyGroup();

        public TestSystem(IBytech bytech) {
            
        }

        public void StartSystem(IObservableGroup observableGroup) {

        }

        public void StopSystem(IObservableGroup observableGroup) {

        }
    }
}
