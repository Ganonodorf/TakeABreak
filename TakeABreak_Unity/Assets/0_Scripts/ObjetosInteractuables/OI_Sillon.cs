using UnityEngine;

public class OI_Sillon : MonoBehaviour, IObjetoInteractuable
{
    private string _nombre;
    private string _textoAMostrar;
    private Sprite _sprite;
    private GameObject jugadorGO;
    private bool sentado;
    public string Nombre { get => _nombre; set => _nombre = value; }
    public string TextoAMostrar { get => _textoAMostrar; set => _textoAMostrar = value; }
    public Sprite Sprite { get => _sprite; set => _sprite = value; }

    public void Accion()
    {
        if (!sentado) Sentarse();
        else Levantarse();
    }

    void Start()
    {
        InicializarVariables();

        BuscarGO();
    }

    private void Sentarse()
    { 
        if (jugadorGO.TryGetComponent(out MovimientoCont movimientoCont))
        {
            movimientoCont.SentarseSillon(transform.position);
        }

        sentado = true;
    }

    private void Levantarse()
    {
        if (jugadorGO.TryGetComponent(out MovimientoCont movimientoCont))
        {
            movimientoCont.LevantarseSillon();
        }

        sentado = false;
    }

    private void InicializarVariables()
    {
        _nombre = Constantes.ObjetosInteractuables.SILLON_NOMBRE;
        _textoAMostrar = Constantes.ObjetosInteractuables.SILLON_TEXTOAMOSTRAR;
        sentado = false;
    }

    private void BuscarGO()
    {
        jugadorGO = GameObject.FindGameObjectWithTag(Constantes.Tags.JUGADOR);
    }
}