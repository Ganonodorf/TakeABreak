using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variables privadas
    private EstadoJuego estado;
    private GameObject jugador;

    //[SerializeField] private EstadoJuego estadoJuegoInicial;

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

        EstablecerResolucionYRaton();

        CambiarEstadoJuego(EstadoJuego.Intro);
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
            case EstadoJuego.Intro:
                Debug.Log("Estado del juego: Intro");
                break;
            case EstadoJuego.Titulo:
                EstadoMenu();
                Debug.Log("Estado del juego: Titulo");
                break;
            case EstadoJuego.Inicio:
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
            case EstadoJuego.SentadoSillon:
                Debug.Log("Estado del juego: SentadoSillon");
                break;
            case EstadoJuego.Meditando:
                Debug.Log("Estado del juego: Meditando");
                break;
            case EstadoJuego.FinJuego:
                EstadoFinJuego();
                Debug.Log("Estado del juego: FinJuego");
                break;
            default:
                break;
        }

        CambioEstadoJuego?.Invoke(nuevoEstado);
    }

    private void EstadoMenu()
    {
        jugador.GetComponent<MovimientoCont>().CambiarEstadoMovimiento(EstadoMovimiento.IdleEspalda);
    }

    private void EstadoFinJuego()
    {
        throw new NotImplementedException();
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

    private void EstablecerResolucionYRaton()
    {
        Screen.SetResolution(1024, 576, true);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}

public enum EstadoJuego
{
    Intro,
    Titulo,
    Inicio,
    Andando,
    Conversando,
    Eligiendo,
    HaciendoAnimacion,
    SentadoSillon,
    Meditando,
    FinJuego
}
