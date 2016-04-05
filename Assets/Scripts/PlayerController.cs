using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject prefabObstacle;
    private List<GameObject> obstacles;
    public float speed;
    public float winTimer;
    public float loseTimer;

    public GameObject ball;
    public GUIText scoreText;
    public GUIText gameText;
    public GUIText LevelText;
    public GUIText LivesText;
    public GUIText RoundsText;

    private int score;
    private int level = 1;
    private int lives = 3;
    private int round = 1;
    Vector3 startPoint;
    private List<GameObject> cubes;
    int scoreToBeatLevel = 700;



    void Start()
    {
        cubes = new List<GameObject>();
        score = 0;
        SetScoreText();
        SetLevelText();
        SetLivesText();
        SetRoundText();
        gameText.text = "";
        startPoint = transform.position;
    }

    void Update()
    {
        if (score == scoreToBeatLevel)
        {
            if (round < 3)
            {
                newRound();
                resetLevel();
                Instantiate(prefabObstacle, new Vector3(0, 4.5f, 0), Quaternion.identity);
            }
            else if (level < 5)
            {
                newLevel();
                resetLevel();
            }
            else {
                wonGame();
            }
            transform.position.Set(0f, 5f, 1.5f);
            //ResetTimer (winTimer);
        }
        else if (transform.position.y <= -4)
        {
            transform.position = startPoint;
            lives--;

        }
        if (lives > 0)
        {
            SetLivesText();
        }
        else
        {
            SetLivesText();
            gameText.color = Color.red;
            gameText.text = "GAME OVER!\n\n\nQ*BERT WILL RETURN IN... " + loseTimer.ToString("0");
            ResetTimer(loseTimer);
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
    }

    /* code for pickups
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "PickUp")
		{
			other.gameObject.SetActive(false);
		}
	}*/
    void resetLevel() {
        foreach (GameObject i in cubes) {
            i.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        }
        transform.position = startPoint;

    }

    void newRound() {
        gameText.color = new Color32(255, 0, 100, 255);
        round++;
        gameText.text = "CONGRATULATIONS Round Completed!\n\n\n On to round: !" + round.ToString();
        SetRoundText();
        scoreToBeatLevel += 700*level;
    }

    void newLevel()
    {
        gameText.color = new Color32(255, 0, 100, 255);
        round = 1;
        level++;
        gameText.text = "CONGRATULATIONS Level Completed!\n\n\n On to Level: !" + level.ToString();
        SetRoundText();
        SetLevelText();
        scoreToBeatLevel += (700 * level);
    }

    void wonGame() {
        gameText.color = Color.yellow;
        gameText.text = "CONGRATULATIONS You Won!" + winTimer.ToString("0");
        ResetTimer(winTimer);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle") {
            Destroy(collision.gameObject);
            transform.position = startPoint;
            lives--;
        }
        if (level == 1)
        {
            if (collision.gameObject.tag == "Cube" && collision.gameObject.GetComponent<Renderer>().material.GetColor("_Color") != Color.yellow)
            {
                if (!cubes.Contains(collision.gameObject))
                {
                    cubes.Add(collision.gameObject);
                }
                collision.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
                score = score + 25;
                SetScoreText();
            }
        }
        else if (level == 2) {
            if (collision.gameObject.tag == "Cube" && collision.gameObject.GetComponent<Renderer>().material.GetColor("_Color") == Color.blue)
            {
                if (!cubes.Contains(collision.gameObject))
                {
                    cubes.Add(collision.gameObject);
                }
                collision.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
                score = score + 25;
                SetScoreText();
            }
            else if (collision.gameObject.tag == "Cube" && collision.gameObject.GetComponent<Renderer>().material.GetColor("_Color") == Color.yellow)
            {
                if (!cubes.Contains(collision.gameObject))
                {
                    cubes.Add(collision.gameObject);
                }
                collision.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                score = score + 25;
                SetScoreText();
            }
        }
        else if (level == 3)
        {
            if (collision.gameObject.tag == "Cube" && collision.gameObject.GetComponent<Renderer>().material.GetColor("_Color") == Color.blue)
            {
                if (!cubes.Contains(collision.gameObject))
                {
                    cubes.Add(collision.gameObject);
                }
                collision.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
                score = score + 25;
                SetScoreText();
            }
            else if (collision.gameObject.tag == "Cube" && collision.gameObject.GetComponent<Renderer>().material.GetColor("_Color") == Color.yellow)
            {
                if (!cubes.Contains(collision.gameObject))
                {
                    cubes.Add(collision.gameObject);
                }
                collision.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                score = score + 25;
                SetScoreText();
            }
            else if (collision.gameObject.tag == "Cube" && collision.gameObject.GetComponent<Renderer>().material.GetColor("_Color") == Color.green)
            {
                if (!cubes.Contains(collision.gameObject))
                {
                    cubes.Add(collision.gameObject);
                }
                collision.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                score = score + 25;
                SetScoreText();
            }
        }
        else if (level == 4)
        {
            if (collision.gameObject.tag == "Cube" && collision.gameObject.GetComponent<Renderer>().material.GetColor("_Color") == Color.blue)
            {
                if (!cubes.Contains(collision.gameObject))
                {
                    cubes.Add(collision.gameObject);
                }
                collision.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
                score = score + 25;
                SetScoreText();
            }
            else if (collision.gameObject.tag == "Cube" && collision.gameObject.GetComponent<Renderer>().material.GetColor("_Color") == Color.yellow)
            {
                if (!cubes.Contains(collision.gameObject))
                {
                    cubes.Add(collision.gameObject);
                }
                collision.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                score = score + 25;
                SetScoreText();
            }
            else if (collision.gameObject.tag == "Cube" && collision.gameObject.GetComponent<Renderer>().material.GetColor("_Color") == Color.green)
            {
                if (!cubes.Contains(collision.gameObject))
                {
                    cubes.Add(collision.gameObject);
                }
                collision.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                score = score + 25;
                SetScoreText();
            }
            else if (collision.gameObject.tag == "Cube" && collision.gameObject.GetComponent<Renderer>().material.GetColor("_Color") == Color.red)
            {
                if (!cubes.Contains(collision.gameObject))
                {
                    cubes.Add(collision.gameObject);
                }
                collision.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.magenta);
                score = score + 25;
                SetScoreText();
            }
        }
        else if (level == 5)
        {
            if (collision.gameObject.tag == "Cube" && collision.gameObject.GetComponent<Renderer>().material.GetColor("_Color") == Color.blue)
            {
                if (!cubes.Contains(collision.gameObject))
                {
                    cubes.Add(collision.gameObject);
                }
                collision.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
                score = score + 25;
                SetScoreText();
            }
            else if (collision.gameObject.tag == "Cube" && collision.gameObject.GetComponent<Renderer>().material.GetColor("_Color") == Color.yellow)
            {
                if (!cubes.Contains(collision.gameObject))
                {
                    cubes.Add(collision.gameObject);
                }
                collision.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                score = score + 25;
                SetScoreText();
            }
            else if (collision.gameObject.tag == "Cube" && collision.gameObject.GetComponent<Renderer>().material.GetColor("_Color") == Color.green)
            {
                if (!cubes.Contains(collision.gameObject))
                {
                    cubes.Add(collision.gameObject);
                }
                collision.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                score = score + 25;
                SetScoreText();
            }
            else if (collision.gameObject.tag == "Cube" && collision.gameObject.GetComponent<Renderer>().material.GetColor("_Color") == Color.red)
            {
                if (!cubes.Contains(collision.gameObject))
                {
                    cubes.Add(collision.gameObject);
                }
                collision.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.magenta);
                score = score + 25;
                SetScoreText();
            }
            else if (collision.gameObject.tag == "Cube" && collision.gameObject.GetComponent<Renderer>().material.GetColor("_Color") == Color.magenta)
            {
                if (!cubes.Contains(collision.gameObject))
                {
                    cubes.Add(collision.gameObject);
                }
                collision.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
                score = score + 25;
                SetScoreText();
            }
        }

    }

    void SetScoreText()
    {
        scoreText.text = "SCORE: " + score.ToString();
    }

    void SetLivesText()
    {
        LivesText.text = "LIVES: " + lives.ToString();
    }
    void SetRoundText()
    {
        RoundsText.text = "ROUND: " + round.ToString();
    }
    void SetLevelText()
    {
        LevelText.text = "LEVEL: " + level.ToString();
    }


    void ResetTimer(float timer)
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SceneManager.LoadScene(0);
        }

        winTimer = timer;
        loseTimer = timer;
    }
}