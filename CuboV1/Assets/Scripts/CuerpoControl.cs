/*Librerias*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*Clase Principal*/
public class CuerpoControl : MonoBehaviour
{/*Variables*/
    public Joystick S1;
    public Joystick S2;
    public float Velocidad;
    public float VelocidadAngular;
    /*Metodos*/
    void Update()
    {
        transform.localPosition += Time.deltaTime * new Vector3(S1.Horizontal, 0, S1.Vertical) * Velocidad;
        transform.Rotate(Vector3.up, Time.deltaTime * S2.Horizontal * VelocidadAngular);
    }
}
