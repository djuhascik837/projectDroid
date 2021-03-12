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
    public GameObject runScriptParticles;
    public GameObject codingChallengePanel;

    public static int tutLevel = 0;

    private bool closeTutorial = false;

    public void StartIDEOpenAnim()
    {
        Animator anim = idePanel.GetComponent<Animator>();
        closeTutorial = false;

        if (anim != null)
        {
            bool isOpen = anim.GetBool("open");

            runScriptParticles.SetActive(false);

            if (isOpen)
            {
                foreach (var panel in challenges)
                {
                    panel.SetActive(false);
                }

                foreach (var tutorial in tutorials)
                {
                    tutorial.SetActive(false);
                }

                runScriptParticles.SetActive(true);
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
                tutorialInputFields1[0].text = "";
                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(tutorials, tutLevel);
                SetInputSuccessToFalse();

                GameController.input = tutorialInputFields1[0];
                GameController.textFieldCompare = "Hello World";
                GameController.inputSuccess = true;

                StartHints.messageToDisplay = "Try typing Hello World into the empty field - This is not case sensitive.";
                GameController.numOfInputs = 1;
                break;
            case 1: // Comments
                print("starting second tutorial");
                tutorialInputFields2[0].text = "";
                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(tutorials, tutLevel);
                SetInputSuccessToFalse();

                // First input
                GameController.input = tutorialInputFields2[0];
                //GameController.textFieldCompare = "Hello World";
                GameController.commentsCheck = true;
                GameController.inputSuccess = true;

                StartHints.messageToDisplay = "Try typing into the box with // as the first two characters.";
                GameController.numOfInputs = 1;
                break;
            case 2: // Variables
                print("starting third tutorial");
                tutorialInputFields3[0].text = "";
                tutorialInputFields3[1].text = "";
                tutorialInputFields3[2].text = "";
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

                StartHints.messageToDisplay = "The primitive code version of an Integer, the name given to the variable that consists of a list of Chars and Lastly used for True/False Statements.";
                GameController.numOfInputs = 3;
                break;
            case 3: // Operators
                print("starting fourth tutorial");
                tutorialInputFields4[0].text = "";
                tutorialInputFields4[1].text = "";
                tutorialInputFields4[2].text = "";
                tutorialInputFields4[3].text = "";
                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(tutorials, tutLevel);
                SetInputSuccessToFalse();

                // First input
                GameController.input = tutorialInputFields4[0];
                GameController.textFieldCompare = "+";
                GameController.inputSuccess = true;

                // Second input
                GameController.input2 = tutorialInputFields4[1];
                GameController.textFieldCompare2 = "-";
                GameController.inputSuccess2 = true;

                // Third input
                GameController.input3 = tutorialInputFields4[2];
                GameController.textFieldCompare3 = "*";
                GameController.inputSuccess3 = true;

                // Fourth Input
                GameController.input4 = tutorialInputFields4[3];
                GameController.textFieldCompare4 = "/";
                GameController.inputSuccess4 = true;

                StartHints.messageToDisplay = "The four most used mathematical symbols '/', '*', '+', '-'.";
                GameController.numOfInputs = 4;
                break;
            case 4: // If Else
                print("starting fifth tutorial");
                tutorialInputFields5[0].text = "";
                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(tutorials, tutLevel);
                SetInputSuccessToFalse();

                GameController.input = tutorialInputFields5[0];
                GameController.textFieldCompare = "If";
                GameController.inputSuccess = true;

                GameController.numOfInputs = 1;
                StartHints.messageToDisplay = "If something is true, then do something, otherwise do something else.";
                break;
            case 5: // Switch
                print("starting sixth tutorial");
                tutorialInputFields6[0].text = "";
                tutorialInputFields6[1].text = "";
                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(tutorials, tutLevel);
                SetInputSuccessToFalse();

                GameController.input = tutorialInputFields6[0];
                GameController.textFieldCompare = "Switch";
                GameController.inputSuccess = true;

                GameController.input2 = tutorialInputFields6[1];
                GameController.textFieldCompare2 = "Case";
                GameController.inputSuccess2 = true;

                GameController.numOfInputs = 2;
                StartHints.messageToDisplay = "Each case in a block of a switch has a different name/number which is referred to as an identifier.";
                break;
            case 6: // Break
                print("starting seventh tutorial");
                tutorialInputFields7[0].text = "";
                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(tutorials, tutLevel);
                SetInputSuccessToFalse();

                GameController.input = tutorialInputFields7[0];
                GameController.textFieldCompare = "Break";
                GameController.inputSuccess = true;

                GameController.numOfInputs = 1;
                StartHints.messageToDisplay = "This is often used to exit a loop early, or to break free from the loop.";
                break;
            case 7: // For Loops
                print("starting eighth tutorial");
                tutorialInputFields8[0].text = "";
                tutorialInputFields8[1].text = "";
                tutorialInputFields8[2].text = "";
                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(tutorials, tutLevel);
                SetInputSuccessToFalse();

                GameController.input = tutorialInputFields8[0];
                GameController.textFieldCompare = "For";
                GameController.inputSuccess = true;

                GameController.input2 = tutorialInputFields8[1];
                GameController.textFieldCompare2 = "Int";
                GameController.inputSuccess2 = true;

                GameController.input3 = tutorialInputFields8[2];
                GameController.textFieldCompare3 = "<";
                GameController.inputSuccess3 = true;

                GameController.numOfInputs = 3;
                StartHints.messageToDisplay = "For this hint you will be given the required inputs but not in the correct order. 'Int', '<' and 'for'.";
                break;
            case 8: // While Loops
                print("starting ninth tutorial");
                tutorialInputFields9[0].text = "";
                tutorialInputFields9[1].text = "";
                tutorialInputFields9[2].text = "";
                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(tutorials, tutLevel);
                SetInputSuccessToFalse();

                GameController.input = tutorialInputFields9[0];
                GameController.textFieldCompare = "While";
                GameController.inputSuccess = true;

                GameController.input2 = tutorialInputFields9[1];
                GameController.textFieldCompare2 = "<";
                GameController.inputSuccess2 = true;

                GameController.input3 = tutorialInputFields9[2];
                GameController.textFieldCompare3 = "i";
                GameController.inputSuccess3 = true;

                GameController.numOfInputs = 3;
                StartHints.messageToDisplay = "For this hint you will be given the required inputs but not necessarily in the correct order. 'i', 'while' and '<'.";

                break;
            case 9: // Methods
                print("starting tenth tutorial");
                tutorialInputFields10[0].text = "";
                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(tutorials, tutLevel);
                SetInputSuccessToFalse();

                GameController.input = tutorialInputFields10[0];
                //GameController.textFieldCompare = "While";
                GameController.methodsCheck = true;
                GameController.inputSuccess = true;

                GameController.numOfInputs = 1;
                StartHints.messageToDisplay = "All you are required to do here is define a method name, any name as long as it ends with '()' no parenthesis are required.";
                break;
            case 10: // Arrays
                print("starting eleventh tutorial");
                tutorialInputFields11[0].text = "";
                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(tutorials, tutLevel);
                SetInputSuccessToFalse();

                GameController.input = tutorialInputFields11[0];
                GameController.textFieldCompare = "Double[]";
                GameController.inputSuccess = true;

                GameController.numOfInputs = 1;
                StartHints.messageToDisplay = "In order to define an array of any var type all is required is [] after typing the variable type.";
                break;
            case 11: // Casts
                print("starting twelfth tutorial");
                tutorialInputFields12[0].text = "";
                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(tutorials, tutLevel);
                SetInputSuccessToFalse();

                GameController.input = tutorialInputFields12[0];
                GameController.textFieldCompare = "int";
                GameController.inputSuccess = true;

                GameController.numOfInputs = 1;
                StartHints.messageToDisplay = "Casting is used to convert one data type to another and is often indicated with (variable Type) before the right-hand side argument.";
                break;
            case 12: // Math
                print("starting thirteenth tutorial");
                tutorialInputFields13[0].text = "";
                tutorialInputFields13[1].text = "";
                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(tutorials, tutLevel);
                SetInputSuccessToFalse();

                GameController.input = tutorialInputFields13[0];
                GameController.textFieldCompare = "Max";
                GameController.inputSuccess = true;

                GameController.input2 = tutorialInputFields13[1];
                GameController.textFieldCompare2 = "y";
                GameController.inputSuccess2 = true;

                GameController.numOfInputs = 2;
                StartHints.messageToDisplay = "In order to find the highest number between two you would be looking for the Maximum value of the given numbers.";
                break;
            case 13:
                print("Tutorial complete");
                closeTutorial = true;
                SetTutorialsOrChallengesInactive(tutorials, tutLevel);
                break;
            default:
                Debug.LogWarning("Tutorial tutLevel defaulted");
                tutLevel = 0;
                break;
        }
    }

    public void Submit()
    {
        GameController.submit = true;

        GameController script = GameObject.Find("GameplayManager").GetComponent<GameController>();
        script.GetInput();

        GameController.submit = false;
    }

    public void StartNextTutorial()
    {
        if (tutLevel != tutorials.Length)
        {
            Debug.Log("Starting Next Tutorial");

            tutLevel++;
            StartTutorial();
        }
        else
        {
            closeTutorial = true;
            //print("Tutorials have ended");
        }
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
        if (closeTutorial)
        {
            //print("Tutorials have ended");
            for (int i = 0; i < tutorials.Length; i++)
            {
                tutorials[i].SetActive(false);
                HideCodingChallengePanel(false);
                tutLevel = 0;
                closeTutorial = false;
            }
        }
        else
        {
            for (int i = 0; i < tutorials.Length; i++)
            {

                if (i != ignore)
                {
                    tutorials[i].SetActive(false);
                }
                else
                {
                    tutorials[i].SetActive(true);
                }
            }
        }
    }

    private void HideCodingChallengePanel(bool hide)
    {
        if (codingChallengePanel != null)
        {
            if (hide == true)
            {
                print("Hiding Coding Challenge");
                codingChallengePanel.SetActive(false);
            }
            else
            {
                print("Showing Coding Challenge");
                codingChallengePanel.SetActive(true);
            }
        }
        else
        {
            Debug.LogWarning("codingChalllengePanel == null in OpenIDE - \"IDE - Panel\"");
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
