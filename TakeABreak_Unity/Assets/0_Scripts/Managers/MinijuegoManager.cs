using System;
using System.Collections;
using UnityEngine;

public class MinijuegoManager : MonoBehaviour
{
    public static MinijuegoManager Instance;

    private TipoMinijuego minijuegoActual;

    private OI_Sillon sillonController;
    private Animator marAnimator;
    private GameObject casaGO;

    private Coroutine fadeCasa;

    private void Awake()
    {
        HacerInmortal();

        SuscribirseEventos();

        BuscarGO();
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
            case EstadoJuego.Meditando:
                ComenzarMeditacion();
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
            case EstadoMovimiento.Meditando:
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

    private void ComenzarMeditacion()
    {
        sillonController.ComenzarMinijuego();

        FadeOutCasa();

        marAnimator.Play(Constantes.Animacion.Mar.QUIETO);

        Debug.Log("Comienzo a meditar");
    }

    private void FinalizarMeditacion()
    {
        sillonController.Accion();

        FadeInCasa();

        marAnimator.Play(Constantes.Animacion.Mar.IDLE);

        Debug.Log("Termino de meditar");
    }

    private void FadeOutCasa()
    {
        if(fadeCasa != null)
        {
            StopCoroutine(fadeCasa);
        }

        fadeCasa = StartCoroutine(FadeOutCoroutine());
    }

    private void FadeInCasa()
    {
        if (fadeCasa != null)
        {
            StopCoroutine(fadeCasa);
        }

        fadeCasa = StartCoroutine(FadeInCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        SpriteRenderer[] spritesCasa = casaGO.GetComponentsInChildren<SpriteRenderer>();

        float nuevaAlfa = 1.0f;

        while(nuevaAlfa > 0.0f)
        {
            foreach (SpriteRenderer sprite in spritesCasa)
            {
                sprite.color = new Color(sprite.color.r,
                                         sprite.color.g,
                                         sprite.color.b,
                                         nuevaAlfa);
            }

            nuevaAlfa -= 0.01f;

            yield return new WaitForFixedUpdate();
        }
    }

    private IEnumerator FadeInCoroutine()
    {
        SpriteRenderer[] spritesCasa = casaGO.GetComponentsInChildren<SpriteRenderer>();

        float nuevaAlfa = 0.0f;

        while (nuevaAlfa < 1.0f)
        {
            foreach (SpriteRenderer sprite in spritesCasa)
            {
                sprite.color = new Color(sprite.color.r,
                                         sprite.color.g,
                                         sprite.color.b,
                                         nuevaAlfa);
            }

            nuevaAlfa += 0.01f;

            yield return new WaitForFixedUpdate();
        }
    }

    private void Inhalar()
    {
        sillonController.gameObject.GetComponent<Animator>().Play(Constantes.Animacion.Sillon.MEDITANDO_INHALAR);

        marAnimator.Play(Constantes.Animacion.Mar.INHALAR);
        
    }

    private void Exhalar()
    {
        sillonController.gameObject.GetComponent<Animator>().Play(Constantes.Animacion.Sillon.MEDITANDO_EXHALAR);

        marAnimator.Play(Constantes.Animacion.Mar.EXHALAR);
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

    private void BuscarGO()
    {
        sillonController = GameObject.Find(Constantes.ObjetosInteractuables.SILLON_NOMBRE).GetComponent<OI_Sillon>();
        casaGO = GameObject.FindGameObjectWithTag(Constantes.Tags.CASA);
        marAnimator = GameObject.FindGameObjectWithTag(Constantes.Tags.MAR).GetComponent<Animator>();
    }

    private void RecogerInfoInputs()
    {
        InputManager.Instance.controlesJugador.Meditando.Salir.performed += contexto => FinalizarMeditacion();
        InputManager.Instance.controlesJugador.Meditando.Respirar.started += contexto => Inhalar();
        InputManager.Instance.controlesJugador.Meditando.Respirar.canceled += contexto => Exhalar();
    }
}

public enum TipoMinijuego
{
    Ninguno,
    Meditar
}
