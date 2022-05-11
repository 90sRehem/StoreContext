using Flunt.Notifications;
using Flunt.Validations;
using Store.Domain.Commands.Interfaces;

namespace Store.Domain.Commands
{
    public class CreateOrderItemCommand : Notifiable, ICommand
    {
        public CreateOrderItemCommand(Guid product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public CreateOrderItemCommand()
        {
        }
        public Guid Product { get; set; }
        public int Quantity { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasLen(val: Product.ToString(), len: 32, property: "Product", message: "Produto inválido.")
                .IsGreaterThan(val: Quantity, comparer: 0, property: "'Quantity", message: "Quantidade inválida."));
        }
    }
}