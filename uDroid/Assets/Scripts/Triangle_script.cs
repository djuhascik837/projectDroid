using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle_script : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("Triangle");
        Destroy(this.gameObject);
    }
}
