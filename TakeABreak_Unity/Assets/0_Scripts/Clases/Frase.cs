public class Frase
{
    private int _id;
    public int ID { get { return _id; }
                    set { _id = value; } }

    private string _texto;
    public string Texto { get { return _texto; }
                          set { _texto  = value; } }

    private InterlocutorEnum _interlocutor;
    public InterlocutorEnum Interlocutor { get { return _interlocutor; }
                                           set { _interlocutor = value; } }

    private bool _mostrar;
    public bool Mostrar { get { return _mostrar; }
                          set { _mostrar = value; } }

    private int[] _siguienteFrase;
    public int[] SiguienteFrase { get { return _siguienteFrase; }
                                  set { _siguienteFrase = value; } }

    public Frase() { }

    public Frase(int ID, string Texto, InterlocutorEnum Interlocutor, bool Mostrar, int[] SiguienteFrase)
    {
        this.ID = ID;
        this.Texto = Texto;
        this.Interlocutor = Interlocutor;
        this.Mostrar = Mostrar;
        this.SiguienteFrase = SiguienteFrase;
    }
}

public enum InterlocutorEnum
{
    Jugador,
    NPC,
    Eleccion,
    Sillon,
    TuMismo
}