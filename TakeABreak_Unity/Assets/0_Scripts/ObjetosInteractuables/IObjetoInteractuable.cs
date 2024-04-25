using UnityEngine;

public interface IObjetoInteractuable
{
    string Nombre { get; set; }

    string TextoAMostrar { get; set; }

    Sprite Sprite { get; set; }

    void Accion();
}
