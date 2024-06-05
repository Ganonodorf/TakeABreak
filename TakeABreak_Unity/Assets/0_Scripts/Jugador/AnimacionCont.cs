using System;
using Unity.VisualScripting;
using UnityEngine;

public class AnimacionCont : MonoBehaviour
{
    private Animator animator;

    private string animacionActual;

    private EstadoMovimiento estadoMovimientoActual;

    private float duracionAnimacion;

    private MovimientoCont movimientoCont;

    private void Awake()
    {
        MovimientoCont.OnMovimientoChanged += MovimientoCont_OnMovimientoChanged;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        movimientoCont = GetComponent<MovimientoCont>();
        animacionActual = Constantes.Animacion.Jugador.IDLE_ALANTE;
    }

    public EstadoMovimiento GetEstadoMovimientoActual()
    {
        return estadoMovimientoActual;
    }

    private void MovimientoCont_OnMovimientoChanged(EstadoMovimiento nuevoEstadoMovimiento)
    {
        string animacionNueva;

        estadoMovimientoActual = nuevoEstadoMovimiento;

        switch (nuevoEstadoMovimiento)
        {
            case EstadoMovimiento.IdleEspalda:
                animacionNueva = Constantes.Animacion.Jugador.IDLE_ESPALDA;
                break;
            case EstadoMovimiento.Girandose:
                animacionNueva = Constantes.Animacion.Jugador.GIRANDOSE;
                GameManager.Instance.CambiarEstadoJuego(EstadoJuego.HaciendoAnimacion);
                break;
            case EstadoMovimiento.IdleAlante:
                animacionNueva = Constantes.Animacion.Jugador.IDLE_ALANTE;
                break;
            case EstadoMovimiento.IdleAtras:
                animacionNueva = Constantes.Animacion.Jugador.IDLE_ATRAS;
                break;
            case EstadoMovimiento.AndandoAlante:
                animacionNueva = Constantes.Animacion.Jugador.ANDANDO_ALANTE;
                break;
            case EstadoMovimiento.AndandoAtras:
                animacionNueva = Constantes.Animacion.Jugador.ANDANDO_ATRAS;
                break;
            case EstadoMovimiento.SubiendoEscIzq:
                animacionNueva = Constantes.Animacion.Jugador.NADA;
                duracionAnimacion = Constantes.Animacion.Escaleras.DURACION_ESCALERAS;
                Invoke("FinSubiendoEscIzq", duracionAnimacion);
                GameManager.Instance.CambiarEstadoJuego(EstadoJuego.HaciendoAnimacion);
                break;
            case EstadoMovimiento.BajandoEscIzq:
                animacionNueva = Constantes.Animacion.Jugador.NADA;
                duracionAnimacion = Constantes.Animacion.Escaleras.DURACION_ESCALERAS;
                Invoke("FinBajandoEscIzq", duracionAnimacion);
                GameManager.Instance.CambiarEstadoJuego(EstadoJuego.HaciendoAnimacion);
                break;
            case EstadoMovimiento.SubiendoEscDer:
                animacionNueva = Constantes.Animacion.Jugador.NADA;
                duracionAnimacion = Constantes.Animacion.Escaleras.DURACION_ESCALERAS;
                Invoke("FinSubiendoEscDer", duracionAnimacion);
                GameManager.Instance.CambiarEstadoJuego(EstadoJuego.HaciendoAnimacion);
                break;
            case EstadoMovimiento.BajandoEscDer:
                animacionNueva = Constantes.Animacion.Jugador.NADA;
                duracionAnimacion = Constantes.Animacion.Escaleras.DURACION_ESCALERAS;
                Invoke("FinBajandoEscDer", duracionAnimacion);
                GameManager.Instance.CambiarEstadoJuego(EstadoJuego.HaciendoAnimacion);
                break;
            case EstadoMovimiento.SentandoseSillon:
                animacionNueva = Constantes.Animacion.Jugador.NADA;
                duracionAnimacion = Constantes.Animacion.Sillon.DURACION_SENTANDOSE_SILLON;
                Invoke("FinSentandoseSillon", duracionAnimacion);
                GameManager.Instance.CambiarEstadoJuego(EstadoJuego.HaciendoAnimacion);
                break;
            case EstadoMovimiento.SentandoSillon:
                animacionNueva = Constantes.Animacion.Jugador.NADA;
                break;
            case EstadoMovimiento.LevantandoseSillon:
                animacionNueva = Constantes.Animacion.Jugador.NADA;
                duracionAnimacion = Constantes.Animacion.Sillon.DURACION_LEVANTANDOSE_SILLON;
                Invoke("FinLevantandoseSillon", duracionAnimacion);
                GameManager.Instance.CambiarEstadoJuego(EstadoJuego.HaciendoAnimacion);
                break;
            case EstadoMovimiento.Meditando:
                animacionNueva = Constantes.Animacion.Jugador.NADA;
                break;
            case EstadoMovimiento.SentandoseBanco:
                animacionNueva = Constantes.Animacion.Jugador.NADA;
                duracionAnimacion = Constantes.Animacion.Banco.DURACION_SENTANDOSE_BANCO;
                Invoke("FinSentandoseBanco", duracionAnimacion);
                GameManager.Instance.CambiarEstadoJuego(EstadoJuego.HaciendoAnimacion);
                break;
            case EstadoMovimiento.SentadoBanco:
                animacionNueva = Constantes.Animacion.Jugador.NADA;
                break;
            default:
                animacionNueva = Constantes.Animacion.Jugador.IDLE_ALANTE;
                GameManager.Instance.CambiarEstadoJuego(EstadoJuego.Andando);
                break;
        }

        if(animacionNueva != animacionActual)
        {
            animator.Play(animacionNueva);
            animacionActual = animacionNueva;
        }

    }

    private void FinSubiendoEscIzq()
    {
        movimientoCont.CambiarEstadoMovimiento(EstadoMovimiento.IdleAlante);
        FinAnimacion(EstadoJuego.Andando);
    }

    private void FinBajandoEscIzq()
    {
        movimientoCont.CambiarEstadoMovimiento(EstadoMovimiento.IdleAtras);
        FinAnimacion(EstadoJuego.Andando);
    }

    private void FinSubiendoEscDer()
    {
        movimientoCont.CambiarEstadoMovimiento(EstadoMovimiento.IdleAtras);
        FinAnimacion(EstadoJuego.Andando);
    }

    private void FinBajandoEscDer()
    {
        movimientoCont.CambiarEstadoMovimiento(EstadoMovimiento.IdleAlante);
        FinAnimacion(EstadoJuego.Andando);
    }

    private void FinSentandoseSillon()
    {
        movimientoCont.CambiarEstadoMovimiento(EstadoMovimiento.SentandoSillon);
        FinAnimacion(EstadoJuego.SentadoSillon);
    }

    private void FinLevantandoseSillon()
    {
        movimientoCont.CambiarEstadoMovimiento(EstadoMovimiento.IdleAlante);
        FinAnimacion(EstadoJuego.Andando);
    }

    private void FinSentandoseBanco()
    {
        movimientoCont.CambiarEstadoMovimiento(EstadoMovimiento.SentadoBanco);
        FinAnimacion(EstadoJuego.Conversando);
    }

    public void FinAnimacion(EstadoJuego nuevoEstadoJuego)
    {
        GameManager.Instance.CambiarEstadoJuego(nuevoEstadoJuego);
    }
}
