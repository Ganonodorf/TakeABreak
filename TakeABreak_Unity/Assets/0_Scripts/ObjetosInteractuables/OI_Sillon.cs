using System;
using System.Collections;
using UnityEngine;

public class OI_Sillon : MonoBehaviour, IObjetoInteractuable
{
    private string _nombre;
    private string _textoAMostrar;

    private Sprite _sprite;

    private GameObject jugadorGO;
    private GameObject casaGO;

    private Animator marAnimator;

    private Coroutine fadeCasa;

    private bool conversacionInicial;

    private float timerRespiracion;

    public string Nombre { get => _nombre; set => _nombre = value; }
    public string TextoAMostrar { get => _textoAMostrar; set => _textoAMostrar = value; }
    public Sprite Sprite { get => _sprite; set => _sprite = value; }

    public void Accion()
    {
        Sentarse();
    }

    void Start()
    {
        InicializarVariables();

        BuscarGO();

        RecogerInfoInputs();

        SuscribirseEventos();
    }

    private void Update()
    {
        if (GameManager.Instance.GetEstadoJuego() == EstadoJuego.Meditando)
        {
            timerRespiracion += Time.fixedDeltaTime;

            if(timerRespiracion > 5.0f)
            {
                FinalizarMeditacion();
            }
        }
    }

    private void Sentarse()
    {
        GetComponent<Animator>().Play(Constantes.Animacion.Sillon.SENTANDOSE_SILLON);

        if (jugadorGO.TryGetComponent(out MovimientoCont movimientoCont))
        {
            movimientoCont.CambiarEstadoMovimiento(EstadoMovimiento.SentandoseSillon);
        }
    }

    private void ComenzarMeditacion()
    {
        GetComponent<Animator>().Play(Constantes.Animacion.Sillon.QUIETO);

        marAnimator.Play(Constantes.Animacion.Mar.QUIETO);

        FadeOutCasa();
    }

    private void FinalizarMeditacion()
    {
        Levantarse();

        marAnimator.Play(Constantes.Animacion.Mar.IDLE);

        FadeInCasa();

        conversacionInicial = false;
    }

    private void Levantarse()
    {
        GetComponent<Animator>().Play(Constantes.Animacion.Sillon.LEVANTANDOSE_SILLON);

        if (jugadorGO.TryGetComponent(out MovimientoCont movimientoCont))
        {
            movimientoCont.CambiarEstadoMovimiento(EstadoMovimiento.LevantandoseSillon);
        }
    }

    private void FadeOutCasa()
    {
        if (fadeCasa != null)
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

        while (nuevaAlfa > 0.0f)
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
        timerRespiracion = 0.0f;

        gameObject.GetComponent<Animator>().Play(Constantes.Animacion.Sillon.MEDITANDO_INHALAR);

        marAnimator.Play(Constantes.Animacion.Mar.INHALAR);
    }

    private void Exhalar()
    {
        timerRespiracion = 0.0f;

        gameObject.GetComponent<Animator>().Play(Constantes.Animacion.Sillon.MEDITANDO_EXHALAR);

        marAnimator.Play(Constantes.Animacion.Mar.EXHALAR);
    }

    private void InicializarVariables()
    {
        _nombre = Constantes.ObjetosInteractuables.SILLON_NOMBRE;
        _textoAMostrar = Constantes.ObjetosInteractuables.SILLON_TEXTOAMOSTRAR;

        conversacionInicial = false;

        timerRespiracion = 0.0f;
    }

    private void BuscarGO()
    {
        jugadorGO = GameObject.FindGameObjectWithTag(Constantes.Tags.JUGADOR);
        casaGO = GameObject.FindGameObjectWithTag(Constantes.Tags.CASA);
        marAnimator = GameObject.FindGameObjectWithTag(Constantes.Tags.MAR).GetComponent<Animator>();
    }

    private void RecogerInfoInputs()
    {
        InputManager.Instance.controlesJugador.Meditando.Salir.performed += contexto => FinalizarMeditacion();
        InputManager.Instance.controlesJugador.Meditando.Respirar.started += contexto => Inhalar();
        InputManager.Instance.controlesJugador.Meditando.Respirar.canceled += contexto => Exhalar();
    }

    private void SuscribirseEventos()
    {
        GameManager.CambioEstadoJuego += GameManager_CambioEstadoJuego;
    }

    private void GameManager_CambioEstadoJuego(EstadoJuego nuevoEstadoJuego)
    {
        switch (nuevoEstadoJuego)
        {
            case EstadoJuego.SentadoSillon:
                SillonConversacion();
                timerRespiracion = 0.0f;
                break;
            case EstadoJuego.Meditando:
                ComenzarMeditacion();
                break;
            default:
                break;
        }
    }

    private void SillonConversacion()
    {
        if (!conversacionInicial)
        {
            conversacionInicial = true;

            DialogueManager.Instance.IniciarConversacion(Constantes.ObjetosInteractuables.SILLON_CONVERSACION_SENTARSE, null);
        }
        else
        {
            DialogueManager.Instance.IniciarConversacion(Constantes.ObjetosInteractuables.SILLON_CONVERSACION_PARAR_MEDITAR, null);
        }
    }
}