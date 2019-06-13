# GameGraphicsFinalProject
Final group project for CMPM 163

Our overall project aims to create an outdoor 3D scene in Unity using HLSL shaders, particle systems, and various models and textures.

Alex Covert - I worked mostly on the smoke and fog in the scene, based largely off of the following tutorials: https://twitter.com/roystanhonks/status/990755998280265728?lang=en (fog) and https://www.alanzucconi.com/2016/03/02/shaders-for-simulations/ (smoke). Both are created with a combination of shader code and C# code. I also worked on creating a first-person camera prefab that moves with keys & the mouse.

Jordan - Caustics shader - river/lake/pool

Bob - Fire particle system, modeling

Alex Bradtke - cloud particle system, scene design

Bryan - I worked on the Subsurface Scattering effect implemented on the tree leaves, based on this tutorial: https://www.alanzucconi.com/2017/08/30/fast-subsurface-scattering-1/. Originally I planned to write the shader as a vertex/frag shader, but after some difficulty with light attentuation, I switched over to a surface shader.

Sam - water

