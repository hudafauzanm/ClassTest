using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Carts
{
    public class Barang
    {
        public int _item;
        public int _price;
        public int _quantity;

        public Barang(int Item,int Price,int Quantity)
        {
            _item = Item;
            _price = Price;
            _quantity = Quantity;
        }
    }
    public class Cart
    {
        private ArrayList barang = new ArrayList();

        private StringBuilder _addFile = new StringBuilder();  
        public double _discount;

        public Cart addItem(int item,int price = 0 ,int quantity = 1)
        {
            barang.Add(new Barang(item,price,quantity));
            return this;
        }

        public Cart removeItem(int id)
        {
            for(int i = 0; i < barang.Count;i++)
            {
                Barang items = (Barang)barang[i];
                if(items._item == id)
                {
                    barang.RemoveAt(i);
                    break;
                }
            }
            return this;
        }

        public Cart addDiscount(string discount)
        { 
            _discount = (double)Decimal.Parse(discount.Remove(discount.Length-1))/100; 
            return this;   
        }

        public void showAll()
        {
            _addFile.Append("ITEM" + "  " + " PRICE" + "  " + "QUANTITY" + "\n");
            foreach(var i in barang)
            {
                Barang barang = (Barang)i;
                Console.WriteLine("{0}    {1}    {2}", barang._item, barang._price, barang._quantity);
                string items = Convert.ToString(barang._item);
                string quan = Convert.ToString(barang._quantity);
                string price = Convert.ToString(barang._price);
                _addFile.Append(items + "      " + price + "    " + quan + "\n");
            }
        }

        public int TotalItem()
        {
            int total = barang.Count;
            _addFile.Append("Total Item :" +" "+total + "\n");
            return total;
        }

        
        public int totalQuantity()
        {
            int x = 0;

            foreach(var i in barang)
            {
                Barang barang = (Barang)i;
                x += barang._quantity;
            }
            int totalq = x;
            _addFile.Append("Total Quantity :" +" "+totalq + "\n");
            return x;

        }

        public double totalPrice()
        {
          int y = 0;

            foreach(var i in barang)
            {
                Barang barang = (Barang)i;
                y += barang._price * barang._quantity;
            }
            double totalp = y - y*_discount;
           _addFile.Append("Total Price : "+ " " +totalp +  "\n");
            return y - y*_discount;   
        }

        

        public void checkout()
        {
            string _filePath = "D://";
            string fileName ="Cart.txt";
            File.Delete(fileName);

            File.AppendAllText(_filePath+fileName, _addFile.ToString());
            _addFile.Clear();           
        }
    }
}
