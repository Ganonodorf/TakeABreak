using System;
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
        DisablearTodo();

        switch (nuevoEstadoJuego)
        {
            case EstadoJuego.Inicio:
                EnablearControlesInicio();
                break;
            case EstadoJuego.Andando:
                EnablearControlesAndando();
                break;
            case EstadoJuego.Conversando:
                EnablearControlesConversando();
                break;
            case EstadoJuego.Eligiendo:
                EnablearControlesEligiendo();
                break;
            case EstadoJuego.HaciendoAnimacion:
                DisablearTodo();
                break;
            case EstadoJuego.Minijuego:
                EnablearControlesMinijuego();
                break;
            default:
                break;
        }
    }

    private void EnablearControlesInicio()
    {
        controlesJugador.Inicio.Enable();
    }

    private void EnablearControlesAndando()
    {
        controlesJugador.Andando.Enable();
    }

    private void EnablearControlesConversando()
    {
        controlesJugador.Conversando.Enable();
    }

    private void EnablearControlesEligiendo()
    {
        controlesJugador.Conversando.Enable();
    }

    private void EnablearControlesMinijuego()
    {
        controlesJugador.Minijuegando.Enable();
    }

    private void DisablearTodo()
    {
        controlesJugador.Andando.Disable();
        controlesJugador.Conversando.Disable();
        controlesJugador.Minijuegando.Disable();
        controlesJugador.Inicio.Disable();
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
    }
}
