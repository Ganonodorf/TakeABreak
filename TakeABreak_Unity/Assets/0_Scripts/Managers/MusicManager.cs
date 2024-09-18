using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource musica;
    private AudioSource guitarra;
    private AudioSource viento;

    public static MusicManager Instance;

    private void Awake()
    {
        HacerInmortal();
    }

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
            case EstadoJuego.Titulo:
                DescargarMusica();
                break;
            case EstadoJuego.Inicio:
                CargarMusica();
                break;
            case EstadoJuego.Pausa:
                PausarMusica();
                break;
            case EstadoJuego.Andando:
                ReanudarMusica();
                break;
            default:
                break;
        }
    }

    private void CargarMusica()
    {
        musica.enabled = true;
        guitarra.enabled = true;
        viento.enabled = true;
    }

    private void DescargarMusica()
    {
        musica.enabled = false;
        guitarra.volume = 0.0f;
        guitarra.enabled = false;
        viento.enabled = false;
    }

    private void PausarMusica()
    {
        musica.Pause();
        guitarra.Pause();
        viento.Pause();
    }

    private void ReanudarMusica()
    {
        if (!musica.isPlaying)
        {
            musica.Play();
            guitarra.Play();
            viento.Play();
        }
    }

    public void ActivarGuitarra()
    {
        guitarra.volume = 1.0f;
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
        musica = GameObject.FindWithTag(Constantes.Tags.MUSICA).GetComponent<AudioSource>();
        guitarra = GameObject.FindWithTag(Constantes.Tags.GUITARRA).GetComponent<AudioSource>();
        viento = GameObject.FindWithTag(Constantes.Tags.VIENTO).GetComponent<AudioSource>();
    }

    private void SuscribirseEventos()
    {
        GameManager.CambioEstadoJuego += GameManager_CambioEstadoJuego;
    }
}
