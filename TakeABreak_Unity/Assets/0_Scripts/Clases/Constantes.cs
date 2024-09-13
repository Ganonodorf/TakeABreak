using UnityEngine;

public class Constantes
{
    public class Dialogos
    {
        public const int FIN_CONVERSACION = -1;
        public const int ANIMACION_PEDO = -2;
        public const int SILLON_MEDITAR = -2;
        public const int SILLON_LEVANTARSE = -3;

        public const int DISTANCIA_BOTONES = 11;

        public const float TIEMPO_ENTRE_LETRAS = 0.1f;

        public const string NOMBRE_PLAYER = "Juanjo";
        public const string NOMBRE_TUMISMO = "Joseju";
        public const string NOMBRE_SILLON = "Sillón";
        public const string NOMBRE_DEFAULT = "Default";

    }

    public class Tags
    {
        public const string INTERACTUABLE = "Interactuable";
        public const string BOCADILLO = "Bocadillo";
        public const string NOMBRE_CONVERSACION = "NombreConversacion";
        public const string TEXTO_CONVERSACION = "TextoConversacion";
        public const string FLECHA = "Flecha";
        public const string BOCADILLO_ACCION = "BocadilloAccion";
        public const string EXCLAMACION = "Exclamacion";
        public const string SPRITE_JUGADOR = "SpriteJugador";
        public const string SPRITE_NPC = "SpriteNPC";
        public const string PANEL_OPCIONES = "PanelOpciones";
        public const string JUGADOR = "Player";
        public const string CAMARA = "MainCamera";
        public const string CASA = "Casa";
        public const string MAR = "Mar";
        public const string EVENT_SYSTEM = "EventSystem";
        public const string MUSICA = "Musica";
        public const string VIENTO = "Viento";
        public const string INTRO = "Intro";
        public const string TITULO = "Titulo";
        public const string FINJUEGO = "FinJuego";
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

        public const string TU_MISMO_NOMBRE = "Tú mismo";
        public const string TU_MISMO_TEXTOAMOSTRAR = "Pulsa Q para hablar contigo mismo";
        public const string TU_MISMO_PATH_SPRITE = "Assets/Sprites/Jugador/Tu_Mismo_Cabeza_Inversa.png";

        public const string ESCALERAS_NOMBRE = "Escaleras";
        public const string ESCALERAS_ABAJO_TEXTOAMOSTRAR = "Pulsa Q para subir las escaleras";
        public const string ESCALERAS_ARRIBA_TEXTOAMOSTRAR = "Pulsa Q para bajar las escaleras";

        public const string SILLON_NOMBRE = "Sillón";
        public const string SILLON_TEXTOAMOSTRAR = "Pulsa Q para sentarte en el sillón";

        public const string SPRITE_VACIO = "Assets/Sprites/UI/DialoganteVacio.png";

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
                          Texto: "Intenta seguir una respiración pausada, cuenta 5 segundos en cada inspiración y exhalación.",
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

        public const string BANCO_NOMBRE = "Banco";
        public const string BANCO_TEXTOAMOSTRAR = "Pulsa Q para sentarte en el banco";

        public static readonly Conversacion CONVERSACION_FINAL = new Conversacion(
            id: 0,
            frases: new Frase[136]
            {
                new Frase(ID: 0,
                Texto: "...",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 1 }),
                new Frase(ID: 1,
                Texto: "¿No vas a decir nada?",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 2 }),
                new Frase(ID: 2,
                Texto: "¿Qué te voy a decir si estoy todo el rato conmigo?",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 3 }),
                new Frase(ID: 3,
                Texto: "No sé, un hola que tal...",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 4 }),
                new Frase(ID: 4,
                Texto: "¿Cómo te gusta eh?",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 5 }),
                new Frase(ID: 5,
                Texto: "Si, ya me conoces, me gusta tener un poquito de atención.",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 6 }),
                new Frase(ID: 6,
                Texto: "Sólo respira y mira el mar... Es precioso...",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 7 }),
                new Frase(ID: 7,
                Texto: "...",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 8 }),
                new Frase(ID: 8,
                Texto: "...",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 9 }),
                new Frase(ID: 9,
                Texto: "La verdad es que si...",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 10 }),
                new Frase(ID: 10,
                Texto: "[Pausa para contemplar.]",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 11 }),
                new Frase(ID: 11,
                Texto: "La verdad es que es impresionante... Se respira mucha calma...",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 12 }),
                new Frase(ID: 12,
                Texto: "¿Recuerdas que esto antes era imposible? Simplemente estar aquí, observando sin nada más que hacer. Estando.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 13 }),
                new Frase(ID: 13,
                Texto: "Si... El psicólogo ayudó mucho la verdad jajaja.",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 14 }),
                new Frase(ID: 14,
                Texto: "Ya ves...",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 15 }),
                new Frase(ID: 15,
                Texto: "¿Cómo fue que llegamos a estar en paz?",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 16 }),
                new Frase(ID: 16,
                Texto: "Me sorprende que me lo preguntes tú, siempre eres el que intenta romperla.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 17 }),
                new Frase(ID: 17,
                Texto: "Quizá por eso se me ha olvidado.",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 18 }),
                new Frase(ID: 18,
                Texto: "A ver... Al principio de los tiempos había mucha ansiedad...",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 19 }),
                new Frase(ID: 19,
                Texto: "Tampoco hace falta que te pongas así.",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 20 }),
                new Frase(ID: 20,
                Texto: "Jeje, vale vale... ¿Recuerdas cuando empezamos con la ansiedad? Sin poder respirar, siempre pensando, pensando, pensando... Era como tener en la cabeza una nube de preocupaciones irreales que te impiden actuar con naturalidad ni espontaneidad.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 21 }),
                new Frase(ID: 21,
                Texto: "Sí... Eso sí lo recuerdo. También recuerdo no ser capaz de decirte nada bueno, sólo te decía que todo iba a ser terrible, que tenías que hacer cosas que no querías, que todo iba a salir mal...",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 22 }),
                new Frase(ID: 22,
                Texto: "Fueron unos años largos si... ¿Y qué más recuerdas?",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 23 }),
                new Frase(ID: 23,
                Texto: "Mmm, que empezamos con el primer psicólogo.",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 24 }),
                new Frase(ID: 24,
                Texto: "Eso es, Jose nos ayudó mucho a entender el porqué decías las cosas que decías y el significado real que había detrás. Cómo era tu funcionamiento.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 25 }),
                new Frase(ID: 25,
                Texto: "Sí... Es verdad que muchas veces digo cosas sin pensar, antes te agobiaban mucho mis comentarios.",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 26 }),
                new Frase(ID: 26,
                Texto: "Y tanto que sí... ¿Y después?",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 27 }),
                new Frase(ID: 27,
                Texto: "Pues... Estuvimos un tiempo mejor, pero había algo que no terminaba de encajar en nosotros, no nos entendíamos y nos hacíamos daño.",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 28 }),
                new Frase(ID: 28,
                Texto: "Y por eso fuimos a la segunda psicóloga, que nos ayudó entender como nos sentíamos el uno con el otro. Incluso aprendimos de dónde venían algunos comportamientos que teníamos en el presente.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 29 }),
                new Frase(ID: 29,
                Texto: "Es verdad, y ahí fue cuando me diste el ultimátum.",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 30 }),
                new Frase(ID: 30,
                Texto: "No podía dejar que me siguieras hablando tan mal, tenía que ponerte freno de una vez por todas.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 31 }),
                new Frase(ID: 31,
                Texto: "Ya... No me enorgullezco de lo que te decía...",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 32 }),
                new Frase(ID: 32,
                Texto: "...",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 33 }),
                new Frase(ID: 33,
                Texto: "... Y... ¿Cómo fue la frase? ¿Cómo era eso que me decías? Háblame como...",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 34 }),
                new Frase(ID: 34,
                Texto: "Como mi mejor amigo.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 35 }),
                new Frase(ID: 35,
                Texto: "¿Y porqué decidiste hacer eso?",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 36 }),
                new Frase(ID: 36,
                Texto: "Pues la verdad... No lo sé. No sé si lo leí en algún sitio, se me ocurrió a mi mismo o qué. Sí que recuerdo el momento en el que te lo dije.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 37 }),
                new Frase(ID: 37,
                Texto: "Yo también, nos estábamos duchando y dijiste muy serio: \"Se acabó, acabo de pasarlo fatal y no puedo soportar que me sigas hablando así. Ten compasión de mí y háblame como si fuera Juanma.\"",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 38 }),
                new Frase(ID: 38,
                Texto: "Es verdad, me puse muy serio, lo había olvidado. Pero funcionó.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 39 }),
                new Frase(ID: 39,
                Texto: "Sí, la verdad es que sí...",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 40 }),
                new Frase(ID: 40,
                Texto: "Aunque me tienes que reconocer que tuve que ser muy pesado para hacerte cambiar.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 41 }),
                new Frase(ID: 41,
                Texto: "Pues sí... Lo siento.",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 42 }),
                new Frase(ID: 42,
                Texto: "Está bien, así pude forjar una actitud más fuerte tanto conmigo mismo como con el resto del mundo para que no me pisotearan.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 43 }),
                new Frase(ID: 43,
                Texto: "Todo camino andado es camino eh...",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 44 }),
                new Frase(ID: 44,
                Texto: "Si...",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 45 }),
                new Frase(ID: 45,
                Texto: "[Pausa para contemplar.]",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 46 }),
                new Frase(ID: 46,
                Texto: "[Pausa para contemplar.]",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 47 }),
                new Frase(ID: 47,
                Texto: "Espera, pero ahí no acaba la cosa.",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 48 }),
                new Frase(ID: 48,
                Texto: "Esperaba que te acordaras.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 49 }),
                new Frase(ID: 49,
                Texto: "Claro que me acuerdo, después de eso te hablaba mucho mejor, pero seguía siendo un papagayo.",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 50 }),
                new Frase(ID: 50,
                Texto: "Jajajaja, efectivamente, un papagayo.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 51 }),
                new Frase(ID: 51,
                Texto: "Es que me gusta mucho hablar.",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 52 }),
                new Frase(ID: 52,
                Texto: "Lo sé, pero también es necesario respirar y estar en calma.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 53 }),
                new Frase(ID: 53,
                Texto: "Sí... Ahí la meditación ayudó mucho. ¿Cómo fue que empezamos?",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 54 }),
                new Frase(ID: 54,
                Texto: "Pues porque decían que era bueno para la mente.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 55 }),
                new Frase(ID: 55,
                Texto: "Ya, jope, ¿pero no hubo nada más?",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 56 }),
                new Frase(ID: 56,
                Texto: "Mmm, bueno, también porque me parecía que me hacía ser un tío guay, no te voy a engañar.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 57 }),
                new Frase(ID: 57,
                Texto: "¿Y ya está? ¿No era porque te lo recomendó alguien importante?",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 58 }),
                new Frase(ID: 58,
                Texto: "Pues ahí te equivocas, empezamos antes de conocerla.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 59 }),
                new Frase(ID: 59,
                Texto: "¿Sí? ¿Pero...? ¡Ah! Es verdad, que antes en vez de respirar y dejar pasar lo que te decía, me dabas bola jajaja.",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 60 }),
                new Frase(ID: 60,
                Texto: "Sí jajaja.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 61 }),
                new Frase(ID: 61,
                Texto: "[Ambos ríen]",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 62 }),
                new Frase(ID: 62,
                Texto: "[Ambos ríen]",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 63 }),
                new Frase(ID: 63,
                Texto: "Si si, ahora recuerdo que fue ella la que te dijo que la estabas cagando, que así no se meditaba.",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 64 }),
                new Frase(ID: 64,
                Texto: "Y cuánta razón tenía... Dios... También me dijo muy seria: \"Tú no eres tu mente, tu ser y tu mente son dos cosas diferentes.\"",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 65 }),
                new Frase(ID: 65,
                Texto: "Eso si que fue fuerte, te hizo ver que todo lo que yo decía no era real.",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 66 }),
                new Frase(ID: 66,
                Texto: "Pues si... Y me costó mucho verlo e interiorizarlo, te tenía como la verdad absoluta, como que todo lo que decías era la realidad. A lo mejor al quitarle peso a tus comentarios hirientes y conventirlos en buenas palabras me pude crear una compasión tan fuerte.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 67 }),
                new Frase(ID: 67,
                Texto: "Es posible, hiciste un buen trabajo.",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 68 }),
                new Frase(ID: 68,
                Texto: "Muchas gracias, fue un trabajo duro.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 69 }),
                new Frase(ID: 69,
                Texto: "Lo sé.",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 70 }),
                new Frase(ID: 70,
                Texto: "[Pausa para contemplar.]",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 71 }),
                new Frase(ID: 71,
                Texto: "¿Y no te gustaría no haber pasado todo lo malo? Porque para haber conseguido esa compasión y esa tranquilidad, hubo que soportar mucha mierda. Los ataques de ansiedad no fueron bonitos...",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 72 }),
                new Frase(ID: 72,
                Texto: "No lo fueron, no... Pero aun así, estoy orgulloso y contento de haber sobrevivido a ello. Los malos momentos me hicieron conectar con un malestar tan profundo que me hizo valorar mucho las cosas buenas que tuve después y también fueron gasolina para querer estar mejor.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 73 }),
                new Frase(ID: 73,
                Texto: "Suenas muy teatral, como si lo hubieras pensado y escrito para este momento.",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 74 }),
                new Frase(ID: 74,
                Texto: "Jeje, ¿y quién te dice que no lo hecho en algún momento de mi vida?",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 75 }),
                new Frase(ID: 75,
                Texto: "Ya bueno, pero eso no viene a cuento. No cambies de tema y sigue contándome, que se estaba poniendo profundo.",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 76 }),
                new Frase(ID: 76,
                Texto: "Muy bien, *ejem*. Todos las experiencias de la vida, buenas y malas, ante el estertor de la muerte se perderán en el tiempo... Como un pedo en el viento...",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 77 }),
                new Frase(ID: 77,
                Texto: "Jajajaja, ahí me has pillado",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 78 }),
                new Frase(ID: 78,
                Texto: "[Ambos ríen]",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 79 }),
                new Frase(ID: 79,
                Texto: "[Ambos ríen]",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 80 }),
                new Frase(ID: 80,
                Texto: "[Pausa para contemplar.]",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 81 }),
                new Frase(ID: 81,
                Texto: "[Pausa para contemplar.]",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 82 }),
                new Frase(ID: 82,
                Texto: "Sinceramente no me arrepiento nada, volvería a vivir la misma vida sin dudarlo. Siento que pasar por un pozo de dolor y sufrimiento me ayudó a evolucionar hasta el punto donde estoy hoy.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 83 }),
                new Frase(ID: 83,
                Texto: "Sí bueno, eso está genial, pero tampoco puede obviar que hemos tenido la vida muy sencilla.",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 84 }),
                new Frase(ID: 84,
                Texto: "Claro, eso tampoco te lo voy a negar, me siento muy afortunado y privilegiado con lo que me ha dado la vida. La familia que tengo es maravillosa y eso sí que no lo pude ni lo puedo cambiar.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 85 }),
                new Frase(ID: 85,
                Texto: "¿Entonces?",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 86 }),
                new Frase(ID: 86,
                Texto: "Pues yo creo que la familia que hemos tenido es una cosa y a dónde hemos querido llegar con nuestra situación vital es otra.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 87 }),
                new Frase(ID: 87,
                Texto: "Explícate.",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 88 }),
                new Frase(ID: 88,
                Texto: "A ver, cuando lo estuvimos pasando tan mal, no veía un momento en el que fuera a estar bien. Sinceramente yo acepté que la vida iba a ser así, siempre viviendo en mi mente, siempre con ansiedad crónica, siempre intraquilo e incapaz de ser feliz.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 89 }),
                new Frase(ID: 88,
                Texto: "Pero antes de empezar con la segunda psicóloga, me pregunté de forma sincera \"¿Porqué tengo tanta ansiedad? ¿Quiero vivir toda mi vida así?\" Y eso fue el motor para cambiar mi situación vital y mi relación conmigo mismo. Con la Gestalt sentía que podía conocerme mejor, saber de dónde venía mi ansiedad y porqué era ansioso en el presente.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 90 }),
                new Frase(ID: 88,
                Texto: "El decidir ir a terapia, enfrentarte a tus mierdas mas internas, a tu oscuridad, tus traumas, tu sombra... Es un camino duro que decidí tomar para estar mejor sabiendo perfectamente que iba a doler... Se puede vivir sin hacer este proceso, podría haber enterrado toda mi mierda en lo más profundo de mi ser, tener ataques de ansiedad de vez en cuando, estar siempre inquieto, con una máscara hacia el mundo, sin saber quién era... Vivir así es posible, pero no lo quería para mí.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 91 }),
                new Frase(ID: 89,
                Texto: "Es ciero que es un camino duro, pero tal como lo cuentas, suena un poco a \"¿Estás mal? No lo estés.\"",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 92 }),
                new Frase(ID: 90,
                Texto: "¿Sí? Puede que tengas razón, voy a intentar decirlo con otras palabras, dame un segundo.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 93 }),
                new Frase(ID: 91,
                Texto: "[Pausa para contemplar.]",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 94 }),
                new Frase(ID: 92,
                Texto: "[Pausa para contemplar.]",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 95 }),
                new Frase(ID: 93,
                Texto: "¿Lo tienes?",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 96 }),
                new Frase(ID: 94,
                Texto: "Lo tengo.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 97 }),
                new Frase(ID: 95,
                Texto: "Dale.",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 98 }),
                new Frase(ID: 96,
                Texto: "[Sonido de pedo]",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 99 }),
                new Frase(ID: 97,
                Texto: "Pfff jajajaja. Ya van dos bromas de pedos.",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 100 }),
                new Frase(ID: 98,
                Texto: "No me pude resistir, necesito rebajar tensión jajajaja.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 101 }),
                new Frase(ID: 99,
                Texto: "[Pausa para contemplar.]",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 102 }),
                new Frase(ID: 100,
                Texto: "Vale, lo tengo. Cuando una persona está muy mal y le dices \"No estés mal\" o \"No tengas ansiedad\" o \"Puedes estar bien, solo tienes que querer\" es de ser un gilipollas.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 103 }),
                new Frase(ID: 101,
                Texto: "En efecto.",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 104 }),
                new Frase(ID: 102,
                Texto: "Pero realmente no hay otra forma.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 105 }),
                new Frase(ID: 103,
                Texto: "Eres un gilipollas.",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 106 }),
                new Frase(ID: 104,
                Texto: "Joder, déjame explicarme. Cuando una persona tiene depresión, ansiedad muy fuerte o estados similares, ese tipo de comentarios no sirve. La persona necesita de atención psiquiátrica y psicológica y no hay más que hablar.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 107 }),
                new Frase(ID: 104,
                Texto: "Una vez que no está en esos umbrales, si la persona quiere estar mejor tiene que hacer un compromiso fuerte con ella misma. Tiene que saber que hay una parte de ella que no funciona correctamente, que no es perfecta y que ha cometido errores en la vida.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 108 }),
                new Frase(ID: 105,
                Texto: "Y para eso hace falta mucha confianza, porque cuando no estás bien, parece que no hay opción a estarlo. Y lo mejor es que todo el mundo puede.",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 109 }),
                new Frase(ID: 106,
                Texto: "Pues sí... Y lo peor de todo es que suena como si fueras una puta taza de Mister Wonderful. \"Confía en la vida y todo irá bien\". Por eso parece que eres un gilipollas cuando dices estas cosas.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 110 }),
                new Frase(ID: 107,
                Texto: "Pues sí, y también tiene un toque místico de \"Confía en la vida y todo irá bien\".",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 111 }),
                new Frase(ID: 108,
                Texto: "Bueno, realmente hay que indagar un poco en la espiritualidad interna de cada uno. A mí me costó mucho ver y aceptar que esa palabra tenía cabida fuera de la religión.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 112 }),
                new Frase(ID: 109,
                Texto: "No te olvides tampoco del ego. Tener el ego bajo para esto es importante.",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 113 }),
                new Frase(ID: 110,
                Texto: "Sí, la verdad es que sí.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 114 }),
                new Frase(ID: 111,
                Texto: "Si tu y yo no nos hubiéramos bajado unos tonitos, no habríamos podido alcanzar la calma. Confiar en la vida está genial, pero asumir que eres humano, que cometes errores, que te has hecho mucho daño, que estás sufriendo y que es posible que tengas algo de culpa... Es muy duro.",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 115 }),
                new Frase(ID: 112,
                Texto: "Eso tampoco le gusta a nadie.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 116 }),
                new Frase(ID: 113,
                Texto: "[Pausa para contemplar.]",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 117 }),
                new Frase(ID: 114,
                Texto: "[Pausa para contemplar.]",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 118 }),
                new Frase(ID: 115,
                Texto: "Yo diría que eso es lo más complejo de todo, asumir que te has equivocado y te has tratado mal en muchas ocasiones.",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 119 }),
                new Frase(ID: 116,
                Texto: "A ver, eso es duro, pero también hay que curar el daño que te ha hecho otra gente.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 120 }),
                new Frase(ID: 117,
                Texto: "Por supuesto, no me malinterpretes, curar ambas cosas es necesario.",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 121 }),
                new Frase(ID: 118,
                Texto: "Si... Y tienes que querer indagar en tu mierda, estar dispuesto a transitar por tus vivencias y emociones. Entrar en eso y salir se siente horrible y liberador a la vez, es acojonante.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 122 }),
                new Frase(ID: 119,
                Texto: "Lo es, tener una convicción dentro de tí que te permita hacer ese viaje es necesario.",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 123 }),
                new Frase(ID: 120,
                Texto: "Y todo el mundo puede hacerlo, te lo puedo asegurar.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 124 }),
                new Frase(ID: 121,
                Texto: "Eso es lo más bonito. Que parece que no, pero todo el mundo puede. Por eso te decía antes lo de querer hacerlo, si tienes confianza y compasión, puedes hacerlo.",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 125 }),
                new Frase(ID: 122,
                Texto: "Ya... Pero realmente no todo el mundo tiene eso o no tiene porqué querer hacerlo.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 126 }),
                new Frase(ID: 123,
                Texto: "También es verdad, el entorno influye mucho, las relaciones personales tienen mucho peso en la vida de una persona. A lo mejor si no hubiéramos tenido el entorno que hemos tenido, no hubiéramos hecho el camino ni estaríamos aquí hoy.",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 127 }),
                new Frase(ID: 124,
                Texto: "A lo mejor tampoco hubiéramos querido hacerlo, y también estaría bien. Cada persona tiene su propio camino y su forma de vivir la vida.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 128 }),
                new Frase(ID: 125,
                Texto: "Por supuesto, lo curioso es cómo esos caminos chocan cuando la gente cambia. Cuando comienzas un proceso de autoconocimiento y sanación, te das cuenta que mucha gente que hay a tu alrededor no te hace tanto bien como pensabas y no puedes evitar verlo. Es rarísimo y duro.",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 129 }),
                new Frase(ID: 126,
                Texto: "Por eso también te decía antes que aunque el camino haya sido duro, merece la pena. Acabas cultivando relaciones que te respetan, te tratan con amor, cariño y quieren lo mejor para ti.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 130 }),
                new Frase(ID: 127,
                Texto: "Pues la verdad es que si...",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 131 }),
                new Frase(ID: 128,
                Texto: "[Pausa para contemplar]",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 132 }),
                new Frase(ID: 129,
                Texto: "[Pausa para contemplar]",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 133 }),
                new Frase(ID: 130,
                Texto: "La verdad es que hemos hecho un buen repaso.",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { 134 }),
                new Frase(ID: 131,
                Texto: "Y que lo digas, no has dejado pasar los pensamientos y ya está. Al final me he vuelto a salir con la mía jeje.",
                Interlocutor: InterlocutorEnum.TuMismo,
                Mostrar: true,
                SiguienteFrase: new int[1] { 135 }),
                new Frase(ID: 132,
                Texto: "Te voy a matar...",
                Interlocutor: InterlocutorEnum.Jugador,
                Mostrar: true,
                SiguienteFrase: new int[1] { Constantes.Dialogos.FIN_CONVERSACION })
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

        public class ObjetosInteractuables
        {
            public const string EXCLAMACION = "Exclamacion";
            public const string NADA = "Nada";
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

        public class Banco
        {
            public const string SENTANDOSE_BANCO = "Jugador_Sentandose_Banco";

            public const float DURACION_SENTANDOSE_BANCO = 0.1f;
        }

        public class UI
        {
            public const string INTRO = "Intro";
            public const string FLECHA = "Flecha";
            public const string NADA = "Nada";
        }
    }

    public class PosicionesClave
    {
        public const float PosXInicialJugador = -30.0f;
        public const float PosXInicialCamara = 0.0f;

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

        public const float PosLimiteIzq = -46.0f;
        public const float PosLimiteDer = 690.0f;

        public static readonly Vector2 Sillon = new Vector2(315.0f, PosYDentroDeCasa);

        public const float DistanciaReflejo = 11.0f;

        public static readonly Vector2 PosDerechaExclamacion = new Vector2(10.0f, 23.0f);
        public static readonly Vector2 PosIzquierdaExclamacion = new Vector2(-10.0f, 23.0f);
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
