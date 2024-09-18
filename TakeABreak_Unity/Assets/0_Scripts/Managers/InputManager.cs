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
            case EstadoJuego.Titulo:
                EnablearControlesTitulo();
                break;
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
            case EstadoJuego.SentadoSillon:
                EnablearControlesConversando();
                break;
            case EstadoJuego.Meditando:
                EnablearControlesMeditando();
                break;
            case EstadoJuego.FinJuego:
                EnablearControlesFinJuego();
                break;
            case EstadoJuego.Pausa:
                EnablearControlesPausa();
                break;
            default:
                break;
        }
    }

    private void EnablearControlesTitulo()
    {
        controlesJugador.Titulo.Enable();
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
        controlesJugador.Eligiendo.Enable();
    }

    private void EnablearControlesMeditando()
    {
        controlesJugador.Meditando.Enable();
    }

    private void EnablearControlesFinJuego()
    {
        controlesJugador.FinJuego.Enable();
    }

    private void EnablearControlesPausa()
    {
        controlesJugador.Pausa.Enable();
    }

    private void DisablearTodo()
    {
        controlesJugador.Titulo.Disable();
        controlesJugador.Inicio.Disable();
        controlesJugador.Andando.Disable();
        controlesJugador.Conversando.Disable();
        controlesJugador.Eligiendo.Disable();
        controlesJugador.Meditando.Disable();
        controlesJugador.FinJuego.Disable();
        controlesJugador.Pausa.Disable();
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
    }

    private void SuscribirseEventos()
    {
        GameManager.CambioEstadoJuego += GameManager_CambioEstadoJuego;
    }
}
