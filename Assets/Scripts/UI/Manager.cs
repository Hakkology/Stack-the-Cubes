using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    // Text Component which holds the point information of the player and the tutorial information
    public Text PointsText;
    public Text IntroText;

    // UI Panel
    public GameObject UIPanel;

    // List that keeps the Coin Pool
    public List<GameObject> CoinPool = new List<GameObject>();

    // Integer Component which represents the number of points accumulated by the player
    public int Points;

    // Completion Time
    public int ChapterState;

    // Game chapters
    public List <GameObject> Chapters = new List<GameObject>();

    // Warning Messages
    List<string> ChaptersText = new List<string>();

    // Repeated Text
    string repeatedText = "\n"
                            + "Gather as many coins as possible.\n"
                            + "Press 'Space' to run.";

    void Start()
    {
        // Initial Chapter Information
        ChapterState = 1;

        // Text Definers
        ChaptersText.Add("Chapter 1: Welcome to Annoying Town.");
        ChaptersText.Add("Chapter 2: We will do this all day.");
        ChaptersText.Add("Chapter 3: Do continue, please.");
        ChaptersText.Add("Chapter 4: The game is not speeding up. You are high.");
        ChaptersText.Add("Chapter 5: Not even sure where we are anymore.");
        ChaptersText.Add("Chapter 6: Why do we live ?");
        ChaptersText.Add("Chapter 7: Why can't we all just get along ?");
        ChaptersText.Add("Chapter 8: This is the last one, I swear.");

        // Initial tutorial text
        IntroText.text = ChaptersText[0] + repeatedText;

    }

    void Update()
    {
        // Point Updated through here
        PointsText.text = Points.ToString();

        // Difficulty Function
        DifficultyAdjustments();

    }

    public void DifficultyAdjustments() {

        // Difficulty for game
        switch (Mathf.Round(ChapterState / 2)) {
            case 0:
                FindObjectOfType<PlayerMovement>()._runningSpeed = 8;
                break;
            case 1:
                FindObjectOfType<PlayerMovement>()._runningSpeed = 10;
                break;
            case 2:
                FindObjectOfType<PlayerMovement>()._runningSpeed = 12;
                break;
            case 3:
                FindObjectOfType<PlayerMovement>()._runningSpeed = 14;
                break;
            case 4:
                FindObjectOfType<PlayerMovement>()._runningSpeed = 16;
                break;

            default: break;
        }
    }

    public void GameState() {

        // switch statement to change the cube gameobject
        switch (ChapterState) {
            case 1:
                Chapters[0].SetActive(true);
                IntroText.text = ChaptersText[0] + repeatedText;
                break;
            case 2:
                Chapters[0].SetActive(false);
                Chapters[1].SetActive(true);
                Chapters[1].transform.GetChild(2).gameObject.SetActive(false);
                FindObjectOfType<CoinSpawner>().FirstCoin[1].transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                FindObjectOfType<CoinSpawner>().SpawnCoin();
                FindObjectOfType<FenceSpawner>().MoveFences(Chapters, ChapterState-1);
                IntroText.text = ChaptersText[1] + repeatedText;
                break;
            case 3:
                Chapters[1].SetActive(false);
                Chapters[2].SetActive(true);
                Chapters[2].transform.GetChild(2).gameObject.SetActive(false);
                FindObjectOfType<CoinSpawner>().FirstCoin[2].transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                FindObjectOfType<CoinSpawner>().SpawnCoin();
                FindObjectOfType<FenceSpawner>().MoveFences(Chapters, ChapterState - 1);
                IntroText.text = ChaptersText[2] + repeatedText;
                break;
            case 4:
                Chapters[2].SetActive(false);
                Chapters[3].SetActive(true);
                Chapters[3].transform.GetChild(2).gameObject.SetActive(false);
                FindObjectOfType<CoinSpawner>().FirstCoin[3].transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                FindObjectOfType<CoinSpawner>().SpawnCoin();
                FindObjectOfType<FenceSpawner>().MoveFences(Chapters, ChapterState - 1);
                IntroText.text = ChaptersText[3] + repeatedText;
                break;
            case 5:
                Chapters[3].SetActive(false);
                Chapters[4].SetActive(true);
                Chapters[4].transform.GetChild(2).gameObject.SetActive(false);
                FindObjectOfType<CoinSpawner>().FirstCoin[4].transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                FindObjectOfType<CoinSpawner>().SpawnCoin();
                FindObjectOfType<FenceSpawner>().MoveFences(Chapters, ChapterState - 1);
                IntroText.text = ChaptersText[4] + repeatedText;
                break;
            case 6:
                Chapters[4].SetActive(false);
                Chapters[5].SetActive(true);
                Chapters[5].transform.GetChild(2).gameObject.SetActive(false);
                FindObjectOfType<CoinSpawner>().FirstCoin[5].transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                FindObjectOfType<CoinSpawner>().SpawnCoin();
                FindObjectOfType<FenceSpawner>().MoveFences(Chapters, ChapterState - 1);
                IntroText.text = ChaptersText[5] + repeatedText;
                break;
            case 7:
                Chapters[5].SetActive(false);
                Chapters[6].SetActive(true);
                Chapters[6].transform.GetChild(2).gameObject.SetActive(false);
                FindObjectOfType<CoinSpawner>().FirstCoin[6].transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                FindObjectOfType<CoinSpawner>().SpawnCoin();
                FindObjectOfType<FenceSpawner>().MoveFences(Chapters, ChapterState - 1);
                IntroText.text = ChaptersText[6] + repeatedText;
                break;
            case 8:
                Chapters[6].SetActive(false);
                Chapters[7].SetActive(true);
                FindObjectOfType<CoinSpawner>().FirstCoin[7].transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                FindObjectOfType<CoinSpawner>().SpawnCoin();
                FindObjectOfType<FenceSpawner>().MoveFences(Chapters, ChapterState - 1);
                Chapters[7].transform.GetChild(2).gameObject.SetActive(false);
                IntroText.text = ChaptersText[7] + repeatedText;
                break;
            default: break;
        }
    }






}
