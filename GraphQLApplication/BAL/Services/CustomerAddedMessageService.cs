using BAL.Messages;
using BAL.Types;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;

namespace BAL.Services
{
    public class CustomerAddedMessageService
    {
        private readonly ISubject<CustomerAddedMessage> _messageStream = new ReplaySubject<CustomerAddedMessage>(1024);

        public CustomerAddedMessage AddCustomerMessage(Customer customer)
        {
            var customerAddedMessage = new CustomerAddedMessage()
            {
                CustomerId = customer.Id
            };
            _messageStream.OnNext(customerAddedMessage);
            return customerAddedMessage;
        }
        public IObservable<CustomerAddedMessage> GetCustomerAddedMessage()
        {
            var observable= _messageStream.AsObservable();
            return observable;
        }
    }
}
