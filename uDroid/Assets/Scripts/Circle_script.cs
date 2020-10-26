using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_script : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("Circle");
        Destroy(this.gameObject);
    }
}
