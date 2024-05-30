using UnityEngine;
using UnityEngine.UI;

public class OI_Espejo : MonoBehaviour, IObjetoInteractuable
{
    private string _nombre;
    private string _textoAMostrar;
    private Sprite _sprite;

    public string Nombre
    { 
        get => _nombre;
        set => _nombre = value;
    }

    public string TextoAMostrar
    {
        get => _textoAMostrar;
        set => _textoAMostrar = value;
    }

    private void Start()
    {
        _nombre = Constantes.ObjetosInteractuables.ESPEJO_NOMBRE;
        _textoAMostrar = Constantes.ObjetosInteractuables.ESPEJO_TEXTOAMOSTRAR;
    }

    public void Accion()
    {
        Debug.Log("Me miro al espejo");
    }
}
