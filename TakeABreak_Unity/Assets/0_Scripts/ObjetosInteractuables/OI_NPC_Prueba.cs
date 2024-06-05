using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class OI_NPC_Prueba : MonoBehaviour, IObjetoInteractuable
{
    // Variables privadas
    private string _nombre;
    private string _textoAMostrar;
    private Sprite _sprite;
    private Conversacion conversacionInicio;


    // Inicializadores
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
        _nombre = Constantes.ObjetosInteractuables.NPC_PRUEBA_NOMBRE;
        _textoAMostrar = Constantes.ObjetosInteractuables.NPC_PRUEBA_TEXTOAMOSTRAR;

        AsyncOperationHandle<Sprite> cargadoSpritenAsync = Addressables.LoadAssetAsync<Sprite>(Constantes.ObjetosInteractuables.NPC_PRUEBA_PATH_SPRITE);
        cargadoSpritenAsync.Completed += CargaSpriteCuandoAcabes;
    }
    
    void CargaSpriteCuandoAcabes(AsyncOperationHandle<Sprite> handleToCheck)
    {
        if (handleToCheck.Status == AsyncOperationStatus.Succeeded)
        {
            _sprite = handleToCheck.Result;
        }
    }

    public void Accion()
    {
        conversacionInicio = new Conversacion
        (
            id: 0,
            frases: new Frase[13]
            {
            new Frase(ID: 0,
                      Texto: "Hola, soy tu yo del pasado",
                      Interlocutor: InterlocutorEnum.NPC,
                      Mostrar: true,
                      SiguienteFrase: new int[1] { 1 }),
            new Frase(ID: 1,
                      Texto: "Hola, y yo del presente",
                      Interlocutor: InterlocutorEnum.Jugador,
                      Mostrar: true,
                      SiguienteFrase: new int[1] { 2 }),
            new Frase(ID: 2,
                      Texto: "¿Qué te gusta más?:",
                      Interlocutor: InterlocutorEnum.NPC,
                      Mostrar: true,
                      SiguienteFrase: new int[4] { 3, 4, 5, 6 }),
            new Frase(ID: 3,
                      Texto: "El smash",
                      Interlocutor: InterlocutorEnum.Eleccion,
                      Mostrar: true,
                      SiguienteFrase: new int[1] { 7 }),
            new Frase(ID: 4,
                      Texto: "El dark souls",
                      Interlocutor: InterlocutorEnum.Eleccion,
                      Mostrar: true,
                      SiguienteFrase: new int[1] { 8 }),
            new Frase(ID: 5,
                      Texto: "El zelda",
                      Interlocutor: InterlocutorEnum.Eleccion,
                      Mostrar: true,
                      SiguienteFrase: new int[1] { 9 }),
            new Frase(ID: 6,
                      Texto: "Avatar",
                      Interlocutor: InterlocutorEnum.Eleccion,
                      Mostrar: true,
                      SiguienteFrase: new int[1] { 10 }),
            new Frase(ID: 7,
                      Texto: "Sí, el Tink va duro",
                      Interlocutor: InterlocutorEnum.NPC,
                      Mostrar: true,
                      SiguienteFrase: new int[1] { 11 }),
            new Frase(ID: 8,
                      Texto: "Muy oscuro y difícil si...",
                      Interlocutor: InterlocutorEnum.NPC,
                      Mostrar: true,
                      SiguienteFrase: new int[1] { 11 }),
            new Frase(ID: 9,
                      Texto: "Buen villano el KOE",
                      Interlocutor: InterlocutorEnum.NPC,
                      Mostrar: true,
                      SiguienteFrase: new int[1] { 11 }),
            new Frase(ID: 10,
                      Texto: "La mejor serie de la historia la verdad",
                      Interlocutor: InterlocutorEnum.NPC,
                      Mostrar: true,
                      SiguienteFrase: new int[1] { 11 }),
            new Frase(ID: 11,
                      Texto: "Está guay",
                      Interlocutor: InterlocutorEnum.Jugador,
                      Mostrar: true,
                      SiguienteFrase: new int[1] { 12 }),
            new Frase(ID: 12,
                      Texto: "Me alegro de que te guste tanto",
                      Interlocutor: InterlocutorEnum.NPC,
                      Mostrar: true,
                      SiguienteFrase: new int[1] { Constantes.Dialogos.FIN_CONVERSACION_FINAL })
            }
        );

        DialogueManager.Instance.IniciarConversacion(this.gameObject, conversacionInicio, _sprite);
    }
}
