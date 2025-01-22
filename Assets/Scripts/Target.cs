using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public Cube cube;

    public float currentHealth;
    public float maxHealth;
    public ParticleSystem hitEffect;

    public Color[] colors;//Una array de colores
    public Color colorTarget;//El color que tiene el target actualmente
    public float timeToChangeColor;//El tiempo que va a tardar de color
    
    public Image healthImage;
    public Image[] spritesCube;
    //public Image spriteCard;

    float timer;//Un timer
    Renderer rend;//Accedemos al material con el componente meshrenderer

    private void Awake()
    {
        rend = GetComponent<Renderer>(); 
        //Hacemos la busqueda por etiqueta y dentro del gameobject que he encontrado accedo
        //al componente Image
        healthImage = GameObject.FindGameObjectWithTag("HealthTarget").GetComponent<Image>();   
    }

    void Start()
    {
        currentHealth = maxHealth;
        rend.material.color = colorTarget;//Esto lo hacemos para que al inicio le
                                          //asigne el color que le he puesto como color
                                          //target
       
        //maxHealth.float = cube.maxHealth.ToString();
        //spriteCard.sprite = cube.spriteCube;
        //colorTarget.color = cube.colorInicial;
        //timeToChangeColor.float = cube.colorInicial.ToString();
    }


    void Update()
    {
        timer += Time.deltaTime;
        ChangeColor();
    }
    void ChangeColor()
    {
        if(timer >= timeToChangeColor)
        {
            //Tenemos un timer
            timer = 0;
            //Una array de colores
            colorTarget = colors[(int)Random.Range(0, colors.Length)];
            //Cambiamos color
            rend.material.color = colorTarget;
            //Avisar al gamemanager de que el cubo ha cambiado de color
            GameManager.gameManager.AmITargetSelected(this);
        }
    }
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthImage.fillAmount = currentHealth/maxHealth;
        if (currentHealth <= 0)
        {
            Death();
        }
    }
    void Death()
    {
        //Llamaos al método DeathTarget del script GameManager
        GameManager.gameManager.DeathTarget();
        Destroy(gameObject);
    }
}
