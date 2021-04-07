using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject player = new GameObject();

    //rotacion del arma 
    [SerializeField] public float rotationSpeed; //velocidad con la que rotara el arma
    [SerializeField] public bool isRotating; //El hacha rota por si misma cuando es lanzada, una vez llega a su objetivo se detiene

    //movimiento del arma
    [SerializeField] public float moveSpeed; //velocidad de lanzamiento
    public Vector3 targetPosition; //registra la posicion del mouse luego de hacer un clic
    public bool isClicked; //registra si el jugador dio un clic en la pantalla

    //llamar arma
    public Transform playerTrans; //se usa para obtener acceso al objeto jugador
    public bool canCallBack; //define si el arma puede ir desde su posicion actual hasta el jugador
    public bool returnWeapon; //si esta variable es verdad, la función de llamar al arma se activa

    public void Start()  
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //obtenemos acceso al objeto "jugador"
    }

    public void Update()
    {
        selfRotation();

        if (Input.GetMouseButtonDown(0) && isClicked == false) //si el jugador da clic y aun no se ha registrado uno
        {
            isClicked = true; //se registra el clic

            targetPosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, //se registra la posición del mouse en x y y despues de 
                                         Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0); //haber dado el clic
        }

        if (isClicked) //si el jugador da un clic el hacha es lanzada
        {
            throwWeapon();
        }

        if (Input.GetMouseButtonDown(1) && canCallBack) //si el jugador da un clic y la variable permite llamar al arma
        {
            returnWeapon = true;
        }

        if (returnWeapon) //si la variable es verdadera
        {
            callWeaponn(); //el arma regresa al jugador
        }

        //if (Vector2.Distance(transform.position, targetPosition) <= 1) //si la distancia entre el arma y el objetivo es mejor o igual a 1
        //{
        //    isRotating = false; //el arma deja de rotar
        //    canCallBack = true; //el jugador puede llamar al arma
        //}

        if (transform.position == player.transform.GetChild(1).position)
        {
            isRotating = false; //el arma deja de rotar
            canCallBack = false; //el jugador aun no puede llamar al arma
            returnWeapon = false; //el jugador no puede llamar al arma
            isClicked = false; //para el que el jugador pueda seleccionar un nuevo objetivo una vez que el arma regresa

            transform.rotation = new Quaternion(0, 0, 0, 0);
        }

        if (transform.position == targetPosition)
        {
            isRotating = false;
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }

        //if (Vector2.Distance(transform.position, playerTrans.position) <= -1) //si la distancia entre la posicion actual del arma y el jugador es menor o igual a 1
        //{
        //    isRotating = false; //el arma deja de rotar
        //    canCallBack = false; //el jugador aun no puede llamar al arma
        //    returnWeapon = false; //el jugador no puede llamar al arma
        //    isClicked = false; //para el que el jugador pueda seleccionar un nuevo objetivo una vez que el arma regresa

        //    transform.rotation = new Quaternion(0, 0, 0, 0); //luego de llegar al jugador, el arma retoma su posicion original
        //}
    }

    public void throwWeapon() //lanzar el arma
    {
        isRotating = true; //el arma comienza a rotar una vez lanzada
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime); //el arma se mueve a la posición del mouse
    
        canCallBack = true;
    }                                                                                                             // que la variable registró

    public void selfRotation()
    {
        if (isRotating) //si la variable es verdad el hacha rotrará en el eje z 
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
        else //en cualquier otro caso dejara de rotar
        {
            transform.Rotate(0, 0, 0);
        }
    }

    public void callWeaponn()
    {
        isRotating = true; 
        var originalAxePosition = Vector2.MoveTowards(transform.position, player.transform.GetChild(1).position, moveSpeed * 5 * Time.deltaTime); 
        transform.position = originalAxePosition;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        isClicked = true;
    }

}
