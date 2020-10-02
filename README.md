# SplashDown
This code-along is meant for absolutely new Unity developers, but it might carry some nice tips for intermediate users.
The source code (Unity project files) will be uploaded mainly for showcasing and asset verification, but anyone can use it however they'd like.
This readme will serve as full documentation on the step-by-step process of creating this game prototype.
Contact JazzyLucas#0749 via Discord if you have any questions.

## Preface
* I won't cover Unity Hub installation or Unity Editor installation, but [here's that](https://docs.unity3d.com/Manual/GettingStartedInstallingHub.html)
* In this tutorial I use Unity 2020.1.6f1. Different versions of Unity should still work, but the UI might look different.
* A very basic understanding of C# or programming is assumed, but not necessarily needed.
* A basic intuition of Unity Editor and its API is *not* assumed, this tutorial should assist with that.

## Step 0: Project Creation and Assets Organization
When you make the new project make sure you have the name set to something other than the default name. I'd also recommend making a subfolder within Documents for all of your Unity Projects, otherwise the default location can become cluttered. It's a good idea to use the 3D template as I'll be using it to start things off.<br />
![Image 0-0](https://i.imgur.com/BVhjljQ.png)<br/>
Once you create the project, the Unity Editor should load in a Scene file named "SampleScene". You'll see this in the top left of the Unity Editor window. We won't be renaming this or changing scenes in this tutorial.
Now, before we create any objects, let's get to the organization of our project. This should look similar to what your Assets folder looks like right now:<br />
![Image 0-1](https://i.imgur.com/LBS8uZZ.png)<br/>
We want to make some more folders to hold our Assets. Right click in the Assets area, create, folder, name it, and repeat. You'll want it to look similar to this afterwards:<br/>
![Image 0-2](https://i.imgur.com/SXDkq16.png)<br/>
Let's take a look at the scene that we're in, SampleScene:<br />
![Image 0-3](https://i.imgur.com/ZIREclE.png)<br/>
As you can see, we've got two default objects: **Main Camera** and **Directional Light**. Let's create two **Empty** GameObjects in the scene and name them "Environment" and "Camera Control". You can do this by right clicking in the SampleScene area, then Create Empty. Unlike folders, you aren't prompted to rename GameObjects right after creation, so you'll want to right click the GameObject and rename it. This is similar to what you want it to look like:<br />
![Image 0-4](https://i.imgur.com/gKuUNm4.png)<br/>
Next, left click each of these newly created **Empty** GameObjects you've made and look over to the right of the screen to verify that their **Transform**s look similar to this:<br/>
![Image 0-5](https://i.imgur.com/JZemeYe.png)<br/>
If the transforms don't look similar just right click the **Transform** header and then Reset.
A final step towards organizing the project is to Parent the **Main Camera** and **Directional Light** GameObjects for future organization. You can simply do this by dragging each one onto their respective **Empty** GameObjects. It should now look similar to this:<br />
![Image 0-6](https://i.imgur.com/UGsgkmE.png)<br/>
The technique of parenting GameObjects to other GameObjects is very useful when categorizing different things in a scene. It becomes very necessary when animating models and particles. From now on in this tutorial I won't go through the step-by-step process everytime I parent or create GameObjects as you can refer to it here.<br/>

## Step 1: Player and a Floor
No programming quite yet, but let's get some more GameObjects into the scene. Create two new 3D Objects, a **Cube** and a **Capsule**. These are probably looking super small in your Scene, but that's just your perspective right now. If you hold right click in your scene's view and use your WASD keys then you can navigate around. It's fairly similar to any freecam used in most sandbox games, but you can watch [this video](https://www.youtube.com/watch?v=aCM3J4fG8B0) for some more help if you need it. Your scene should look something like this:<br/>
![Image 1-0](https://i.imgur.com/WQbunG3.png)<br/>
Let's focus on the **Cube**. Rename it to "Floor" and we'll work on expanding it outwards. You can expand or shrink a GameObject by changing it's scale in its **Transform** component. A GameObject's component is anything under the **Inspector** tab on the right. Go over to that **Transform** component and change some values to something like this:<br/>
![Image 1-1](https://i.imgur.com/GhjMph0.png)<br/>
Now, you might notice that the **Capsule** is stuck inside the Floor, and we definitely don't want to leave it that way. Let's change the **Capsule**'s name to "Player" and its **Transform** to something like this:<br/>
![Image 1-2](https://i.imgur.com/mrUkT9s.png)<br/>
We've made a Floor and put a Player above it, but these two GameObjects are not affected by physics at all (or better corrected, we need them affected by Unity's Physics. You can make your own physics system with scripting but that is for another day). In order to make physical entities affected by gravity, friction, forces, etc, we'll need to add a component called **Rigidbody**. Check out the Inspector of your GameObjects. There should be a button that says "Add Component". Click that Add Component button, search up "Rigidbody", and add it on to both your Player and Floor.
> If you've ever used Unity before, then you might've used a **CharacterController** component to control a player. Don't try to mix that with **Rigidbody** components because things will get messy *really quickly*. Usually you should only use one or the other. :)

So for example, your Player's Inspector should now look like this (*For the sake of visuals, I minimized some components by clicking the triangle symbol on their header*):<br/>
![Image 1-3](https://i.imgur.com/yvRL6jP.png)<br/>
One last thing before we move on to programming some real functionality... we need to fix the Floor a bit more. We've added the **Rigidbody** component to both the Player and the Floor, but that also currently means that both the Floor and the Player will continuously fall endlessly through the void of space. We need to freeze the Floor's position that way the Player will actually fall onto the Floor and not the void. Navigate to the Floor's **Rigidbody** component, find the header called "Constraints" and check *all* of the boxes. Should look something like this:<br/>
![Image 1-4](https://i.imgur.com/le12rde.png)<br/>
Now we should be ready to add a **Script** component to the Player and get into the nitty gritty of Unity.<br/>

## Step 2: First Steps
Remember in Step 0 where we created a Folder named "Scripts"? Open up that Scripts Folder and we'll now create our first Unity Script. You'll notice that the creation of a Script immediately prompts you to type in its name:
> Unlike most GameObjects and Assets, Scripts aren't easily renamed. Keep this in mind when creating Scripts. (If you're into programming then you might understand that this is because Scripts are basically classes.)

You'll want to name this first script "PlayerControl". If you accidentally named it something different then I'd recommend deleting the Script and creating a new one. Once created, double click the Script to open it in the Integrated Development Environment called Microsoft Visual Studio. Your Unity editor might freeze a bit and look like it's glitching out when you open your script, don't freak out. This is most likely caused by Microsoft Visual Studio starting up (It's never been fixed or smoothed out, you'll just have to bear with it). Code-wise, this is what you should have so far in PlayerControl.cs (The PlayerControl script):
```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
```
Before we even slap down some functioning code, it's time for a fancy outlining feature called regions! This isn't something that most online Unity tutorials teach but we're gonna be cooler than most Unity tutorials. Let's surround the 2 Monobehaviour methods **Start()** and **Update()** with `#region Monobehaviour Callbacks` and then create a new region above that (enclosing nothing for now) with `#region Private Fields`. It should looks something like this now:
```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    #region Private Fields
    #endregion

    #region Monobehaviour Callbacks

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion
}
```
What's useful about regions is that we can now close and open code blocks depending on what we want to see in when coding a script (the plus and minus symbols between the line number and your code on the left). Tidying up code like this isn't necessarily needed, but it really helps other people who review your code when it becomes long and complex. You can also change the Unity editor files and setup regions to be premade everytime you create a script ([Link Right Here](https://support.unity3d.com/hc/en-us/articles/210223733-How-to-customize-Unity-script-templates)). I'm going to go ahead and make a few more regions for preliminary purposes, but like I said, it's optional. My code will end up looking like this now:
```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    #region Private Fields
    #endregion

    #region Monobehaviour Callbacks

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    #endregion
}
```
From here on I will only upload snippets of code like functions and variables and expect you to be able to place them where you feel necessary depending on where you might have regions or what-not. With that being said, let's get into controlling our Player with this script. Let's add a new Private but Serializable Field that we'll use to reference our Player **GameObject**. We'll also make a private **Rigidbody** component. We'll also go ahead and make another private field but this one will be a fancy **Vector3** called input and defaulted to 0. This is what these will look like:
```C#
    [SerializeField] private GameObject playerObject;
    private Rigidbody playerRigidbody;
    private Vector3 input = Vector3.zero;
```
At runtime we'll get the **Rigidbody** from the Player so it's not necessary to make it a SerializeField. The method we'll use for that is the **Start()** method. Here's what that will look like right now:
```C#
    void Start()
    {
        playerRigidbody = playerObject.GetComponent<Rigidbody>();
    }
```
Next, we'll make a private method called **GetInput()** that returns void with the no parameters. Here's what we'll fill the **GetInput()** function with:
```C#
    private void GetInput()
    {
        // Reset the vector each time we get input.
        input = Vector3.zero;
        // Using Horizontal and Vertical axes allows for use of controllers and easy control redefining with an Input Manager.
        input.x = Input.GetAxis("Horizontal");
        input.z = Input.GetAxis("Vertical");
    }
```
We'll call **GetInput()** in the Update method, and we'll actually move the Player in a **FixedUpdate()** which is another Monobehaviour Callback just like **Update()** and **Start()** but it's called on a fixed timescale no matter what device is playing your game. This is what it'll look like:
```C#
    void FixedUpdate()
    {
        playerRigidbody.MovePosition(playerRigidbody.position + input * 10 * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }
```
Save your script (Ctrl+S) and make sure Unity is able to compile it without problems (Go back to the Unity editor and if it's looking normal then it's good). Drag your PlayerControl script onto your Player GameObject. Now, we're going to reference your Player GameObject in the PlayerControl script component. The way you do this is by dragging the entire Player GameObject onto the area that says "Player Object". It might be easier to see a quick gif of it being done:<br/>
![vid1](https://i.imgur.com/NsjOhgL.gif)<br/>
Now, time for some action! Click the Play button located in the top middle of the Unity editor, and you can now use WASD to move your character! Step 2 is complete!<br/>
![vid2](https://i.imgur.com/pI3P7v5.gif)<br/>

## Step 3: Diving Board and Pool
This next step should serve as a neat challenge to get your more comfortable with moving and placing objects in Unity. I have made a few changes to the **SampleScene**. It should be fairly intuitive to understand what's going on just by comparing the scene's view with respective objects. I have outlined **Empty** GameObjects in the Heirarchy in red. I used these **Empty** GameObjects to parent both the Diving Board and the Pool for organizational purposes. I also parented our Camera Controller to the Player, this will allow the camera to follow everywhere the player goes. The "Diving Board Teleport Empty" will serve as **Transform** data when we need to teleport our player back up to the Diving Board. You might also notice a cube object over to the side: that's the Pool Filling. You should add a **Box Collider** component along with checking the "Is Trigger" for that object for later.<br/>
![Image 3-0](https://i.imgur.com/IwAMchs.png)<br/>
![Image 3-1](https://i.imgur.com/v6AkyYH.png)<br/>
Let's create a new script called "SplashDetection". In this script we will teleport the player when they collide with the pool filler. It sounds simple, but let's get to the code. Here's what our Private Fields will look like:
```C#
    [SerializeField] private GameObject jumpPoint;
    [SerializeField] private GameObject playerObject;
    private Rigidbody playerRigidbody;
```
The jumpPoint will be what that "Diving Board Teleport Empty" that I created earlier. Here's some MonoBehaviour Callbacks that we'll be using:
```C#
    void Start()
    {
        playerRigidbody = playerObject.GetComponent<Rigidbody>();
        goToJumpLocation();
    }

    private void Update()
    {
        if(Input.GetKeyDown("j"))
        {
            goToJumpLocation();
        }
    }
```
And (before your Visual Studio editor yells at your for not knowing where our private goToJumpLocation() method is) let's code this public method:
```C#
    private void goToJumpLocation()
    {
        // Teleport the player to the jumpPoint
        playerObject.transform.position = jumpPoint.transform.localPosition;
        // Reset the player's rotation when they get to the jumpPoint
        playerObject.transform.eulerAngles = Vector3.zero;
        // Reset the player's velocity to 0 in all directions. Very Important!
        playerRigidbody.velocity = Vector3.zero;
        playerRigidbody.angularVelocity = Vector3.zero;
    }
```
Now, we haven't made the pool filling fully functional quite yet. We need a Unity Method for when the player actually collides with it:
```C#
    private void OnTriggerEnter()
    {
        goToJumpLocation();
    }
```
This should be everything for the SplashDetection script, but we'll want some better visuals for the pool filling. We can do so by assigning it a new **Material**. I made mine look like green jello. I'd recommend having some fun with this part. You can make some really cool visuals just using a single material.<br/>
![vid3](https://i.imgur.com/0nwk5Cd.gif)<br/>
![vid4](https://i.imgur.com/93baMxr.gif)<br/>
When you're done, make sure to move your pool filling to its correct spot, reference the correct objects in the script, and you're good to go!<br/>
![Image 3-2](https://i.imgur.com/6wkpox9.png)<br/>
![Image 3-3](https://i.imgur.com/3g4eSVl.png)<br/>
You should be able to click play and be able to endlessly jump off a diving board to try and hit water. If you don't end up doing so, just press J and retry.

## Step 4: Scoring System
In this 4th step we're going to make a score/streak system. The first step to this is we need a User Interface (UI for short) for showing the score. Unity handles this with **Canvas** objects. We'll be creating just a **Text - TextMeshPro** object and Unity automatically creates a **Canvas** object as well as an **EventSystem** associated with it. You might have to import the resources for TextMeshPro during this (Unity should prompt you for it), and I highly recommend doing so. Change your text values to be similar to mine:<br/>
![Image 4-0](https://i.imgur.com/3WYVl22.png)<br/>
Next, we'll dive back into the SplashDetection script. We need to add a new serialized private field for our **Text - TextMeshPro** object. We'll also need a private integer to keep score. Visual Studio should automatically import the TMPro library at the top of your script.
```C#
    [SerializeField] private TextMeshProUGUI scoreText;
    private int currentScore = 0;
```
The first thing to do is make a private method for updating the score display. Here's what that would look like:
```C#
    private void updateScoreText()
    {
        scoreText.text = currentScore.ToString();
    }
```
We can add the score update to the goToJumpLocation() method:
```C#
    private void goToJumpLocation()
    {
        // Teleport the player to the jumpPoint
        playerObject.transform.position = jumpPoint.transform.localPosition;
        // Reset the player's rotation when they get to the jumpPoint
        playerObject.transform.eulerAngles = Vector3.zero;
        // Reset the player's velocity to 0 in all directions. Very Important!
        playerRigidbody.velocity = Vector3.zero;
        playerRigidbody.angularVelocity = Vector3.zero;
        // Update the score
        updateScoreText();
    }
```
We'll need to increment the score by 1 each time the player lands into the pool of water successfuly, but we'll reset the score when the player resets their jump. We can add the score incrementing in the OnTriggerEnter() method:
```C#
    private void OnTriggerEnter()
    {
        goToJumpLocation();
        currentScore++;
    }
```
And we can reset the score in the Update() method when the J key is pressed:
```C#
    private void Update()
    {
        if(Input.GetKeyDown("j"))
        {
            goToJumpLocation();
            currentScore = 0;
        }
    }
```
Save your script, find your pool filling, and reference your score **Text - TextMeshPro** object. Your entire project should now be playable with a score. Just as a side note, you might need to go back into your SplashDetection script and configure your initial values for the currentScore integer depending on if you have any colliders surrounding your pool filling.

## Step 5: Continuing
This is where the tutorial ends, but I wanted to provide some pointers to helpful Unity techniques/areas to get into.
If you're an absolute beginner:
- Particle Systems (they're amazing and tons of fun)
- Sounds
- Animations as well as the animation controller
- Building projects with HTML5
- Post Processing
- The Unity Asset Store (thousands of free resources)

If you've done the above or you are a more advanced Unity user, then I suggest these:
- Prefabs and using objects across scenes
- Scriptable GameObjects (for holding data)
- Object Pooling
- Shaders with Unity URP, and HDRP
- Multiplayer with Photon PUN
