namespace VektorKlasse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Aufgaben*/
            Console.WriteLine(" AUFGABEN: ");

            VektorDrei myVektor = new VektorDrei();
            translateVektor(myVektor, "1: Leerer Konstruktor: ");

            VektorDrei myVektor2 = new VektorDrei(1,2,3);
            translateVektor(myVektor2, "2: Konstruktor mit Werten: ");

            VektorDrei myVektor3 = new VektorDrei(1, 2, 3);
            translateVektor(myVektor2, "3: Konstruktor mit Werten: ");

            translateVektor(myVektor2 + myVektor3, "Vektoren 2 + 3 addiert: ");

            translateVektor(myVektor2 - myVektor3, "Vektoren 2 - 3 subtrahiert: ");

            translateVektor(myVektor2 * 2, "Vektor 2 mit integer 2 multipliziert: ");

            Console.WriteLine("Distanz zwischen 3 und 2 (unstatisch): " + myVektor3.Distanz(myVektor2));
            Console.WriteLine("Distanz zwischen 3 und 2 (statisch): " + VektorDrei.Distanz(myVektor3, myVektor2));

            Console.WriteLine("Betrag von 2: " + myVektor2.Betrag());

            Console.WriteLine("Quadrat von 2: " + myVektor2.Quadrat());

            /*Zusatz*/
            Console.WriteLine("\n ZUSATZ: ");

            Console.WriteLine("Skalarprodukt von 2 & 3: " + myVektor2.Skalarprodukt(myVektor3));
            translateVektor(myVektor2.Kreuzprodukt(myVektor3), "Kreuzprodukt von 2 & 3: ");

            translateVektor(myVektor2 / 2, "Vektor 2 mit integer 2 dividiert: ");

            translateVektor(myVektor2*myVektor3, "Vektor 2 mit Vektor 3 multipliziert: ");

            translateVektor(myVektor2.Normalisiert(), "Vektor 2 normalisiert: ");

            translateVektor( VektorDrei.Null, "Vektor 'Null': ");
            translateVektor( VektorDrei.Eins, "Vektor 'Eins': ");

            translateVektor( VektorDrei.Zufall(5,5,5), "Zufalls Vektor: ");
            translateVektor(VektorDrei.Zufall(5,5,5), "Zufalls Vektor (2): ");

            Console.ReadKey(true);
        }


        static void translateVektor(VektorDrei vektor, string text)
        {
            Console.WriteLine(text + vektor.x + "/" + vektor.y + "/" + vektor.z);
        }
    }
}