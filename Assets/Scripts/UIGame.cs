using UnityEngine;
using UnityEngine.UI;

public class UIGame : MonoBehaviour
{
    public Text aAnswer;
    public Text bAnswer;
    public Text cAnswer;
    public Text playerTurnText;
    public Text moveSpacesText;
    public Text leftPlaces;
    public Text currentPlace;
    public Text eventTvText;
    public Text moveDiceText;
    public Text counterQuestionText;

    private string currentMovingText;
    private string answerResult;
    private string[] sentencesArray;
    private string[] randomAnswerWord;
    private string[] generalCultureCorrectAnswer, generalCultureWrongAnswer, generalCultureWrongAnswer2, generalCultureQuestion;
    private GameQuestions gQReferences;
    private GameSentences gSReferences;

    public void ShowPlayerTexts(int turnOfPlayer)
    {
        playerTurnText.text = "Player " + (turnOfPlayer + 1) + " Turn";
    }
    public void ShowDiceMoves(int showDicePart, int diceNumber)
    {
        if (showDicePart == 1)
            moveDiceText.text = "How Much... \nCan You Advance?";
        else if (showDicePart == 2)
        {
            if (diceNumber == 1)
                moveDiceText.text = "Move... \nspace";
            else
                moveDiceText.text = "Move... \nspaces";
        }
    }
    public void ShowMovingText(MovingType movingType, int diceNumber, int currentTarget)
    {
        if (diceNumber > 1)
            switch ((int)movingType)
            {
                case 0:
                    moveSpacesText.text = "Advance " + (diceNumber--); ; break;
                case 1:
                    moveSpacesText.text = "Reverse " + (diceNumber--); break;
                case 2:
                    moveSpacesText.text = "Teleporting  to \n" + currentTarget + " point"; break;
            }
    }
    public void QuestionAssignation(int randomQuestion, int parts)
    {
        switch (parts)
        {
            case 0: eventTvText.text = generalCultureQuestion[randomQuestion]; break;
            case 1: eventTvText.text = sentencesArray[Random.Range(0, sentencesArray.Length)]; break;
        }
    }
    public void AnswerAssignations(int answerFinal, int randomSelections, int randomQuestion)
    {
        if (answerFinal == 1)
            randomAnswerWord[randomSelections] = generalCultureWrongAnswer[randomQuestion];
        else if (answerFinal == 2)
            randomAnswerWord[randomSelections] = generalCultureWrongAnswer2[randomQuestion];
        else if (answerFinal == 3)
            answerResult = generalCultureCorrectAnswer[randomQuestion];
    }
    public void ShowPlatformsMoves(int temporalCurrentTarget, int currentTarget, Transform[] wayPoints)
    {
        if (temporalCurrentTarget != currentTarget)
            currentPlace.text = "Moving At \nPlatform \n" + temporalCurrentTarget;
        else
            currentPlace.text = "Current \nPlatform \n" + currentTarget;

        leftPlaces.text = "Lefting \nPlatforms \n" + ((wayPoints.Length - 1) - temporalCurrentTarget);
    }

    private void Start()
    {
        randomAnswerWord = new string[3] { aAnswer.text, bAnswer.text, cAnswer.text };
        gQReferences = gameObject.GetComponent<GameQuestions>();
        gSReferences = gameObject.GetComponent<GameSentences>();
        gQReferences.SendGeneralCAnswersValues(generalCultureCorrectAnswer, generalCultureWrongAnswer, generalCultureWrongAnswer2);
        gSReferences.SendStringArray(sentencesArray);
    }
}
