using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public Text WinText;
    public Text ScoreText;

    private Rigidbody rb;
    private int score;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        SetScoreText();
        WinText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * Speed);
    }

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
            score ++;
		    SetScoreText();
		}
	}

    void SetScoreText()
    {
        ScoreText.text = "Score: " + score;

        if (score >= 12)
        {
            WinText.text = "YOU WIN !";
            Speed = 0;
        }
    }
}