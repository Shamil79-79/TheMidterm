using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public GameObject StartMenu, InGameMenu, GameOverMenu;
    public GameObject countdownTextObject;
    public TextMeshProUGUI countdownText;
    public float countdownDuration = 1f;

    void Start()
    {
        StartMenu.SetActive(true);
        InGameMenu.SetActive(false);
        GameOverMenu.SetActive(false);
        StartCoroutine(Countdown());
    }

    public void ResetTheTextSize()
    {
        countdownTextObject.transform.localScale = new Vector3(4f, 4f, 4f);
        countdownTextObject.transform.DOScale(new Vector3(7f, 7f, 7f), countdownDuration);
    }

    IEnumerator Countdown()
    {
        ResetTheTextSize();
        countdownText.text = "3";
        yield return new WaitForSeconds(countdownDuration);
        ResetTheTextSize();
        countdownText.text = "2";
        yield return new WaitForSeconds(countdownDuration);
        ResetTheTextSize();
        countdownText.text = "1";
        yield return new WaitForSeconds(countdownDuration);
        ResetTheTextSize();
        countdownText.text = "BEAT HIM UP!";
        yield return new WaitForSeconds(countdownDuration);
        StartMenu.SetActive(false);
        InGameMenu.SetActive(true);

    }
}
