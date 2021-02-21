using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMenuAnim : MonoBehaviour
{
    public Button Text;
    public AudioClip sound;
    public Animator anim;
    public Canvas canvas;


    // Start is called before the first frame update
    void Start()
    {
        Text = Text.GetComponent<Button>();
        anim.enabled = false;
        canvas.enabled = true;
    }

   public void press()
    {
        Text.enabled = true;
        AudioSource.PlayClipAtPoint(sound, transform.position);
        //Animator anim = canvas.GetComponent<Animator>();
        if (anim != null)
        {
            bool isOpen = anim.GetBool("open");
            anim.SetBool("open", !isOpen);
            anim.enabled = true;
        }
    }
}
