using System.Collections;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    // Public fields
    public static DialogueManager Instance;
    public GameObject buttonPrefab;

    // Private fields
    private GameObject bocadilloGO;
    private Image imagenBocadillo;
    private TextMeshProUGUI textoBocadillo;
    private GameObject panelOpcionesGO;
    private GameObject jugadorSpriteGO;
    private GameObject npcSpriteGO;
    private GameObject jugadorGO;

    private Image imagenJugador;
    private Image imagenNPC;

    private Coroutine mostrarTextoCoroutine;

    private float tiempoEntreLetras = 0.05f;

    private Conversacion conversacionActual;
    private Frase fraseActual;
    private int[] listaOpciones;
    private bool estaEscribiendo;

    private void Awake()
    {
        HacerInmortal();

        InputManager.Instance.controlesJugador.Conversando.Continuar.performed += contexto => Continuar();
    }

    private void Continuar()
    {
        if (estaEscribiendo == false)
        {
            SiguienteFrase();
        }
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

        foreach (char letra in texto.ToCharArray())
        {
            textoBocadillo.text += letra;
            yield return new WaitForSeconds(tiempoEntreLetras);
        }

        if(fraseActual.SiguienteFrase.Length > 1)
        {
            MostrarEleccion();
        }

        estaEscribiendo = false;
    }

    public void MostrarBocadillo(Frase frase)
    {
        MostrarImagenes(frase.Interlocutor);

        MostrarTexto(frase.Texto);
    }

    private void MostrarImagenes(InterlocutorEnum interlocutor)
    {
        imagenBocadillo.enabled = true;

        if (interlocutor == InterlocutorEnum.NPC)
        {
            imagenJugador.enabled = false;
            imagenNPC.enabled = true;
        }
        else
        {
            imagenJugador.enabled = true;
            imagenNPC.enabled = false;
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
    }


    public void IniciarConversacion(Conversacion conversacion, Sprite sprite)
    {
        GameManager.Instance.CambiarEstadoJuego(EstadoJuego.Conversando);

        conversacionActual = conversacion;

        fraseActual = conversacionActual.Frases[0];

        imagenNPC.sprite = sprite;

        MostrarBocadillo(fraseActual);
    }

    public void FinalizarConversacion()
    {
        OcultarBocadillo();

        conversacionActual = null;
        fraseActual = null;
        imagenNPC.sprite = null;
    }

    private void SiguienteFrase()
    {
        // Si hay un fin de conversación, se acaba
        if (fraseActual.SiguienteFrase.Contains(Constantes.Dialogos.FIN_CONVERSACION))
        {
            FinalizarConversacion();

            GameManager.Instance.CambiarEstadoJuego(EstadoJuego.Andando);
        }
        else if (fraseActual.SiguienteFrase.Contains(Constantes.Dialogos.SILLON_MEDITAR))
        {
            FinalizarConversacion();

            GameManager.Instance.CambiarEstadoJuego(EstadoJuego.Meditando);

            jugadorGO.GetComponent<MovimientoCont>().CambiarEstadoMovimiento(EstadoMovimiento.Meditando);
        }
        else if (fraseActual.SiguienteFrase.Contains(Constantes.Dialogos.SILLON_LEVANTARSE))
        {
            FinalizarConversacion();

            jugadorGO.GetComponent<MovimientoCont>().CambiarEstadoMovimiento(EstadoMovimiento.LevantandoseSillon);
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

        foreach (int ID in listaOpciones)
        {
            GameObject createdButton = Instantiate(buttonPrefab);

            Frase fraseButton = conversacionActual.Frases[ID];

            createdButton.transform.SetParent(panelOpcionesGO.transform);

            createdButton.transform.localPosition = new Vector3(0.0f,
                                                                22.0f - counter * Constantes.Dialogos.DISTANCIA_BOTONES,
                                                                0.0f);

            createdButton.GetComponentInChildren<TextMeshProUGUI>().text = fraseButton.Texto;

            createdButton.GetComponent<Button>().onClick.AddListener(delegate { SeleccionBoton(fraseButton.SiguienteFrase[0]); }) ;

            GameManager.Instance.CambiarEstadoJuego(EstadoJuego.Eligiendo);

            counter++;
        }
    }

    private void SeleccionBoton(int idSiguienteFrase)
    {
        GameManager.Instance.CambiarEstadoJuego(EstadoJuego.Conversando);

        fraseActual = conversacionActual.Frases[idSiguienteFrase];

        listaOpciones = null;

        foreach (Transform hijo in panelOpcionesGO.transform)
        {
            Destroy(hijo.gameObject);
        }

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

    private void BuscarGO()
    {
        bocadilloGO = GameObject.FindGameObjectWithTag(Constantes.Tags.BOCADILLO);
        panelOpcionesGO = GameObject.FindGameObjectWithTag(Constantes.Tags.PANEL_OPCIONES);
        jugadorSpriteGO = GameObject.FindGameObjectWithTag(Constantes.Tags.SPRITE_JUGADOR);
        npcSpriteGO = GameObject.FindGameObjectWithTag(Constantes.Tags.SPRITE_NPC);
        jugadorGO = GameObject.FindGameObjectWithTag(Constantes.Tags.JUGADOR);
    }

    private void InicializarVariables()
    {
        textoBocadillo = bocadilloGO.GetComponentInChildren<TextMeshProUGUI>();
        imagenBocadillo = bocadilloGO.GetComponent<Image>();
        imagenBocadillo.enabled = false;

        imagenJugador = jugadorSpriteGO.GetComponent<Image>();
        imagenJugador.enabled = false;

        imagenNPC = npcSpriteGO.GetComponent<Image>();
        imagenNPC.enabled = false;

        conversacionActual = null;
        estaEscribiendo = false;
    }
}
