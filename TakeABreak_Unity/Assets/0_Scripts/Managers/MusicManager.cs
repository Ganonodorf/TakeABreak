using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constantes.Animacion;

public class MusicManager : MonoBehaviour
{
    private GameObject jugador;

    public static MusicManager Instance;

    private void Awake()
    {
        HacerInmortal();
    }
    // Start is called before the first frame update
    void Start()
    {
        BuscarGO();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void HacerInmortal()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void BuscarGO()
    {
        jugador = GameObject.FindWithTag(Constantes.Tags.JUGADOR);
    }
}
