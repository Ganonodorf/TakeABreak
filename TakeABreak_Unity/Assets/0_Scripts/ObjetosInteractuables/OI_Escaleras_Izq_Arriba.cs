using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OI_Escaleras_Izq_Arriba : MonoBehaviour, IObjetoInteractuable
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
        BajarEscaleras();
    }

    void Start()
    {
        InicializarVariables();

        BuscarGO();
    }

    private void BajarEscaleras()
    {
        if (jugadorGO.TryGetComponent(out MovimientoCont movimientoCont))
        {
            movimientoCont.BajarEscalerasIzq();
        }
    }

    private void InicializarVariables()
    {
        _nombre = Constantes.ObjetosInteractuables.ESCALERAS_NOMBRE;
        _textoAMostrar = Constantes.ObjetosInteractuables.ESCALERAS_ARRIBA_TEXTOAMOSTRAR;
    }

    private void BuscarGO()
    {
        jugadorGO = GameObject.FindGameObjectWithTag(Constantes.Tags.JUGADOR);
    }
}
