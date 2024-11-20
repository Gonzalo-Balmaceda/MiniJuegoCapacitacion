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
    public float xRange = 11F;
    private bool mirandoDerecha = true;

    // Start is called before the first frame update
    void Start()
    {
      
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
