using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataCounterCommon
{
    public enum CounterInputState
    {
        NotReady,
        Ready,
        Running
    }

    public interface ISink<T>
    {
        void Signal(T data);
    }

    public interface ISource<T>
    {
        ISink<T> Receiver { get; set; }
    }

    public interface ICounterInput: ISource<int>
    {
        Control GetSettingsPanel();

        CounterInputState State { get; }

        string Name { get; }

        void Start();
        void Stop();
    }
}
