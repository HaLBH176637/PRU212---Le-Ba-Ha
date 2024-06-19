using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Threading.Tasks;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] RectTransform pausePanelRect, pauseButtonRect, timerRect, EDeathRect, ESpawnRect, BestScoreRect, HealthBarRect;
    [SerializeField] float topPosY, middlePosY;
    [SerializeField] float tweenDuration;
    [SerializeField] CanvasGroup canvasGroup;
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        PausePanelIntro();
    }
    public void Home()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public async void Resume()
    {
        await PausePanelOuttro();
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    void PausePanelIntro()
    {
        canvasGroup.DOFade(1, tweenDuration).SetUpdate(true);
        pausePanelRect.DOAnchorPosY(middlePosY, tweenDuration).SetUpdate(true);
        pauseButtonRect.DOAnchorPosX(100, tweenDuration).SetUpdate(true);
        timerRect.DOAnchorPosY(300, tweenDuration).SetUpdate(true);
        EDeathRect.DOAnchorPosY(300, tweenDuration).SetUpdate(true);
        ESpawnRect.DOAnchorPosY(300, tweenDuration).SetUpdate(true);
        BestScoreRect.DOAnchorPosY(300, tweenDuration).SetUpdate(true);
        HealthBarRect.DOAnchorPosX(-300, tweenDuration).SetUpdate(true);
    }
    async Task PausePanelOuttro()
    {
        canvasGroup.DOFade(0, tweenDuration).SetUpdate(true);
        await pausePanelRect.DOAnchorPosY(topPosY, tweenDuration).SetUpdate(true).AsyncWaitForCompletion();
        pauseButtonRect.DOAnchorPosX(-10, tweenDuration).SetUpdate(true);
        timerRect.DOAnchorPosY(145, tweenDuration).SetUpdate(true);
        EDeathRect.DOAnchorPosY(145, tweenDuration).SetUpdate(true);
        ESpawnRect.DOAnchorPosY(145, tweenDuration).SetUpdate(true);
        BestScoreRect.DOAnchorPosY(145, tweenDuration).SetUpdate(true);
        HealthBarRect.DOAnchorPosX(120, tweenDuration).SetUpdate(true);
    }
}
