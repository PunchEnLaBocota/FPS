using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTarget : MonoBehaviour
{
    public float frequency;
    public float amplitude;

    void Start()
    {
        
    }

   
    void Update()
    {
        //Movimiento de coseno en el eje x
        float x = Mathf.Cos(Time.time * frequency) * amplitude;
        
        float y = transform.position.y;
        
        //Movimiento de seno en el eje z
        float z = Mathf.Sin(Time.time * frequency) * amplitude;
       
        /*
        Movimiento de seno en el eje y
        float y = Mathf.Sin(Time.time * frequency) * amplitude;

        En la x y la z permanezca igual, pero en la y va a ser igual al seno del tiempo
        Se moveria del -1 al 1 por ejemplo siguiendo la forma de la onda del seno
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
        */
        
        //Al juntar un movimiento de coseno y un movimiento de seno,
        //se hace un movimiento circular
        transform.position = new Vector3(x, y, z);
    }
}
