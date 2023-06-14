using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] private float playBall_Xmax = 7f, playBall_Xmin = -7f;

    private GameObject myPlayBall;
    public GameObject PlayBall_Prefab;
    private float playBallPos;

    public int[] Bowls = new int[6];

    public int collectedBalls, totalBall;

    private int playerNumber, computerNumber;

    private int player_Score, computer_Score;
    
    private bool isPlay;

    public GameObject SelectNumber_Screen, Gameplay_Screen, Final_Screen;
    
    public Text player_SelectedNumber_Text, computer_SelectedNumber_Text, player_Score_Text, computer_Score_Text;

    private void Awake()
    {
        SelectNumber_Screen.SetActive(true);
        Gameplay_Screen.SetActive(false);
        Final_Screen.SetActive(false);
        isPlay = false;
    }

    private void Start()
    {
        collectedBalls = 0;
        playerNumber = 0;
        player_Score = 0;
        computerNumber = 0;
        computer_Score = 0;
    }


    private void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space))&& isPlay)
        {
            isPlay = false;
            EnabledPlayBall();
        }

    }

    void EnabledPlayBall()
    {
        myPlayBall = Instantiate(PlayBall_Prefab).gameObject;
        playBallPos = Random.Range(playBall_Xmax, playBall_Xmin);
        myPlayBall.transform.position = new Vector2(playBallPos, 0f);
        totalBall = myPlayBall.transform.childCount;
    }



    public void SelectedNumber()
    {
        switch (int.Parse(EventSystem.current.currentSelectedGameObject.name.ToString()))
        {
            case 1:
                playerNumber = 1;
                break;

            case 2:
                playerNumber = 2;
                break;

            case 3:
                playerNumber = 3;
                break;

            case 4:
                playerNumber = 4;
                break;

            case 5:
                playerNumber = 5;
                break;

            case 6:
                playerNumber = 6;
                break;
        }
        computerNumber = Random.Range(1, 7);

        player_SelectedNumber_Text.text = playerNumber.ToString();
        computer_SelectedNumber_Text.text = computerNumber.ToString();

        isPlay = true;
        SelectNumber_Screen.SetActive(false);
        Gameplay_Screen.SetActive(true);
    }

    public void FindScore()
    {
        player_Score += Bowls[playerNumber - 1];
        computer_Score += Bowls[computerNumber - 1];
        Invoke("ScoreUI_OpenScreen", 2f);
    }


    void ScoreUI_OpenScreen()
    {

        player_Score_Text.text = player_Score.ToString();
        computer_Score_Text.text = computer_Score.ToString();

        Gameplay_Screen.SetActive(false);
        Final_Screen.SetActive(true);
    }


    public void PlayAgain()
    {
        collectedBalls = 0;
        Destroy(GameObject.FindWithTag("Player"));

        for (int i = 0; i < 6; i++)
        {
            Bowls[i] = 0;
        }

        Final_Screen.SetActive(false);
        SelectNumber_Screen.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
