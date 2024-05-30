using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constantes.Animacion;
using static Constantes;

public class SeguirCamara : MonoBehaviour
{
    private Camera camara;

    void Start()
    {
        BuscarGO();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(camara.transform.position.x, camara.transform.position.y);
    }
    private void BuscarGO()
    {
        camara = GameObject.FindGameObjectWithTag(Constantes.Tags.CAMARA).GetComponent<Camera>();
    }
}
