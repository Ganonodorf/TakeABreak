using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private GameObject musica;
    private GameObject viento;

    public static MusicManager Instance;

    private void Awake()
    {
        HacerInmortal();
    }
    // Start is called before the first frame update
    void Start()
    {
        BuscarGO();

        SuscribirseEventos();
    }

    private void GameManager_CambioEstadoJuego(EstadoJuego nuevoEstadoJuego)
    {
        switch (nuevoEstadoJuego)
        {
            case EstadoJuego.Intro:
                DescargarMusica();
                break;
            case EstadoJuego.Inicio:
                CargarMusica();
                break;
            default:
                break;
        }
    }

    private void CargarMusica()
    {
        musica.GetComponent<AudioSource>().enabled = true;
        viento.GetComponent<AudioSource>().enabled = true;
    }

    private void DescargarMusica()
    {
        musica.GetComponent<AudioSource>().enabled = false;
        viento.GetComponent<AudioSource>().enabled = false;
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
        musica = GameObject.FindWithTag(Constantes.Tags.MUSICA);
        viento = GameObject.FindWithTag(Constantes.Tags.VIENTO);
    }

    private void SuscribirseEventos()
    {
        GameManager.CambioEstadoJuego += GameManager_CambioEstadoJuego;
    }
}
