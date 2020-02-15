/*Dungeon of the Funky Orcs
 * A rogue-like RPG adventures designed by Mark Tasaka 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;

    public float waitToLoad = 4.0f;

    public string nextLevel;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //coroutine: happens at a different time rate than everything else
    public IEnumerator LevelEnd()
    {

        AudioManager.instance.NextLevel();

        PlayerController.instance.canMove = false;
        UIController.instance.StartFadeToBlack();

        //wait in the middle of a coroutine
        yield return new WaitForSeconds(waitToLoad);

        SceneManager.LoadScene(nextLevel);
    }

}
