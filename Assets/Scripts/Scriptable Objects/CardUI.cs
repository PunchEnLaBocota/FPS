using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;    

public class CardUI : MonoBehaviour
{
    public Card card;//ScriptableObject

    public Image spriteUI;
    public TextMeshProUGUI nameCardUI;
    public TextMeshProUGUI attackUI;
    public TextMeshProUGUI healthUI;
    public TextMeshProUGUI manaUI;

    void Start()
    {
        //El sprite que va a aparecer en la interfaz (spriteUI.sprite va a ser igual a la
        //la variable del Script Card (card.spriteCard)
        spriteUI.sprite = card.spriteCard;
        nameCardUI.text = card.nameCard;
        attackUI.text = card.attack.ToString();
        healthUI.text = card.health.ToString();
        manaUI.text = card.mana.ToString();

        //Llamo a un método que está en el SO(ScriptableObject) card
        card.ShowName();
    }

   
    void Update()
    {
        
    }
}
