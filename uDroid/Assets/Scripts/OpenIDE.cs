using UnityEngine;
using UnityEngine.UI;

public class OpenIDE : MonoBehaviour
{
    public GameObject idePanel;
    private CanvasGroup testPanel;
    private CanvasGroup levelOne;
    public Text text;
    public Text textInput;
    public GameObject[] panels;
    private bool isAnimOpen;
    private static bool isActive = true;
    private readonly string strIdePanel = "IDE - Panel";
    private readonly string tester = "TextEditor - Panel";
    private readonly string level1 = "Level 1 - Basic If";

    public void StartIDEOpenAnim()
    {
        Animator anim = idePanel.GetComponent<Animator>();

        if (anim != null)
        {
            bool isOpen = anim.GetBool("open");



            anim.SetBool("open", !isOpen);
            isAnimOpen = isOpen;
        } else
        {
            Debug.LogWarning("Anim == null");
        }
    }

    public void SelectRandomChallenge()
    {
        Debug.Log("starting Random Challenge");

        CanvasGroup[] canvasGroups = CreateCanvasGroupRef();
        string ideEditor = "IDE Editor - Input Field";

        InputField testerField = GameObject.Find(strIdePanel).transform.Find(tester).Find(ideEditor).GetComponent<InputField>();
        InputField level1Field = GameObject.Find(strIdePanel).transform.Find(level1).Find(ideEditor).GetComponent<InputField>();

        if (isActive)
        {
            int randSwitcher = RandomNumber(0, canvasGroups.Length);
            isActive = false;

            if (randSwitcher == 0)
            {
                if (!isAnimOpen)
                {
                    foreach (var panel in panels)
                    {
                        if (panel.name.Equals(tester)) panel.SetActive(true);
                    }

                    GameController.input = testerField;

                    text.text = "Test for IDE Panel Tester";
                    textInput.text = "\"Test me\"";

                    testPanel.alpha = 1;
                    //CanvasAlphaSetter(testPanel);
                }
                else
                {
                    foreach (var canvas in canvasGroups)
                    {
                        canvas.alpha = 0;
                    }
                }
            }
            else if (randSwitcher == 1)
            {
                if (!isAnimOpen)
                {
                    foreach (var panel in panels)
                    {
                        if (panel.name.Equals(level1)) panel.SetActive(true);
                    }

                    GameController.input = level1Field;

                    text.text = "Test for Level 1 Basic if";
                    textInput.text = "\"Test me 2\"";

                    levelOne.alpha = 1;
                    //CanvasAlphaSetter(levelOne);
                }
                else
                {
                    foreach (var canvas in canvasGroups)
                    {
                        canvas.alpha = 0;
                    }
                }
            }
        }
        else
        {
            foreach (var panel in panels)
            {
                panel.SetActive(false);
            }
            isActive = true;
        }
    }

    private int RandomNumber(int min, int max)
    {
        System.Random random = new System.Random();
        return random.Next(min, max);
    }

    // Removed as it started causing issues - after changing code to include tutorial button found this was the issue
    //private void CanvasAlphaSetter(CanvasGroup canvasGroup)
    //{
    //    if (canvasGroup.alpha != 0)
    //    {
    //        canvasGroup.alpha = 0;
    //    }
    //    else if (canvasGroup.alpha != 1)
    //    {
    //        canvasGroup.alpha = 1;
    //    }
    //}

    public CanvasGroup[] CreateCanvasGroupRef()
    {
        testPanel = GameObject.Find(strIdePanel).transform.Find(tester).GetComponent<CanvasGroup>();
        levelOne = GameObject.Find(strIdePanel).transform.Find(level1).GetComponent<CanvasGroup>();
        CanvasGroup[] canvasGroups = new CanvasGroup[2];
        canvasGroups[0] = testPanel;
        canvasGroups[1] = levelOne;

        return canvasGroups;
    }
}
