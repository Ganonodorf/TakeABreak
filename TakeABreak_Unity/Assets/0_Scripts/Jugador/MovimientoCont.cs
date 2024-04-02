using System;
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
        OnMovimientoChanged?.Invoke(EstadoMovimiento.Idle_Alante);
    }

    private void IdleIzquierda()
    {
        OnMovimientoChanged?.Invoke(EstadoMovimiento.Idle_Atras);
    }

    public void MovimientoAlante()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x + 1,
                                                    gameObject.transform.position.y);
    }

    public void MovimientoAtras()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x - 1,
                                                    gameObject.transform.position.y);
    }

    private void RecogerInfoInputs()
    {
        Debug.Log("MovimientoCont");
        InputManager.Instance.controlesJugador.Andando.Derecha.performed += contexto => AndarDerecha();
        InputManager.Instance.controlesJugador.Andando.Izquierda.performed += contexto => AndarIzquierda();
        InputManager.Instance.controlesJugador.Andando.Derecha.canceled += contexto => IdleDerecha();
        InputManager.Instance.controlesJugador.Andando.Izquierda.canceled += contexto => IdleIzquierda();
    }
}

public enum EstadoMovimiento
{
    Idle_Alante,
    Idle_Atras,
    AndandoAlante,
    AndandoAtras
}
