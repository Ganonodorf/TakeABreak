using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class OI_Banco : MonoBehaviour, IObjetoInteractuable, IObjetoDialogable
{
    private string _nombre;
    private string _textoAMostrar;

    private Sprite _sprite;

    private GameObject jugadorGO;
    private Animator cabezaAnimator;
    private Animator bocaAnimator;
    private SpriteRenderer bocaSpriteRenderer;

    private Animator tuMismoAnimator;
    private Animator cabezaTuMismoAnimator;
    private Animator bocaTuMismoAnimator;
    private SpriteRenderer bocaTuMismoSpriteRenderer;

    private AudioSource pedoAudioSource;

    [SerializeField] private AudioClip pedo;
    [SerializeField] private AudioClip risa;

    public string Nombre { get => _nombre; set => _nombre = value; }
    public string TextoAMostrar { get => _textoAMostrar; set => _textoAMostrar = value; }
    public Sprite Sprite { get => _sprite; set => _sprite = value; }

    void Start()
    {
        InicializarVariables();

        BuscarGO();

        SuscribirseEventos();

        CargarSprite();
    }

    public void RespuestaDialogo(int codigoRespuesta)
    {
        switch (codigoRespuesta)
        {
            case Constantes.Dialogos.FIN_CONVERSACION:
                GameManager.Instance.CambiarEstadoJuego(EstadoJuego.FinJuego);
                break;
            case Constantes.Dialogos.RISA_1:
                EstadoRisa(Constantes.Dialogos.CONVERSACION_FINAL_RETOMAR_RISA_1);
                break;
            case Constantes.Dialogos.RISA_2:
                EstadoRisa(Constantes.Dialogos.CONVERSACION_FINAL_RETOMAR_RISA_2);
                break;
            case Constantes.Dialogos.RISA_3:
                EstadoPedorro();
                break;
            default:
                break;
        }
    }

    private void EstadoRisa(int siguienteFrase)
    {
        GameManager.Instance.CambiarEstadoJuego(EstadoJuego.HaciendoAnimacion);

        PararAnimaciones();

        StartCoroutine(EstadoRisaCoroutine(siguienteFrase));
    }

    private IEnumerator EstadoRisaCoroutine(int siguienteFrase)
    {
        gameObject.GetComponent<Animator>().enabled = true;
        gameObject.GetComponent<Animator>().Play(Constantes.Animacion.Banco.SENTANDO_RIENDO);

        tuMismoAnimator.enabled = true;
        tuMismoAnimator.Play(Constantes.Animacion.TuMismo.RIENDO);

        cabezaAnimator.enabled = true;
        cabezaAnimator.Play(Constantes.Animacion.TuMismo.NADA);
        bocaAnimator.enabled = true;
        bocaAnimator.Play(Constantes.Animacion.TuMismo.NADA);

        cabezaTuMismoAnimator.enabled = true;
        cabezaTuMismoAnimator.Play(Constantes.Animacion.TuMismo.NADA);
        bocaTuMismoAnimator.enabled = true;
        bocaTuMismoAnimator.Play(Constantes.Animacion.TuMismo.NADA);

        pedoAudioSource.PlayOneShot(risa);

        float contadorRiendo = 0.0f;

        while (contadorRiendo < 2.0f)
        {
            contadorRiendo += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        pedoAudioSource.Stop();

        ReanudarAnimaciones();

        DialogueManager.Instance.IniciarConversacion(this.gameObject,
                                                     Constantes.ObjetosInteractuables.CONVERSACION_FINAL,
                                                     _sprite,
                                                     siguienteFrase);
    }

    private void EstadoPedorro()
    {
        GameManager.Instance.CambiarEstadoJuego(EstadoJuego.HaciendoAnimacion);

        PararAnimaciones();

        StartCoroutine(EstadoPedorroCoroutine());
    }

    private IEnumerator EstadoPedorroCoroutine()
    {
        pedoAudioSource.Play();

        while (pedoAudioSource.isPlaying)
        {
            yield return new WaitForFixedUpdate();
        }

        gameObject.GetComponent<Animator>().enabled = true;
        gameObject.GetComponent<Animator>().Play(Constantes.Animacion.Banco.SENTANDO_RIENDO);

        tuMismoAnimator.enabled = true;
        tuMismoAnimator.Play(Constantes.Animacion.TuMismo.RIENDO);

        cabezaAnimator.enabled = true;
        cabezaAnimator.Play(Constantes.Animacion.TuMismo.NADA);
        bocaAnimator.enabled = true;
        bocaAnimator.Play(Constantes.Animacion.TuMismo.NADA);

        cabezaTuMismoAnimator.enabled = true;
        cabezaTuMismoAnimator.Play(Constantes.Animacion.TuMismo.NADA);
        bocaTuMismoAnimator.enabled = true;
        bocaTuMismoAnimator.Play(Constantes.Animacion.TuMismo.NADA);

        pedoAudioSource.PlayOneShot(risa);

        float contadorRiendo = 0.0f;

        while(contadorRiendo < 2.0f)
        {
            contadorRiendo += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        pedoAudioSource.Stop();

        ReanudarAnimaciones();

        DialogueManager.Instance.IniciarConversacion(this.gameObject,
                                                     Constantes.ObjetosInteractuables.CONVERSACION_FINAL,
                                                     _sprite,
                                                     Constantes.Dialogos.CONVERSACION_FINAL_RETOMAR_RISA_3);
    }

    private void PararAnimaciones()
    {
        gameObject.GetComponent<Animator>().enabled = false;
        cabezaAnimator.enabled = false;
        bocaAnimator.enabled = false;

        tuMismoAnimator.enabled = false;
        cabezaTuMismoAnimator.enabled = false;
        bocaTuMismoAnimator.enabled = false;
    }

    private void ReanudarAnimaciones()
    {
        gameObject.GetComponent<Animator>().enabled = true;
        gameObject.GetComponent<Animator>().Play(Constantes.Animacion.Banco.SENTANDO_BANCO_IDLE);

        cabezaAnimator.Play(Constantes.Animacion.Banco.SENTANDO_BANCO_IDLE_CABEZA);

        bocaAnimator.Play(Constantes.Animacion.Banco.SENTANDO_BANCO_IDLE_BOCA);

        tuMismoAnimator.Play(Constantes.Animacion.TuMismo.IDLE);

        cabezaTuMismoAnimator.Play(Constantes.Animacion.TuMismo.IDLE_CABEZA);

        bocaTuMismoAnimator.Play(Constantes.Animacion.TuMismo.IDLE_BOCA);
    }

    public void Accion()
    {
        Sentarse();
    }

    private void Sentarse()
    {
        GetComponent<Animator>().Play(Constantes.Animacion.Banco.SENTANDOSE_BANCO);

        if (jugadorGO.TryGetComponent(out MovimientoCont movimientoCont))
        {
            movimientoCont.CambiarEstadoMovimiento(EstadoMovimiento.SentandoseBanco);
        }
    }

    private void FinSentarse()
    {
        BancoConversacion();

        IniciarAnimaciones();
    }

    private void BancoConversacion()
    {
        DialogueManager.Instance.IniciarConversacion(this.gameObject, Constantes.ObjetosInteractuables.CONVERSACION_FINAL, _sprite);

        MusicManager.Instance.ActivarGuitarra();
    }

    private void DialogueManager_EstaEscribiendo(bool estaEscribiendo, InterlocutorEnum interlocutor)
    {
        if (estaEscribiendo && interlocutor == InterlocutorEnum.Jugador)
        {
            bocaSpriteRenderer.color = new Color(bocaSpriteRenderer.color.r,
                                                 bocaSpriteRenderer.color.g,
                                                 bocaSpriteRenderer.color.b,
                                                 1.0f);
        }
        else if(!estaEscribiendo && interlocutor == InterlocutorEnum.Jugador)
        {
            bocaSpriteRenderer.color = new Color(bocaSpriteRenderer.color.r,
                                                 bocaSpriteRenderer.color.g,
                                                 bocaSpriteRenderer.color.b,
                                                 0.0f);
        }
        else if (estaEscribiendo && interlocutor == InterlocutorEnum.TuMismo)
        {
            bocaTuMismoSpriteRenderer.color = new Color(bocaTuMismoSpriteRenderer.color.r,
                                                        bocaTuMismoSpriteRenderer.color.g,
                                                        bocaTuMismoSpriteRenderer.color.b,
                                                        1.0f);
        }
        else if(!estaEscribiendo && interlocutor == InterlocutorEnum.TuMismo)
        {
            bocaTuMismoSpriteRenderer.color = new Color(bocaTuMismoSpriteRenderer.color.r,
                                                        bocaTuMismoSpriteRenderer.color.g,
                                                        bocaTuMismoSpriteRenderer.color.b,
                                                        0.0f);
        }
        else
        {
            bocaSpriteRenderer.color = new Color(bocaSpriteRenderer.color.r,
                                                 bocaSpriteRenderer.color.g,
                                                 bocaSpriteRenderer.color.b,
                                                 0.0f);

            bocaTuMismoSpriteRenderer.color = new Color(bocaTuMismoSpriteRenderer.color.r,
                                                        bocaTuMismoSpriteRenderer.color.g,
                                                        bocaTuMismoSpriteRenderer.color.b,
                                                        0.0f);
        }
    }

    private void IniciarAnimaciones()
    {
        gameObject.GetComponent<Animator>().Play(Constantes.Animacion.Banco.SENTANDO_BANCO_IDLE);
        cabezaAnimator.Play(Constantes.Animacion.Banco.SENTANDO_BANCO_IDLE_CABEZA);
        bocaSpriteRenderer.color = new Color(bocaSpriteRenderer.color.r,
                                             bocaSpriteRenderer.color.g,
                                             bocaSpriteRenderer.color.b,
                                             0.0f);
        bocaAnimator.Play(Constantes.Animacion.Banco.SENTANDO_BANCO_IDLE_BOCA);
    }

    private void InicializarVariables()
    {
        _nombre = Constantes.ObjetosInteractuables.BANCO_NOMBRE;
        _textoAMostrar = Constantes.ObjetosInteractuables.BANCO_TEXTOAMOSTRAR;

        pedoAudioSource = gameObject.GetComponent<AudioSource>();
    }

    private void BuscarGO()
    {
        jugadorGO = GameObject.FindGameObjectWithTag(Constantes.Tags.JUGADOR);
        cabezaAnimator = GameObject.FindGameObjectWithTag(Constantes.Tags.CABEZA).GetComponent<Animator>();
        bocaAnimator = GameObject.FindGameObjectWithTag(Constantes.Tags.BOCA).GetComponent<Animator>();
        bocaSpriteRenderer = bocaAnimator.GetComponent<SpriteRenderer>();

        tuMismoAnimator = GameObject.FindGameObjectWithTag(Constantes.Tags.TUMISMO).GetComponent<Animator>();
        cabezaTuMismoAnimator = GameObject.FindGameObjectWithTag(Constantes.Tags.CABEZA_TUMISMO).GetComponent<Animator>();
        bocaTuMismoAnimator = GameObject.FindGameObjectWithTag(Constantes.Tags.BOCA_TUMISMO).GetComponent<Animator>();
        bocaTuMismoSpriteRenderer = GameObject.FindGameObjectWithTag(Constantes.Tags.BOCA_TUMISMO).GetComponent<SpriteRenderer>();
    }

    private void SuscribirseEventos()
    {
        DialogueManager.EstaHablando += DialogueManager_EstaEscribiendo;
    }

    private void CargarSprite()
    {
        AsyncOperationHandle<Sprite> cargadoSpritenAsync = Addressables.LoadAssetAsync<Sprite>(Constantes.ObjetosInteractuables.TU_MISMO_PATH_SPRITE);
        cargadoSpritenAsync.Completed += CargaSpriteCuandoAcabes;
    }

    void CargaSpriteCuandoAcabes(AsyncOperationHandle<Sprite> handleToCheck)
    {
        if (handleToCheck.Status == AsyncOperationStatus.Succeeded)
        {
            _sprite = handleToCheck.Result;
        }
    }
}
