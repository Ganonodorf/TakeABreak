using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflejoController : MonoBehaviour
{
    private SpriteRenderer spriteRendererJugador;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        InicializarVariables();

        BuscarGO();

        SuscribirseEventos();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(spriteRendererJugador.transform.position.x - 11.0f,
                                         transform.position.y,
                                         transform.position.z);
        transform.GetComponent<SpriteRenderer>().sprite = spriteRendererJugador.sprite;
    }
    private void MovimientoCont_OnMovimientoChanged(EstadoMovimiento nuevoEstadoMovimiento)
    {
        switch (nuevoEstadoMovimiento)
        {
            case EstadoMovimiento.IdleAlante:
                IdleAlante();
                break;
            case EstadoMovimiento.IdleAtras:
                IdleAtras();
                break;
            case EstadoMovimiento.AndandoAlante:
                AndandoAlante();
                break;
            case EstadoMovimiento.AndandoAtras:
                AndandoAtras();
                break;
            default:
                Nada();
                break;
        }
    }

    private void IdleAlante()
    {
        animator.Play(Constantes.Animacion.Reflejo.IDLE_ESPALDAS_ALANTE);
    }

    private void IdleAtras()
    {
        animator.Play(Constantes.Animacion.Reflejo.IDLE_ESPALDAS_ATRAS);
    }

    private void AndandoAlante()
    {
        animator.Play(Constantes.Animacion.Reflejo.ANDANDO_ESPALDAS_ALANTE);
    }

    private void AndandoAtras()
    {
        animator.Play(Constantes.Animacion.Reflejo.ANDANDO_ESPALDAS_ATRAS);
    }

    private void Nada()
    {
        animator.Play(Constantes.Animacion.Reflejo.NADA);
    }

    private void InicializarVariables()
    {
        animator = transform.GetComponent<Animator>();
    }

    private void BuscarGO()
    {
        spriteRendererJugador = GameObject.FindGameObjectWithTag(Constantes.Tags.JUGADOR).GetComponent<SpriteRenderer>();
    }

    private void SuscribirseEventos()
    {
        MovimientoCont.OnMovimientoChanged += MovimientoCont_OnMovimientoChanged;
    }
}
