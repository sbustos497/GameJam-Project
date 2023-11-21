using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazomouse : MonoBehaviour
{
    public Transform targetTransform;
    public Transform originalTransform;
    public float launchSpeed = 2f;
    public float returnSpeed = 1f;
    private bool isLaunching = false;

    void Start()
    {
        targetTransform = GetComponent<Transform>();
        originalTransform = targetTransform;
    }

    void Update()
    {
       //quiero que se haga la accion hasta que suelte el boton del mouse
        if (Input.GetMouseButtonDown(0) && !isLaunching)
        {
            StartCoroutine(LaunchAndReturn());
        }
    }

    IEnumerator LaunchAndReturn()
    {
        isLaunching = true;

        // Guardar la posición original
        Vector3 originalPosition = targetTransform.position;

        // Calcular la dirección hacia donde se lanzará el objeto por medio del mouse
        Vector3 launchDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - originalPosition;

        // Lanzar el objeto hacia adelante pero que este tenga un rango limitado , tambien si sigo manteniedo el click izquierdo del mouse que sea capaz de manegar la linea como me plasca
        while (Vector3.Distance(targetTransform.position, originalPosition) < 7f)
        {

            targetTransform.position += launchDirection * Time.deltaTime * launchSpeed;
            yield return null;
        }


        

        // Esperar un momento antes de regresar
        //si suelto el click del mouse que regrese a su posicion original si sigo manteniendo el click que se quede en la posicion que se encuentra
         if (Input.GetMouseButtonUp(0))
        {
            yield return new WaitForSeconds(0.5f);
        }
       



        // Regresar el objeto a su posición original
         if (Input.GetMouseButtonUp(0))
        {
            while (Vector3.Distance(targetTransform.position, originalPosition) > 0.1f)
            {
                targetTransform.position = Vector3.MoveTowards(targetTransform.position, originalPosition, Time.deltaTime * returnSpeed);
                yield return null;
            }

        }
            

        // Restaurar la posición original
        targetTransform.position = originalPosition;

        isLaunching = false;
    }

  
    void OnMouseDown()
    {
        Debug.Log("Mouse Down");
    }
}




    