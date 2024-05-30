using UnityEngine;

public class OI_Foto : MonoBehaviour, IObjetoInteractuable
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
        _nombre = Constantes.ObjetosInteractuables.FOTO_NOMBRE;
        _textoAMostrar = Constantes.ObjetosInteractuables.FOTO_TEXTOAMOSTRAR;
    }

    public void Accion()
    {
        Debug.Log("Miro la foto");
    }
}
