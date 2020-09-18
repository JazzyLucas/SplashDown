# SplashDown
This tutorial is meant for absolutely new Unity developers, but it might carry some nice tips for intermediate users.
The source code (Unity project files) is uploaded mainly for showcasing and asset verification, but anyone can use it however they'd like.
This readme will serve as full documentation on the step-by-step process of creating this game prototype.
Contact JazzyLucas#0749 via Discord if you have any questions.

## Preface
I won't cover Unity Hub installation or Unity Editor installation, but here's that if you need it: https://docs.unity3d.com/Manual/GettingStartedInstallingHub.html
In this tutorial I use Unity 2020.1.6f1. Earlier versions of Unity should still work, but they will look very different.
A basic understanding of C# with Microsoft Visual Studio is assumed.
A basic intuition of Unity Editor and its API is *not* assumed, this tutorial should assist with that.

## Step 0: Project Creation and Assets Organization
When you make the new project make sure you have the name set to something other than the default name. I'd also recommend making a subfolder within Documents for all of your Unity Projects, otherwise the default location can become cluttered. It's a good idea to use the 3D template as I'll be using it to start things off.<br />
![Image 0-0](https://i.imgur.com/BVhjljQ.png)<br/>
Once you create the project, the Unity Editor should load in a Scene file named "SampleScene". You'll see this in the top left of the Unity Editor window. We won't be renaming this or changing scenes in this tutorial.
Now, before we create any cool objects, let's get to the organization of our project. This should look similar to what your Assets folder looks like right now:<br />
![Image  0-1](https://i.imgur.com/LBS8uZZ.png)<br/>
We want to make some more folders to hold our Assets. Right click in the Assets area, go to create, folder, name it, and repeat. You'll want it to look similar to this afterwards:<br/>
![Image  0-2](https://i.imgur.com/SXDkq16.png)<br/>
Let's take a look at the scene that we're in, SampleScene:<br />
![Image  0-3](https://i.imgur.com/ZIREclE.png)<br/>
As you can see, we've got two default objects: **Main Camera** and **Directional Light**. Let's create two **Empty** GameObjects in the scene and name them "Environment" and "Camera Control". You can do this by right clicking in the SampleScene area, then Create Empty. Unlike folders, you aren't prompted to rename GameObjects right after creation, so you'll want to right click the GameObject and rename it. This is similar to what you want it to look like:<br />
![Image  0-4](https://i.imgur.com/gKuUNm4.png)<br/>
Next, left click each of these newly created **Empty** GameObjects you've made and look over to the right of the screen to verify that their **Transform**s look similar to this:<br/>
![Image  0-5](https://i.imgur.com/JZemeYe.png)<br/>
If the transforms don't look similar just right click the **Transform** header and then Reset.
A final step towards organizing the project is to Parent the **Main Camera** and **Directional Light** GameObjects for future organization. You can simply do this by dragging each one onto their respective **Empty** GameObjects. It should now look similar to this:<br />
![Image  0-6](https://i.imgur.com/UGsgkmE.png)<br/>
This technique of parenting other GameObjects to other **Empty** GameObjects is very useful when categorizing different things in a scene. It becomes very necessary when animating models and particles in Unity. From now on in this tutorial I won't go through the step-by-step process everytime I parent or create GameObjects as you can refer to it here.<br/>

## Step 1: A Diving Board and a Player
