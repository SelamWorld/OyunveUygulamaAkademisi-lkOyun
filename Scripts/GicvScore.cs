using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GicvScore : MonoBehaviour
{
    public TextMeshProUGUI tscoreText;

    private void Awake()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text= ("Your Score: " + (Points.Score).ToString());
        //tscoreText.text=("Your Score: "+(Points.Score).ToString());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
