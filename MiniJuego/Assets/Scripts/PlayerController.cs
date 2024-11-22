using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    public float speed = 20F;
    private float xRange = 10.2F;
    private bool mirandoDerecha = true;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); // Obtengo el componente.
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoJugador();
        GestionarOrientacion();
        LimitesEscena();

    }

    void MovimientoJugador() {
        // Movimiento del jugador.
        horizontalInput = Input.GetAxis("Horizontal"); // Obtengo el movimiento horizontal.
        transform.Translate(Vector2.right * horizontalInput * Time.deltaTime * speed); // Le damos el movimiento al jugador.

        // Activar animación de movimiento.
        if (horizontalInput != 0F) { // Si es distinto a cero es porque que el jugador se está moviendo.
            animator.SetBool("isRunning", true);
        } else {
            animator.SetBool("isRunning", false); // Si el jugador se queda quieto desactivamos la animación.
        }
    }

    void GestionarOrientacion() {
        if (mirandoDerecha && horizontalInput < 0 || !mirandoDerecha && horizontalInput > 0) {
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y); // Volteamos el jugador en el eje x.
        }
    }

    void LimitesEscena() {
        
        // Limites en el eje x.
        // Limite hacia la izquiera.
        if (transform.position.x < -xRange) {
            transform.position = new Vector2(-xRange, transform.position.y);
        }

        // Limite hacia la derecha.
        if (transform.position.x > xRange) {
            
            transform.position = new Vector2(xRange, transform.position.y);
        }
    }
}
