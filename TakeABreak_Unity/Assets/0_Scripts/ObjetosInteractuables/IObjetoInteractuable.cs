using UnityEngine;

public interface IObjetoInteractuable
{
    string Nombre { get; set; }

    string TextoAMostrar { get; set; }

    void Accion();
}
