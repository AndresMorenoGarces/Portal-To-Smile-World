using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsGame : MonoBehaviour
{
    public GameObject settingsInterfaces;
    public GameObject generalCultureButtons;
    private string aAnswer, bAnswer, cAnswer;
    private string[] generalCultureCorrectAnswer;
    private bool isAudioPausedActive = false;
    private bool isSettingsActive = false;
    private bool isCorrectTheAnswer;
    private int randomInt;

    public void OpenSettings()
    {
        isSettingsActive = !isSettingsActive;
        isAudioPausedActive = !isAudioPausedActive;
        settingsInterfaces.SetActive(isSettingsActive);
        Time.timeScale = isSettingsActive ? 0 : 1;
        AudioListener.pause = isAudioPausedActive ? true : false;
    }
    public void LoadMenu()
    {
        DefaultValues();
        SceneManager.LoadScene("Menu");
    }

    bool isMuteActive = false;
    public void Mutebutton()
    {
        isMuteActive = !isMuteActive;
        AudioListener.volume = isMuteActive ? 0 : 1;
    }
    public void RestartCurrentLevel()
    {
        DefaultValues();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitButton()
    {
        DefaultValues();
        Application.Quit();
    }
    private void DefaultValues()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

    public void AAnswerButton()
    {
        generalCultureButtons.SetActive(false);

        if (aAnswer == generalCultureCorrectAnswer[randomInt])
            isCorrectTheAnswer = true;
        else
            isCorrectTheAnswer = false;
    }
    public void BAnswerButton()
    {
        generalCultureButtons.SetActive(false);

        if (bAnswer == generalCultureCorrectAnswer[randomInt])
            isCorrectTheAnswer = true;
        else
            isCorrectTheAnswer = false;
    }
    public void CAnswerButton()
    {
        generalCultureButtons.SetActive(false);

        if (cAnswer == generalCultureCorrectAnswer[randomInt])
            isCorrectTheAnswer = true;
        else
            isCorrectTheAnswer = false;
    }

    public void ReceiveRandomValue(int _randomQuestion)
    {
        randomInt = _randomQuestion;
    }
    public bool SendAnswerResult()
    {
        return isCorrectTheAnswer;
    }
}
