using System;
using TMPro;
using UnityEngine;

public class InteractuableCont : MonoBehaviour
{
    private GameObject _objetoInteractuableGO;
    private IObjetoInteractuable _objetoInteractuable;

    private Animator exclamacionAnimator;
    private SpriteRenderer exclamacionSpriteRenderer;

    private void Awake()
    {
        MovimientoCont.OnMirandoDerechaChanged += MovimientoCont_OnMirandoDerechaChanged;

        GameManager.CambioEstadoJuego += GameManager_CambioEstadoJuego;
    }

    private void Start()
    {
        InicializarVariables(); 

        RecogerInfoInputs();
    }

    private void MovimientoCont_OnMirandoDerechaChanged(bool mirandoDerecha)
    {
        exclamacionAnimator.transform.localPosition = mirandoDerecha ? Constantes.PosicionesClave.PosDerechaExclamacion :
                                                                       Constantes.PosicionesClave.PosIzquierdaExclamacion;
    }

    private void GameManager_CambioEstadoJuego(EstadoJuego nuevoEstadoJuego)
    {
        if (nuevoEstadoJuego == EstadoJuego.Andando)
        {
            MostrarAccionV2();
        }

        if (nuevoEstadoJuego == EstadoJuego.HaciendoAnimacion)
        {
            OcultarAccionV2();
        }
    }

    private void EjecutarAccion()
    {
        if (_objetoInteractuable != null)
        {
            OcultarAccionV2();

            _objetoInteractuable.Accion();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IObjetoInteractuable objetoInteractuable))
        {
            _objetoInteractuableGO = collision.gameObject;
            _objetoInteractuable = objetoInteractuable;

            MostrarAccionV2();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IObjetoInteractuable objetoInteractuable))
        {
            OcultarAccionV2();

            _objetoInteractuableGO = null;
            _objetoInteractuable = null;
        }
    }

    private void MostrarAccionV2()
    {
        if(_objetoInteractuable != null && GameManager.Instance.GetEstadoJuego() == EstadoJuego.Andando)
        {
            exclamacionSpriteRenderer.enabled = true;
            exclamacionAnimator.Play(Constantes.Animacion.ObjetosInteractuables.EXCLAMACION);
        }
    }

    private void OcultarAccionV2()
    {
        exclamacionSpriteRenderer.enabled = false;
        exclamacionAnimator.Play(Constantes.Animacion.ObjetosInteractuables.NADA);
    }

    private void MostrarAccion(GameObject objetoInteractuableGO, IObjetoInteractuable objetoInteractuable)
    {
        foreach(Transform child in objetoInteractuableGO.transform)
        {
            if(child.tag == Constantes.Tags.BOCADILLO_ACCION)
            {
                MostrarOcultarBocadillo(child, true, objetoInteractuable.TextoAMostrar);
                return;
            }
        }
    }

    private void OcultarAccion(GameObject objetoInteractuableGO)
    {
        if(objetoInteractuableGO != null)
        {
            foreach (Transform child in objetoInteractuableGO.transform)
            {
                if (child.tag == Constantes.Tags.BOCADILLO_ACCION)
                {
                    MostrarOcultarBocadillo(child, false, string.Empty);
                    return;
                }
            }
        }
    }

    private void MostrarOcultarBocadillo(Transform bocadilloAccion, bool estado, string texto)
    {
        bocadilloAccion.GetComponent<SpriteRenderer>().enabled = estado;
        bocadilloAccion.GetComponentInChildren<TextMeshPro>().text = texto;
    }

    private void InicializarVariables()
    {
        _objetoInteractuableGO = null;
        _objetoInteractuable = null;

        exclamacionAnimator = GameObject.FindGameObjectWithTag(Constantes.Tags.EXCLAMACION).GetComponent<Animator>();
        exclamacionSpriteRenderer = GameObject.FindGameObjectWithTag(Constantes.Tags.EXCLAMACION).GetComponent<SpriteRenderer>();
    }

    private void RecogerInfoInputs()
    {
        InputManager.Instance.controlesJugador.Andando.Accion.performed += contexto => EjecutarAccion();
    }
}
