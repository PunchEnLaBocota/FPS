using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cube", menuName = "Cube")]

public class Cube : ScriptableObject
{
    //Salud máxima, sprite, color inicial, tiempo para cambiar de color

    /*
     * Hacer un generador de cubos que pille los datos de arriba puestos a través 
     * de diferentes Scriptable Objects
     */

    //Mi carta va a tener una imagen, un nombre, un ataque, una vida y un mana
    public Sprite spriteCube;
    public Color colorCube;
    public float maxHealth;
    public float timeToChangeColor;
}
