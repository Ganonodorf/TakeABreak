using System;
using UnityEngine;
using static Constantes;

public class MovimientoCont : MonoBehaviour
{
    public static event Action<EstadoMovimiento> OnMovimientoChanged;

    private void Start()
    {
        RecogerInfoInputs();
    }

    public void CambiarEstadoMovimiento(EstadoMovimiento nuevoEstadoMovimiento)
    {
        switch (nuevoEstadoMovimiento)
        {
            case EstadoMovimiento.IdleEspalda:
                break;
            case EstadoMovimiento.Girandose:
                break;
            case EstadoMovimiento.IdleAlante:
                break;
            case EstadoMovimiento.IdleAtras:
                break;
            case EstadoMovimiento.AndandoAlante:
                break;
            case EstadoMovimiento.AndandoAtras:
                break;
            case EstadoMovimiento.SubiendoEscDer:
                SubirEscalerasDer();
                break;
            case EstadoMovimiento.SubiendoEscIzq:
                SubirEscalerasIzq();
                break;
            case EstadoMovimiento.BajandoEscDer:
                BajarEscalerasDer();
                break;
            case EstadoMovimiento.BajandoEscIzq:
                BajarEscalerasIzq();
                break;
            case EstadoMovimiento.SentandoseSillon:
                SentarseSillon();
                break;
            case EstadoMovimiento.Meditando:
                break;
            case EstadoMovimiento.LevantandoseSillon:
                break;
            default:
                break;
        }

        OnMovimientoChanged?.Invoke(nuevoEstadoMovimiento);
    }

    public void SubirEscalerasDer()
    {
        ColocarArribaSubiendoEscDer();
    }

    public void SubirEscalerasIzq()
    {
        ColocarArribaSubiendoEscIzq();
    }

    public void BajarEscalerasDer()
    {
        ColocarAbajoBajandoEscDer();
    }

    public void BajarEscalerasIzq()
    {
        ColocarAbajoBajandoEscIzq();
    }

    public void SentarseSillon()
    {
        ColocarPosFinalLevantarseSillon();

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
        if ((posicionDeseada >= PosicionesClave.PosLimiteAbajoEscalerasIzq && posicionDeseada <= PosicionesClave.PosLimiteArribaEscalerasIzq) ||
            (posicionDeseada >= PosicionesClave.PosLimiteArribaEscalerasDer && posicionDeseada <= PosicionesClave.PosLimiteAbajoEscalerasDer))
        {
            return false;
        }

        return true;
    }

    public void ColocarAbajoBajandoEscIzq()
    {
        gameObject.transform.position = new Vector2(PosicionesClave.AbajoBajandoEscalerasIzq.x,
                                                    PosicionesClave.AbajoBajandoEscalerasIzq.y);
    }

    public void ColocarArribaSubiendoEscIzq()
    {
        gameObject.transform.position = new Vector2(PosicionesClave.ArribaSubiendoEscalerasIzq.x,
                                                    PosicionesClave.ArribaSubiendoEscalerasIzq.y);
    }

    public void ColocarAbajoBajandoEscDer()
    {
        gameObject.transform.position = new Vector2(PosicionesClave.AbajoBajandoEscalerasDer.x,
                                                    PosicionesClave.AbajoBajandoEscalerasDer.y);
    }

    public void ColocarArribaSubiendoEscDer()
    {
        gameObject.transform.position = new Vector2(PosicionesClave.ArribaSubiendoEscalerasDer.x,
                                                    PosicionesClave.ArribaSubiendoEscalerasDer.y);
    }

    private void ColocarPosFinalLevantarseSillon()
    {
        gameObject.transform.position = new Vector2(PosicionesClave.Sillon.x,
                                                    PosicionesClave.Sillon.y);
    }

    private void RecogerInfoInputs()
    {
        InputManager.Instance.controlesJugador.Andando.Derecha.performed += contexto => CambiarEstadoMovimiento(EstadoMovimiento.AndandoAlante);
        InputManager.Instance.controlesJugador.Andando.Izquierda.performed += contexto => CambiarEstadoMovimiento(EstadoMovimiento.AndandoAtras);
        InputManager.Instance.controlesJugador.Andando.Derecha.canceled += contexto => CambiarEstadoMovimiento(EstadoMovimiento.IdleAlante);
        InputManager.Instance.controlesJugador.Andando.Izquierda.canceled += contexto => CambiarEstadoMovimiento(EstadoMovimiento.IdleAtras);
    }
}

public enum EstadoMovimiento
{
    IdleEspalda,
    Girandose,
    IdleAlante,
    IdleAtras,
    AndandoAlante,
    AndandoAtras,
    SubiendoEscDer,
    SubiendoEscIzq,
    BajandoEscDer,
    BajandoEscIzq,
    SentandoseSillon,
    Meditando,
    LevantandoseSillon
}
