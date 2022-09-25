using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class enemyControl : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] exitPoints; 
    public GameObject[] targetPoints;
    public float enemycreationTime;  //Düþman oluþturma süresi
    float health=100;       //Saldýrýlan nesnenin caný
    public Image HealthBar;
   
    public int enemyNumber; //Baþlangýç düþman sayýsý
    public static int survivingEnemy; //Kalan düþman sayýsý
    public TextMeshProUGUI survivingEnemyText;
    [Header("Screen")]
    public GameObject GameOverCanvas;  //Game over ekraný
    public GameObject winCanvas;       //Kazandýn ekraný

    public AudioSource gameMusic;

    void Start()
    {
        gameMusic=GetComponent<AudioSource>();
        gameMusic.Play();
        survivingEnemyText.text = enemyNumber.ToString();
        survivingEnemy = enemyNumber;
        
        StartCoroutine(randEnemy());
    }

    IEnumerator randEnemy()
    {
        

        while (true)
        {
            yield return new WaitForSeconds(enemycreationTime);

            if (enemyNumber!=0)
            {
            int enemy = Random.Range(0, 3);
            int exitPoint = Random.Range(0, 3);
            int targetPoint = Random.Range(0, 4);

            GameObject Obje=Instantiate(enemies[enemy], exitPoints[exitPoint].transform.position,Quaternion.identity);
            Obje.GetComponent<Enemy>().setGoal(targetPoints[targetPoint]);
            enemyNumber--;

            }
            
        }
    }   //Random düþman çýkma 

   public void updateEnemyCount() //Düþman sayýsýný güncelle
    {
        survivingEnemy--;
        if (survivingEnemy<=0)
        {
            winCanvas.SetActive(true);
            survivingEnemyText.text = "0";
            Time.timeScale = 0;
        }
        else
        {
            survivingEnemyText.text = survivingEnemy.ToString();
        }
       
    }

    public void Attack(float enemyHit)
    {
        health -= enemyHit;
        HealthBar.fillAmount = health / 100;
        if (health <= 0)
        {
            GameOver();
        }
    
    }

    void GameOver()
    {
        GameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }   //Game over ekraný

    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {

        Application.Quit();

    }
}
