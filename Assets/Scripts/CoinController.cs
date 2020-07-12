using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour    // Rename it CoinController
{
    public GameObject[] coins;   // 8 coins. 1p, 2p, 5p, 10p, 20p, 50, £1, £2.

    public int coinSelected;   // Maybe these need to be -1 too? This shouldn't affect things.
    public int correctNumber;
    public int keyPressed = -1; // Not sure if it should stay as -1.
    public int points = 0;
    public int timer = 5;

    public bool coinAnswer = false;

    public Text scoreTextNumber;
    public Text keyDisplayText1;    // There is alot of these and thus a better way should done during the polish stage.
    public Text keyDisplayText2;
    public Text keyDisplayText3;
    public Text keyDisplayText4;
    public Text keyDisplayText5;
    public Text keyDisplayText6;
    public Text keyDisplayText7;
    public Text keyDisplayText8;

    private AudioSource audioSource;

    public AudioClip wrongChoice;
    public AudioClip correctChoice;

    private IEnumerator coinDisplayTime;      // Make public?

    void Start()
    {
        coinDisplayTime = WaitAndPrint(1.0f);
        StartCoroutine(coinDisplayTime);
        Reset();

        setCoinsValues();   //sets the controls in a method.
        //Associate each of the keys with a coin/element.

        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //print("Update start!");
        Controls();
        //print("Controls");
        if (keyPressed == correctNumber) { coinAnswer = true; CorrectChoiceaudio(); Reset(); }
        //else { coinAnswer = false; }

        //else if (keyPressed > correctNumber || keyPressed < correctNumber) { points++; print(points); }  // It is still printing the wrong button constantly.
        // Also change the displayed number (Reset) if you hit the wrong key.

        //else if (keyPressed != correctNumber) { print("minus points"); } // Moved to the wrong audio method bellow controls.

        //print(timer);
        //print(points);
        //print("correct Number " + correctNumber);

        scoreTextNumber.text = points.ToString();

        if (timer == 0)
        {
            timer = 5;                               // Resets the timer.  // Maybe have this as timer = curentTime and then later just say currentTime = timer when Reset.
            coins[coinSelected].SetActive(false);    // Resets the coin selected.
        }

        // Some kind of decrease points by 1 code, may be needed much later on.

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
            //print("Reset");
            coinSelected = Random.Range(0, coins.Length);
            correctNumber = coinSelected;
            //print(correctNumber);

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


    public void Controls()
    {
        print("Inside the controls method");
        if (Input.GetButtonDown("Key1"))
        {
            print("Key 1 has been pressed");
            keyPressed = 0;
            keyDisplayText1.GetComponent<Text>().color = Color.green;
            WrongKeyaudio();
            // PLAY AUDIO call audio method down bellow if not currently playing audio then play audio clip.
        }

        if (Input.GetButtonDown("Key2"))
        {
            print("Key 2 has been pressed");
            keyPressed = 1;
            keyDisplayText2.GetComponent<Text>().color = Color.green;
            WrongKeyaudio();
        }

        if (Input.GetButtonDown("Key3"))
        {
            print("Key 3 has been pressed");
            keyPressed = 2;
            keyDisplayText3.GetComponent<Text>().color = Color.green;
            WrongKeyaudio();
        }

        if (Input.GetButtonDown("Key4"))
        {
            print("Key 4 has been pressed");
            keyPressed = 3;
            keyDisplayText4.GetComponent<Text>().color = Color.green;
            WrongKeyaudio();
        }

        if (Input.GetButtonDown("Key5"))
        {
            print("Key 5 has been pressed");
            keyPressed = 4;
            keyDisplayText5.GetComponent<Text>().color = Color.green;
            WrongKeyaudio();
        }

        if (Input.GetButtonDown("Key6"))
        {
            print("Key 6 has been pressed");
            keyPressed = 5;
            keyDisplayText6.GetComponent<Text>().color = Color.green;
            WrongKeyaudio();
        }

        if (Input.GetButtonDown("Key7"))
        {
            print("Key 7 has been pressed");
            keyPressed = 6;
            keyDisplayText7.GetComponent<Text>().color = Color.green;
            WrongKeyaudio();
        }

        if (Input.GetButtonDown("Key8"))
        {
            print("Key 8 has been pressed");
            keyPressed = 7;
            keyDisplayText8.GetComponent<Text>().color = Color.green;
            WrongKeyaudio();
        }

        //else { keyPressed = -1; }
        return; // Is this needed?
    }

    private void WrongKeyaudio()
    {
        audioSource.clip = wrongChoice;
        audioSource.Play();
        //if (coinAnswer == false) { points--; }
        //points--;
        //print("minus points" + points);
    }

    private void CorrectChoiceaudio()
    {
        //print("Correct Choice Audio!");
        audioSource.clip = correctChoice;
        audioSource.Play();
        points++;
        print("increase points " + points);
    }

    void Reset()
    {
        keyPressed = -1;
        timer = 5;
        coins[coinSelected].SetActive(false);
        //coinAnswer = false;

        keyDisplayText1.GetComponent<Text>().color = Color.black;
        keyDisplayText2.GetComponent<Text>().color = Color.black;
        keyDisplayText3.GetComponent<Text>().color = Color.black;
        keyDisplayText4.GetComponent<Text>().color = Color.black;
        keyDisplayText5.GetComponent<Text>().color = Color.black;
        keyDisplayText6.GetComponent<Text>().color = Color.black;
        keyDisplayText7.GetComponent<Text>().color = Color.black;
        keyDisplayText8.GetComponent<Text>().color = Color.black;
    }

}
