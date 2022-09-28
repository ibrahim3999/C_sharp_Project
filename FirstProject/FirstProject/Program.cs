using System;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {

            City c1 = new City("Tel Aviv", 1);
            City c2 = new City("Hafia", 4);
            City c3 = new City("Ramat Hashron", 3);
            City c4 = new City("New york", 2);

            List<City> citers = new List<City>();
            citers.Add(c1);
            citers.Add(c2);
            citers.Add(c3);
            citers.Add(c4);
            HelperCity HH = new HelperCity();
            citers.Sort(HH);
            citers.ForEach(c => Console.WriteLine(c.getCode()));

            /* Street  */
            Street s1 = new Street("hetsel", 1, c1);
            Street s2 = new Street("bazl", 4, c3);
            Street s3 = new Street("Wall street", 6, c4);
            Street s4 = new Street("rom yal", 3, c2);
            Street s5 = new Street("bazl ", 2, c1);
            List<Street> streets = new List<Street>();
            streets.Add(s1);
            streets.Add(s2);
            streets.Add(s3);
            streets.Add(s4);
            streets.Add(s5);
            HelperStreet AA = new HelperStreet();
            int codeOfTelAviv = c1.getCode();
            streets.Sort(AA);
            streets.FindAll(s => s.getCodeOfCity() == codeOfTelAviv).ForEach(c => Console.WriteLine(c.getName()));



        }
        class HelperCity : IComparer<City>
        {

            public int Compare(City x, City y)
            {
                if (x.getOrderOfPresentationa() == 0 || y.getOrderOfPresentationa() == 0)
                {
                    return 0;
                }
                // CompareTo() method
                return x.getOrderOfPresentationa().CompareTo(y.getOrderOfPresentationa());

            }
        }
        class HelperStreet : IComparer<Street>
        {

            public int Compare(Street x, Street y)
            {
                if (x.getOrderOfPresentationa() == 0 || y.getOrderOfPresentationa() == 0)
                {
                    return 0;
                }
                // CompareTo() method
                return x.getOrderOfPresentationa().CompareTo(y.getOrderOfPresentationa());

            }
        }
        class City
        {
            private string name;
            private int code;
            public static int HelperCode;
            private int orderOfPresentationa;

            public City(string name, int orderOfPresentationa)
            {
                this.name = name;
                this.orderOfPresentationa = orderOfPresentationa;
                this.code = ++HelperCode;
            }
            //getter
            public int getCode()
            {
                return code;
            }
            public string getName()
            {
                return this.name;
            }

            public int getOrderOfPresentationa()
            {
                return this.orderOfPresentationa;

            }
            //setter
            public void setOrderOfPresentationa(int orderNumber)
            {
                this.orderOfPresentationa = orderNumber;
            }


        }
        class Street
        {
            private string name;
            private int codeOfStreet = 1;//first street be 1 then 2 then 3 ....
            public static int HelperCode;
            private int orderOfPresentationa;
            private int codeOfCity;

            public Street(string name, int orderOfPresentationa, City city)
            {
                this.name = name;
                this.orderOfPresentationa = orderOfPresentationa;
                this.codeOfCity = city.getCode();
                this.codeOfStreet = ++HelperCode;
            }
            //getter
            public string getName()
            {
                return this.name;
            }
            public int getOrderOfPresentationa()
            {
                return this.orderOfPresentationa;
            }
            public int getCodeOfCity()
            {
                return this.codeOfCity;
            }
            public int getCodeStreet()
            {
                return this.codeOfStreet;
            }
            //setter
            public void setOrderOfPresentationa(int orderNumber)
            {
                this.codeOfCity = orderNumber;
            }

        }

    }
}