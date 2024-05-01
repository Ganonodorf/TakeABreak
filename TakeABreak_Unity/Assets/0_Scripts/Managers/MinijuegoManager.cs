using System;
using UnityEngine;

public class MinijuegoManager : MonoBehaviour
{
    public static MinijuegoManager Instance;

    private TipoMinijuego minijuegoActual;

    private void Awake()
    {
        HacerInmortal();

        SuscribirseEventos();
    }

    private void Start()
    {
        RecogerInfoInputs();

        InicializarVariables();
    }

    public TipoMinijuego GetTipoMinijuego()
    {
        return minijuegoActual;
    }

    public void SetTipoMinijuego(TipoMinijuego nuevoTipoMinijuego)
    {
        minijuegoActual = nuevoTipoMinijuego;
    }

    private void GameManager_CambioEstadoJuego(EstadoJuego nuevoEstadoJuego)
    {
        switch (nuevoEstadoJuego)
        {
            case EstadoJuego.Minijuego:
                ComenzarMinijuego();
                break;
            default:
                SetTipoMinijuego(TipoMinijuego.Ninguno);
                break;
        }
    }

    private void MovimientoCont_OnMovimientoChanged(EstadoMovimiento nuevoEstadoMovimiento)
    {
        switch (nuevoEstadoMovimiento)
        {
            case EstadoMovimiento.SentandoseSillon:
                SetTipoMinijuego(TipoMinijuego.Meditar);
                break;
            case EstadoMovimiento.LevantandoseSillon:
                SetTipoMinijuego(TipoMinijuego.Ninguno);
                break;
            default:
                SetTipoMinijuego(TipoMinijuego.Ninguno);
                break;
        }
    }

    private void ComenzarMinijuego()
    {
        if(minijuegoActual == TipoMinijuego.Meditar)
        {
            GameObject.Find(Constantes.ObjetosInteractuables.SILLON_NOMBRE).GetComponent<OI_Sillon>().ComenzarMinijuego();
            Debug.Log("Comienzo a meditar");
        }
    }

    private void SalirMinijuego()
    {
        if (minijuegoActual == TipoMinijuego.Meditar)
        {
            GameObject.Find(Constantes.ObjetosInteractuables.SILLON_NOMBRE).GetComponent<OI_Sillon>().Accion();
            Debug.Log("Termino de meditar");
        }
    }

    private void RecogerInfoInputs()
    {
        InputManager.Instance.controlesJugador.Minijuegando.Salir.performed += contexto => SalirMinijuego();
    }

    private void InicializarVariables()
    {
        minijuegoActual = TipoMinijuego.Ninguno;
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

    private void SuscribirseEventos()
    {
        GameManager.CambioEstadoJuego += GameManager_CambioEstadoJuego;

        MovimientoCont.OnMovimientoChanged += MovimientoCont_OnMovimientoChanged;
    }
}

public enum TipoMinijuego
{
    Ninguno,
    Meditar
}
