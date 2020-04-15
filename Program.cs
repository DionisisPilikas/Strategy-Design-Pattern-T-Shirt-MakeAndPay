using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Pattern_Strategy
{
    interface IPaymentMethod
    {
        void Cost();
    }
    class BankTransferMethod : IPaymentMethod
    {
        public void Cost()
        {
            Console.WriteLine("Paying using Money / Bank Transfer");
        }
    }
    class CashMethod : IPaymentMethod
    {
        public void Cost()
        {
            Console.WriteLine("Paying using Cash");
        }
    }
    class CreditCardMethod : IPaymentMethod
    {
        public void Cost()
        {
            Console.WriteLine("Paying using Credit / Debit card");
        }
    }
    class TShirt
    {
        public readonly Color Color;
        public readonly Size Size;
        public readonly Fabric Fabric;

        public decimal Price { get; set; }

        public TShirt(Color color, Size size, Fabric fabric)
        {
            Color = color;
            Size = size;
            Fabric = fabric;
        }
    }

    enum Color { RED, ORANGE, YELLOW, GREEN, BLUE, INDIGO, VIOLE }
    enum Size { XS, S, M, L, XL, XXL, XXXL }
    enum Fabric { WOOL, COTTON, POLYESTER, RAYON, LINEN, CASHMERE, SILK }
    abstract class Variation
    {
        public abstract decimal Cost(TShirt tshirt);
    }
    class ColorVariation : Variation
    {
        //On creating a ColorVariation instance, in this instance we can run the method Cost that takes a new t-shirt as a parameter
        //and we can get the price of this t-shirt according its color
        public override decimal Cost(TShirt tshirt)
        {
            switch (tshirt.Color)
            {
                case Color.BLUE:
                    tshirt.Price += 0.1m;
                    break;
                case Color.GREEN:
                    tshirt.Price += 0.2m;
                    break;
                case Color.INDIGO:
                    tshirt.Price += 0.3m;
                    break;
                case Color.ORANGE:
                    tshirt.Price += 0.4m;
                    break;
                case Color.RED:
                    tshirt.Price += 0.5m;
                    break;
                case Color.VIOLE:
                    tshirt.Price += 0.6m;
                    break;
                case Color.YELLOW:
                    tshirt.Price += 0.7m;
                    break;
            }

            Console.WriteLine(tshirt.Price);
            return tshirt.Price;
        }
    }
    class SizeVariation : Variation
    {
        private static Dictionary<Size, decimal> _sizeCosts;
        //making SizeVariation instance, a static dictionary will be creating in ram
        //this dictionary includes all values by any size
        static SizeVariation()
        {
            _sizeCosts = new Dictionary<Size, decimal>()
            {
                { Size.XS, 1m },
                { Size.S, 2m },
                { Size.M, 3m },
                { Size.L, 4m },
                { Size.XL, 5m },
                { Size.XXL, 6m },
                { Size.XXXL, 7m }
            };
        }
        public override decimal Cost(TShirt tshirt)
        {
            tshirt.Price += _sizeCosts[tshirt.Size]; //return tha price value of this t-shirt (the specific key value)
            Console.WriteLine(tshirt.Price);
            return tshirt.Price;
        }
    }
    class FabricVariation : Variation
    {
        private static Dictionary<Fabric, decimal> _fabricVariations;
        static FabricVariation()
        {
            _fabricVariations = new Dictionary<Fabric, decimal>()
            {
                { Fabric.CASHMERE, 10m },
                { Fabric.COTTON, 20m },
                { Fabric.LINEN, 30m },
                { Fabric.POLYESTER, 40m },
                { Fabric.RAYON, 50m },
                { Fabric.SILK, 60m },
                { Fabric.WOOL, 70m }
            };
        }
        public override decimal Cost(TShirt tshirt)
        {
            tshirt.Price += _fabricVariations[tshirt.Fabric];
            return tshirt.Price;
        }
    }
    class Eshop
    {
        private IEnumerable<Variation> _variations;
        private IPaymentMethod _paymentMethod;

        public Eshop(IEnumerable<Variation> variations)
        {
            _variations = variations;
        }

        public void GetTshirtCost(TShirt tshirt)
        {
            foreach (var variation in _variations)
            {
                Console.WriteLine($"After{variation.GetType().Name}");
                variation.Cost(tshirt);
                Console.WriteLine($"the T-shirt cost {variation.GetType().Name} is: {tshirt.Price}");
            }

        }
        public void SetVariation(IEnumerable<Variation> variations)
        {
            _variations = variations;
        }

        public void SelectPaymentMethod(IPaymentMethod paymentMethod)
        {
            _paymentMethod = paymentMethod;

        }

        public void ShowTheWayOfPaying()
        {
            _paymentMethod.Cost();
        }
    }
    class ChooseMenu
    {
        public void Start()
        {
            //make a new t-shirt using all characteristics you like
            TShirt t1 = new TShirt(Color.RED, Size.M, Fabric.COTTON);

            //make Variation list
            IEnumerable<Variation> varietionList = new List<Variation>() { new ColorVariation(), new SizeVariation(), new FabricVariation() };
            //make an e-shop using the variation list
            Eshop e1 = new Eshop(varietionList);
            //Eshop e1 = new Eshop(new List<Variation>() { new ColorVariation(), new SizeVariation(), new FabricVariation() });


            //the new eshop e1 has a method that is show the cost of this t-shirt (Pay this t-shirt)
            e1.GetTshirtCost(t1);

            //choose the payment method you like
            e1.SelectPaymentMethod(new BankTransferMethod());
            //show this method
            e1.ShowTheWayOfPaying();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            ChooseMenu menu1 = new ChooseMenu();
            menu1.Start();
        }
    }
}
