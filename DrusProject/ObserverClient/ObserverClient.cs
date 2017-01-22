using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ObserverClient
{
    public class ObserverClient : ClientBase<IObserverService>, IObserverService
    {
        public ObserverClient(InstanceContext context,WSDualHttpBinding binding, EndpointAddress address) : base(context,binding, address)
        {
        }

        public void Subscribe(List<string> meterIDs)
        {
            Channel.Subscribe(meterIDs);
        }
    }
}
