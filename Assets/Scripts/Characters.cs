using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Characters : MonoBehaviour
{
    public Animator playerAnimController;
    public Animator enemyAnimController;
    public int enemyHealth = 100;
    public int damage;
    public TextMeshProUGUI enemyHealthText;
    public GameObject hitEffect1;
    public GameObject hitEffect2;
    private GameObject currentHitEffect;
    public GameObject StartMenu, InGameMenu, GameOverMenu;
    public Slider healthBar;

    void Start()
    {
        transform.position = new Vector3(-2f, 8f, 0f);
        StartCoroutine(FallDown());
    }

    IEnumerator FallDown()
    {
        yield return new WaitForSeconds(4f);
        playerAnimController.SetBool("IsFalling", true);
        transform.DOMoveY(-1.5f, 0.6f);
        yield return new WaitForSeconds(0.2f);
        playerAnimController.SetBool("IsFalling", false);
    }

    void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            Attack1();
        }

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            Attack2();
        }
    }

    public void GameOver()
    {
        enemyAnimController.SetBool("Death", true);
        enemyHealthText.text = "Enemy Health: 0";
        hitEffect1.SetActive(false);
        hitEffect2.SetActive(false);
        GameOverMenu.SetActive(true);
        StartMenu.SetActive(false);
        InGameMenu.SetActive(false);
    }

    public void Attack1()
    {
        playerAnimController.SetTrigger("Attack1");
        damage = 20;
        currentHitEffect = hitEffect1;
        Invoke("GiveDamage", 0.7f);
    }
    public void Attack2()
    {
        playerAnimController.SetTrigger("Attack2");
        damage = 10;
        currentHitEffect = hitEffect2;
        Invoke("GiveDamage", 0.8f);
    }

    public void GiveDamage()
    {
        enemyAnimController.SetTrigger("Hurt");
        enemyHealth -= damage;
        healthBar.value = enemyHealth;
        currentHitEffect.SetActive(false);
        currentHitEffect.SetActive(true);
        enemyHealthText.text = "Enemy Health: " + enemyHealth.ToString();
        if (enemyHealth <= 0)
        {
            GameOver();
        }
    }
}
