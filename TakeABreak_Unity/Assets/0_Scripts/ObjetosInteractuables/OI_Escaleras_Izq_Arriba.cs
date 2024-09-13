using UnityEngine;

public class OI_Escaleras_Izq_Arriba : MonoBehaviour, IObjetoInteractuable
{
    private string _nombre;
    private string _textoAMostrar;
    private GameObject jugadorGO;
    public string Nombre { get => _nombre; set => _nombre = value; }
    public string TextoAMostrar { get => _textoAMostrar; set => _textoAMostrar = value; }

    public void Accion()
    {
        BajarEscaleras();
    }

    void Start()
    {
        InicializarVariables();

        BuscarGO();
    }

    private void BajarEscaleras()
    {
        GetComponent<Animator>().Play(Constantes.Animacion.Escaleras.BAJANDO_ESCALERAS_IZQ);

        if (jugadorGO.TryGetComponent(out MovimientoCont movimientoCont))
        {
            movimientoCont.CambiarEstadoMovimiento(EstadoMovimiento.BajandoEscIzq);
        }
    }

    private void InicializarVariables()
    {
        _nombre = Constantes.ObjetosInteractuables.ESCALERAS_NOMBRE;
        _textoAMostrar = Constantes.ObjetosInteractuables.ESCALERAS_ARRIBA_TEXTOAMOSTRAR;
    }

    private void BuscarGO()
    {
        jugadorGO = GameObject.FindGameObjectWithTag(Constantes.Tags.JUGADOR);
    }
}
