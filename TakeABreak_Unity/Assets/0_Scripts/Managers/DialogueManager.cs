using System;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    // Public fields
    public static DialogueManager Instance;
    public GameObject buttonPrefab;

    public static event Action<bool, InterlocutorEnum> EstaHablando;

    // Private fields
    private GameObject bocadilloGO;
    private Image imagenBocadillo;
    private GameObject nombreConversacionGO;
    private GameObject textoConversacionGO;
    private GameObject flechaGO;
    private TextMeshProUGUI textoNombre;
    private TextMeshProUGUI textoBocadillo;
    private Animator flechaAnimator;
    private GameObject panelOpcionesGO;
    private GameObject jugadorSpriteGO;
    private GameObject interlocutorGO;
    private GameObject interlocutorSpriteGO;

    private BotonEleccion[] listaBotones;
    private int botonSeleccionado;

    private Image imagenJugador;
    private Image imagenNPC;

    private Coroutine mostrarTextoCoroutine;

    private Conversacion conversacionActual;
    private Frase fraseActual;
    private int[] listaOpciones;
    private bool estaEscribiendo;

    [SerializeField] float tiempoEntreletras;

    private void Awake()
    {
        HacerInmortal();

        RecogerInfoInputs();
    }

    private void Start()
    {
        BuscarGO();

        InicializarVariables();
    }

    private IEnumerator TextoLetraPorLetra(string texto)
    {
        textoBocadillo.text = string.Empty;

        estaEscribiendo = true;

        EstaHablando.Invoke(estaEscribiendo, fraseActual.Interlocutor);

        foreach (char letra in texto.ToCharArray())
        {
            textoBocadillo.text += letra;
            yield return new WaitForSeconds(tiempoEntreletras);
        }

        if(fraseActual.SiguienteFrase.Length > 1)
        {
            MostrarEleccion();
        }

        else
        {
            MostrarFlecha();
        }

        estaEscribiendo = false;

        EstaHablando.Invoke(estaEscribiendo, fraseActual.Interlocutor);
    }

    private void MostrarFlecha()
    {
        flechaAnimator.Play(Constantes.Animacion.UI.FLECHA);
    }

    private void OcultarFlecha()
    {
        flechaAnimator.Play(Constantes.Animacion.UI.NADA);
    }

    public void MostrarBocadillo(Frase frase)
    {
        MostrarImagenes(frase.Interlocutor);

        MostrarNombre(frase.Interlocutor);

        MostrarTexto(frase.Texto);
    }

    private void MostrarImagenes(InterlocutorEnum interlocutor)
    {
        imagenBocadillo.enabled = true;

        if (interlocutor == InterlocutorEnum.Jugador)
        {
            imagenJugador.enabled = true;
            imagenNPC.enabled = false;
        }
        else
        {
            imagenJugador.enabled = false;
            imagenNPC.enabled = true;
        }
    }

    private void MostrarNombre(InterlocutorEnum interlocutor)
    {
        switch(interlocutor)
        {
            case InterlocutorEnum.Jugador:
                //textoNombre.color = new Color(68.0f / 255.0f, 112.0f / 255.0f, 76.0f / 255.0f);
                //textoNombre.text = Constantes.Dialogos.NOMBRE_PLAYER;
                break;
            case InterlocutorEnum.Sillon:
                //textoNombre.color = new Color(202.0f / 255.0f, 116.0f / 255.0f, 51.0f / 255.0f);
                //textoNombre.text = Constantes.Dialogos.NOMBRE_SILLON;
                break;
            case InterlocutorEnum.TuMismo:
                //textoNombre.color = new Color(108.0f / 255.0f, 73.0f / 255.0f, 140.0f / 255.0f);
                //textoNombre.text = Constantes.Dialogos.NOMBRE_TUMISMO;
                break;
            default:
                //textoNombre.color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f);
                //textoNombre.text = Constantes.Dialogos.NOMBRE_DEFAULT;
                break;
        }
    }

    private void MostrarTexto(string texto)
    {
        if (mostrarTextoCoroutine != null)
        {
            StopCoroutine(mostrarTextoCoroutine);
        }

        mostrarTextoCoroutine = StartCoroutine(TextoLetraPorLetra(texto));
    }

    public void OcultarBocadillo()
    {
        OcultarImagenes();

        OcultarTexto();
    }

    private void OcultarImagenes()
    {
        imagenJugador.enabled = false;
        imagenNPC.enabled = false;
        imagenBocadillo.enabled = false;
    }

    private void OcultarTexto()
    {
        if (mostrarTextoCoroutine != null)
        {
            StopCoroutine(mostrarTextoCoroutine);
        }

        textoBocadillo.text = string.Empty;
        //textoNombre.text = string.Empty;
    }


    public void IniciarConversacion(GameObject interlocutor, Conversacion conversacion, Sprite sprite, int comienzoConversacion = 0)
    {
        GameManager.Instance.CambiarEstadoJuego(EstadoJuego.Conversando);

        interlocutorGO = interlocutor;

        conversacionActual = conversacion;

        fraseActual = conversacionActual.Frases[comienzoConversacion];

        imagenNPC.sprite = sprite;

        MostrarBocadillo(fraseActual);
    }

    public void FinalizarConversacion(int respuestaDialogo)
    {
        OcultarBocadillo();

        if(interlocutorGO.TryGetComponent(out IObjetoDialogable objetoDialogable))
        {
            objetoDialogable.RespuestaDialogo(respuestaDialogo);
        }

        conversacionActual = null;

        fraseActual = null;

        imagenNPC.sprite = null;
    }

    private void Continuar()
    {
        if (estaEscribiendo == false)
        {
            SiguienteFrase();
        }
    }

    private void SiguienteFrase()
    {
        OcultarFlecha();

        if (fraseActual.SiguienteFrase[0] < 0.0f)
        {
            FinalizarConversacion(fraseActual.SiguienteFrase[0]);
        }
        else
        {
            fraseActual = conversacionActual.Frases[fraseActual.SiguienteFrase[0]];

            MostrarBocadillo(fraseActual);
        }
    }

    private void MostrarEleccion()
    {
        listaOpciones = fraseActual.SiguienteFrase;

        int counter = 0;

        listaBotones = new BotonEleccion[listaOpciones.Count()];

        foreach (int ID in listaOpciones)
        {
            GameObject createdButton = Instantiate(buttonPrefab);

            Frase fraseButton = conversacionActual.Frases[ID];

            createdButton.transform.SetParent(panelOpcionesGO.transform);

            createdButton.GetComponentInChildren<TextMeshProUGUI>().text = fraseButton.Texto;

            if(counter == 0)
            {
                createdButton.GetComponent<Button>().Select();
                botonSeleccionado = 0;
            }

            listaBotones[counter] = new BotonEleccion(createdButton, fraseButton.SiguienteFrase[0]);

            counter++;
        }

        GameManager.Instance.CambiarEstadoJuego(EstadoJuego.Eligiendo);
    }

    private void Presionar()
    {
        if (listaBotones != null)
        {
            SeleccionBoton(listaBotones[botonSeleccionado].SiguienteFrase);
        }
    }

    private void SeleccionArriba()
    {
        if(botonSeleccionado - 1 >= 0)
        {
            botonSeleccionado -= 1;
            listaBotones[botonSeleccionado].Boton.GetComponent<Button>().Select();
        }
    }

    private void SeleccionAbajo()
    {
        if (botonSeleccionado + 1 < listaBotones.Count())
        {
            botonSeleccionado += 1;
            listaBotones[botonSeleccionado].Boton.GetComponent<Button>().Select();
        }
    }

    private void SeleccionBoton(int idSiguienteFrase)
    {
        fraseActual = conversacionActual.Frases[idSiguienteFrase];

        listaOpciones = null;

        foreach (Transform hijo in panelOpcionesGO.transform)
        {
            Destroy(hijo.gameObject);
        }

        botonSeleccionado = 0;

        listaBotones = null;

        GameManager.Instance.CambiarEstadoJuego(EstadoJuego.Conversando);

        MostrarBocadillo(fraseActual);
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

    private void RecogerInfoInputs()
    {
        InputManager.Instance.controlesJugador.Conversando.Continuar.performed += contexto => Continuar();
        InputManager.Instance.controlesJugador.Eligiendo.Presionar.performed += contexto => Presionar();
        InputManager.Instance.controlesJugador.Eligiendo.Arriba.performed += contexto => SeleccionArriba();
        InputManager.Instance.controlesJugador.Eligiendo.Abajo.performed += contexto => SeleccionAbajo();
    }

    private void BuscarGO()
    {
        bocadilloGO = GameObject.FindGameObjectWithTag(Constantes.Tags.BOCADILLO);
        nombreConversacionGO = GameObject.FindGameObjectWithTag(Constantes.Tags.NOMBRE_CONVERSACION);
        textoConversacionGO = GameObject.FindGameObjectWithTag(Constantes.Tags.TEXTO_CONVERSACION);
        flechaGO = GameObject.FindGameObjectWithTag(Constantes.Tags.FLECHA);
        panelOpcionesGO = GameObject.FindGameObjectWithTag(Constantes.Tags.PANEL_OPCIONES);
        jugadorSpriteGO = GameObject.FindGameObjectWithTag(Constantes.Tags.SPRITE_JUGADOR);
        interlocutorSpriteGO = GameObject.FindGameObjectWithTag(Constantes.Tags.SPRITE_NPC);
    }

    private void InicializarVariables()
    {
        //textoNombre = nombreConversacionGO.GetComponentInChildren<TextMeshProUGUI>();
        textoBocadillo = textoConversacionGO.GetComponentInChildren<TextMeshProUGUI>();
        flechaAnimator = flechaGO.GetComponent<Animator>();

        imagenBocadillo = bocadilloGO.GetComponent<Image>();
        imagenBocadillo.enabled = false;

        imagenJugador = jugadorSpriteGO.GetComponent<Image>();
        imagenJugador.enabled = false;

        imagenNPC = interlocutorSpriteGO.GetComponent<Image>();
        imagenNPC.enabled = false;

        conversacionActual = null;
        estaEscribiendo = false;
    }
}
