using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OI_Escaleras : MonoBehaviour, IObjetoInteractuable
{
    private string _nombre;

    private string _textoAMostrar;

    private Sprite _sprite;
    public string Nombre { get => _nombre; set => _nombre = value; }
    public string TextoAMostrar { get => _textoAMostrar; set => _textoAMostrar = value; }
    public Sprite Sprite { get => _sprite; set => _sprite = value; }

    public void Accion()
    {
        SubirEscaleras();
    }

    void Start()
    {
        _nombre = Constantes.ObjetosInteractuables.ESPEJO_NOMBRE;
        _textoAMostrar = Constantes.ObjetosInteractuables.ESPEJO_TEXTOAMOSTRAR;
    }

    private void SubirEscaleras()
    {

    }
}
