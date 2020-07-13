using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : MonoBehaviour, IDragHandler, IEndDragHandler
{ /*Variables*/
    public Canvas Padre;
    public float Radio;
    private Vector2 Axis;

    Vector3 PosInicial;

    /*Metodos*/

    public Vector2 axis
    {
        get { return Axis; }
    }

    public float Horizontal
    {
        get { return Axis.x; }
    }

    public float Vertical
    {
        get { return Axis.y; }
    }

    public bool IsMoving
    {
        get { return Axis != Vector2.zero; }
    }

    void Start()
    {
        PosInicial = transform.position;
    }

    public void OnDrag(PointerEventData point)
    {
        Vector2 Pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(Padre.transform as RectTransform, point.position, Padre.worldCamera, out Pos);
        Vector2 NewPos = Padre.transform.TransformPoint(Pos) - PosInicial;
        NewPos.x = Mathf.Clamp(NewPos.x, -Radio, Radio);
        NewPos.y = Mathf.Clamp(NewPos.y, -Radio, Radio);

        Axis = NewPos / Radio;

        transform.localPosition = NewPos;
    }

    public void OnEndDrag(PointerEventData point)
    {
        transform.position = PosInicial;
        Axis = Vector2.zero;
    }


}

