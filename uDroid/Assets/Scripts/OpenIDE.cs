﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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
    public GameObject optionsMenu;
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
            optionsMenu.SetActive(false);

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

    public InputField[] ChallengeInputFields1;
    public InputField[] ChallengeInputFields2;
    public InputField[] ChallengeInputFields3;
    public InputField[] ChallengeInputFields4;
    public InputField[] ChallengeInputFields5;
    public InputField[] ChallengeInputFields6;
    public InputField[] ChallengeInputFields7;
    public InputField[] ChallengeInputFields8;
    public InputField[] ChallengeInputFields9;
    public InputField[] ChallengeInputFields10;
    public InputField[] ChallengeInputFields11;
    public InputField[] ChallengeInputFields12;

    public void StartRandomChallenge()
    {
        Debug.Log("Starting Challenge");
        HideCodingChallengePanel(true);

        GameController.isChallenge = true;

        int rand = RandomNumber(0, challenges.Length);

        switch (rand)
        {
            case 0: //1
                ChallengeInputFields1[0].text = "";
                ChallengeInputFields1[1].text = "";

                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(challenges, rand);
                SetInputSuccessToFalse();

                GameController.input = ChallengeInputFields1[0];
                GameController.textFieldCompare = "currentDay";
                GameController.inputSuccess = true;

                GameController.input2 = ChallengeInputFields1[1];
                GameController.textFieldCompare2 = "Its Friday!";
                GameController.inputSuccess2 = true;

                GameController.numOfInputs = 2;

                StartHints.messageToDisplay = "Don't forget to use the equal to operator when comparing with currentDay";
                break;
            case 1: //2
                ChallengeInputFields2[0].text = "";
                ChallengeInputFields2[1].text = "";

                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(challenges, rand);
                SetInputSuccessToFalse();

                GameController.input = ChallengeInputFields2[0];
                GameController.textFieldCompare = "For";
                GameController.inputSuccess = true;

                GameController.input2 = ChallengeInputFields2[1];
                GameController.textFieldCompare2 = "i++";
                GameController.inputSuccess2 = true;

                GameController.numOfInputs = 2;

                StartHints.messageToDisplay = "Which for loop are we using? Also don't forget to use the increment operator";
                break;
            case 2: //3
                ChallengeInputFields3[0].text = "";
                ChallengeInputFields3[1].text = "";
                ChallengeInputFields3[2].text = "";

                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(challenges, rand);
                SetInputSuccessToFalse();

                GameController.input = ChallengeInputFields3[0];
                GameController.textFieldCompare = "10";
                GameController.inputSuccess = true;

                GameController.input2 = ChallengeInputFields3[1];
                GameController.textFieldCompare2 = "10";
                GameController.inputSuccess2 = true;

                GameController.input3 = ChallengeInputFields3[2];
                GameController.textFieldCompare3 = "i";
                GameController.inputSuccess3 = true;

                GameController.numOfInputs = 3;

                StartHints.messageToDisplay = "How many elements do we want? Also which int should we call within the for loop to print all the numbers?";
                break;
            case 3: //4
                ChallengeInputFields4[0].text = "";

                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(challenges, rand);
                SetInputSuccessToFalse();

                GameController.input = ChallengeInputFields4[0];
                GameController.textFieldCompare = "float";
                GameController.inputSuccess = true;

                GameController.numOfInputs = 1;

                StartHints.messageToDisplay = "Round to int only accepts float numbers";
                break;
            case 4: //5
                ChallengeInputFields5[0].text = "";

                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(challenges, rand);
                SetInputSuccessToFalse();

                GameController.input = ChallengeInputFields5[0];
                GameController.textFieldCompare = "displayWindow()";
                GameController.inputSuccess = true;

                GameController.numOfInputs = 1;

                StartHints.messageToDisplay = "We need to call the displayWindow method within main. Don't forget to use () when calling a method";
                break;
            case 5: //6
                ChallengeInputFields6[0].text = "";
                ChallengeInputFields6[1].text = "";

                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(challenges, rand);
                SetInputSuccessToFalse();

                GameController.input = ChallengeInputFields6[0];
                GameController.textFieldCompare = "int";
                GameController.inputSuccess = true;

                GameController.input2 = ChallengeInputFields6[1];
                GameController.textFieldCompare2 = "*";
                GameController.inputSuccess2 = true;

                GameController.numOfInputs = 2;

                StartHints.messageToDisplay = "Check what type of variable a is. Also check the name of the method";
                break;
            case 6: //7
                ChallengeInputFields7[0].text = "";
                ChallengeInputFields7[1].text = "";

                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(challenges, rand);
                SetInputSuccessToFalse();

                GameController.input = ChallengeInputFields7[0];
                GameController.textFieldCompare = "String";
                GameController.inputSuccess = true;

                GameController.input2 = ChallengeInputFields7[1];
                GameController.textFieldCompare2 = "str";
                GameController.inputSuccess2 = true;

                GameController.numOfInputs = 2;

                StartHints.messageToDisplay = "We need to check for the variable string, and then display the string in the console";
                break;
            case 7: //8
                ChallengeInputFields8[0].text = "";
                ChallengeInputFields8[1].text = "";
                ChallengeInputFields8[2].text = "";
                ChallengeInputFields8[3].text = "";

                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(challenges, rand);
                SetInputSuccessToFalse();

                GameController.input = ChallengeInputFields8[0];
                GameController.textFieldCompare = "%";
                GameController.inputSuccess = true;

                GameController.input2 = ChallengeInputFields8[1];
                GameController.textFieldCompare2 = "2";
                GameController.inputSuccess2 = true;

                GameController.input3 = ChallengeInputFields8[2];
                GameController.textFieldCompare3 = "%";
                GameController.inputSuccess3 = true;

                GameController.input4 = ChallengeInputFields8[3];
                GameController.textFieldCompare4 = "1";
                GameController.inputSuccess4 = true;

                GameController.numOfInputs = 4;

                StartHints.messageToDisplay = "Don't forget to use the modulo operator, the rest is just good old math";
                break;
            case 8: //9
                ChallengeInputFields9[0].text = "";
                ChallengeInputFields9[1].text = "";
                ChallengeInputFields9[2].text = "";

                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(challenges, rand);
                SetInputSuccessToFalse();

                GameController.input = ChallengeInputFields9[0];
                GameController.textFieldCompare = "isActive";
                GameController.inputSuccess = true;

                GameController.input2 = ChallengeInputFields9[1];
                GameController.textFieldCompare2 = "counter";
                GameController.inputSuccess2 = true;

                GameController.input3 = ChallengeInputFields9[2];
                GameController.textFieldCompare3 = "counter";
                GameController.inputSuccess3 = true;

                GameController.numOfInputs = 3;

                StartHints.messageToDisplay = "Use the isActive and the counter variable in the right place.";
                break;
            case 9: //10
                ChallengeInputFields10[0].text = "";

                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(challenges, rand);
                SetInputSuccessToFalse();

                GameController.input = ChallengeInputFields10[0];
                GameController.textFieldCompare = "Random";
                GameController.inputSuccess = true;

                GameController.numOfInputs = 1;

                StartHints.messageToDisplay = "We need to call the Random method here, don't forget to use () when making a method call";
                break;
            case 10: //11
                ChallengeInputFields11[0].text = "";

                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(challenges, rand);
                SetInputSuccessToFalse();

                GameController.input = ChallengeInputFields11[0];
                GameController.textFieldCompare = "Return";
                GameController.inputSuccess = true;

                GameController.numOfInputs = 1;

                StartHints.messageToDisplay = "We need to return the value of num1 and 2";
                break;
            case 11: //12
                ChallengeInputFields12[0].text = "";
                ChallengeInputFields12[1].text = "";

                HideCodingChallengePanel(true);
                SetTutorialsOrChallengesInactive(challenges, rand);
                SetInputSuccessToFalse();

                GameController.input = ChallengeInputFields12[0];
                GameController.textFieldCompare = "str";
                GameController.inputSuccess = true;

                GameController.input2 = ChallengeInputFields12[1];
                GameController.textFieldCompare2 = "else";
                GameController.inputSuccess2 = true;

                GameController.numOfInputs = 2;

                StartHints.messageToDisplay = "Don't forget the name of the string and also think about the structure of an if else statement.";
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

        GameController.isChallenge = false;

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
