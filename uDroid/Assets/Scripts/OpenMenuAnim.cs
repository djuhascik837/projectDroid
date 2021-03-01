using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMenuAnim : MonoBehaviour
{
    public AudioClip sound;
    public Animator anim;
    public Canvas canvas;


    // Start is called before the first frame update
    void Start()
    {
        anim.enabled = false;
        canvas.enabled = true;
    }

   public void pressButton()
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
        openAnim();
    }

    public void openAnim()
    {
        if (anim != null)
        {
            bool isOpen = anim.GetBool("open");
            anim.SetBool("open", !isOpen);
            anim.enabled = true;
        }
    }
}
