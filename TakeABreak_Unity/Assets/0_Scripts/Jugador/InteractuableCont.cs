using System;
using TMPro;
using UnityEditor.Build.Pipeline.Interfaces;
using UnityEngine;

public class InteractuableCont : MonoBehaviour
{
    private GameObject _objetoInteractuableGO;
    private IObjetoInteractuable _objetoInteractuable;

    private void Awake()
    {
        InputManager.Instance.controlesJugador.Andando.Accion.performed += contexto => EjecutarAccion();
    }

    private void Start()
    {
        _objetoInteractuableGO = null;
        _objetoInteractuable = null;
    }

    private void EjecutarAccion()
    {
        if (_objetoInteractuable != null)
        {
            _objetoInteractuable.Accion();
            OcultarAccion(_objetoInteractuableGO);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IObjetoInteractuable objetoInteractuable))
        {
            _objetoInteractuableGO = collision.gameObject;
            _objetoInteractuable = objetoInteractuable;

            MostrarAccion(_objetoInteractuableGO, objetoInteractuable);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IObjetoInteractuable objetoInteractuable))
        {
            OcultarAccion(_objetoInteractuableGO);

            _objetoInteractuableGO = null;
            _objetoInteractuable = null;
        }
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
        foreach (Transform child in objetoInteractuableGO.transform)
        {
            if (child.tag == Constantes.Tags.BOCADILLO_ACCION)
            {
                MostrarOcultarBocadillo(child, false, string.Empty);
                return;
            }
        }
    }

    private void MostrarOcultarBocadillo(Transform bocadilloAccion, bool estado, string texto)
    {
        bocadilloAccion.GetComponent<SpriteRenderer>().enabled = estado;
        bocadilloAccion.GetComponentInChildren<TextMeshPro>().text = texto;
    }
}
