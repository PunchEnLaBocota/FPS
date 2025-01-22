using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Metemos un atributo CreateAssetMenu que me va a permitir a partir de esta plantila crear
//diferentes dataconteiners en el menú de unity
//fileName es que nombre le vamos a poner cada vez que creemos una nueva carta y el menuName
//como se va a llamar ese menú donde voy a poder crear esos dataconteiners
[CreateAssetMenu(fileName = "New Card", menuName = "Card")]

/*Los scriptstableObjects son prefabs de datos, son archivos que ocupan muy poco.
Por ejemplo en un juega de cartas vas a tener muchas cartas con su ataque,vida,mana,ect.
En vez de crearnos un prefab por cada carta, creamos un solo prefab (nuestro modelo base)
y vamos pasando los datos/sprites de la carta enconcreto que utilicemos.
Esto puede servir para un monton de enemigos diferentes, un montoón de cartas,
de objectos de una tienda con sus stats, ect.*/

//Herede de ScriptableObject no de MonoBehaviour. La clase hijo, es decir (Card) puede
//usar las variables y las funciones de la clase padre que en este caso es (ScriptableObject)
public class Card : ScriptableObject
{
    //Mi carta va a tener una imagen, un nombre, un ataque, una vida y un mana
    public Sprite spriteCard;
    public string nameCard;
    public int attack;
    public int health;
    public int mana;

    public void ShowName()
    {
        Debug.Log("Name card: " + nameCard);
    }
}
