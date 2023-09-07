using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookfiend.Application.MessageBroker
{
    public interface IRabbitMqPublisher
    {

        void Publish<T>(T message);
    }
}
