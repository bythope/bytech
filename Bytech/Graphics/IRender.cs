using Bythope.Bytech.Core;
using System;

namespace Bythope.Bytech.Graphics {
    public interface IRender : IDisposable {

        void Initialize(IBytech bytech, IGameScheduler gameScheduler);

    }
}
