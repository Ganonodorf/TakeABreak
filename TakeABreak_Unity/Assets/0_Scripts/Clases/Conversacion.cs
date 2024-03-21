public class Conversacion
{
    public int ID { get; set; }

    public Frase[] Frases { get; set; }

    public Conversacion() { }

    public Conversacion(int id, Frase[] frases)
    {
        ID = id;
        Frases = frases;
    }
}
