using UnityEngine;

public class AnimacionCont : MonoBehaviour
{
    private Animator animator;

    private string animacionActual;

    private void Awake()
    {
        MovimientoCont.OnMovimientoChanged += MovimientoCont_OnMovimientoChanted;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animacionActual = Constantes.Jugador.Animacion.IDLE_ALANTE;
    }

    private void MovimientoCont_OnMovimientoChanted(EstadoMovimiento nuevoEstadoMovimiento)
    {
        string animacionNueva;

        switch (nuevoEstadoMovimiento)
        {
            case EstadoMovimiento.Idle_Alante:
                animacionNueva = Constantes.Jugador.Animacion.IDLE_ALANTE;
                break;
            case EstadoMovimiento.Idle_Atras:
                animacionNueva = Constantes.Jugador.Animacion.IDLE_ATRAS;
                break;
            case EstadoMovimiento.AndandoAlante:
                animacionNueva = Constantes.Jugador.Animacion.ANDANDO_ALANTE;
                break;
            case EstadoMovimiento.AndandoAtras:
                animacionNueva = Constantes.Jugador.Animacion.ANDANDO_ATRAS;
                break;
            default:
                animacionNueva = Constantes.Jugador.Animacion.IDLE_ALANTE;
                break;
        }

        if(animacionNueva != animacionActual)
        {
            animator.Play(animacionNueva);
            animacionActual = animacionNueva;
        }
    }
}
