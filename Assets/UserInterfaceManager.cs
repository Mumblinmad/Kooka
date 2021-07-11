using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceManager : MonoBehaviour
{
    [SerializeField]
    Text scoreText;
    int scoreForUI;

    public void incrementScore(int amount){

        scoreForUI += amount;
        UpdateText();
    }

    private void UpdateText(){
        scoreText.text = $"Score: {scoreForUI}";
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreForUI = 0;
        UpdateText();
    }
}
