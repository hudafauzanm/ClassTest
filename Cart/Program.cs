using System;
using Carts;

namespace Carto
{
    class Program
    {
        static void Main(string[] args)
        {
            Cart cart = new Cart();
            cart.addItem(1,30000,3)
                .addItem(2,10000)
                .addItem(3,5000,2)
                .removeItem(2)
                .addItem(4,400,6)
                .addDiscount("50%");
            cart.showAll();
            Console.WriteLine(cart.TotalItem());
            Console.WriteLine(cart.totalQuantity());
            Console.WriteLine(cart.totalPrice());
            
            cart.checkout();
        }
    }
}
