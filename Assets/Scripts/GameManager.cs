using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject enemySpawner;
    public GameObject GameOverGO;
    public GameObject scoreUITextGO;
    public GameObject TimeCounterGO;
    public GameObject GameTileGO;

    public enum GameManagerState
    {
        Opening,
        GamePlay,
        GameOver,
    }

    GameManagerState GMState;


    void Start()
    {
        GMState = GameManagerState.Opening;
    }

    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case GameManagerState.Opening:

                GameOverGO.SetActive(false);

                GameTileGO.SetActive(true);

                playButton.SetActive(true);


                break;
            case GameManagerState.GamePlay:

                scoreUITextGO.GetComponent<GameScore>().Score = 0;

                playButton.SetActive(false);

                GameTileGO.SetActive(false);

                playerShip.GetComponent<PlayerControl>().Init();

                enemySpawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();

                TimeCounterGO.GetComponent<TimeCounter>().StartTimeCounter();

                break;
            case GameManagerState.GameOver:

                TimeCounterGO.GetComponent<TimeCounter>().StopTimeCounter();

                enemySpawner.GetComponent<EnemySpawner>().UnscheduleEnemySpawner();

                GameOverGO.SetActive(true);


                Invoke("ChangeToOpeningState", 5f);

                break;
        }
    }

    


    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }



    public void StartGamePlay()
    {
        GMState = GameManagerState.GamePlay;
        UpdateGameManagerState();
    }


    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }
}