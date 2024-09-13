using UnityEngine;

public class BotonEleccion
{
    public GameObject Boton { get; set; }

    public int SiguienteFrase { get; set; }

    public BotonEleccion(GameObject boton, int siguienteFrase)
    {
        this.Boton = boton;
        this.SiguienteFrase = siguienteFrase;
    }
}
