using System;
using UnityEngine;

public class EfectoParallax : MonoBehaviour
{
    private Camera camara;

    private Transform jugador;

    private Vector2 posicionInicialCamara;

    private Vector2 posicionInicialPlano;

    private float posicionInicialZPlano;

    // Esto hace que se calcule cada vez que se llame a distanciaRecorridaCamara
    private Vector2 distanciaRecorridaCamara => (Vector2)camara.transform.position - posicionInicialCamara;

    private float distanciaPlanoJugador => transform.position.z - jugador.position.z;

    private float clippingPlane => camara.transform.position.z + (distanciaPlanoJugador > 0 ? camara.farClipPlane : camara.nearClipPlane);

    private float parallaxFactor => Mathf.Abs(distanciaPlanoJugador) / clippingPlane;

    // Start is called before the first frame update
    void Start()
    {
        BuscarGO();

        InicializarVariables();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 posicionNueva = posicionInicialPlano + distanciaRecorridaCamara * parallaxFactor;
        transform.position = new Vector3(posicionNueva.x, posicionNueva.y, posicionInicialZPlano);
    }

    private void BuscarGO()
    {
        camara = GameObject.FindGameObjectWithTag(Constantes.Tags.CAMARA).GetComponent<Camera>();

        jugador = GameObject.FindGameObjectWithTag(Constantes.Tags.JUGADOR).transform;
    }

    private void InicializarVariables()
    {
        posicionInicialCamara = camara.transform.position;
        posicionInicialPlano = transform.position;
        posicionInicialZPlano = transform.position.z;
    }
}
