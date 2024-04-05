using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(player.position.z);
        scoreText.text = player.position.z.ToString("0");
    }
}
