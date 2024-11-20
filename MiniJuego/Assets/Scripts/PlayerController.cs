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

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento del jugador.
        horizontalInput = Input.GetAxis("Horizontal"); // Obtengo el movimiento horizontal.
        transform.Translate(Vector2.right * horizontalInput * Time.deltaTime * speed); // Le damos el movimiento al jugador.

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
