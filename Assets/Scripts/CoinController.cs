using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour    // Rename it CoinController
{
    public GameObject[] coins;   // 8 coins. 1p, 2p, 5p, 10p, 20p, 50, £1, £2.
    public GameObject loseText;

    public int coinSelected;   // Maybe these need to be -1 too? This shouldn't affect things.
    public int correctNumber;
    public int keyPressed = -1; // Not sure if it should stay as -1.
    public int points = 0;
    //public int timer = 5;   // shows 1 less in the inspector because it starts at 0?   // Can I make this into a float and call it in the wait time method in some way?
    public int lives = 3; // Does counting from 0 affect this?
    //public int currentTimer;

    public bool coinAnswer = false;

    public Text scoreTextNumber;
    public Text Displaylives;

    public Text keyDisplayText1;    // There is alot of these and thus a better way should be done during the polish stage.
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

    public bool controlsActive = true;
    //public bool potatoe = false;
    public bool someBool = false;

    public IEnumerator coinDisplayTime;      // Should this be public? // Even when public it is not viewable in the inspector.

    void Start()
    {
        someBool = false;

        //currentTimer = timer;
        //controlsActive = true;

        coinDisplayTime = WaitAndPrint(5f);
        StartCoroutine(coinDisplayTime);
        Reset();

        audioSource = GetComponent<AudioSource>();
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        //waitTime = 5f; // This affects the time, the timer and current timer stuff that I was doing, wasn't being counted at all!

        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Reset();
            //print("Reset");
            coinSelected = Random.Range(0, coins.Length);
            correctNumber = coinSelected;

            //someBool = false;

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
            //if (timer > 0) 
            // if (currentTimer > 0)                                                                   // These will just be UI.images without the score worth or being in this array.
            // {                                                                                // They will look the same but they won't be affected by this set active code.
            //timer--;
            //     currentTimer--;
            //    print("currentTimer decrease");
            //}

            // if (waitTime == 0)
            //  {
            //      potatoe = true;
            //  }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //print("timer " + timer);
        //print("currentTimer " + currentTimer);
        Displaylives.text = lives.ToString();

        //print("Update start!");
        //if (controlsActive == true)
        //{
            Controls();
            //print("Controls");
            if (keyPressed == correctNumber) { coinAnswer = true; CorrectChoiceaudio(); Reset(); } // add before Reset someBool = false and maybe else {someBool = true;}
            //else { someBool = true; }
            //else { coinAnswer = false; }

            //else if (keyPressed > correctNumber || keyPressed < correctNumber) { points++; print(points); }  // It is still printing the wrong button constantly.
            // Also change the displayed number (Reset) if you hit the wrong key.

            //else if (keyPressed != correctNumber) { print("minus points"); } // Moved to the wrong audio method bellow controls.

            //print(timer);
            //print(points);
            //print("correct Number " + correctNumber);

            scoreTextNumber.text = points.ToString();

            //if (timer == 0)
            //if (currentTimer == 0)
          //  if (currentTimer == 0)
          //  {
                //timer = 5;
          //      currentTimer = timer;                               // Resets the timer.  // Maybe have this as timer = curentTime and then later just say currentTime = timer when Reset.
          //      coins[coinSelected].SetActive(false);    // Resets the coin selected.
           // }

            // Some kind of decrease points by 1 code, may be needed much later on.

      //  if (potatoe == true)
      //      {
       //         coins[coinSelected].SetActive(false);    // Resets the coin selected.
       //     }

        //}
    }

    public void Controls()
    {
        //print("Inside the controls method");
        if (Input.GetButtonDown("Key1"))
        {
            print("Key 1 has been pressed");
            keyPressed = 0;
            keyDisplayText1.GetComponent<Text>().color = Color.green;
            WrongKeyaudio();
            // PLAY AUDIO call audio method down bellow if not currently playing audio then play audio clip.
            print("Decrease lives by 1."); LifeCounter();
        }

        if (Input.GetButtonDown("Key2"))
        {
            print("Key 2 has been pressed");
            keyPressed = 1;
            keyDisplayText2.GetComponent<Text>().color = Color.green;
            WrongKeyaudio();
            print("Decrease lives by 1."); LifeCounter();
        }

        if (Input.GetButtonDown("Key3"))
        {
            print("Key 3 has been pressed");
            keyPressed = 2;
            keyDisplayText3.GetComponent<Text>().color = Color.green;
            WrongKeyaudio();
            print("Decrease lives by 1."); LifeCounter();
        }

        if (Input.GetButtonDown("Key4"))
        {
            print("Key 4 has been pressed");
            keyPressed = 3;
            keyDisplayText4.GetComponent<Text>().color = Color.green;
            WrongKeyaudio();
            print("Decrease lives by 1."); LifeCounter();
        }

        if (Input.GetButtonDown("Key5"))
        {
            print("Key 5 has been pressed");
            keyPressed = 4;
            keyDisplayText5.GetComponent<Text>().color = Color.green;
            WrongKeyaudio();
            print("Decrease lives by 1."); LifeCounter();
        }

        if (Input.GetButtonDown("Key6"))
        {
            print("Key 6 has been pressed");
            keyPressed = 5;
            keyDisplayText6.GetComponent<Text>().color = Color.green;
            WrongKeyaudio();
            print("Decrease lives by 1."); LifeCounter();
        }

        if (Input.GetButtonDown("Key7"))
        {
            print("Key 7 has been pressed");
            keyPressed = 6;
            keyDisplayText7.GetComponent<Text>().color = Color.green;
            WrongKeyaudio();
            print("Decrease lives by 1."); LifeCounter();
        }

        if (Input.GetButtonDown("Key8"))
        {
            print("Key 8 has been pressed");
            keyPressed = 7;
            keyDisplayText8.GetComponent<Text>().color = Color.green;
            WrongKeyaudio();
            print("Decrease lives by 1."); LifeCounter();
        }

        //else { keyPressed = -1; }
        return; // Is this needed?
    }

    private void WrongKeyaudio()
    {
        audioSource.clip = wrongChoice;
        audioSource.Play();
        someBool = true;
        print("FUCKING someBool"); // This is called when it is wrong but also when it is correct.

        //if (someBool == true) { lives--; }

        //print("Decrease lives by 1."); LifeCounter();
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
        //someBool = false;
    }

    void LifeCounter()
    {
         if (someBool == true) {lives--;}
        //lives--;    // maybe if lives are greater than 0, decreased by 1.
        print(lives);

        if (lives <= 0)
        {
            print("Reset points");
            points = 0;

            //loseText.SetActive(true);
            //controlsActive = false;
            // if statement here that is like set would you like to try again text to active.
            // Maybe not an if statement, maybe just a line of code that sets it active.
            // By pressing Yes in the game it resets the lives and everything anyway.

            // KEEP the bellow lives and reset code commented out and this way I can activate them again if I need them.
            //lives = 3;
            //Reset();
        }
    }

    void Reset()
    {
        keyPressed = -1;
        //timer = 5;
        //currentTimer = timer;
        coins[coinSelected].SetActive(false);
        someBool = false;

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
