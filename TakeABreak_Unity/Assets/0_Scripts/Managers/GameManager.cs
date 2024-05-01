using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variables privadas
    private EstadoJuego estado;
    private GameObject jugador;

    // Variables públicas
    public static GameManager Instance;

    public static event Action<EstadoJuego> CambioEstadoJuego;

    private void Awake()
    {
        HacerInmortal();

        BuscarGO();
    }

    private void Start()
    {
        RecogerInfoInputs();

        CambiarEstadoJuego(EstadoJuego.Inicio);
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
            case EstadoJuego.Inicio:
                EstadoInicial();
                Debug.Log("Estado del juego: Inicio");
                break;
            case EstadoJuego.Andando:
                Debug.Log("Estado del juego: Andando");
                break;
            case EstadoJuego.Conversando:
                Debug.Log("Estado del juego: Conversando");
                break;
            case EstadoJuego.Eligiendo:
                Debug.Log("Estado del juego: Eligiendo");
                break;
            case EstadoJuego.HaciendoAnimacion:
                Debug.Log("Estado del juego: HaciendoAnimacion");
                break;
            case EstadoJuego.Minijuego:
                Debug.Log("Estado del juego: Minijuego");
                break;
            default:
                break;
        }

        CambioEstadoJuego?.Invoke(nuevoEstado);
    }

    private void EstadoInicial()
    {
        jugador.GetComponent<MovimientoCont>().CambiarEstadoMovimiento(EstadoMovimiento.IdleEspalda);
    }

    private void IniciarJuego()
    {
        jugador.GetComponent<MovimientoCont>().CambiarEstadoMovimiento(EstadoMovimiento.Girandose);
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

    private void BuscarGO()
    {
        jugador = GameObject.FindWithTag(Constantes.Tags.JUGADOR);
    }

    private void RecogerInfoInputs()
    {
        InputManager.Instance.controlesJugador.Inicio.Accion.performed += contexto => IniciarJuego();
    }
}

public enum EstadoJuego
{
    Inicio,
    Andando,
    Conversando,
    Eligiendo,
    HaciendoAnimacion,
    Minijuego
}
