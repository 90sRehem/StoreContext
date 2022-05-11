using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using Flunt.Validations;

namespace Store.Domain.Commands.Interfaces
{
    public class CreateOrderCommand : Notifiable, ICommand
    {
        public CreateOrderCommand(string customer, string zipCode, string promoCode, IList<CreateOrderItemCommand> items)
        {
            Customer = customer;
            ZipCode = zipCode;
            PromoCode = promoCode;
            Items = items;
        }

        public CreateOrderCommand()
        {
            Items = new List<CreateOrderItemCommand>();
        }
        public string Customer { get; set; }
        public string ZipCode { get; set; }
        public string PromoCode { get; set; }
        public IList<CreateOrderItemCommand> Items { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
            .Requires()
            .HasLen(Customer, 11, "Customer", "Cliente inválido.")
            .HasLen(ZipCode, 8, "ZipCode", "CEP inválido."));
        }
    }
}