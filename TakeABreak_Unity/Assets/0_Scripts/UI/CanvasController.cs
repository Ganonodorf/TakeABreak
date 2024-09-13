using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    private GameObject CanvasIntro;
    private GameObject CanvasTitulo;
    private GameObject CanvasFinJuego;

    private Button[] listaBotones;
    private int botonSeleccionado;

    private Coroutine fadeCoroutine;

    void Start()
    {
        BuscarGO();

        RecogerInfoInputs();

        SuscribirseEventos();
    }

    private void GameManager_CambioEstadoJuego(EstadoJuego nuevoEstadoJuego)
    {
        switch (nuevoEstadoJuego)
        {
            case EstadoJuego.Intro:
                OcultarMenu(CanvasTitulo);
                OcultarMenu(CanvasFinJuego);
                CargarIntro();
                break;
            case EstadoJuego.Titulo:
                OcultarMenu(CanvasIntro);
                OcultarMenu(CanvasFinJuego);
                CargarMenu(CanvasTitulo);
                break;
            case EstadoJuego.FinJuego:
                OcultarMenu(CanvasIntro);
                OcultarMenu(CanvasTitulo);
                CargarMenu(CanvasFinJuego);
                break;
            default:
                break;
        }
    }

    private void CargarIntro()
    {
        Image imagen = CanvasIntro.GetComponent<Image>();
        imagen.color = new Color(imagen.color.r, imagen.color.g, imagen.color.b, 1.0f);

        CanvasIntro.GetComponent<Animator>().Play(Constantes.Animacion.UI.INTRO);
    }

    private void CargarMenu(GameObject menuACargar)
    {
        botonSeleccionado = 0;

        listaBotones = menuACargar.GetComponentsInChildren<Button>();

        listaBotones[botonSeleccionado].Select();

        Image[] imagenes = menuACargar.GetComponentsInChildren<Image>();
        TextMeshProUGUI[] textos = menuACargar.GetComponentsInChildren<TextMeshProUGUI>();

        foreach (Image image in imagenes)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1.0f);
        }

        foreach (TextMeshProUGUI texto in textos)
        {
            texto.color = new Color(texto.color.r, texto.color.g, texto.color.b, 1.0f);
        }
    }

    private void OcultarMenu(GameObject menuAOcultar)
    {
        Image[] imagenes = menuAOcultar.GetComponentsInChildren<Image>();
        TextMeshProUGUI[] textos = menuAOcultar.GetComponentsInChildren<TextMeshProUGUI>();

        foreach (Image image in imagenes)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.0f);
        }

        foreach (TextMeshProUGUI texto in textos)
        {
            texto.color = new Color(texto.color.r, texto.color.g, texto.color.b, 0.0f);
        }
    }

    private void FadeOutMenu(GameObject menuADescargar)
    {
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }

        fadeCoroutine = StartCoroutine(FadeOutCoroutine(menuADescargar));
    }

    private IEnumerator FadeOutCoroutine(GameObject menuADescargar)
    {
        Image[] imagenes = menuADescargar.GetComponentsInChildren<Image>();
        TextMeshProUGUI[] textos = menuADescargar.GetComponentsInChildren<TextMeshProUGUI>();
        float alfa = 1.0f;

        while (alfa > 0.0f)
        {
            alfa -= 0.05f;

            foreach (Image image in imagenes)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, alfa);
            }

            foreach (TextMeshProUGUI texto in textos)
            {
                texto.color = new Color(texto.color.r, texto.color.g, texto.color.b, alfa);
            }

            yield return new WaitForFixedUpdate();
        }
    }

    private void FadeInMenu(GameObject menuACargar)
    {
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }

        fadeCoroutine = StartCoroutine(FadeInCoroutine(menuACargar));
    }

    private IEnumerator FadeInCoroutine(GameObject menuACargar)
    {
        Image[] imagenes = menuACargar.GetComponentsInChildren<Image>();
        TextMeshPro[] textos = menuACargar.GetComponentsInChildren<TextMeshPro>();
        float alfa = 0.0f;

        while (alfa < 1.0f)
        {
            alfa += 0.05f;

            foreach (Image image in imagenes)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, alfa);
            }

            foreach (TextMeshPro texto in textos)
            {
                texto.color = new Color(texto.color.r, texto.color.g, texto.color.b, alfa);
            }

            yield return new WaitForFixedUpdate();
        }
    }

    private void Presionar()
    {
        switch (botonSeleccionado)
        {
            case 0:
                BotonPrimero();
                break;
            case 1:
                BotonSalir();
                break;
            default:
                break;
        }
    }

    private void SeleccionArriba()
    {
        if (botonSeleccionado - 1 >= 0)
        {
            botonSeleccionado -= 1;
            listaBotones[botonSeleccionado].Select();
        }
    }

    private void SeleccionAbajo()
    {
        if (botonSeleccionado + 1 < listaBotones.Length)
        {
            botonSeleccionado += 1;
            listaBotones[botonSeleccionado].Select();
        }
    }

    private void BotonPrimero()
    {
        if(GameManager.Instance.GetEstadoJuego() == EstadoJuego.Titulo)
        {
            FadeOutMenu(CanvasTitulo);
            GameManager.Instance.CambiarEstadoJuego(EstadoJuego.Inicio);
        }
        else
        {
            GameManager.Instance.CambiarEstadoJuego(EstadoJuego.Titulo);
        }
    }

    private void BotonSalir()
    {
        Application.Quit();
    }

    private void BuscarGO()
    {
        CanvasIntro = GameObject.FindGameObjectWithTag(Constantes.Tags.INTRO);
        CanvasTitulo = GameObject.FindGameObjectWithTag(Constantes.Tags.TITULO);
        CanvasFinJuego = GameObject.FindGameObjectWithTag(Constantes.Tags.FINJUEGO);
    }

    private void RecogerInfoInputs()
    {
        InputManager.Instance.controlesJugador.Titulo.Presionar.performed += contexto => Presionar();
        InputManager.Instance.controlesJugador.Titulo.Arriba.performed += contexto => SeleccionArriba();
        InputManager.Instance.controlesJugador.Titulo.Abajo.performed += contexto => SeleccionAbajo();
        InputManager.Instance.controlesJugador.FinJuego.Presionar.performed += contexto => Presionar();
        InputManager.Instance.controlesJugador.FinJuego.Arriba.performed += contexto => SeleccionArriba();
        InputManager.Instance.controlesJugador.FinJuego.Abajo.performed += contexto => SeleccionAbajo();
    }

    private void SuscribirseEventos()
    {
        GameManager.CambioEstadoJuego += GameManager_CambioEstadoJuego;
    }
}
