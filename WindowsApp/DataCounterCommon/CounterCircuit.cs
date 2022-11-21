using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCounterCommon
{
    internal class InputRootNubRelay: Relay<int>
    {
    }

    public class CounterCircuit
    {
        private ISource<int> _activeInput = null;
        private InputRootNubRelay _inputRelay = new InputRootNubRelay();
        public ISource<int> InputNub
        {
            get { return _inputRelay;  }
            set
            {
                if(_activeInput != null)
                {
                    _activeInput.Receivers.Remove(_inputRelay);
                }
                _activeInput = value;
                if(_activeInput != null)
                {
                    _activeInput.ConnectReceiver(_inputRelay);
                }
            }
        }
    }
}
