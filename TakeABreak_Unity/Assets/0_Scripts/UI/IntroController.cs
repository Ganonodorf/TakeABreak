using UnityEngine;

public class IntroController : MonoBehaviour
{
    private void InicioAnimacionIntro()
    {
        GetComponent<AudioSource>().Play();
    }
    private void FinAnimacionIntro()
    {
        GameManager.Instance.CambiarEstadoJuego(EstadoJuego.Titulo);
    }
}
