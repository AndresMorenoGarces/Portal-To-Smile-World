using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private Character charCReference;
    private PlatformScript platformScript;
    private GameQuestions gameQReference;
    private ButtonsGame buttonsGame;
    private AnimationScript animReference;
    private UIGame uIGameReference;
    private CameraManager camMReference;

    private GameCycle gameCycle = 0;
    private ActiveCamera activeCamera = 0;
    private MovingType movingType = 0;
    private PlatformType platformType = 0;
    private TurnState turnState = 0;
    private QuestionState questionState;

    private float timerToLooseQuestion = 10, skyboxRotationSpeed;
    private string[] generalCultureQuestions;
    private GameObject[] interfacesArray;
    private Transform specificVoidTransform, specificCharacterTransform, temporalTransform, targetTransform;
    private List<int> intAdvanceLimit = new List<int>(3), intReverseLimit = new List<int>(3), intMisteryLimit = new List<int>(3),
        randomAnswerList = new List<int>(3), randomWrongAnswer = new List<int>(2);
    private int turnOfPlayer = 0, diceNumber, moveAlterateSign = 1, currentTarget = 0, temporalTarget = 0, randomQuestion = 0, 
        randomSelections = 0, randomWrongSelections = 0;
    private int[] playersCurrentTarget = new int[4], playersTemporalTarget = new int[4];

    [Header("Interface Canvas")]  public GameObject gameInterfaceFP; public GameObject diceInterface; public GameObject gameInterfaceTP; public GameObject tvInterface;
    [Header("Transforms")] public Transform emptyDiceTransform;
    [Header("Arrays")] public Transform[] voidCharacters = new Transform[4]; public Transform[] bodyCharacters = new Transform[4];  public Transform[] wayPoints; public Vector3[] diceFaceRotation;

    private void ShowCurrentPlayer()
    {
        if (gameCycle == GameCycle.FirstStep)
        {
            turnState = TurnState.Started;
            AlternateInterface(0);
            activeCamera = ActiveCamera.FirstPerson;
            camMReference.TypesOfCameras(activeCamera);
            UpdateCurrentData();
            AnimationScript.instance.TapAnimation(true);
            uIGameReference.ShowPlayerTexts(turnOfPlayer);
            gameCycle = GameCycle.SecondStep;
        }
        void UpdateCurrentData()
        {
            temporalTarget = playersTemporalTarget[turnOfPlayer];
            currentTarget = playersCurrentTarget[turnOfPlayer];
        }
    }
    private void ShowDice()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && gameCycle == GameCycle.SecondStep)
        {
            AlternateInterface(1);
            activeCamera = ActiveCamera.DiceCamera;
            camMReference.TypesOfCameras(activeCamera);
            uIGameReference.ShowDiceMoves(1, diceNumber);
            AnimationScript.instance.TapAnimation(false);
            AnimationScript.instance.DiceAnimations(true);
            AudioScript.instance.DiceAudioState(0);
            diceNumber = Random.Range(1, 7);
            movingType = MovingType.Advancing;
            StartCoroutine(TimeToDiceAnimation());
        }
        IEnumerator TimeToDiceAnimation()
        {
            yield return new WaitForSeconds(1);
            AudioScript.instance.DiceAudioState(1);
            uIGameReference.ShowDiceMoves(2, diceNumber);
            yield return new WaitForSeconds(2);
            AudioScript.instance.DiceAudioState(2);
            AnimationScript.instance.DiceAnimations(false);
            emptyDiceTransform.eulerAngles = diceFaceRotation[diceNumber - 1];
            yield return new WaitForSeconds(2);
            AudioScript.instance.DiceAudioState(3);
            gameCycle = GameCycle.ThirdStep;
        }
    }
    private void WaypointDisplacing()
    {
        if (gameCycle == GameCycle.ThirdStep)
        {
            AlternateInterface(2);
            activeCamera = ActiveCamera.ThirdPerson;
            camMReference.TypesOfCameras(activeCamera);
            charCReference.PlayerMove(specificVoidTransform, wayPoints, UpdatingTemporalTarget(), UpdatingCurrentTarget());
            uIGameReference.ShowMovingText(movingType, diceNumber, UpdatingCurrentTarget());
        }
        int UpdatingTemporalTarget() 
        {
            if (specificVoidTransform.position == temporalTransform.position && temporalTarget < currentTarget || temporalTarget > currentTarget)
            {
                switch ((int)movingType)
                {
                    case 0: break;
                    case 1: temporalTarget++; moveAlterateSign = 1; break;
                    case 2: temporalTarget--; moveAlterateSign = -1; break;
                    case 3: StartCoroutine(TimeToWaitAfterTeleport()); break;
                }
                IEnumerator TimeToWaitAfterTeleport()
                {
                    yield return new WaitForSeconds(2f);
                    temporalTarget = currentTarget;
                }
            }
            return temporalTarget;
        }
        int UpdatingCurrentTarget() 
        {
            if (specificVoidTransform.position == temporalTransform.position && specificVoidTransform.position == targetTransform.position)
            {
                if (currentTarget + diceNumber <= wayPoints.Length - 1)
                    currentTarget = temporalTarget + (diceNumber * moveAlterateSign);
                else if (temporalTarget + (diceNumber * moveAlterateSign) < 0)
                    currentTarget = 0;
                else
                    currentTarget = wayPoints.Length - 1;
            }
            return currentTarget;
        }
        if (temporalTarget == currentTarget)
        {
            StartCoroutine(TimeWaitingToTVEvent());
            IEnumerator TimeWaitingToTVEvent()
            {
                yield return new WaitForSeconds(2f);
                gameCycle = GameCycle.FourthStep;
            }
        }
    }
    private void ShowTVQuestions()
    {
        if (gameCycle == GameCycle.FourthStep)
        {
            AlternateInterface(3);
            RandomTestSelection();
            activeCamera = ActiveCamera.TVCamera;
            camMReference.TypesOfCameras(activeCamera);
            animReference.TVAnimations(true);

            timerToLooseQuestion = 20f;
            while (timerToLooseQuestion > 0)
            {
                if (questionState == QuestionState.Answered)
                {
                    AnswerResult(buttonsGame.SendAnswerResult());
                    break;
                }
                else if (questionState == QuestionState.NotAnswered)
                {
                    timerToLooseQuestion -= Time.time;
                    if (timerToLooseQuestion <= 0)
                        StartCoroutine(TimeToEndTurn(4f));
                }
            }
        }
        void RandomTestSelection()
        {
            randomQuestion = Random.Range(0, generalCultureQuestions.Length);
            buttonsGame.ReceiveRandomValue(randomQuestion);
            uIGameReference.QuestionAssignation(randomQuestion, 0);
            randomAnswerList = new List<int>(3);
            randomWrongAnswer = new List<int>(2);
            for (int i = 0; i < randomAnswerList.Capacity; i++)
            {
                randomSelections = Random.Range(0, randomAnswerList.Capacity);
                randomWrongSelections = Random.Range(0, randomWrongAnswer.Capacity);
                if (randomAnswerList.Capacity != 1)
                {
                    if (randomWrongAnswer.Capacity != 1)
                        uIGameReference.AnswerAssignations(1, randomSelections, randomQuestion);
                    else
                        uIGameReference.AnswerAssignations(2, randomSelections, randomQuestion);
                    randomAnswerList.Remove(randomSelections);
                    randomWrongAnswer.Remove(randomWrongSelections);
                }
                else
                    uIGameReference.AnswerAssignations(3, randomSelections, randomQuestion);
            }
        }
        void AnswerResult(bool isAcerted)
        {
            platformScript.SendCurrentPlatform(wayPoints[currentTarget].position, platformType);
            if (isAcerted && platformType != PlatformType.Neutral)
            {
                MovingTypeAssignation(true);
                gameCycle = GameCycle.ThirdStep;
            }
            else if (isAcerted == false && platformType != PlatformType.Neutral)
                MovingTypeAssignation(false);

            uIGameReference.QuestionAssignation(randomQuestion, 1);
            if (platformType == PlatformType.Neutral)
                StartCoroutine(TimeToEndTurn(4f));
        }
        void MovingTypeAssignation(bool isAcerted)
        {
            if (isAcerted)
                switch ((int)platformType)
                {
                    case 0: movingType = MovingType.Waiting; break;
                    case 1: movingType = MovingType.Advancing; break;
                    case 2: movingType = MovingType.Waiting; break;
                    case 3: movingType = MovingType.Teleporting; break;
                }
            else
                switch ((int)platformType)
                {
                    case 0: movingType = MovingType.Waiting; break;
                    case 1: movingType = MovingType.Waiting; break;
                    case 2: movingType = MovingType.Reversing; break;
                    case 3: movingType = MovingType.Teleporting; break;
                }
        }
        void EventLimiter() // funcion que cumple el proposito de limitar el maximo de movimiento
        {
            //if (intAdvanceLimit >= 2)
            //    isLimAdvanceOver = true;
            //else if (intReverseLimit >= 2)
            //    isLimReverseOver = true;
            //else if (intMisteryLimit >= 2)
            //    isLimMisteryOver = true;
            //else
            //{
            //    isLimAdvanceOver = false;
            //    isLimReverseOver = false;
            //    isLimMisteryOver = false;
            //}
        }
    }
    private IEnumerator TimeToEndTurn(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        turnState = TurnState.Ended;
        animReference.TVAnimations(false);
        activeCamera = ActiveCamera.FirstPerson;
        camMReference.TypesOfCameras(activeCamera);
        yield return new WaitForSeconds(1.5f);
        StopAllCoroutines();
        gameCycle = GameCycle.LastStep;
    }
    private void SavePlayerValues()
    {
        if (gameCycle == GameCycle.LastStep)
        {
            playersTemporalTarget[turnOfPlayer] = temporalTarget;
            playersCurrentTarget[turnOfPlayer] = currentTarget;
            UpdatePlayerTurn();
            gameCycle = GameCycle.FirstStep;
        }
        void UpdatePlayerTurn()
        {
            charCReference.PlayerResituate(turnOfPlayer, voidCharacters);
            if (turnOfPlayer < voidCharacters.Length - 1)
                turnOfPlayer++;
            else
                turnOfPlayer = 0;
        }
    }

    private void AlternateInterface(int interfaceNum)
    {
        for (int i = 0; i < interfacesArray.Length; i++)
            interfacesArray[i].SetActive(false);
        interfacesArray[interfaceNum].SetActive(true);
    }
    private void GameSequencyBucle()
    {
        ShowCurrentPlayer();
        ShowDice();
        WaypointDisplacing();
        ShowTVQuestions();
        SavePlayerValues();
    }

    private void Awake()
    {
        charCReference = gameObject.GetComponent<Character>();
        platformScript = GameObject.FindGameObjectWithTag("Platforms").GetComponent<PlatformScript>();
        gameQReference = gameObject.GetComponent<GameQuestions>();
        buttonsGame = gameObject.GetComponent<ButtonsGame>();
        animReference = gameObject.GetComponent<AnimationScript>();
        uIGameReference = gameObject.GetComponent<UIGame>();
        camMReference = gameObject.GetComponent<CameraManager>();
    }
    private void Start()
    {
        gameQReference.SendGeneralCQuestionsValues(generalCultureQuestions);
        temporalTransform = wayPoints[0].transform;
        timerToLooseQuestion = 20;
        interfacesArray = new GameObject[4] { gameInterfaceFP, diceInterface, gameInterfaceTP, tvInterface };
    }
    private void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * skyboxRotationSpeed);
        specificVoidTransform = voidCharacters[turnOfPlayer].transform;
        specificCharacterTransform = bodyCharacters[turnOfPlayer].transform;
        temporalTransform = wayPoints[temporalTarget].transform;
        targetTransform = wayPoints[currentTarget].transform;

        GameSequencyBucle();
    }
}
