using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCounterCommon
{
    public interface ISink<T>
    {
        void Signal(T data);
    }

    public interface ISource<T>
    {
        List<ISink<T>> Receivers { get; }
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
    }

    public sealed class Signal {
        private static Signal _shared = new Signal();

        public static Signal v {
            get { return _shared; }
        }
    }
}
