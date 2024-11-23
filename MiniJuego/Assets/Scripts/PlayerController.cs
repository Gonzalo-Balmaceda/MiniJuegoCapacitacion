using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    public float speed = 20F;
    private float xRange = 10.2F;
    private bool mirandoDerecha = true;
    private Animator animator;
    private int score = 0;
    private int lives = 3;
    public TextMeshProUGUI scoreText, livesText;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); // Obtengo el componente.
        UpdateScoreText(); //Inicializa el texto de puntaje
        UpdateLivesText(); // Inicializa el texto de vidas
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoJugador();
        GestionarOrientacion();
        LimitesEscena();

    }

    void MovimientoJugador()
    {
        horizontalInput = Input.GetAxis("Horizontal"); // Obtengo el movimiento horizontal.
        if (!gameOver)
        {
            // Movimiento del jugador.
            transform.Translate(Vector2.right * horizontalInput * Time.deltaTime * speed); // Le damos el movimiento al jugador.

            // Activar animación de movimiento.
            if (horizontalInput != 0F)
            { // Si es distinto a cero es porque que el jugador se está moviendo.

                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false); // Si el jugador se queda quieto desactivamos la animación.
            }
        }

        if (gameOver)
        {
            animator.SetBool("isRunning", false);
        }

    }

    void GestionarOrientacion()
    {
        if (mirandoDerecha && horizontalInput < 0 && !gameOver || !mirandoDerecha && horizontalInput > 0 && !gameOver)
        {
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y); // Volteamos el jugador en el eje x.
        }
    }

    void LimitesEscena()
    {

        // Limites en el eje x.
        // Limite hacia la izquiera.
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector2(-xRange, transform.position.y);
        }

        // Limite hacia la derecha.
        if (transform.position.x > xRange)
        {

            transform.position = new Vector2(xRange, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Círculo")) // Objeto bueno que nos da puntos.
        {
            score += 100; // Aumentar el puntaje.
            UpdateScoreText(); //Va actualizando el texto con el puntaje
        }
        else if (other.CompareTag("Cuadrado")) // Objeto malo que nos quita vida.
        {
            lives -= 1; // Reducir vidas.
            UpdateLivesText();

            if (lives <= 0)
            {
                Debug.Log("¡Game Over!"); // Aquí puedes implementar la lógica de fin de juego.
                gameOver = true;
            }
        }
        Destroy(other.gameObject); // Destruir el objeto tras la interacción.
    }

    void UpdateScoreText()
    {
        scoreText.text = "Puntos: " + score; // Actualizar el texto del puntaje.
    }

    void UpdateLivesText()
    {
        livesText.text = "Vidas: " + lives; //Actualizar el texto de vidas.
    }

    void GameOver()
    {

    }
}
