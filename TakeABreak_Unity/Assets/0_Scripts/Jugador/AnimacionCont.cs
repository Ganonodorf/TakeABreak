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
        animacionActual = Constantes.Jugador.Animacion.IDLE_ALANTE;
    }

    private void MovimientoCont_OnMovimientoChanged(EstadoMovimiento nuevoEstadoMovimiento)
    {
        string animacionNueva;

        estadoMovimientoActual = nuevoEstadoMovimiento;

        switch (nuevoEstadoMovimiento)
        {
            case EstadoMovimiento.IdleEspalda:
                animacionNueva = Constantes.Jugador.Animacion.IDLE_ESPALDA;
                break;
            case EstadoMovimiento.Girandose:
                animacionNueva = Constantes.Jugador.Animacion.GIRANDOSE;
                GameManager.Instance.CambiarEstadoJuego(EstadoJuego.HaciendoAnimacion);
                break;
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
                animacionNueva = Constantes.Jugador.Animacion.NADA;
                duracionAnimacion = Constantes.Jugador.Animacion.DURACION_ESCALERAS;
                Invoke("ActuarTrasAnimacion", duracionAnimacion);
                GameManager.Instance.CambiarEstadoJuego(EstadoJuego.HaciendoAnimacion);
                break;
            case EstadoMovimiento.BajandoEscIzq:
                animacionNueva = Constantes.Jugador.Animacion.NADA;
                duracionAnimacion = Constantes.Jugador.Animacion.DURACION_ESCALERAS;
                Invoke("ActuarTrasAnimacion", duracionAnimacion);
                GameManager.Instance.CambiarEstadoJuego(EstadoJuego.HaciendoAnimacion);
                break;
            case EstadoMovimiento.SubiendoEscDer:
                animacionNueva = Constantes.Jugador.Animacion.NADA;
                duracionAnimacion = Constantes.Jugador.Animacion.DURACION_ESCALERAS;
                Invoke("ActuarTrasAnimacion", duracionAnimacion);
                GameManager.Instance.CambiarEstadoJuego(EstadoJuego.HaciendoAnimacion);
                break;
            case EstadoMovimiento.BajandoEscDer:
                animacionNueva = Constantes.Jugador.Animacion.NADA;
                duracionAnimacion = Constantes.Jugador.Animacion.DURACION_ESCALERAS;
                Invoke("ActuarTrasAnimacion", duracionAnimacion);
                GameManager.Instance.CambiarEstadoJuego(EstadoJuego.HaciendoAnimacion);
                break;
            case EstadoMovimiento.SentandoseSillon:
                animacionNueva = Constantes.Jugador.Animacion.NADA;
                duracionAnimacion = Constantes.Jugador.Animacion.DURACION_SENTANDOSE_SILLON;
                Invoke("ActuarTrasAnimacion", duracionAnimacion);
                GameManager.Instance.CambiarEstadoJuego(EstadoJuego.HaciendoAnimacion);
                break;
            case EstadoMovimiento.LevantandoseSillon:
                animacionNueva = Constantes.Jugador.Animacion.NADA;
                duracionAnimacion = Constantes.Jugador.Animacion.DURACION_LEVANTANDOSE_SILLON;
                Invoke("ActuarTrasAnimacion", duracionAnimacion);
                GameManager.Instance.CambiarEstadoJuego(EstadoJuego.HaciendoAnimacion);
                break;
            default:
                animacionNueva = Constantes.Jugador.Animacion.IDLE_ALANTE;
                GameManager.Instance.CambiarEstadoJuego(EstadoJuego.Andando);
                break;
        }

        if(animacionNueva != animacionActual)
        {
            animator.Play(animacionNueva);
            animacionActual = animacionNueva;
        }

    }

    private void ActuarTrasAnimacion()
    {
        switch (estadoMovimientoActual)
        {
            case EstadoMovimiento.SubiendoEscIzq:
                FinSubiendoEscIzq();
                break;
            case EstadoMovimiento.BajandoEscIzq:
                FinBajandoEscIzq();
                break;
            case EstadoMovimiento.SubiendoEscDer:
                FinSubiendoEscDer();
                break;
            case EstadoMovimiento.BajandoEscDer:
                FinBajandoEscDer();
                break;
            case EstadoMovimiento.SentandoseSillon:
                FinSentandoseSillon();
                break;
            case EstadoMovimiento.LevantandoseSillon:
                FinLevantandoseSillon();
                break;
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
        FinAnimacion(EstadoJuego.Minijuego);
    }

    private void FinLevantandoseSillon()
    {
        movimientoCont.CambiarEstadoMovimiento(EstadoMovimiento.IdleAlante);
        FinAnimacion(EstadoJuego.Andando);
    }

    public void FinAnimacion(EstadoJuego nuevoEstadoJuego)
    {
        GameManager.Instance.CambiarEstadoJuego(nuevoEstadoJuego);
    }
}
