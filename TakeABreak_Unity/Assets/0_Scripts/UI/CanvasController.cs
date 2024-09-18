using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    private GameObject CanvasIntro;
    private GameObject CanvasTitulo;
    private GameObject CanvasFinJuego;
    private GameObject CanvasPausa;

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
                CargarIntro();
                break;
            case EstadoJuego.Titulo:
                CargarTitulo();
                break;
            case EstadoJuego.FinJuego:
                CargarFinJuego();
                break;
            case EstadoJuego.Pausa:
                CargarPausa();
                break;
            default:
                break;
        }
    }

    private void CargarFinJuego()
    {
        OcultarMenu(CanvasIntro);

        OcultarMenu(CanvasTitulo);

        FadeInMenu(CanvasFinJuego);
    }

    private void CargarTitulo()
    {
        OcultarMenu(CanvasIntro);

        OcultarMenu(CanvasFinJuego);

        FadeInMenu(CanvasTitulo);
    }

    private void CargarIntro()
    {
        OcultarMenu(CanvasTitulo);

        OcultarMenu(CanvasFinJuego);

        Image imagen = CanvasIntro.GetComponent<Image>();
        imagen.color = new Color(imagen.color.r, imagen.color.g, imagen.color.b, 1.0f);

        CanvasIntro.GetComponent<Animator>().Play(Constantes.Animacion.UI.INTRO);
    }
    
    private void CargarPausa()
    {
        FadeInMenu(CanvasPausa);
    }


    private void OcultarMenu(GameObject menuAOcultar)
    {
        Image[] imagenes = menuAOcultar.GetComponentsInChildren<Image>();
        TextMeshProUGUI[] textos = menuAOcultar.GetComponentsInChildren<TextMeshProUGUI>();
        Button[] botones = menuAOcultar.GetComponentsInChildren<Button>();

        foreach (Image image in imagenes)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.0f);
        }

        foreach (TextMeshProUGUI texto in textos)
        {
            texto.color = new Color(texto.color.r, texto.color.g, texto.color.b, 0.0f);
        }

        foreach(Button boton in botones)
        {
            boton.enabled = false;
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
        listaBotones = null;
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
        TextMeshProUGUI[] textos = menuACargar.GetComponentsInChildren<TextMeshProUGUI>();
        listaBotones = menuACargar.GetComponentsInChildren<Button>();

        float alfa = 0.0f;

        while (alfa < 1.0f)
        {
            alfa += 0.05f;

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

        foreach (Button boton in listaBotones)
        {
            boton.enabled = true;
        }

        botonSeleccionado = 0;

        listaBotones[botonSeleccionado].Select();
    }

    private void PresionarTitulo()
    {
        switch (botonSeleccionado)
        {
            case 0:
                OcultarMenu(CanvasTitulo);
                GameManager.Instance.CambiarEstadoJuego(EstadoJuego.Inicio);
                break;
            case 1:
                BotonSalir();
                break;
            default:
                break;
        }
    }

    private void PresionarFinJuego()
    {
        switch (botonSeleccionado)
        {
            case 0:
                GameManager.Instance.CambiarEstadoJuego(EstadoJuego.Titulo);
                break;
            case 1:
                BotonSalir();
                break;
            default:
                break;
        }
    }

    private void PresionarPausa()
    {
        switch (botonSeleccionado)
        {
            case 0:
                OcultarMenu(CanvasPausa);
                GameManager.Instance.CambiarEstadoJuego(EstadoJuego.Andando);
                break;
            case 1:
                OcultarMenu(CanvasPausa);
                GameManager.Instance.CambiarEstadoJuego(EstadoJuego.Titulo);
                break;
            case 2:
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

    private void BotonSalir()
    {
        Application.Quit();
    }

    private void BuscarGO()
    {
        CanvasIntro = GameObject.FindGameObjectWithTag(Constantes.Tags.INTRO);
        CanvasTitulo = GameObject.FindGameObjectWithTag(Constantes.Tags.TITULO);
        CanvasFinJuego = GameObject.FindGameObjectWithTag(Constantes.Tags.FINJUEGO);
        CanvasPausa = GameObject.FindGameObjectWithTag(Constantes.Tags.PAUSA);
    }

    private void RecogerInfoInputs()
    {
        InputManager.Instance.controlesJugador.Titulo.Presionar.performed += contexto => PresionarTitulo();
        InputManager.Instance.controlesJugador.Titulo.Arriba.performed += contexto => SeleccionArriba();
        InputManager.Instance.controlesJugador.Titulo.Abajo.performed += contexto => SeleccionAbajo();
        InputManager.Instance.controlesJugador.FinJuego.Presionar.performed += contexto => PresionarFinJuego();
        InputManager.Instance.controlesJugador.FinJuego.Arriba.performed += contexto => SeleccionArriba();
        InputManager.Instance.controlesJugador.FinJuego.Abajo.performed += contexto => SeleccionAbajo();
        InputManager.Instance.controlesJugador.Pausa.Presionar.performed += contexto => PresionarPausa();
        InputManager.Instance.controlesJugador.Pausa.Arriba.performed += contexto => SeleccionArriba();
        InputManager.Instance.controlesJugador.Pausa.Abajo.performed += contexto => SeleccionAbajo();
    }

    private void SuscribirseEventos()
    {
        GameManager.CambioEstadoJuego += GameManager_CambioEstadoJuego;
    }
}
