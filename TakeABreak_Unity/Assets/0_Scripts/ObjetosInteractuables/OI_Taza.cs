using UnityEngine;

public class OI_Taza : MonoBehaviour, IObjetoInteractuable
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

    public Sprite Sprite
    {
        get => _sprite;
        set => _sprite = value;
    }

    private void Start()
    {
        _nombre = Constantes.ObjetosInteractuables.TAZA_NOMBRE;
        _textoAMostrar = Constantes.ObjetosInteractuables.TAZA_TEXTOAMOSTRAR;
    }

    public void Accion()
    {
        Debug.Log("Cojo la taza");
    }
}
