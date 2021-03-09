using UnityEngine;
using UnityEngine.UI;

public class OpenIDE : MonoBehaviour
{
    public GameObject idePanel;
    //// -- to be removed
    ////private CanvasGroup testPanel;
    ////private CanvasGroup levelOne;
    //public Text text;
    //public Text textInput;
    public GameObject[] challenges;
    public GameObject[] tutorials;
    public GameObject codingChallengePanel;

    private static int tutLevel = 0;

    public void StartIDEOpenAnim()
    {
        Animator anim = idePanel.GetComponent<Animator>();

        if (anim != null)
        {
            bool isOpen = anim.GetBool("open");

            if(isOpen)
            {
                foreach (var panel in challenges)
                {
                    panel.SetActive(false);
                }

                foreach (var tutorial in tutorials)
                {
                    tutorial.SetActive(false);
                }
                HideCodingChallengePanel(false);
            }

            anim.SetBool("open", !isOpen);
        } else
        {
            Debug.LogWarning("Anim == null");
        }
    }


    // -- to be removed
    //Variable for Select Random Challenge
    //private readonly string strIdePanel = "IDE - Panel";
    //private readonly string level2 = "Level 2 - Basic For Loop";
    //private readonly string level1 = "Level 1 - Basic If";
    //private readonly string tutHelloWorld = "Tutorial - HelloWorld";
    //private readonly string tutHWCodeConsole = "CodeConsole";

    public void StartRandomChallenge()
    {
        Debug.Log("Starting Challenge");
        HideCodingChallengePanel(true);

        int rand = RandomNumber(0, challenges.Length);

        switch (rand)
        {
            case 0:
                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(challenges, rand);
                break;
            case 1:
                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(challenges, rand);
                break;
            default:
                Debug.LogWarning("Challenges rand defaulted");
                break;
        }
    }

    public InputField[] tutorialInputFields1;
    public InputField[] tutorialInputFields2;
    public InputField[] tutorialInputFields3;
    public InputField[] tutorialInputFields4;
    public InputField[] tutorialInputFields5;
    public InputField[] tutorialInputFields6;
    public InputField[] tutorialInputFields7;
    public InputField[] tutorialInputFields8;
    public InputField[] tutorialInputFields9;
    public InputField[] tutorialInputFields10;
    public InputField[] tutorialInputFields11;
    public InputField[] tutorialInputFields12;
    public InputField[] tutorialInputFields13;

    public void StartTutorial()
    {
        Debug.Log("Starting Tutorial");

        switch (tutLevel)
        {
            case 0: // Hello World
                print("starting first tutorial");
                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(tutorials, tutLevel);
                SetInputSuccessToFalse();

                GameController.input = tutorialInputFields1[0];
                GameController.textFieldCompare = "Hello World";
                GameController.inputSuccess = true;

                GameController.numOfInputs = 1;
                break;
            case 1: // Comments
                print("starting second tutorial");
                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(tutorials, tutLevel);
                SetInputSuccessToFalse();

                // First input
                GameController.input = tutorialInputFields2[0];
                GameController.textFieldCompare = "Hello World";
                GameController.inputSuccess = true;

                GameController.numOfInputs = 1;
                break;
            case 2: // Variables
                print("starting third tutorial");
                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(tutorials, tutLevel);
                SetInputSuccessToFalse();

                // First input
                GameController.input = tutorialInputFields3[0];
                GameController.textFieldCompare = "Int";
                GameController.inputSuccess = true;

                // Second input
                GameController.input2 = tutorialInputFields3[1];
                GameController.textFieldCompare2 = "String";
                GameController.inputSuccess2 = true;

                // Third input
                GameController.input3 = tutorialInputFields3[2];
                GameController.textFieldCompare3 = "Bool";
                GameController.inputSuccess3 = true;

                GameController.numOfInputs = 3;
                break;
            case 3: // Operators
                print("starting fourth tutorial");
                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(tutorials, tutLevel);
                SetInputSuccessToFalse();

                GameController.input = tutorialInputFields4[0];
                GameController.textFieldCompare = "Hello World";

                GameController.numOfInputs = 1;
                break;
            case 4: // If Else
                print("starting fifth tutorial");
                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(tutorials, tutLevel);
                SetInputSuccessToFalse();

                GameController.input = tutorialInputFields5[0];
                print("need to work out multiple input fields actually -- not gonna work as i thought");
                Debug.LogWarning("!!! Add Text field compare string, currently: Hello World");
                GameController.textFieldCompare = "Hello World";

                break;
            case 5: // Switch
                print("starting sixth tutorial");
                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(tutorials, tutLevel);
                SetInputSuccessToFalse();

                GameController.input = tutorialInputFields6[0];
                print("need to work out multiple input fields actually -- not gonna work as i thought");
                Debug.LogWarning("!!! Add Text field compare string, currently: Hello World");
                GameController.textFieldCompare = "Hello World";

                break;
            case 6: // Break
                print("starting seventh tutorial");
                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(tutorials, tutLevel);
                SetInputSuccessToFalse();

                GameController.input = tutorialInputFields7[0];
                Debug.LogWarning("!!! Add Text field compare string, currently: Hello World");
                GameController.textFieldCompare = "Hello World";

                break;
            case 7: // For Loops
                print("starting seventh tutorial");
                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(tutorials, tutLevel);
                SetInputSuccessToFalse();

                GameController.input = tutorialInputFields8[0];
                Debug.LogWarning("!!! Add Text field compare string, currently: Hello World");
                GameController.textFieldCompare = "Hello World";

                break;
            case 8: // While Loops
                print("starting seventh tutorial");
                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(tutorials, tutLevel);
                SetInputSuccessToFalse();

                GameController.input = tutorialInputFields9[0];
                Debug.LogWarning("!!! Add Text field compare string, currently: Hello World");
                GameController.textFieldCompare = "Hello World";

                break;
            case 9: // Methods
                print("starting seventh tutorial");
                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(tutorials, tutLevel);
                SetInputSuccessToFalse();

                GameController.input = tutorialInputFields10[0];
                Debug.LogWarning("!!! Add Text field compare string, currently: Hello World");
                GameController.textFieldCompare = "Hello World";

                break;
            case 10: // Arrays
                print("starting seventh tutorial");
                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(tutorials, tutLevel);
                SetInputSuccessToFalse();

                GameController.input = tutorialInputFields11[0];
                Debug.LogWarning("!!! Add Text field compare string, currently: Hello World");
                GameController.textFieldCompare = "Hello World";

                break;
            case 11: // Casts
                print("starting seventh tutorial");
                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(tutorials, tutLevel);
                SetInputSuccessToFalse();

                GameController.input = tutorialInputFields11[0];
                Debug.LogWarning("!!! Add Text field compare string, currently: Hello World");
                GameController.textFieldCompare = "Hello World";

                break;
            case 12: // Math
                print("starting seventh tutorial");
                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(tutorials, tutLevel);
                SetInputSuccessToFalse();

                GameController.input = tutorialInputFields11[0];
                Debug.LogWarning("!!! Add Text field compare string, currently: Hello World");
                GameController.textFieldCompare = "Hello World";

                break;
            case 13:
                print("Tutorial complete");
                break;
            default:
                Debug.LogWarning("Tutorial tutLevel defaulted");
                tutLevel = 0;
                break;
        }
    }

    public void StartNextTutorial()
    {
        Debug.Log("Starting Next Tutorial");

        tutLevel++;
        StartTutorial();
    }

    private void SetInputSuccessToFalse()
    {
        GameController.inputSuccess = false;
        GameController.inputSuccess2 = false;
        GameController.inputSuccess3 = false;
        GameController.inputSuccess4 = false;
    }

    private void SetTutorialsOrChallengesInactive(GameObject[] tutorials, int ignore)
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
}

// --- all to be removed -- leaving for documentation

//public CanvasGroup[] CreateCanvasGroupRef()
//{
//    CanvasGroup[] canvasGroups = new CanvasGroup[2];
//    canvasGroups[0] = GameObject.Find(strIdePanel).transform.Find(level2).GetComponent<CanvasGroup>();
//    canvasGroups[1] = GameObject.Find(strIdePanel).transform.Find(level1).GetComponent<CanvasGroup>();
//    //canvasGroups[2] = GameObject.Find(strIdePanel).transform.Find(tutHelloWorld).GetComponent<CanvasGroup>();

//    return canvasGroups;
//}

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


//public void SelectRandomChallenge()
//{
//    Debug.Log("starting Random Challenge");
//    HideCodingChallengePanel(true);

//    CanvasGroup[] canvasGroups = CreateCanvasGroupRef();
//    string ideEditor = "IDE Editor - Input Field";

//    InputField level2Field = GameObject.Find(strIdePanel).transform.Find(level2).Find(ideEditor).GetComponent<InputField>();
//    InputField level1Field = GameObject.Find(strIdePanel).transform.Find(level1).Find(ideEditor).GetComponent<InputField>();
//    // -- to be removed
//    //InputField tutHelloWorldField = GameObject.Find(strIdePanel).transform.Find(tutHelloWorld).Find(tutHWCodeConsole).Find(ideEditor).GetComponent<InputField>();

//    if (isActive)
//    {
//        int randSwitcher = RandomNumber(0, canvasGroups.Length);
//        isActive = false;

//        if (randSwitcher == 0)
//        {
//            if (!isAnimOpen)
//            {
//                CanvasGroup testPanel = null;

//                foreach (var panel in challenges)
//                {
//                    if (panel.name.Equals(level2))
//                    {
//                        testPanel = panel.GetComponent<CanvasGroup>();
//                        panel.SetActive(true);
//                    }
//                }

//                GameController.input = level2Field;
//                GameController.textFieldCompare = "Test Panel Test";

//                testPanel.alpha = 1;
//                //CanvasAlphaSetter(testPanel);
//            }
//            else
//            {
//                foreach (var canvas in canvasGroups)
//                {
//                    canvas.alpha = 0;
//                }
//            }
//        }
//        else if (randSwitcher == 1)
//        {
//            if (!isAnimOpen)
//            {
//                CanvasGroup levelOne = null;

//                foreach (var panel in challenges)
//                {
//                    if (panel.name.Equals(level1))
//                    {
//                        levelOne = panel.GetComponent<CanvasGroup>();
//                        panel.SetActive(true);
//                    }
//                }

//                GameController.input = level1Field;
//                GameController.textFieldCompare = "Level One Test";

//                levelOne.alpha = 1;
//                //CanvasAlphaSetter(levelOne);
//            }
//            else
//            {
//                foreach (var canvas in canvasGroups)
//                {
//                    canvas.alpha = 0;
//                }
//            }
//        }
//    }
//    else
//    {
//        foreach (var panel in challenges)
//        {
//            panel.SetActive(false);
//        }
//        isActive = true;
//    }
//}
