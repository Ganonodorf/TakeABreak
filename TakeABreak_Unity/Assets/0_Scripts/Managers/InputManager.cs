using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public ControlesJugador controlesJugador;

    private void Awake()
    {
        HacerInmortal();

        InicializarVariables();

        SuscribirseEventos();
    }

    private void GameManager_CambioEstadoJuego(EstadoJuego nuevoEstadoJuego)
    {
        switch(nuevoEstadoJuego)
        {
            case EstadoJuego.Andando:
                EnablearControlesAndando();
                break;
            case EstadoJuego.Conversando:
                EnablearControlesConversando();
                break;
            case EstadoJuego.Eligiendo:
                EnablearControlesEligiendo();
                break;
            default:
                break;
        }
    }

    private void EnablearControlesAndando()
    {
        controlesJugador.Andando.Enable();
        controlesJugador.Conversando.Disable();
    }

    private void EnablearControlesConversando()
    {
        controlesJugador.Andando.Disable();
        controlesJugador.Conversando.Enable();
    }

    private void EnablearControlesEligiendo()
    {
        controlesJugador.Andando.Disable();
        controlesJugador.Conversando.Enable();
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


    private void InicializarVariables()
    {
        controlesJugador = new ControlesJugador();
        controlesJugador.Andando.Enable();
    }

    private void SuscribirseEventos()
    {
        GameManager.CambioEstadoJuego += GameManager_CambioEstadoJuego;
        Debug.Log("Input manager");
    }
}
