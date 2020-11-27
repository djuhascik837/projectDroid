using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenIDE : MonoBehaviour
{
    public GameObject idePanel;

    public void StartIDEOpenAnim()
    {
        Animator anim = idePanel.GetComponent<Animator>();
        if (anim != null)
        {
            bool isOpen = anim.GetBool("open");
            anim.SetBool("open", !isOpen);
        }
    }

}
