using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square_script : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("Square");
        Destroy(this.gameObject);
    }
}
