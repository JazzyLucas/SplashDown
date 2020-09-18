# SplashDown
This tutorial is meant for absolutely new Unity developers, but it might carry some nice tips for intermediate users.
The source code (Unity project files) is uploaded mainly for showcasing and asset verification, but anyone can use it however they'd like.
This readme will serve as full documentation on the step-by-step process of creating this game prototype.
Contact JazzyLucas#0749 via Discord if you have any questions.

## Preface
* I won't cover Unity Hub installation or Unity Editor installation, but [here's that](https://docs.unity3d.com/Manual/GettingStartedInstallingHub.html)
* In this tutorial I use Unity 2020.1.6f1. Earlier versions of Unity should still work, but the UI might look different.
* A very basic understanding of C# with Microsoft Visual Studio is assumed.
* A basic intuition of Unity Editor and its API is *not* assumed, this tutorial should assist with that.

## Step 0: Project Creation and Assets Organization
When you make the new project make sure you have the name set to something other than the default name. I'd also recommend making a subfolder within Documents for all of your Unity Projects, otherwise the default location can become cluttered. It's a good idea to use the 3D template as I'll be using it to start things off.<br />
![Image 0-0](https://i.imgur.com/BVhjljQ.png)<br/>
Once you create the project, the Unity Editor should load in a Scene file named "SampleScene". You'll see this in the top left of the Unity Editor window. We won't be renaming this or changing scenes in this tutorial.
Now, before we create any cool objects, let's get to the organization of our project. This should look similar to what your Assets folder looks like right now:<br />
![Image 0-1](https://i.imgur.com/LBS8uZZ.png)<br/>
We want to make some more folders to hold our Assets. Right click in the Assets area, go to create, folder, name it, and repeat. You'll want it to look similar to this afterwards:<br/>
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
The technique of parenting other GameObjects to other GameObjects is very useful when categorizing different things in a scene. It becomes very necessary when animating models and particles. From now on in this tutorial I won't go through the step-by-step process everytime I parent or create GameObjects as you can refer to it here.<br/>

## Step 1: A Floor and a Player
No programming quite yet, but let's get some more GameObjects into the scene. Create two new 3D Objects, a **Cube** and a **Capsule**. These are probably looking super small in your Scene, but that's just your perspective right now. If you hold right click in your scene's view and use your WASD keys then you can navigate around. It's fairly similar to any freecam used in most sandbox games, but you can watch [this video](https://www.youtube.com/watch?v=aCM3J4fG8B0) for some more help if you need it. Your scene should look something like this:<br/>
![Image 1-0](https://i.imgur.com/WQbunG3.png)<br/>
Let's focus on the **Cube**. Rename it to "Floor" and we'll work on expanding it outwards. You can expand or shrink a GameObject by changing it's scale in its **Transform** component. A GameObject's component is anything under the **Inspector** tab on the right. Go over to that **Transform** component and change some values to something like this:<br/>
![Image 1-1](https://i.imgur.com/GhjMph0.png)<br/>
Now, you might notice that the **Capsule** is stuck inside the Floor, and we definitely don't to leave it that way. Let's change the **Capsule**'s name to "Player" and its **Transform** to something like this:<br/>
![Image 1-2](https://i.imgur.com/mrUkT9s.png)<br/>
We've made a Floor and put a Player above it, but these two GameObjects are not affected by physics at all (or better corrected, we need them affected by Unity's Physics. You can make your own physics system with scripting but that is for another day). In order to make physical entities affected by gravity, friction, forces, etc, we'll need to add a component called **Rigidbody**. Well, we've modified components, but how do we add components? Check out the Inspector of your GameObjects. There should be a button that says "Add Component". Click that Add Component button, search up "Rigidbody", and add it on to both your Player and Floor. While you're at it, you should also add a **Character Controller** component but only to your Player. So for example, your Player's Inspector should now look like this (*For the sake of visuals, I minimized some components by clicking the square on their header*):<br/>
![Image 1-3](https://i.imgur.com/aHtoDT5.png)<br/>
One last thing before we move on to programming some real functionality... we need to fix the Floor a bit more. We've made both the Player and the Floor **Rigidbody**, but that also currently means that both the Floor and the Player will continually fall endlessly through the void of space. We need to freeze the Floor's position that way the Player will actually fall onto the Floor and not the void. Navigate to the Floor's **Rigidbody** component, find the header called "Constraints" and check *all* of the boxes. Should look something like this:<br/>
![Image 1-4](https://i.imgur.com/le12rde.png)<br/>
Now we should be ready to add a **Script** component to the Player and get into the nitty gritty of Unity.<br/>

## Step 2: First Steps
