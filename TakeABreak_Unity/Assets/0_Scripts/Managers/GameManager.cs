using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variables privadas
    private EstadoJuego estado;

    // Variables públicas
    public static GameManager Instance;

    public static event Action<EstadoJuego> CambioEstadoJuego;

    private void Awake()
    {
        HacerInmortal();
    }

    private void Start()
    {
        CambiarEstadoJuego(EstadoJuego.Andando);
    }

    public EstadoJuego GetEstadoJuego()
    {
        return estado;
    }

    public void CambiarEstadoJuego(EstadoJuego nuevoEstado)
    {
        estado = nuevoEstado;

        switch (nuevoEstado)
        {
            case EstadoJuego.Andando:
                Debug.Log("Estado del juego: Andando");
                break;
            case EstadoJuego.Conversando:
                Debug.Log("Estado del juego: Conversando");
                break;
            case EstadoJuego.Eligiendo:
                Debug.Log("Estado del juego: Eligiendo");
                break;
            default:
                break;

        }

        CambioEstadoJuego?.Invoke(nuevoEstado);
    }

    private void HacerInmortal()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}

public enum EstadoJuego
{
    Andando,
    Conversando,
    Eligiendo
}
