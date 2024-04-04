using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MovimientoCont : MonoBehaviour
{
    public static event Action<EstadoMovimiento> OnMovimientoChanged;

    private void Start()
    {
        RecogerInfoInputs();
    }

    private void AndarDerecha()
    {
        OnMovimientoChanged?.Invoke(EstadoMovimiento.AndandoAlante);
    }

    private void AndarIzquierda()
    {
        OnMovimientoChanged?.Invoke(EstadoMovimiento.AndandoAtras);
    }

    private void IdleDerecha()
    {
        OnMovimientoChanged?.Invoke(EstadoMovimiento.IdleAlante);
    }

    private void IdleIzquierda()
    {
        OnMovimientoChanged?.Invoke(EstadoMovimiento.IdleAtras);
    }

    public void SubirEscalerasIzq()
    {
        GameManager.Instance.CambiarEstadoJuego(EstadoJuego.HaciendoAnimacion);
        OnMovimientoChanged?.Invoke(EstadoMovimiento.SubiendoEscIzq);
    }

    public void BajarEscalerasIzq()
    {
        GameManager.Instance.CambiarEstadoJuego(EstadoJuego.HaciendoAnimacion);
        OnMovimientoChanged?.Invoke(EstadoMovimiento.BajandoEscIzq);
    }

    public void SubirEscalerasDer()
    {
        GameManager.Instance.CambiarEstadoJuego(EstadoJuego.HaciendoAnimacion);
        OnMovimientoChanged?.Invoke(EstadoMovimiento.SubiendoEscDer);
    }

    public void BajarEscalerasDer()
    {
        GameManager.Instance.CambiarEstadoJuego(EstadoJuego.HaciendoAnimacion);
        OnMovimientoChanged?.Invoke(EstadoMovimiento.BajandoEscDer);
    }

    public void MovimientoHorizontal(float cantidadMovimiento)
    {
        if(SePuede(gameObject.transform.position.x + cantidadMovimiento))
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + cantidadMovimiento,
                                                        gameObject.transform.position.y);
        }
    }

    public void MovimientoVertical(float cantidadMovimiento)
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x,
                                                    gameObject.transform.position.y + cantidadMovimiento);
    }

    private bool SePuede(float posicionDeseada)
    {
        if ((posicionDeseada >= 118.0f && posicionDeseada <= 153.0f) ||
            (posicionDeseada >= 604.0f && posicionDeseada <= 638.0f))
        {
            return false;
        }

        return true;
    }

    public void MovSubirEscaleraIzq()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x + 10.0f,
                                                    gameObject.transform.position.y);
        gameObject.transform.position = new Vector2(gameObject.transform.position.x,
                                                    gameObject.transform.position.y + 2.0f);
    }

    public void MovBajarEscaleraIzq()
    {

        gameObject.transform.position = new Vector2(gameObject.transform.position.x - 10.0f,
                                                    gameObject.transform.position.y);
        gameObject.transform.position = new Vector2(gameObject.transform.position.x,
                                                    gameObject.transform.position.y - 2.0f);
    }

    public void MovBajarEscaleraDer()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x + 10.0f,
                                                    gameObject.transform.position.y);
        gameObject.transform.position = new Vector2(gameObject.transform.position.x,
                                                    gameObject.transform.position.y - 2.0f);
    }

    public void MovSubirEscaleraDer()
    {

        gameObject.transform.position = new Vector2(gameObject.transform.position.x - 10.0f,
                                                    gameObject.transform.position.y);
        gameObject.transform.position = new Vector2(gameObject.transform.position.x,
                                                    gameObject.transform.position.y + 2.0f);
    }

    private void RecogerInfoInputs()
    {
        InputManager.Instance.controlesJugador.Andando.Derecha.performed += contexto => AndarDerecha();
        InputManager.Instance.controlesJugador.Andando.Izquierda.performed += contexto => AndarIzquierda();
        InputManager.Instance.controlesJugador.Andando.Derecha.canceled += contexto => IdleDerecha();
        InputManager.Instance.controlesJugador.Andando.Izquierda.canceled += contexto => IdleIzquierda();
    }
}

public enum EstadoMovimiento
{
    IdleAlante,
    IdleAtras,
    AndandoAlante,
    AndandoAtras,
    SubiendoEscDer,
    SubiendoEscIzq,
    BajandoEscDer,
    BajandoEscIzq
}
