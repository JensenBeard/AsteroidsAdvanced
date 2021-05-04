using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTrigger : MonoBehaviour
{
    [SerializeField] private int entranceDirection;
    public Animator transition;

    //Activates when player collides with trigger.
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
            //set the direction the ship is travelling (0 top, 1 right, 2 bottom, 3, left)
            PlayerPrefs.SetInt("EntranceDir", entranceDirection);
        }
    }

    //Activates transition animation and switches scene.
    IEnumerator LoadLevel(int levelIndex) 
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        if (levelIndex > 6) 
        {
            levelIndex = 3;
        }
        SceneManager.LoadScene(levelIndex);
    }
}
