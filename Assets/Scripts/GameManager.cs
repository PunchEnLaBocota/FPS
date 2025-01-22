using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Target targetSelect;
    public Color colorSelect;

    public Image healthImageUI;
    public Image healthImagePlayerUI;

    public Color[] colors;
    public float timeToChangeColor;
    public float damage;

    public GameObject arrow;
    public CanvasTarget canvasTarget;

    public static GameManager gameManager;

    public GameObject cubePrefab;
    public Cube[] cubeSO;//Array de scriptabe objects

    float timer;

    private void Awake()
    {
        gameManager = this;
    }

    void Start()
    {
        colorSelect = colors[(int)Random.Range(0, colors.Length)];
        healthImagePlayerUI.color = colorSelect;

        InvokeRepeating("CreateCubes", 3, 3);
    }

  
    void Update()
    {
        timer += Time.deltaTime;
        ChangeColor();
    }
    void ChangeColor()
    {
        if (timer >= timeToChangeColor)
        {
            //Tenemos un timer
            timer = 0;
            //La array de colores
            colorSelect = colors[(int)Random.Range(0, colors.Length)];
     
            healthImagePlayerUI.color = colorSelect;
          
        }
    }
    //Método que se va a encargar de comprobar si el player está disparando el cubo de color
    //correcto
    public void CheckColorTarget()
    {
        //Si estoy disparando al color erroneo, si el color del target es distinto
        //al color del player
        if(targetSelect  != null && targetSelect.colorTarget != colorSelect)
        {
            //Me quito vida
            healthImagePlayerUI.fillAmount -= damage;
        }
    }


    public void SelectTarget(Target target)
    {
        //Si targetSelect es igual a target, es decir si estoy seleccionando el target
        //que ya tengo marcado
        if(targetSelect == target)
        {
            //Activamos o desactivamos (dependiendo del estado que tenga) la flecha y la 
            //barra de la interfaz correspondiente a la vida del cubo
            arrow.SetActive(!arrow.activeInHierarchy);
            healthImageUI.gameObject.SetActive(!healthImageUI.gameObject.activeInHierarchy);
            //Si la flecha queda desactivada, significa que he deseleccionado el cubo y
            //por lo tanto mi target es nulo
            if (!arrow.activeInHierarchy) targetSelect = null;
        }
        else
        {
            //Activo flecha
            arrow.SetActive(true);
            //Posiciono la flecha
            canvasTarget.target = target.transform;
            //Activo la barrita de vida de la interfaz
            healthImageUI.gameObject.SetActive(true);
            //Asigno color
            healthImageUI.color = target.colorTarget;
            //Asigno vida
            healthImageUI.fillAmount = target.currentHealth / target.maxHealth;
            //Digo este es mi target
            targetSelect = target;

        }
    }
    public void DeathTarget()
    {
        //Desactiva flecha
        arrow.SetActive(false);
        //Desactiva barrita de vida de la interfaz
        healthImageUI.gameObject.SetActive(false);
        //Y el target a null
        targetSelect = null;
    }
    
    //La vamos a llamar desde el target cada vez que el cubo cambie de color
    //va a comprobar si en ese momento es el cubo seleccionado, si es que si,
    //cambiamos el color de la barra de la interfaz
    public void AmITargetSelected(Target target)
    {
        if (target == targetSelect) healthImageUI.color = target.colorTarget;
    }
    
    //Método que va a devolver un true si el target que le pasamos como párametro es igual 
    //al target que tenemos seleccionado, sino devolverá un falso
    public bool CheckTarget(Target target)
    {
        if (target == targetSelect) return true;
        else return false;
    }

    void CreateCubes()
    {
        //Instancia un cubo 
        GameObject cubeClone = Instantiate(cubePrefab) as GameObject;
        //Hacemos una variable TargetClone que coja el componente target
        Target targetClone = cubeClone.GetComponent<Target>();
        //Y otra que como el MovementTarget
        MovementTarget movementTargetClone = cubeClone.GetComponent<MovementTarget>();

        //Creamos un RandomRange y cobe un SO aleatorio
        int n = Random.Range(0, cubeSO.Length);//Coger un SO aleatorio

        //Asignamos, cogemos los valores de scriptable objects y se lo metemos al targetClone
        targetClone.maxHealth = cubeSO[n].maxHealth;
        targetClone.colorTarget = cubeSO[n].colorCube;
        targetClone.timeToChangeColor = cubeSO[n].timeToChangeColor;

        //Recorremos el array de Images que tiene el targetClone(spriteCubes)
        for(int i = 0; i < targetClone.spritesCube.Length; i++)
        {
            //Y en cada casilla, asignamos el sprite que tiene el Scriptable objects
            targetClone.spritesCube[i].sprite = cubeSO[n].spriteCube;
        }
        //La amplitud que sea entre 1 y 7
        movementTargetClone.amplitude = Random.Range(1, 7);
        //La frequencia que sea entre 1 y 4
        movementTargetClone.frequency = Random.Range(1, 4);
    }
}
