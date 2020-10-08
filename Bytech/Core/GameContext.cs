using EcsRx.MicroRx.Subjects;
using EcsRx.Scheduling;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;

namespace Bythope.Bytech.Core {
    public class GameContext : Game, IGameContext {

        public IObservable<Unit> OnLoading => _onLoading;

        public IObservable<Unit> OnUnloading { get; }

        public IObservable<ElapsedTime> OnPreRender => _onPreRender;

        public IObservable<ElapsedTime> OnRender => _onRender;

        public IObservable<ElapsedTime> OnPostRender => _onPostRender;

        public IObservable<ElapsedTime> OnPreUpdate => _onPreUpdate;

        public IObservable<ElapsedTime> OnUpdate => _onUpdate;

        public IObservable<ElapsedTime> OnPostUpdate => _onPostUpdate;

        public ElapsedTime ElapsedTime { get; private set; }

        public IBytech Bytech { get; }

        private readonly Subject<ElapsedTime> _onPreRender, _onRender, _onPostRender, _onPreUpdate, _onUpdate, _onPostUpdate;
        private readonly Subject<Unit> _onLoading;

        public GameContext() {
            _onPreRender = new Subject<ElapsedTime>();
            _onRender = new Subject<ElapsedTime>();
            _onPostRender = new Subject<ElapsedTime>();
            _onPreUpdate = new Subject<ElapsedTime>();
            _onUpdate = new Subject<ElapsedTime>();
            _onPostUpdate = new Subject<ElapsedTime>();
            _onLoading = new Subject<Unit>();
            OnUnloading = Observable.FromEventPattern<EventArgs>(x => Exiting += x, x => Exiting -= x).FirstAsync().Select(x => Unit.Default);

            Bytech = new Bytech(this);
            // LOAD STANDARD THINGS FOR MONOGAME
        }

        protected override void LoadContent() {
            // MONOGAME THINGS
            base.LoadContent();
            _onLoading.OnNext(Unit.Default);
        }

        protected override void Draw(GameTime gameTime) {
            base.Draw(gameTime);
            ElapsedTime = new ElapsedTime(gameTime.ElapsedGameTime, gameTime.TotalGameTime);

            _onPreRender.OnNext(ElapsedTime);
            _onRender.OnNext(ElapsedTime);
            _onPostRender.OnNext(ElapsedTime);
        }

        protected override void Update(GameTime gameTime) {
            base.Update(gameTime);
            ElapsedTime = new ElapsedTime(gameTime.ElapsedGameTime, gameTime.TotalGameTime);

            _onPreUpdate.OnNext(ElapsedTime);
            _onUpdate.OnNext(ElapsedTime);
            _onPostUpdate.OnNext(ElapsedTime);
        }

        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);

            _onPreRender.Dispose();
            _onRender.Dispose();
            _onPostRender.Dispose();

            _onPreUpdate.Dispose();
            _onUpdate.Dispose();
            _onPostUpdate.Dispose();

            _onLoading.Dispose();
        }
    }
}
