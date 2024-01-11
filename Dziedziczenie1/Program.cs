public interface IProdukt
{
    void WyświetlInfo();
    decimal AktualnaCena();
    int DostepnaIlosc();
}

public abstract class Produkt : IProdukt
{
    public string Nazwa { get; set; }
    public string Opis { get; set; }
    protected decimal cena;
    protected int ilosc;

    protected Produkt(string nazwa, string opis, decimal cena, int ilosc)
    {
        Nazwa = nazwa;
        Opis = opis;
        this.cena = cena;
        this.ilosc = ilosc;
    }

    public virtual void WyświetlInfo()
    {
        Console.WriteLine($"Nazwa: {Nazwa}, Opis: {Opis}, Cena: {cena}, Dostępna ilość: {ilosc}");
    }

    public decimal AktualnaCena()
    {
        return cena;
    }

    public int DostepnaIlosc()
    {
        return ilosc;
    }
}
public class Ksiazka : Produkt
{
    public string Autor { get; set; }
    
  public string Model { get; set; }
    public string Producent { get; set; }
    public DateTime DataWydania { get; set; }

    public Ksiazka(string model, string producent, DateTime dataWydania, string nazwa, string opis, decimal cena, int ilosc)
      : base(nazwa, opis, cena, ilosc)
    {
        Model = model;
        Producent = producent;
        DataWydania = dataWydania;
    }

    public override void WyświetlInfo()
    {
        base.WyświetlInfo();
        Console.WriteLine($"Model: {Model}, Producent: {Producent}, Data wydania: {DataWydania}");
    }
}
    
public abstract class Osoba
{
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public Osoba(string imie, string nazwisko)
    {
        Imie = imie;
        Nazwisko = nazwisko;
    }
 
}
public class Klient : Osoba
{
    public List<IProdukt> Koszyk { get; set; }

    public Klient() => Koszyk = new List<IProdukt>();

    public void DodajDoKoszyka(IProdukt produkt)
    {
        if (produkt.DostepnaIlosc() > 0)
        {
            Koszyk.Add(produkt);
        }
        else
        {
            Console.WriteLine("Produkt nie jest dostępny.");
        }
    }

    public void PokazCeneProduktu(IProdukt produkt)
    {
        Console.WriteLine($"Cena produktu: {produkt.AktualnaCena()}");
    }

    public decimal ObliczKosztKoszyka()
    {
        decimal koszt = 0;
        foreach (var produkt in Koszyk)
        {
            koszt += produkt.AktualnaCena();
        }
        return koszt;
    }
}
