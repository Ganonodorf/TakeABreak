using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using static Constantes;

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
        // x:120 y:-28
        OnMovimientoChanged?.Invoke(EstadoMovimiento.SubiendoEscIzq);
    }

    public void BajarEscalerasIzq()
    {
        OnMovimientoChanged?.Invoke(EstadoMovimiento.BajandoEscIzq);
    }

    public void SubirEscalerasDer()
    {
        OnMovimientoChanged?.Invoke(EstadoMovimiento.SubiendoEscDer);
    }

    public void BajarEscalerasDer()
    {
        OnMovimientoChanged?.Invoke(EstadoMovimiento.BajandoEscDer);
    }

    public void SentarseSillon(Vector3 posicionSillon)
    {
        transform.position = new Vector3(posicionSillon.x,
                                         posicionSillon.y);

        OnMovimientoChanged?.Invoke(EstadoMovimiento.SentandoseSillon);
    }

    public void LevantarseSillon()
    {
        OnMovimientoChanged?.Invoke(EstadoMovimiento.LevantandoseSillon);
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

    public void ColocarArribaEscIzq()
    {
        gameObject.transform.position = new Vector2(PosicionesClave.ArribaEscalerasIzq.x,
                                                    PosicionesClave.ArribaEscalerasIzq.y);
    }

    public void ColocarAbajoEscIzq()
    {
        gameObject.transform.position = new Vector2(PosicionesClave.AbajoEscalerasIzq.x,
                                                    PosicionesClave.AbajoEscalerasIzq.y);
    }

    public void ColocarArribaEscDer()
    {
        gameObject.transform.position = new Vector2(PosicionesClave.ArribaEscalerasDer.x,
                                                    PosicionesClave.ArribaEscalerasDer.y);
    }

    public void ColocarAbajoEscDer()
    {
        gameObject.transform.position = new Vector2(PosicionesClave.AbajoEscalerasDer.x,
                                                    PosicionesClave.AbajoEscalerasDer.y);
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
    BajandoEscIzq,
    SentandoseSillon,
    LevantandoseSillon
}
