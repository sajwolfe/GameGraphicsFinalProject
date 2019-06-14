# GameGraphicsFinalProject
Final group project for CMPM 163

Our overall project aims to create an outdoor 3D scene in Unity using HLSL shaders, particle systems, and various models and textures.
The downloadable build of our project is at the following link, as well as inside this repository: https://alexcovert.itch.io/game-graphics-final-project. Our video is here: https://www.youtube.com/watch?v=1-E-ema4nxQ&feature=youtu.be

### IMAGES INCLUDED IN WRITE-UP PDF

BUILD CONTROLS:

WASD to move around

QE to move up and down

SHIFT to speed up

ESC to quit the build

Alex Covert - I worked mostly on the smoke and fog in the scene, based largely off of the following tutorials: https://twitter.com/roystanhonks/status/990755998280265728?lang=en (fog) and https://www.alanzucconi.com/2016/03/02/shaders-for-simulations/ (smoke). Both are created with a combination of shader code and C# code. I also worked on creating a first-person camera prefab that moves with keys & the mouse.


Bryan - I worked on the Subsurface Scattering effect implemented on the tree leaves, based on this tutorial: https://www.alanzucconi.com/2017/08/30/fast-subsurface-scattering-1/. Originally I planned to write the shader as a vertex/frag shader, but after some difficulty with light attentuation, I switched over to a surface shader. Solo GitHub Repo: https://github.com/BryanArvizu/CMPM163_Subsurface


Bob - Fire particle system, modeling - My roles are to complete the outdooe scene for my team members to represent their special effects and to build the fire particle system. The fire particle system is based largely off of the tutorial:
https://www.youtube.com/watch?v=5Mw6NpSEb2o&t=319s and https://www.raywenderlich.com/138-introduction-to-unity-particle-systems. The Unity scene is created with help from Alex Bradtke. I also recorded and edited the project video.


Sam - water reflection


Jordan - Created water caustics using Chris Cunningham's shader: https://www.patreon.com/posts/21987965 This iteration uses a noise texture to distort the caustics over time for a realistic effect instead of animating an array of textures. I researched other, more complex implementations such as ray tracing or using a mesh's vertices as a light source, but found them too far outside my current skillset to use. I managed the settings for the caustics to fit the scene accordingly.


Alex Bradtke - cloud particle system, scene design - My role was to help create the the outdoor scene to show off everyones part(s) and attempt to highlight them and create clouds using the particle systems. The cloud particle system was based off of the tutorial: https://www.youtube.com/watch?v=F8conwqx2kY. I used a combination of effects from the options on the particle menu off of a texture image.

