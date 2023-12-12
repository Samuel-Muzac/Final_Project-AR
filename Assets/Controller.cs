using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Controller : MonoBehaviour
{
    GameObject p1;
    GameObject p2;
    private int rounds;
    private bool isP1Turn;
    private bool isP2Turn;
    private PlayerMovement pm1;
    private PlayerMovement pm2;


    public TextMeshProUGUI countText;

    // Start is called before the first frame update
    void Start()
    {
        p1 = GameObject.Find("Player1");
        p2 = GameObject.Find("Player2");
        pm1 = p1.GetComponent<PlayerMovement>();
        pm2 = p2.GetComponent<PlayerMovement>();
        isP1Turn = true;
        isP2Turn = false;
        SetCountText();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //integer state to represent flags
        //constantly check the state of the player
    }

    void changeTurn()
    {
        isP1Turn = !isP1Turn;
        isP2Turn = !isP2Turn;
        rounds++;


        if (rounds == 7)
        {
            SetCountText();
        }

    }


    void SetCountText()
    {
        int player1Score = pm1.playerScore;
        int player2Score = pm2.playerScore;
        countText.text = "P1 Score: " + player1Score.ToString() + "P2 Score: " + player2Score.ToString();
        if (rounds == 3)
        {
            if (player1Score > player2Score)
            {
                countText.text = "P1 Wins!";
                Application.Quit();
            }
            else if (player1Score < player2Score)
            {
                countText.text = "P2 Wins!";
                Application.Quit();
            }
            else
            {
                countText.text = "Tie: Play Again!";
                Application.Quit();

            }
        }

    }
}

