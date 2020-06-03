using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour    // Rename it CoinController
{
    public GameObject[] coins;   // 8 coins. 1p, 2p, 5p, 10p, 20p, 50, £1, £2.
    public int coinSelected;
    public int correctNumber;
    public int keyPressed = -1; // Not sure if it should stay as -1.
    public int points = 0;
    public bool coinPressed; // It needs to check what input is pressed. Maybe in a specific method and checked in update or something.
    public bool correctAnswerCoin;
    // maybe correctAnswerCoin; is a boolean? But how the fuck does it know what control key it is?
    // points increase? points? correctAnswerCoin?
    public int timer = 3;
    private IEnumerator coinDisplayTime;      // Make public?

    void Start()
    {
        coinDisplayTime = WaitAndPrint(1.0f);
        StartCoroutine(coinDisplayTime);
        Reset();

        setCoinsValues();   //sets the controls in a method.
        //Associate each of the keys with a coin/element.
    }

    public void setCoinsValues()
    {
        //coins[0] = keyPressed1; Maybe keyPressed1 needs to be a boolean, maybe an array of booleans?
        //          SOMEHOW the coins array needs to take in the number entered as another value.
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Reset();
            print("Reset");
            coinSelected = Random.Range(0, coins.Length);
            correctNumber = coinSelected;
            print(correctNumber);
            //correctAnswerCoin = true;
            // associate the coinSelected with the correct button?
            // Add something to the element or coinSelected. Like add a component or whatever I need it to do.
            //          TRY setting the coinSelected element GameObject to have the correct answer tag or whatever. 
            //          Then in update it checks for that tag and sets correctAnswerCoin to true.
            coins[coinSelected].SetActive(true);
            // if (NumberEntered == correctNumber)
            //{
            //    print ("increase points by 1");
            //    Reset(); // Reset timer and other stuff.
            //}
            //print("coinSelected " + coinSelected);
            //print("Choose a coin");                                                          // All the coins should have the same position but be disabled.
            //print("Decrease timer by 1");                                                    // Whereas the bottom of the screen display should be seperate.        
            if (timer > 0)                                                                   // These will just be UI.images without the score worth or being in this array.
            {                                                                                // They will look the same but they won't be affected by this set active code.
                timer--;
            }
        }
    }

    // void coinIsPressed()
    // {
    //     coinPressed = true;
    //}


    public void Controls()  // Probably should be higher up in the script.
    {
        if (Input.GetKeyDown(KeyCode.Keypad1)) // Change the input manager to have a top row 1 for positve and num pad 1 for negative. Do this for all 8.
        {// GetKeyDown?
            print("Key 1 has been pressed");
            // Does correctNumber == key pressed 1? Maybe earlier say KEYpad1 = keyPressed!? Fuck knows.
             keyPressed = 1; 
            // Then check if it's the correct answer over in the update method.
        }

        if (Input.GetKey("down"))
        {
            print("down arrow key is held down");
        }

        //else { keyPressed = -1; }
        return; // Is this needed?
    }

        // Update is called once per frame
        void Update()
    {
        Controls();
        if (keyPressed == correctNumber) { print("increase points"); Reset(); }
        //else if (keyPressed > correctNumber || keyPressed < correctNumber) { points++; print(points); }  // It is still printing the wrong button constantly.

        //print(timer);

        if (timer == 0)
        {
            timer = 3;                                  // Resets the timer.
            coins[coinSelected].SetActive(false);       // Resets the coin selected.
        }

        // Some kind of decrease points by 1 code, may be needed much later on.

    }

    void Reset()
    {
        keyPressed = -1;
        timer = 3;
        coins[coinSelected].SetActive(false);
    }

}
