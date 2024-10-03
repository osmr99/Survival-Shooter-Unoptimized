using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
	public float restartDelay = 5f;
    

    Animator anim;
    //float restartTimer;

    int id_GameOver = Animator.StringToHash("GameOver");

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void gameOver() // Unity Event that gets Invoked by PlayerHealth script
    {
        //anim.SetTrigger("GameOver");
        anim.SetTrigger(id_GameOver);
        StartCoroutine(restartGame());
    }

    IEnumerator restartGame()
    {
        yield return new WaitForSeconds(restartDelay);

        SceneManager.LoadScene("Main Menu");
    }


    /*void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");

			restartTimer += Time.deltaTime;
            Debug.Log("here2");
            if (restartTimer >= restartDelay) {
                Debug.Log("here");
                Application.LoadLevel(Application.loadedLevel);
                Debug.Log("here1");
                //SceneManager.LoadScene(Application.loadedLevel);
            }
        }
    }*/

}
