using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//testing getters and setters
// class Count 
// {
//     public int Num {get;set; }
//     public string Name {get; set; }

//     public Count() {}

//     public Count (int num, string name)
//     {
//         Num = num; 
//         Name = "";
//     }
// }

public class Hints : MonoBehaviour
{

    public Text hintsText;
    public List<string> hintsList = new List<string>();
    public int x;

    private float timeRemaining = 0;

    //List<Collider> colliders = new List<Collider>();

    // Start is called before the first frame update
    void Start()
    {
        hintsList.Add("This is the first tutorial hint!");
        hintsList.Add("This is another tutorial hint maybe?!");
        hintsList.Add("This is hint number 3!");
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (timeRemaining > 0) 
        // {
        //     timeRemaining -= Time.deltaTime;
        // }
        // else 
        // {
        //     hintsText.text = "";
        // }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") //Remember to tag player controller as "Player"
        {
            //var countShow = new Count(Num,"Matt");
            timeRemaining = 10;
            hintsText.text = hintsList[x];
            //x += 1;
            //this.gameObject.SetActive(false);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") //Remember to tag player controller as "Player"
        {
            //var countShow = new Count(Num,"Matt");
            //timeRemaining = 10;
            hintsText.text = "";
            //x += 1;
            this.gameObject.SetActive(false);
        }
    }
}
