using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OI_Escaleras_Der_Abajo : MonoBehaviour, IObjetoInteractuable
{
    private string _nombre;
    private string _textoAMostrar;
    private Sprite _sprite;
    private GameObject jugadorGO;
    public string Nombre { get => _nombre; set => _nombre = value; }
    public string TextoAMostrar { get => _textoAMostrar; set => _textoAMostrar = value; }
    public Sprite Sprite { get => _sprite; set => _sprite = value; }

    public void Accion()
    {
        SubirEscaleras();
    }

    void Start()
    {
        InicializarVariables();

        BuscarGO();
    }

    private void SubirEscaleras()
    {
        GetComponent<Animator>().Play(Constantes.Animacion.Escaleras.SUBIENDO_ESCALERAS_DER);

        if (jugadorGO.TryGetComponent(out MovimientoCont movimientoCont))
        {
            movimientoCont.CambiarEstadoMovimiento(EstadoMovimiento.SubiendoEscDer);
        }
    }

    private void InicializarVariables()
    {
        _nombre = Constantes.ObjetosInteractuables.ESCALERAS_NOMBRE;
        _textoAMostrar = Constantes.ObjetosInteractuables.ESCALERAS_ABAJO_TEXTOAMOSTRAR;
    }

    private void BuscarGO()
    {
        jugadorGO = GameObject.FindGameObjectWithTag(Constantes.Tags.JUGADOR);
    }
}
