using UnityEngine;
using UnityEngine.UI;

public class OpenIDE : MonoBehaviour
{
    public GameObject idePanel;
    // -- to be removed
    //private CanvasGroup testPanel;
    //private CanvasGroup levelOne;
    public Text text;
    public Text textInput;
    public GameObject[] panels;
    public GameObject[] tutorials;
    public GameObject codingChallengePanel;

    private bool isAnimOpen;
    private static bool isActive = true;
    private static int tutLevel = 0;

    public void StartIDEOpenAnim()
    {
        Animator anim = idePanel.GetComponent<Animator>();
        CanvasGroup[] canvasGroups = CreateCanvasGroupRef();

        if (anim != null)
        {
            bool isOpen = anim.GetBool("open");

            if(isOpen)
            {
                foreach (var panel in panels)
                {
                    panel.SetActive(false);
                }

                foreach (var canvas in canvasGroups)
                {
                    canvas.alpha = 0;
                }

                isActive = true;
                HideCodingChallengePanel(false);
            }

            anim.SetBool("open", !isOpen);
            isAnimOpen = isOpen;
        } else
        {
            Debug.LogWarning("Anim == null");
        }
    }

    //Variable for Select Random Challenge
    private readonly string strIdePanel = "IDE - Panel";
    private readonly string tester = "TextEditor - Panel";
    private readonly string level1 = "Level 1 - Basic If";

    // -- to be removed
    //private readonly string tutHelloWorld = "Tutorial - HelloWorld";
    //private readonly string tutHWCodeConsole = "CodeConsole";

    public void SelectRandomChallenge()
    {
        Debug.Log("starting Random Challenge");
        HideCodingChallengePanel(true);

        CanvasGroup[] canvasGroups = CreateCanvasGroupRef();
        string ideEditor = "IDE Editor - Input Field";

        InputField testerField = GameObject.Find(strIdePanel).transform.Find(tester).Find(ideEditor).GetComponent<InputField>();
        InputField level1Field = GameObject.Find(strIdePanel).transform.Find(level1).Find(ideEditor).GetComponent<InputField>();
        // -- to be removed
        //InputField tutHelloWorldField = GameObject.Find(strIdePanel).transform.Find(tutHelloWorld).Find(tutHWCodeConsole).Find(ideEditor).GetComponent<InputField>();

        if (isActive)
        {
            int randSwitcher = RandomNumber(0, canvasGroups.Length);
            isActive = false;

            if (randSwitcher == 0)
            {
                if (!isAnimOpen)
                {
                    CanvasGroup testPanel = null;

                    foreach (var panel in panels)
                    {
                        if (panel.name.Equals(tester))
                        {
                            testPanel = panel.GetComponent<CanvasGroup>();
                            panel.SetActive(true);
                        }
                    }

                    GameController.input = testerField;
                    GameController.textFieldCompare = "Test Panel Test";

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
                    CanvasGroup levelOne = null;

                    foreach (var panel in panels)
                    {
                        if (panel.name.Equals(level1))
                        {
                            levelOne = panel.GetComponent<CanvasGroup>();
                            panel.SetActive(true);
                        }
                    }

                    GameController.input = level1Field;
                    GameController.textFieldCompare = "Level One Test";

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
            //Testing purposed -- remove later
            //else if (randSwitcher == 2)
            //{
            //    if (!isAnimOpen)
            //    {
            //        CanvasGroup tutHelloWorldCanvas = null;

            //        foreach (var panel in panels)
            //        {
            //            if (panel.name.Equals(tutHelloWorld))
            //            {
            //                tutHelloWorldCanvas = panel.GetComponent<CanvasGroup>();
            //                panel.SetActive(true);
            //            }
            //        }

            //        GameController.input = tutHelloWorldField;
            //        GameController.textFieldCompare = "Hello World";

            //        tutHelloWorldCanvas.alpha = 1;
            //        //CanvasAlphaSetter(levelOne);
            //    }
            //    else
            //    {
            //        foreach (var canvas in canvasGroups)
            //        {
            //            canvas.alpha = 0;
            //        }
            //    }
            //}
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

    public InputField[] tutorialInputFields;

    public void StartTutorial()
    {
        Debug.Log("Starting Tutorial");

        switch (tutLevel)
        {
            case 0:
                print("starting first tutorial");
                HideCodingChallengePanel(true);
                SetTutorialsInactive(tutorials, tutLevel);

                GameController.input = tutorialInputFields[0];
                GameController.textFieldCompare = "Hello World";

                tutLevel++;
                break;
            case 1:
                print("starting second tutorial");
                HideCodingChallengePanel(true);
                SetTutorialsInactive(tutorials, tutLevel);
                tutLevel++;
                break;
            case 2:
                print("starting third tutorial");
                HideCodingChallengePanel(true);
                SetTutorialsInactive(tutorials, tutLevel);
                tutLevel++;
                break;
            case 3:
                print("starting fourth tutorial");
                HideCodingChallengePanel(true);
                SetTutorialsInactive(tutorials, tutLevel);
                tutLevel++;
                break;
            case 4:
                print("starting fifth tutorial");
                HideCodingChallengePanel(true);
                SetTutorialsInactive(tutorials, tutLevel);
                tutLevel++;
                break;
            case 5:
                print("Tutorial complete");
                break;
            default:
                Debug.LogWarning("tutLevel isn't 0,1,2,3 or 4");
                tutLevel = 0;
                break;
        }
    }

    private void SetTutorialsInactive(GameObject[] tutorials, int ignore)
    {
        for (int i = 0; i < tutorials.Length; i++)
        {
            if(i != ignore)
            {
                tutorials[i].SetActive(false);
            }
            else
            {
                tutorials[i].SetActive(true);
            }
        }
    }

    private void HideCodingChallengePanel(bool hide)
    {
        if (codingChallengePanel != null)
        {
            if (hide == true)
            {
                codingChallengePanel.SetActive(false);
            }
            else
            {
                codingChallengePanel.SetActive(true);
            }
        }
        else
        {
            Debug.LogWarning("codingChalllengePanle == null in OpenIDE - \"IDE - Panel\"");
        }
    }

    private int RandomNumber(int min, int max)
    {
        System.Random random = new System.Random();
        return random.Next(min, max);
    }

    // To be Removed as it started causing issues - after changing code to include tutorial button found this was the issue
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
        CanvasGroup[] canvasGroups = new CanvasGroup[2];
        canvasGroups[0] = GameObject.Find(strIdePanel).transform.Find(tester).GetComponent<CanvasGroup>();
        canvasGroups[1] = GameObject.Find(strIdePanel).transform.Find(level1).GetComponent<CanvasGroup>();
        //canvasGroups[2] = GameObject.Find(strIdePanel).transform.Find(tutHelloWorld).GetComponent<CanvasGroup>();

        return canvasGroups;
    }
}
