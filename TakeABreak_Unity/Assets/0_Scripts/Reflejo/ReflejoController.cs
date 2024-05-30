using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflejoController : MonoBehaviour
{
    private GameObject jugadorGO;

    private Animator animator;

    private bool reflejandose;

    // Start is called before the first frame update
    void Start()
    {
        InicializarVariables();

        BuscarGO();

        SuscribirseEventos();
    }

    private void Update()
    {
        if (reflejandose == false && jugadorGO.transform.position.x >= 200.0f && jugadorGO.transform.position.x <= 300.0f)
        {
            reflejandose = true;
            transform.position = new Vector3(jugadorGO.transform.position.x - Constantes.PosicionesClave.DistanciaReflejo,
                                             transform.position.y,
                                             transform.position.z);
        }
        else if (reflejandose == true && (jugadorGO.transform.position.x < 200.0f || jugadorGO.transform.position.x > 300.0f))
        {
            reflejandose = false;
        }
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

    public void MovimientoHorizontal(float cantidadMovimiento)
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x + cantidadMovimiento,
                                                    gameObject.transform.position.y);
    }

    private void InicializarVariables()
    {
        animator = transform.GetComponent<Animator>();
    }

    private void BuscarGO()
    {
        jugadorGO = GameObject.FindGameObjectWithTag(Constantes.Tags.JUGADOR);
    }

    private void SuscribirseEventos()
    {
        MovimientoCont.OnMovimientoChanged += MovimientoCont_OnMovimientoChanged;
    }
}
