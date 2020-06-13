using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Controls();
    }

    public void Controls()
    {
        if (Input.GetKey(KeyCode.Keypad1)) // Change the input manager to have a top row 1 for positve and num pad 1 for negative. Do this for all 8.
        {
            print("Key 1 has been pressed");    // It only affects the num pad 1 key?
            // element 0. Like get component[0]? Something? Then somewhere else check if the button pressed is the coinSelected game object then print increase points.
            // else print minus points.
            // CALL element 0 or whatever it's called inthe editor.
            // if current correct answer {print "increase points"} or call the increase points method
            // else {decrease points}
            //IT needs to say hey number entered = 0 or 1 or whatever. Then in the other script it says oh we have the same number!
        }

        if (Input.GetKey("down"))
        {
            print("down arrow key is held down");
        }
    }
}
