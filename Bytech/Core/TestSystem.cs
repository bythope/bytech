using EcsRx.Groups;
using EcsRx.Groups.Observable;
using EcsRx.Systems;

namespace Bythope.Bytech.Core {
    internal class TestSystem : IManualSystem {
        public IGroup Group => new EmptyGroup();

        public void StartSystem(IObservableGroup observableGroup) {
            throw new System.NotImplementedException();
        }

        public void StopSystem(IObservableGroup observableGroup) {
            throw new System.NotImplementedException();
        }
    }
}