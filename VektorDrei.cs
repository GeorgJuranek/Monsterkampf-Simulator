public class VektorDrei
{
    #region Aufgaben
    /*Drei float Attribute/Felder: x, y, z*/
    private float X, Y, Z;

    public float x { get => X; set => X=value; }
    public float y { get => Y; set => Y=value; }
    public float z { get => Z; set => Z=value; }

    /*Standardkonstruktor in dem x,y,z auf 0 gesetzt werden */
    public VektorDrei()
    {
        x = 0;
        y = 0;
        z = 0;
    }

    /*Einen Konstruktor in dem x,y,z mit Parametern initialisiert werden*/
    public VektorDrei(float _x, float _y, float _z)
    {
        x = _x;
        y = _y;
        z = _z;
    }

    /*+ Operator für die Addition mit einem anderen Vektor*/
    public static VektorDrei operator +(VektorDrei first, VektorDrei second)
    {
        float resultX = first.x + second.x;
        float resultY = first.y + second.y;
        float resultZ = first.z + second.z;
        return new VektorDrei(resultX, resultY, resultZ);
    }

    /*- Operator für die Substraktion mit einem anderen Vektor*/
    public static VektorDrei operator -(VektorDrei first, VektorDrei second)
    {
        float resultX = first.x - second.x;
        float resultY = first.y - second.y;
        float resultZ = first.z - second.z;
        return new VektorDrei(resultX, resultY, resultZ);
    }

    /** Operator für die Multiplikation mit einem Skalar (Zahl)*/
    public static VektorDrei operator *(VektorDrei vektor, int skalar)
    {
        float resultX = vektor.x * skalar;
        float resultY = vektor.y * skalar;
        float resultZ = vektor.z * skalar;
        return new VektorDrei(resultX, resultY, resultZ);
    }

    /*Methode die die Distanz zwischen zwei Vektoren/Punkten berechnet und als float zurückgeben. Implementiere diese Methode in einer statischen und nicht-statischen Version.*/
    public float Distanz(VektorDrei other)
    {
        return Distanz(this,other);
    }
    public static float Distanz(VektorDrei first, VektorDrei second)
    {
        VektorDrei result = second - first;
        return result.Betrag();
    }

    /*Methode die die Länge eines Vektors berechnet und als float ausgibt.*/
    public float Betrag()
    {
        return (float)Math.Sqrt(Quadrat());
    }

    /*Methode die die Quadratlänge eines Vektors berechnet und als float ausgibt.*/
    public float Quadrat()
    {
        float resultX = x * x;
        float resultY = y * y;
        float resultZ = z * z;
        float resultXYZ = resultX + resultY + resultZ;
        return resultXYZ;
    }

    #endregion

    #region Zusatz

    /*Punkt|Skalar Produkt*/
    public float Skalarprodukt(VektorDrei other)
    {
        float resultX = x * other.x;
        float resultY = y * other.y;
        float resultZ = z * other.z;
        float resultXYZ = resultX + resultY + resultZ;
        return resultXYZ;
    }
    public float Punktprodukt(VektorDrei other)
    {
        return Skalarprodukt(other);
    }

    /*Kreuz Produkt*/
    public VektorDrei Kreuzprodukt(VektorDrei other)
    {
        float resultX = y * other.z - z * other.y;
        float resultY = z * other.x - x * other.z;
        float resultZ = x * other.y - y * other.x;
        return new VektorDrei(resultX, resultY, resultZ);
    }

    /*Division mit Skalar*/
    public static VektorDrei operator /(VektorDrei vektor, int skalar)
    {
        float resultX = vektor.x / skalar;
        float resultY = vektor.y / skalar;
        float resultZ = vektor.z / skalar;
        return new VektorDrei(resultX, resultY, resultZ);
    }

    /*Vektor mit Vektor multiplikation*/
    public static VektorDrei operator *(VektorDrei first, VektorDrei second)
    {
        float resultX = first.x * second.x;
        float resultY = first.y * second.y;
        float resultZ = first.z * second.z;
        return new VektorDrei(resultX, resultY, resultZ);
    }

    /*Normalisiert*/
    public VektorDrei Normalisiert()
    {
        float normal = Betrag();
        float resultX = x/normal;
        float resultY = y/normal;
        float resultZ = z/normal;
        return new VektorDrei(resultX, resultY, resultZ);
    }

    /*Voreinstellungen*/
    public static VektorDrei Eins => new VektorDrei(1,1,1);
    public static VektorDrei Null => new VektorDrei(0,0,0);
    public static VektorDrei Vorwaerts => new VektorDrei(0,0,1);
    public static VektorDrei Rueckwaerts => new VektorDrei(0,0,-1);
    public static VektorDrei Links => new VektorDrei(-1,0,0);
    public static VektorDrei Rechts => new VektorDrei(1,0,0);
    public static VektorDrei Oben => new VektorDrei(0,1,0);
    public static VektorDrei Unten => new VektorDrei(0,-1,0);

    /*Zufall*/
    public static VektorDrei Zufall(int ranX, int ranY, int ranZ)
    {
        Random random = new Random();
        ranX = random.Next(0, ranX+1);
        ranY = random.Next(0, ranY+1);
        ranZ = random.Next(0, ranZ+1);
        return new VektorDrei(ranX, ranY, ranZ);
    }

    #endregion
}

