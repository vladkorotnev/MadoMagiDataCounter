using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCounterCommon
{
    public interface ICounterNode { }

    public interface IResetable
    {
        void Reset();
    }

    public interface ISink<T>: ICounterNode
    {
        void Signal(T data);
    }

    public interface ISignalSink: ICounterNode
    {
        void Signal();
    }

    public interface ISource<T>: ICounterNode
    {
        List<ISink<T>> Receivers { get; }
        void ConnectReceiver(ISink<T> receiver);
        void ConnectReceivers(params ISink<T>[] receiver);
    }

    public interface ISignalSource: ICounterNode
    {
        List<ISignalSink> Receivers { get;  }
        void ConnectReceiver(ISignalSink receiver);
        void ConnectReceivers(params ISignalSink[] receiver);
    }

    public abstract class Source<T> : ISource<T>
    {
        public Source()
        {
            Receivers = new List<ISink<T>>();
        }

        public List<ISink<T>> Receivers { get; private set; }

        protected void NotifySinks(T data)
        {
            foreach (var sink in Receivers)
            {
                sink.Signal(data);
            }
        }

        public void ConnectReceiver(ISink<T> receiver)
        {
            Receivers.Add(receiver);
        }

        public void ConnectReceivers(params ISink<T>[] receiver)
        {
            Receivers.AddRange(receiver);
        }
    }

    public abstract class SignalSource
    {
        public SignalSource()
        {
            Receivers = new List<ISignalSink>();
        }

        public List<ISignalSink> Receivers { get; private set; }

        protected void NotifySinks()
        {
            foreach (var sink in Receivers)
            {
                sink.Signal();
            }
        }

        public void ConnectReceiver(ISignalSink receiver)
        {
            Receivers.Add(receiver);
        }

        public void ConnectReceivers(params ISignalSink[] receiver)
        {
            Receivers.AddRange(receiver);
        }
    }

    public sealed class Resetter: ISignalSink, IResetable
    {
        public Resetter()
        {
            Receivers = new List<IResetable>();
        }

        public List<IResetable> Receivers { get; private set; }

        protected void NotifySinks()
        {
            foreach (var sink in Receivers)
            {
                sink.Reset();
            }
        }

        public void ConnectReceiver(IResetable receiver)
        {
            Receivers.Add(receiver);
        }

        public void ConnectReceivers(params IResetable[] receiver)
        {
            Receivers.AddRange(receiver);
        }

        public void Signal()
        {
            NotifySinks();
        }

        public void Reset()
        {
            NotifySinks();
        }
    }

    public class Relay<T>: Source<T>, ISink<T>
    {
        public virtual void Signal(T data) => NotifySinks(data);
    }

    public class Memory<T>: Relay<T>
    {
        private T _value = default(T);

        public T LastValue { get { return _value; } }

        public override void Signal(T data)
        {
            _value = data;
            base.Signal(data);
        }
    }

    public class SignalRelay: SignalSource, ISignalSink
    {
        public void Signal() => NotifySinks();
    }

    public class ActionReceiver<T>: ISink<T>
    {
        public Action<T> Action { get; set; }

        public ActionReceiver(Action<T> action)
        {
            Action = action;
        }

        public void Signal(T data) => Action(data);
    }

    public class ActionReceiver: ISignalSink
    {
        public Action Action { get; set; }

        public ActionReceiver(Action action)
        {
            Action = action;
        }

        public void Signal() => Action();
    }
}
