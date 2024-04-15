using UnityEngine;

public class AnimacionCont : MonoBehaviour
{
    private Animator animator;

    private string animacionActual;

    private void Awake()
    {
        MovimientoCont.OnMovimientoChanged += MovimientoCont_OnMovimientoChanged;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animacionActual = Constantes.Jugador.Animacion.IDLE_ALANTE;
    }

    private void MovimientoCont_OnMovimientoChanged(EstadoMovimiento nuevoEstadoMovimiento)
    {
        string animacionNueva;

        switch (nuevoEstadoMovimiento)
        {
            case EstadoMovimiento.IdleAlante:
                animacionNueva = Constantes.Jugador.Animacion.IDLE_ALANTE;
                break;
            case EstadoMovimiento.IdleAtras:
                animacionNueva = Constantes.Jugador.Animacion.IDLE_ATRAS;
                break;
            case EstadoMovimiento.AndandoAlante:
                animacionNueva = Constantes.Jugador.Animacion.ANDANDO_ALANTE;
                break;
            case EstadoMovimiento.AndandoAtras:
                animacionNueva = Constantes.Jugador.Animacion.ANDANDO_ATRAS;
                break;
            case EstadoMovimiento.SubiendoEscIzq:
                animacionNueva = Constantes.Jugador.Animacion.SUBIENDO_ESCALERAS_IZQ;
                GameManager.Instance.CambiarEstadoJuego(EstadoJuego.HaciendoAnimacion);
                break;
            case EstadoMovimiento.BajandoEscIzq:
                animacionNueva = Constantes.Jugador.Animacion.BAJANDO_ESCALERAS_IZQ;
                GameManager.Instance.CambiarEstadoJuego(EstadoJuego.HaciendoAnimacion);
                break;
            case EstadoMovimiento.SubiendoEscDer:
                animacionNueva = Constantes.Jugador.Animacion.SUBIENDO_ESCALERAS_DER;
                GameManager.Instance.CambiarEstadoJuego(EstadoJuego.HaciendoAnimacion);
                break;
            case EstadoMovimiento.BajandoEscDer:
                animacionNueva = Constantes.Jugador.Animacion.BAJANDO_ESCALERAS_DER;
                GameManager.Instance.CambiarEstadoJuego(EstadoJuego.HaciendoAnimacion);
                break;
            case EstadoMovimiento.SentandoseSillon:
                animacionNueva = Constantes.Jugador.Animacion.SENTANDOSE_SILLON;
                GameManager.Instance.CambiarEstadoJuego(EstadoJuego.HaciendoAnimacion);
                MinijuegoManager.Instance.SetTipoMinijuego(TipoMinijuego.Meditar);
                break;
            case EstadoMovimiento.LevantandoseSillon:
                animacionNueva = Constantes.Jugador.Animacion.LEVANTANDOSE_SILLON;
                GameManager.Instance.CambiarEstadoJuego(EstadoJuego.HaciendoAnimacion);
                MinijuegoManager.Instance.SetTipoMinijuego(TipoMinijuego.Ninguno);
                break;
            default:
                animacionNueva = Constantes.Jugador.Animacion.IDLE_ALANTE;
                break;
        }

        if(animacionNueva != animacionActual)
        {
            animator.Play(animacionNueva);
            animacionActual = animacionNueva;
        }
    }

    public void FinAnimacion(EstadoJuego nuevoEstadoJuego)
    {
        GameManager.Instance.CambiarEstadoJuego(nuevoEstadoJuego);
    }
}
