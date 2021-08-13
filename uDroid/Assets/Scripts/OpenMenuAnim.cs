using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMenuAnim : MonoBehaviour
{
    public Animator anim;
    public Canvas canvas;

    public GameObject optionsMenu;

    // Start is called before the first frame update
    void Start()
    {
        anim.enabled = false;
        canvas.enabled = true;
    }

   public void pressButton()
    {
        openAnim();
    }

    public void openAnim()
    {
        if (anim != null)
        {
            optionsMenu.SetActive(false);

            bool isOpen = anim.GetBool("open");
            anim.SetBool("open", !isOpen);
            anim.enabled = true;
        }
    }
}
