using System;
using System.Collections.Generic;

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
            TShirt t2 = new TShirt(Color.VIOLE, Size.L, Fabric.CASHMERE);
            TShirt t3 = new TShirt(Color.BLUE, Size.S, Fabric.LINEN);
            TShirt t4 = new TShirt(Color.INDIGO, Size.M, Fabric.COTTON);
            TShirt t5 = new TShirt(Color.YELLOW, Size.XXXL, Fabric.POLYESTER);
            TShirt t6 = new TShirt(Color.GREEN, Size.XXL, Fabric.RAYON);
            TShirt t7 = new TShirt(Color.INDIGO, Size.M, Fabric.LINEN);
            TShirt t8 = new TShirt(Color.RED, Size.XS, Fabric.SILK);
            TShirt t9 = new TShirt(Color.RED, Size.M, Fabric.WOOL);
            TShirt t10 = new TShirt(Color.BLUE, Size.XS, Fabric.CASHMERE);
            TShirt t11 = new TShirt(Color.GREEN, Size.L, Fabric.COTTON);
            TShirt t12 = new TShirt(Color.RED, Size.M, Fabric.POLYESTER);
            TShirt t13 = new TShirt(Color.VIOLE, Size.L, Fabric.RAYON);
            TShirt t14 = new TShirt(Color.RED, Size.M, Fabric.COTTON);
            TShirt t15 = new TShirt(Color.INDIGO, Size.XXXL, Fabric.COTTON);
            TShirt t16 = new TShirt(Color.ORANGE, Size.XXL, Fabric.CASHMERE);
            TShirt t17 = new TShirt(Color.ORANGE, Size.XL, Fabric.COTTON);
            TShirt t18 = new TShirt(Color.BLUE, Size.M, Fabric.LINEN);
            TShirt t19 = new TShirt(Color.VIOLE, Size.M, Fabric.SILK);
            TShirt t20 = new TShirt(Color.ORANGE, Size.L, Fabric.WOOL);
            TShirt t21 = new TShirt(Color.RED, Size.S, Fabric.CASHMERE);
            TShirt t22 = new TShirt(Color.GREEN, Size.S, Fabric.COTTON);
            TShirt t23 = new TShirt(Color.RED, Size.M, Fabric.LINEN);
            TShirt t24 = new TShirt(Color.BLUE, Size.XL, Fabric.RAYON);
            TShirt t25 = new TShirt(Color.RED, Size.XS, Fabric.COTTON);
            TShirt t26 = new TShirt(Color.RED, Size.XXL, Fabric.WOOL);
            TShirt t27 = new TShirt(Color.GREEN, Size.L, Fabric.COTTON);
            TShirt t28 = new TShirt(Color.ORANGE,Size.M, Fabric.LINEN);
            TShirt t29 = new TShirt(Color.RED, Size.M, Fabric.SILK);
            TShirt t30 = new TShirt(Color.RED, Size.L, Fabric.RAYON);
            TShirt t31 = new TShirt(Color.YELLOW, Size.S, Fabric.COTTON);
            TShirt t32 = new TShirt(Color.RED, Size.XXL, Fabric.COTTON);
            TShirt t33 = new TShirt(Color.VIOLE, Size.M, Fabric.CASHMERE);
            TShirt t34 = new TShirt(Color.RED, Size.XL, Fabric.COTTON);
            TShirt t35 = new TShirt(Color.YELLOW, Size.M, Fabric.CASHMERE);
            TShirt t36 = new TShirt(Color.INDIGO, Size.XS, Fabric.COTTON);
            TShirt t37 = new TShirt(Color.RED, Size.XXL, Fabric.COTTON);
            TShirt t38 = new TShirt(Color.RED, Size.XXL, Fabric.CASHMERE);
            TShirt t39 = new TShirt(Color.ORANGE, Size.M, Fabric.COTTON);
            TShirt t40 = new TShirt(Color.GREEN, Size.XS, Fabric.LINEN);



            //make Variation list
            IEnumerable<Variation> varietionList = new List<Variation>() { new ColorVariation(), new SizeVariation(), new FabricVariation() };
            //make an e-shop using the variation list
            Eshop e1 = new Eshop(varietionList);
            //Eshop e1 = new Eshop(new List<Variation>() { new ColorVariation(), new SizeVariation(), new FabricVariation() });


            //the new eshop e1 has a method that is show the cost of this t-shirt (Pay this t-shirt)
            e1.GetTshirtCost(t1);
            e1.GetTshirtCost(t2);
            e1.GetTshirtCost(t3);
            e1.GetTshirtCost(t4);
            e1.GetTshirtCost(t5);




            TShirt[] tshirtsArray = { t1,t2,t3,t4,t5,t6,t7,t8,t9,t10,t11,t12,t13,t14,t15,t16,t17,t18,t19,t20,
                t21,t22,t23,t24,t25,t26,t27,t28,t29,t30,t31,t32,t33,t34,t35,t36,t37,t38,t39,t40 };

            TShirt temp;
            for (int j = 0; j <= tshirtsArray.Length - 2; j++)
            {
                for (int i = 0; i <= tshirtsArray.Length - 2; i++)
                {
                    if (tshirtsArray[i].Price > tshirtsArray[i + 1].Price)
                    {
                        temp = tshirtsArray[i + 1];
                        tshirtsArray[i + 1] = tshirtsArray[i];
                        tshirtsArray[i] = temp;
                    }
                }
            }
            Console.WriteLine("\n" + "Sorted array :");
            foreach (TShirt t in tshirtsArray)
                Console.Write(t.Price + " ");

            Console.Write("\n");

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

            Console.ReadKey();
        }
    }
}
