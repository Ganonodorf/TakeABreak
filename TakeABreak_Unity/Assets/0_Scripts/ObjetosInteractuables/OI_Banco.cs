using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class OI_Banco : MonoBehaviour, IObjetoInteractuable, IObjetoDialogable
{
    private string _nombre;
    private string _textoAMostrar;

    private Sprite _sprite;

    private GameObject jugadorGO;

    public string Nombre { get => _nombre; set => _nombre = value; }
    public string TextoAMostrar { get => _textoAMostrar; set => _textoAMostrar = value; }
    public Sprite Sprite { get => _sprite; set => _sprite = value; }

    void Start()
    {
        InicializarVariables();

        BuscarGO();

        CargarSprite();
    }


    public void RespuestaDialogo(int codigoRespuesta)
    {
        if (codigoRespuesta == Constantes.Dialogos.FIN_CONVERSACION)
        {
            GameManager.Instance.CambiarEstadoJuego(EstadoJuego.FinJuego);
        }
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
    }

    private void BancoConversacion()
    {
        DialogueManager.Instance.IniciarConversacion(this.gameObject, Constantes.ObjetosInteractuables.CONVERSACION_FINAL, _sprite);
    }

    private void InicializarVariables()
    {
        _nombre = Constantes.ObjetosInteractuables.BANCO_NOMBRE;
        _textoAMostrar = Constantes.ObjetosInteractuables.BANCO_TEXTOAMOSTRAR;
    }

    private void BuscarGO()
    {
        jugadorGO = GameObject.FindGameObjectWithTag(Constantes.Tags.JUGADOR);
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
