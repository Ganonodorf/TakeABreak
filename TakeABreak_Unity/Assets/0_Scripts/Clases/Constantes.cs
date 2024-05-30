using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Constantes
{
    public class Dialogos
    {
        public const int FIN_CONVERSACION = -1;
        public const int SILLON_MEDITAR = -2;
        public const int SILLON_LEVANTARSE = -3;

        public const int DISTANCIA_BOTONES = 11;

        public const float TIEMPO_ENTRE_LETRAS = 0.001f;
    }

    public class Tags
    {
        public const string INTERACTUABLE = "Interactuable";
        public const string BOCADILLO = "Bocadillo";
        public const string BOCADILLO_ACCION = "BocadilloAccion";
        public const string SPRITE_JUGADOR = "SpriteJugador";
        public const string SPRITE_NPC = "SpriteNPC";
        public const string PANEL_OPCIONES = "PanelOpciones";
        public const string JUGADOR = "Player";
        public const string CAMARA = "MainCamera";
        public const string CASA = "Casa";
        public const string MAR = "Mar";
    }

    public class ObjetosInteractuables
    {
        public const string ESPEJO_NOMBRE = "Espejo";
        public const string ESPEJO_TEXTOAMOSTRAR = "Pulsa Q para mirarte al espejo";

        public const string FOTO_NOMBRE = "Foto";
        public const string FOTO_TEXTOAMOSTRAR = "Pulsa Q para ver la foto";

        public const string TAZA_NOMBRE = "Taza";
        public const string TAZA_TEXTOAMOSTRAR = "Pulsa Q para coger la taza";

        public const string NPC_PRUEBA_NOMBRE = "NPC";
        public const string NPC_PRUEBA_TEXTOAMOSTRAR = "Pulsa Q para hablar con este NPC";
        public const string NPC_PRUEBA_PATH_SPRITE = "Assets/Sprites/Jugador/Jugador_Cabeza_Inversa.png";

        public const string ESCALERAS_NOMBRE = "Escaleras";
        public const string ESCALERAS_ABAJO_TEXTOAMOSTRAR = "Pulsa Q para subir las escaleras";
        public const string ESCALERAS_ARRIBA_TEXTOAMOSTRAR = "Pulsa Q para bajar las escaleras";

        public const string SILLON_NOMBRE = "Sillon";
        public const string SILLON_TEXTOAMOSTRAR = "Pulsa Q para sentarte en el sillón";

        public static readonly Conversacion SILLON_CONVERSACION_SENTARSE = new Conversacion(
            id: 0,
            frases: new Frase[9]
            {
                new Frase(ID: 0,
                          Texto: "Que mayor me he vuelto que me cuesta hasta sentarme en el sillón...",
                          Interlocutor: InterlocutorEnum.Jugador,
                          Mostrar: true,
                          SiguienteFrase: new int[1] { 1 }),
                new Frase(ID: 1,
                          Texto: "Hoy aún no medité. No sé si me apetece.",
                          Interlocutor: InterlocutorEnum.Jugador,
                          Mostrar: true,
                          SiguienteFrase: new int[1] { 2 }),
                new Frase(ID: 2,
                          Texto: "¿Quieres meditar?:",
                          Interlocutor: InterlocutorEnum.Sillon,
                          Mostrar: true,
                          SiguienteFrase: new int[2] { 3, 4 }),
                new Frase(ID: 3,
                          Texto: "Sí",
                          Interlocutor: InterlocutorEnum.Eleccion,
                          Mostrar: true,
                          SiguienteFrase: new int[1] { 5 }),
                new Frase(ID: 4,
                          Texto: "No",
                          Interlocutor: InterlocutorEnum.Eleccion,
                          Mostrar: true,
                          SiguienteFrase: new int[1] { 7 }),
                new Frase(ID: 5,
                          Texto: "Intenta seguir una respiración pausada, cuenta 5 segundo en cada inspiración y exhalación.",
                          Interlocutor: InterlocutorEnum.Sillon,
                          Mostrar: true,
                          SiguienteFrase: new int[1] { 6 }),
                new Frase(ID: 6,
                          Texto: "Para respirar usa el botón de acción. Al pulsar inhalarás y al soltar exhalarás.",
                          Interlocutor: InterlocutorEnum.Sillon,
                          Mostrar: true,
                          SiguienteFrase: new int[1] { Constantes.Dialogos.SILLON_MEDITAR }),
                new Frase(ID: 7,
                          Texto: "Pues arriba entonces.",
                          Interlocutor: InterlocutorEnum.Jugador,
                          Mostrar: true,
                          SiguienteFrase: new int[1] { Constantes.Dialogos.SILLON_LEVANTARSE }),
                new Frase(ID: 8,
                          Texto: "¿Voy a meditar de nuevo?",
                          Interlocutor: InterlocutorEnum.Jugador,
                          Mostrar: true,
                          SiguienteFrase: new int[2] { 3, 4 })
            }
        );

        public static readonly Conversacion SILLON_CONVERSACION_PARAR_MEDITAR = new Conversacion(
            id: 0,
            frases: new Frase[6]
            {
                new Frase(ID: 0,
                          Texto: "Que bien me he quedado.",
                          Interlocutor: InterlocutorEnum.Jugador,
                          Mostrar: true,
                          SiguienteFrase: new int[1] { 1 }),
                new Frase(ID: 1,
                          Texto: "¿Medito más?",
                          Interlocutor: InterlocutorEnum.Jugador,
                          Mostrar: true,
                          SiguienteFrase: new int[2] { 2, 3 }),
                new Frase(ID: 2,
                          Texto: "Sí",
                          Interlocutor: InterlocutorEnum.Eleccion,
                          Mostrar: true,
                          SiguienteFrase: new int[1] { 4 }),
                new Frase(ID: 3,
                          Texto: "No",
                          Interlocutor: InterlocutorEnum.Eleccion,
                          Mostrar: true,
                          SiguienteFrase: new int[1] { 5 }),
                new Frase(ID: 4,
                          Texto: "Vamos allá.",
                          Interlocutor: InterlocutorEnum.Sillon,
                          Mostrar: true,
                          SiguienteFrase: new int[1] { Constantes.Dialogos.SILLON_MEDITAR }),
                new Frase(ID: 5,
                          Texto: "Pues arriba entonces.",
                          Interlocutor: InterlocutorEnum.Jugador,
                          Mostrar: true,
                          SiguienteFrase: new int[1] { Constantes.Dialogos.SILLON_LEVANTARSE })
            }
        );
    }

    public class Animacion
    {
        public class Jugador
        {
            public const string IDLE_ESPALDA = "Jugador_Idle_Espalda";
            public const string GIRANDOSE = "Jugador_Girandose";
            public const string IDLE_ALANTE = "Jugador_Idle_Alante";
            public const string IDLE_ATRAS = "Jugador_Idle_Atras";
            public const string ANDANDO_ALANTE = "Jugador_Andando_Alante";
            public const string ANDANDO_ATRAS = "Jugador_Andando_Atras";
            public const string NADA = "Jugador_Nada";
        }

        public class Escaleras
        {
            public const string SUBIENDO_ESCALERAS_DER = "Subiendo_Escaleras_Der";
            public const string BAJANDO_ESCALERAS_DER = "Bajando_Escaleras_Der";
            public const string SUBIENDO_ESCALERAS_IZQ = "Subiendo_Escaleras_Izq";
            public const string BAJANDO_ESCALERAS_IZQ = "Bajando_Escaleras_Izq";

            public const float DURACION_ESCALERAS = 2.4f;
        }

        public class Sillon
        {

            public const string SENTANDOSE_SILLON = "Sentandose_Sillon";
            public const string SENTADO_SILLON = "Idle_Sentado";
            public const string LEVANTANDOSE_SILLON = "Levantandose_Sillon";

            public const string MEDITANDO = "Meditando";
            public const string MEDITANDO_INHALAR = "Meditando_Inhalar";
            public const string MEDITANDO_EXHALAR = "Meditando_Exhalar";

            public const string QUIETO = "Quieto";

            public const float DURACION_SENTANDOSE_SILLON = 5.2f;
            public const float DURACION_LEVANTANDOSE_SILLON = 3.2f;
        }

        public class Mar
        {
            public const string IDLE = "Mar";
            public const string INHALAR = "MarInhalar";
            public const string EXHALAR = "MarExhalar";
            public const string QUIETO = "MarQuieto";
        }

        public class Reflejo
        {
            public const string IDLE_ESPALDAS_ALANTE = "Jugador_idle_espaldas";
            public const string IDLE_ESPALDAS_ATRAS = "Jugador_idle_espaldas_atras";
            public const string ANDANDO_ESPALDAS_ALANTE = "Jugador_andando_espaldas";
            public const string ANDANDO_ESPALDAS_ATRAS = "Jugador_andando_espaldas_atras";
            public const string NADA = "Nada";
        }
    }

    public class PosicionesClave
    {
        public const float PosXInicial = -30.0f;

        public const float PosYDentroDeCasa = -28.0f;
        public const float PosYFueraDeCasa = -37.0f;

        public const float PosLimiteArribaEscalerasIzq = 143.0f;
        public const float PosLimiteAbajoEscalerasIzq = 122.0f;
        public static readonly Vector2 ArribaBajandoEscalerasIzq = new Vector2(144.0f, PosYDentroDeCasa);
        public static readonly Vector2 AbajoBajandoEscalerasIzq = new Vector2(116.0f, PosYFueraDeCasa);
        public static readonly Vector2 ArribaSubiendoEscalerasIzq = new Vector2(148.0f, PosYDentroDeCasa);
        public static readonly Vector2 AbajoSubiendoEscalerasIzq = new Vector2(121.0f, PosYFueraDeCasa);


        public const float PosLimiteArribaEscalerasDer = 613.0f;
        public const float PosLimiteAbajoEscalerasDer = 635.0f;
        public static readonly Vector2 ArribaBajandoEscalerasDer = new Vector2(612.0f, PosYDentroDeCasa);
        public static readonly Vector2 AbajoBajandoEscalerasDer = new Vector2(640.0f, PosYFueraDeCasa);
        public static readonly Vector2 ArribaSubiendoEscalerasDer = new Vector2(609.0f, PosYDentroDeCasa);
        public static readonly Vector2 AbajoSubiendoEscalerasDer = new Vector2(636.0f, PosYFueraDeCasa);


        public static readonly Vector2 Sillon = new Vector2(315.0f, PosYDentroDeCasa);

        public const float DistanciaReflejo = 11.0f;
    }

    public class Camara
    {
        public const float VELOCIDAD = 20.0f; // El original son 20
        public const float LIMITE_IZQ = 0.0f;
        public const float LIMITE_DER = 640.0f;

        public const float DIRECCION_ESCALERAS = 0.6f;

        public const float POSICION_MEDITANDO = 388.0f;
    }
}
