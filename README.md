# COMP30019 Assignment 1 - Ray Tracer

**Name:** Seth Ng Jun-Jie \
**Student Number:** 1067992 \
**Username:** sethjunjien \
**Email:** sethjunjien@student.unimelb.edu.au

## Completed stages

#### Stage 1

- [x] Stage 1.1 - Familiarise yourself with the template
- [x] Stage 1.2 - Implement vector mathematics
- [x] Stage 1.3 - Fire a ray for each pixel
- [x] Stage 1.4 - Calculate ray-entity intersections
- [x] Stage 1.5 - Output primitives as solid colours

#### Stage 2

- [x] Stage 2.1 - Diffuse materials
- [x] Stage 2.2 - Shadow rays
- [x] Stage 2.3 - Reflective materials
- [x] Stage 2.4 - Refractive materials
- [x] Stage 2.5 - The Fresnel effect
- [x] Stage 2.6 - Anti-aliasing

#### Stage 3

- [ ] Option A - Emissive materials (+6)
- [ ] Option B - Ambient lighting/occlusion (+6)
- [ ] Option C - OBJ models (+6)
- [x] Option D - Glossy materials (+3)
- [x] Option E - Custom camera orientation (+3)
- [ ] Option F - Beer's law (+3)
- [ ] Option G - Depth of field (+3)

#### Glossy Materials

For Glossy materials, I used the code for diffuse materials as a starting point and also added in the reflection part. I then read through Scratchapixel (The Phong Model Introduction) and 1000 Forms of Bunnies (Reflecting Materials) to better understand the diffuse and reflective implementations in Glossy materials and modified my code accordingly. As for the proportions of color from the diffuse element (kd) and the specular element (ks = 1 - kd), I just played around with the values and ended up choosing ks = 0.2 as it provided the best and most noticeable gloss on the outputs.

#### Custom Camera Orientation

For the custom camera orientation, I first tried playing around with the origin and the initial origin direction in the Render function. After getting no where, I found the Gabriel Gambetta's website and read the first section on camera positioning. I found out that a 'Canvas to Viewport' / 'Image to World' function was needed. I researched a bit more and found some code on Scratchapixel (Generating Camera Rays) and implemented it. I found out about how to transform 3D Vectors for the origin's initial direction (0,0,1) using rotation matrices from Wikipedia. I later found out from the discussion board we had to use the left-handed coordinate system, so I modified the rotation matrices from Wikipedia accordingly to the Butterfly of Dream website.


## Final Scene Render

In my final scene, I implement Glossy materials onto the red, yellow, and purple spheres, and I positioned the camera to the right of the room at (1,0,0) while turning 20 degrees anti-clockwise (left-handed coordinate system) on the axis (0.15,1.-0.5).

![My final render](./images/final_scene.png)

This render took 13 minutes and 48 seconds on my PC.

I used the following command to render the image exactly as shown:

```
dotnet run -- -f tests/final_scene.txt -o final_scene.png --cam-pos 1,0,0 --cam-axis 0.15,1,-0.5 --cam-angle 20 -x 16
```

## Other Outputs

### Sample Scenes 1 and 2
Here are my output codes and images for replicating sample scenes 1 and 2 with x16 anti-aliasing:
```
dotnet run -- -f tests/sample_scene_1.txt -o stage_2_sample_scene_1.png -x 16
dotnet run -- -f tests/sample_scene_2.txt -o stage_2_sample_scene_2.png -x 16 
```
<p float="left">
  <img src="./images/stage_2_sample_scene_1.png" />
  <img src="./images/stage_2_sample_scene_2.png" /> 
</p>

### Glossy Materials
Here was the image I was satified with after implementing Glossy materials. The purple and yellow spheres were of Glossy material. NOTE: I used a old version of final_scene.txt for this image so running the code below won't achieve the same results as shown.
```
dotnet run -- -f tests/final_scene.txt -o glossy_scene.png -x 16
```
<p float="left">
  <img src="./images/glossy_scene.png" />
</p>

## References

Here are the references that I have used to implement into my code.

1000 Forms of Bunnies: Ray Tracing - Camera and Multisampling Antialiasing: http://viclw17.github.io/2018/07/17/raytracing-camera-and-msaa/

1000 Forms of Bunnies: Ray Tracing - Diffuse Materials: http://viclw17.github.io/2018/07/20/raytracing-diffuse-materials/

1000 Forms of Bunnies: Ray Tracing - Ray Sphere Intersection: http://viclw17.github.io/2018/07/16/raytracing-ray-sphere-intersection/

1000 Forms of Bunnies: Ray Tracing - Reflecting Materials: http://viclw17.github.io/2018/07/30/raytracing-reflecting-materials/

Butterfly of Dream: Converting Rotation Matrices of Left-Handed Coordinate System: https://butterflyofdream.wordpress.com/2016/07/05/converting-rotation-matrices-of-left-handed-coordinate-system/

Dr Jarrod Knibbe (University of Melbourne, 2021 Sem 2): Graphics and Interaction: Week 2b: Rasterising and Ray Tracing Lecture

Gabriel Gambetta: Extending the Raytracer: https://gabrielgambetta.com/computer-graphics-from-scratch/05-extending-the-raytracer.html

Kemptm GitHub: Ray Tracer: https://github.com/kemptm/RayTracer

Kyle Halladay: Ray-Sphere Intersection with Simple Math: http://kylehalladay.com/blog/tutorial/math/2013/12/24/Ray-Sphere-Intersection.html

Scratchapixel: A Minimal Ray-Tracer: Rendering Simple Shapes (Sphere, Cube, Disk, Plane, etc.): https://www.scratchapixel.com/lessons/3d-basic-rendering/minimal-ray-tracer-rendering-simple-shapes

Scratchapixel : An Overview of the Ray-Tracing Rendering Technique: https://www.scratchapixel.com/lessons/3d-basic-rendering/ray-tracing-overview/light-transport-ray-tracing-whitted

Scratchapixel: Introduction to Ray Tracing: a Simple Method for Creating 3D Images: https://www.scratchapixel.com/lessons/3d-basic-rendering/introduction-to-ray-tracing/

Scratchapixel: Introduction to Shading: https://www.scratchapixel.com/lessons/3d-basic-rendering/introduction-to-shading/

Scratchapixel: Placing a Camera: the LookAt Function: https://www.scratchapixel.com/lessons/mathematics-physics-for-computer-graphics/lookat-function/framing-lookat-function

Scratchapixel: The Phong Model Introduction to the Concepts of Shader, Reflection Models, and BRDF: https://www.scratchapixel.com/lessons/3d-basic-rendering/

Scratchapixel: Rasterization: a Practical Implementation: https://www.scratchapixel.com/lessons/3d-basic-rendering/rasterization-practical-implementation

Scratchapixel: Ray Tracing: Generating Camera Rays: https://www.scratchapixel.com/lessons/3d-basic-rendering/ray-tracing-generating-camera-rays

Scratchapixel: Ray Tracing: Rendering a Triangle: https://www.scratchapixel.com/lessons/3d-basic-rendering/ray-tracing-rendering-a-triangle

Stack Overflow: How to move a camera using in a ray-tracer?: https://stackoverflow.com/questions/13078243/how-to-move-a-camera-using-in-a-ray-tracer

Tom's Hardware: Anti-Aliasing Analysis, Part 1: Settings and Surprises: https://www.tomshardware.com/reviews/anti-aliasing-nvidia-geforce-amd-radeon,2868-2.html

Totologic: Accurate Point in Triangle Test: https://totologic.blogspot.com/2014/01/accurate-point-in-triangle-test.html

Wikipedia: Rotation Matrix: https://en.wikipedia.org/wiki/Rotation_matrix
## Grading Report
**Final Grade:** 23.0  
**Additional Comments:** -  
   
8:31:18 PM: Building project C:\Users\Alex\Documents\GitHub\Project-1-Auto-Test\projects\seth300301  
8:31:20 PM: STDOUT: 

Microsoft (R) Build Engine version 16.10.2+857e5a733 for .NET
Copyright (C) Microsoft Corporation. All rights reserved.

  Determining projects to restore...
  Restored C:\Users\Alex\Documents\GitHub\Project-1-Auto-Test\projects\seth300301\RayTracer.csproj (in 128 ms).
  RayTracer -> C:\Users\Alex\Documents\GitHub\Project-1-Auto-Test\projects\seth300301\report\bin\RayTracer.dll

Build succeeded.
    0 Warning(s)
    0 Error(s)

Time Elapsed 00:00:00.99  
8:31:20 PM: Success building project.  
### Stage 1
8:31:20 PM: Running test: 1_1_camera @ tests\Stage_1\1_1_camera~30s~-w_400_-h_300.txt  
8:31:20 PM: Iteration timeout: 30 seconds  
8:31:20 PM: Additional args: -w 400 -h 300  
8:31:20 PM: Render completed in **0.2 seconds** user processor time (raw = 0.2s).  

<p float="left">
<img src="./report/benchmarks\1_1_camera~30s~-w_400_-h_300.png" />
<img src="./report/outputs\1_1_camera~30s~-w_400_-h_300.png" />
</p>

8:31:20 PM: Running test: 1_2_primitives @ tests\Stage_1\1_2_primitives~30s.txt  
8:31:20 PM: Iteration timeout: 30 seconds  
8:31:20 PM: Additional args: none  
8:31:20 PM: Render completed in **0.44 seconds** user processor time (raw = 0.44s).  

<p float="left">
<img src="./report/benchmarks\1_2_primitives~30s.png" />
<img src="./report/outputs\1_2_primitives~30s.png" />
</p>

8:31:20 PM: Running test: 1_3_depth @ tests\Stage_1\1_3_depth~30s.txt  
8:31:20 PM: Iteration timeout: 30 seconds  
8:31:20 PM: Additional args: none  
8:31:21 PM: Render completed in **0.47 seconds** user processor time (raw = 0.47s).  

<p float="left">
<img src="./report/benchmarks\1_3_depth~30s.png" />
<img src="./report/outputs\1_3_depth~30s.png" />
</p>

### Stage 1 Rubric
---
- [x] Stage Attempted (+12 marks)
---
- [x] Camera - FOV Incorrect (-1 marks)
- [ ] Camera - Aspect Ratio Incorrect (-1 marks)
- [ ] Camera - Other Issue (minor) (-0.5 marks)
- [ ] Camera - Other Issue (major) (-1 marks)
---
- [ ] Shape - Plane Incorrect (-1 marks)
- [ ] Shape - Triangle Incorrect (-1 marks)
- [ ] Shape - Sphere Incorrect (-1 marks)
- [ ] Shape - Other Issue (minor) (-0.5 marks)
- [ ] Shape - Other Issue (major) (-1 marks)
---
- [ ] Depth - Wrong Order (1 case) (-1 marks)
- [ ] Depth - Wrong Order (2+ cases) (-2 marks)
- [ ] Depth - Other Issue (minor) (-0.5 marks)
- [ ] Depth - Other Issue (major) (-1 marks)
---
- [ ] Colour - Wrong Colour (1 case) (-1 marks)
- [ ] Colour - Wrong Colour (2+ cases) (-2 marks)
- [ ] Colour - Other Issue (minor) (-0.5 marks)
- [ ] Colour - Other Issue (major) (-1 marks)
---
- [ ] Other Issue #1 (major) (-1 marks)
- [ ] Other Issue #2 (major) (-1 marks)
- [ ] Other Issue #3 (minor) (-0.5 marks)
- [ ] Other Issue #4 (minor) (-0.5 marks)
---
**Additional Comments:** -  
  
---

  
### Stage 2
8:31:21 PM: Running test: 2_1_diffuse @ tests\Stage_2\2_1_diffuse~60s.txt  
8:31:21 PM: Iteration timeout: 60 seconds  
8:31:21 PM: Additional args: none  
8:31:21 PM: Render completed in **0.44 seconds** user processor time (raw = 0.44s).  

<p float="left">
<img src="./report/benchmarks\2_1_diffuse~60s.png" />
<img src="./report/outputs\2_1_diffuse~60s.png" />
</p>

8:31:21 PM: Running test: 2_2_reflection @ tests\Stage_2\2_2_reflection~60s.txt  
8:31:21 PM: Iteration timeout: 60 seconds  
8:31:21 PM: Additional args: none  
8:31:22 PM: Render completed in **0.55 seconds** user processor time (raw = 0.55s).  

<p float="left">
<img src="./report/benchmarks\2_2_reflection~60s.png" />
<img src="./report/outputs\2_2_reflection~60s.png" />
</p>

8:31:22 PM: Running test: 2_3_refraction @ tests\Stage_2\2_3_refraction~300s.txt  
8:31:22 PM: Iteration timeout: 300 seconds  
8:31:22 PM: Additional args: none  
8:31:23 PM: Render completed in **1.52 seconds** user processor time (raw = 1.52s).  

<p float="left">
<img src="./report/benchmarks\2_3_refraction~300s.png" />
<img src="./report/outputs\2_3_refraction~300s.png" />
</p>

8:31:23 PM: Running test: 2_4_sample @ tests\Stage_2\2_4_sample~300s~-x_3.txt  
8:31:23 PM: Iteration timeout: 300 seconds  
8:31:23 PM: Additional args: -x 3  
8:31:33 PM: Render completed in **9.17 seconds** user processor time (raw = 9.17s).  

<p float="left">
<img src="./report/benchmarks\2_4_sample~300s~-x_3.png" />
<img src="./report/outputs\2_4_sample~300s~-x_3.png" />
</p>

### Stage 2 Rubric
---
- [x] Stage Attempted (+9 marks)
---
- [ ] Diffuse Light - No Output (-1 marks)
- [ ] Diffuse Light - Incorrect Equation/Normals (-1 marks)
- [ ] Diffuse Light - Other Issue (major) (-1 marks)
- [ ] Diffuse Light - Other Issue (minor) (-0.5 marks)
---
- [ ] Shadows - No Output (-1 marks)
- [ ] Shadows - Multiple Light Issues (-0.5 marks)
- [ ] Shadows - Other Issue (major) (-1 marks)
- [ ] Shadows - Other Issue (minor) (-0.5 marks)
---
- [ ] Reflection - No Output (-2 marks)
- [ ] Reflection - Partial Output (-1 marks)
- [ ] Reflection - Reflecting Refraction Issue (major) (-1 marks)
- [ ] Reflection - Reflecting Refraction Issue (minor) (-0.5 marks)
- [x] Reflection - Other Issue (major) (-1 marks)
- [ ] Reflection - Other Issue (minor) (-0.5 marks)
---
- [ ] Refraction - No Output (-2 marks)
- [ ] Refraction - Partial Output (-1 marks)
- [ ] Refraction - Recursivity Issue(s) (-0.5 marks)
- [x] Refraction - Non-Sphere Issue(s) (-0.5 marks)
- [ ] Refraction - Other Issue (major) (-1 marks)
- [x] Refraction - Other Issue (minor) (-0.5 marks)
---
- [ ] Fresnel - No Output (-2 marks)
- [ ] Fresnel - Angle of Incidence Issue (-1 marks)
- [x] Fresnel - Minor Artefact (-0.5 marks)
- [ ] Fresnel - Major Artefact (-1 marks)
---
- [ ] Anti-aliasing - No Output (-1 marks)
- [ ] Anti-aliasing - Minor Artefact (-0.5 marks)
- [ ] Anti-aliasing - Major Artefact (-1 marks)
---
- [ ] Other Issue #1 (major) (-1 marks)
- [ ] Other Issue #2 (major) (-1 marks)
- [ ] Other Issue #3 (minor) (-0.5 marks)
- [ ] Other Issue #4 (minor) (-0.5 marks)
---
**Additional Comments:** -  
  Reflection was incorrect in test scene. Refraction in the test scene was incorrect for the pyramid and the background. Fresenel effect is not very visible.
---

  
### Stage 3A
8:31:33 PM: Running test: 3A_1_baseline @ tests\Stage_3A\3A_1_baseline~60s.txt  
8:31:33 PM: Iteration timeout: 60 seconds  
8:31:33 PM: Additional args: none  
8:31:33 PM: Render completed in **0.41 seconds** user processor time (raw = 0.41s).  

<p float="left">
<img src="./report/benchmarks\3A_1_baseline~60s.png" />
<img src="./report/outputs\3A_1_baseline~60s.png" />
</p>

8:31:33 PM: Running test: 3A_2_emissive_low @ tests\Stage_3A\3A_2_emissive_low~1800s.txt  
8:31:33 PM: Iteration timeout: 1800 seconds  
8:31:33 PM: Additional args: none  
8:31:34 PM: Render completed in **0.36 seconds** user processor time (raw = 0.36s).  

<p float="left">
<img src="./report/benchmarks\3A_2_emissive_low~1800s.png" />
<img src="./report/outputs\3A_2_emissive_low~1800s.png" />
</p>

8:31:34 PM: Running test: 3A_3_emissive_med @ tests\Stage_3A\3A_3_emissive_med~1800s.txt  
8:31:34 PM: Iteration timeout: 1800 seconds  
8:31:34 PM: Additional args: none  
8:31:34 PM: Render completed in **0.31 seconds** user processor time (raw = 0.31s).  

<p float="left">
<img src="./report/benchmarks\3A_3_emissive_med~1800s.png" />
<img src="./report/outputs\3A_3_emissive_med~1800s.png" />
</p>

8:31:34 PM: Running test: 3A_4_emissive_high @ tests\Stage_3A\3A_4_emissive_high~1800s.txt  
8:31:34 PM: Iteration timeout: 1800 seconds  
8:31:34 PM: Additional args: none  
8:31:34 PM: Render completed in **0.33 seconds** user processor time (raw = 0.33s).  

<p float="left">
<img src="./report/benchmarks\3A_4_emissive_high~1800s.png" />
<img src="./report/outputs\3A_4_emissive_high~1800s.png" />
</p>

### Stage 3A Rubric
---
- [ ] Stage Attempted (+6 marks)
---
- [ ] Source - Invisible (-1 marks)
- [ ] Source - Emission Colour Incorrect (-1 marks)
- [ ] Source - Material Colour Incorrect (-1 marks)
- [ ] Source - Material Receives Illumination (-1 marks)
- [ ] Source - Other Issue (major) (-1 marks)
- [ ] Source - Other Issue (minor) (-0.5 marks)
---
- [ ] Soft Shadows - Not Present (all cases) (-5 marks)
- [ ] Soft Shadows - Not Present (one+ case) (-2 marks)
- [ ] Soft Shadows - Major Issue (-2 marks)
- [ ] Soft Shadows - Minor Issue (-1 marks)
---
- [ ] Noise - Incomprehensible Image (-6 marks)
- [ ] Noise - Not Justified (-2 marks)
- [ ] Noise - Partially Justified (-1 marks)
---
- [ ] Time - Complete Timeout (-6 marks)
- [ ] Time - Not Justified (-2 marks)
- [ ] Time - Partially Justified (-1 marks)
---
- [ ] Other Issue #1 (major) (-1 marks)
- [ ] Other Issue #2 (major) (-1 marks)
- [ ] Other Issue #3 (minor) (-0.5 marks)
- [ ] Other Issue #4 (minor) (-0.5 marks)
---
**Additional Comments:** -  
  
---

  
### Stage 3B
8:31:34 PM: Running test: 3B_1_ambient @ tests\Stage_3B\3B_1_ambient~3600s~-l.txt  
8:31:34 PM: Iteration timeout: 3600 seconds  
8:31:34 PM: Additional args: -l  
8:31:35 PM: Render completed in **0.34 seconds** user processor time (raw = 0.34s).  

<p float="left">
<img src="./report/benchmarks\3B_1_ambient~3600s~-l.png" />
<img src="./report/outputs\3B_1_ambient~3600s~-l.png" />
</p>

### Stage 3B Rubric
---
- [ ] Stage Attempted (+6 marks)
---
- [ ] Indirect Light - None (-6 marks)
- [ ] Indirect Light - Partial or Unrealistic (-3 marks)
- [ ] Indirect Light - Incorrect Colour(s) (-2 marks)
- [ ] Indirect Light - Other Issue (major) (-1 marks)
- [ ] Indirect Light - Other Issue (minor) (-0.5 marks)
---
- [ ] Noise - Incomprehensible Image (-6 marks)
- [ ] Noise - Not Justified (-2 marks)
- [ ] Noise - Partially Justified (-1 marks)
---
- [ ] Time - Complete Timeout (-6 marks)
- [ ] Time - Not Justified (-2 marks)
- [ ] Time - Partially Justified (-1 marks)
---
- [ ] Other Issue #1 (major) (-1 marks)
- [ ] Other Issue #2 (major) (-1 marks)
- [ ] Other Issue #3 (minor) (-0.5 marks)
- [ ] Other Issue #4 (minor) (-0.5 marks)
---
**Additional Comments:** -  
  
---

  
### Stage 3C
8:31:35 PM: Running test: 3C_1_baseline @ tests\Stage_3C\3C_1_baseline~1200s.txt  
8:31:35 PM: Iteration timeout: 1200 seconds  
8:31:35 PM: Additional args: none  
8:31:36 PM: Render completed in **0.94 seconds** user processor time (raw = 0.94s).  

<p float="left">
<img src="./report/benchmarks\3C_1_baseline~1200s.png" />
<img src="./report/outputs\3C_1_baseline~1200s.png" />
</p>

8:31:36 PM: Running test: 3C_2_obj @ tests\Stage_3C\3C_2_obj~1200s.txt  
8:31:36 PM: Iteration timeout: 1200 seconds  
8:31:36 PM: Additional args: none  
8:31:37 PM: Render completed in **0.84 seconds** user processor time (raw = 0.84s).  

<p float="left">
<img src="./report/benchmarks\3C_2_obj~1200s.png" />
<img src="./report/outputs\3C_2_obj~1200s.png" />
</p>

8:31:37 PM: Running test: 3C_3_obj @ tests\Stage_3C\3C_3_obj~1200s.txt  
8:31:37 PM: Iteration timeout: 1200 seconds  
8:31:37 PM: Additional args: none  
8:31:37 PM: Render completed in **0.7 seconds** user processor time (raw = 0.7s).  

<p float="left">
<img src="./report/benchmarks\3C_3_obj~1200s.png" />
<img src="./report/outputs\3C_3_obj~1200s.png" />
</p>

### Stage 3C Rubric
---
- [ ] Stage Attempted (+6 marks)
---
- [ ] Shape - Not Visible (-6 marks)
- [ ] Shape - Major Artefact(s) (-2 marks)
- [ ] Shape - Minor Artefact(s) (-1 marks)
- [ ] Shape - RH Coordinate System (-0.5 marks)
---
- [ ] Lighting - Incorrect Normals (-2 marks)
- [ ] Lighting - Unsmoothed Normals (-1 marks)
- [ ] Lighting - Material Issue(s) (-1 marks)
- [ ] Lighting - Other Issue (minor) (-0.5 marks)
- [ ] Lighting - Other Issue (major) (-1 marks)
---
- [ ] Reflection - Major Artefact(s) (-2 marks)
- [ ] Reflection - Minor Artefact(s) (-1 marks)
- [ ] Reflection - Other Issue (minor) (-0.5 marks)
- [ ] Reflection - Other Issue (major) (-1 marks)
---
- [ ] Time - Bunny >5x Sphere (-0.5 marks)
- [ ] Time - Bunny >10x Sphere (-1 marks)
- [ ] Time - Bunny >25x Sphere (-2 marks)
- [ ] Time - Bunny >100x Sphere (or downscale) (-3 marks)
- [ ] Time - Complete Timeout (-6 marks)
---
- [ ] Other Issue #1 (major) (-1 marks)
- [ ] Other Issue #2 (major) (-1 marks)
- [ ] Other Issue #3 (minor) (-0.5 marks)
- [ ] Other Issue #4 (minor) (-0.5 marks)
---
**Additional Comments:** -  
  
---

  
### Stage 3D
8:31:37 PM: Running test: 3D_1_glossy @ tests\Stage_3D\3D_1_glossy~1800s.txt  
8:31:37 PM: Iteration timeout: 1800 seconds  
8:31:37 PM: Additional args: none  
8:31:39 PM: Render completed in **1.08 seconds** user processor time (raw = 1.08s).  

<p float="left">
<img src="./report/benchmarks\3D_1_glossy~1800s.png" />
<img src="./report/outputs\3D_1_glossy~1800s.png" />
</p>

### Stage 3D Rubric
---
- [x] Stage Attempted (+3 marks)
---
- [ ] Effect - Not Visible (-3 marks)
- [ ] Effect - Unconvincing (-2 marks)
- [ ] Effect - Partially convincing (-1 marks)
- [x] Effect - Minor Issue/Artefact(s) (-0.5 marks)
---
- [ ] Technique - Overly Simple (-1 marks)
- [ ] Technique - Minor Issue (-0.5 marks)
- [ ] Technique - Major Issue (-1 marks)
---
- [ ] Time - Complete Timeout (-3 marks)
- [ ] Time - Not Justified (-2 marks)
- [ ] Time - Partially Justified (-1 marks)
---
- [ ] Other Issue #1 (major) (-1 marks)
- [ ] Other Issue #2 (major) (-1 marks)
- [ ] Other Issue #3 (minor) (-0.5 marks)
- [ ] Other Issue #4 (minor) (-0.5 marks)
---
**Additional Comments:** -  
  The specular light could be stronger.
---

  
### Stage 3E
8:31:39 PM: Running test: 3E_1_camera @ tests\Stage_3E\3E_1_camera~30s~--cam-pos_0,2,-0.5_--cam-axis_1,0,0_--cam-angle_45.txt  
8:31:39 PM: Iteration timeout: 30 seconds  
8:31:39 PM: Additional args: --cam-pos 0,2,-0.5 --cam-axis 1,0,0 --cam-angle 45  
8:31:39 PM: Render completed in **0.22 seconds** user processor time (raw = 0.22s).  

<p float="left">
<img src="./report/benchmarks\3E_1_camera~30s~--cam-pos_0,2,-0.5_--cam-axis_1,0,0_--cam-angle_45.png" />
<img src="./report/outputs\3E_1_camera~30s~--cam-pos_0,2,-0.5_--cam-axis_1,0,0_--cam-angle_45.png" />
</p>

8:31:39 PM: Running test: 3E_2_camera @ tests\Stage_3E\3E_2_camera~30s~--cam-pos_0,2,-0.5_--cam-axis_1,0,0_--cam-angle_-45.txt  
8:31:39 PM: Iteration timeout: 30 seconds  
8:31:39 PM: Additional args: --cam-pos 0,2,-0.5 --cam-axis 1,0,0 --cam-angle -45  
8:31:39 PM: Render completed in **0.48 seconds** user processor time (raw = 0.48s).  

<p float="left">
<img src="./report/benchmarks\3E_2_camera~30s~--cam-pos_0,2,-0.5_--cam-axis_1,0,0_--cam-angle_-45.png" />
<img src="./report/outputs\3E_2_camera~30s~--cam-pos_0,2,-0.5_--cam-axis_1,0,0_--cam-angle_-45.png" />
</p>

8:31:39 PM: Running test: 3E_3_camera @ tests\Stage_3E\3E_3_camera~30s~--cam-pos_0,0,-1_--cam-axis_0,0.707,0.707_--cam-angle_20.txt  
8:31:39 PM: Iteration timeout: 30 seconds  
8:31:39 PM: Additional args: --cam-pos 0,0,-1 --cam-axis 0,0.707,0.707 --cam-angle 20  
8:31:40 PM: Render completed in **0.47 seconds** user processor time (raw = 0.47s).  

<p float="left">
<img src="./report/benchmarks\3E_3_camera~30s~--cam-pos_0,0,-1_--cam-axis_0,0.707,0.707_--cam-angle_20.png" />
<img src="./report/outputs\3E_3_camera~30s~--cam-pos_0,0,-1_--cam-axis_0,0.707,0.707_--cam-angle_20.png" />
</p>

### Stage 3E Rubric
---
- [x] Stage Attempted (+3 marks)
---
- [ ] Position - Incorrect (1 case) (-1 marks)
- [ ] Position - Incorrect (2+ cases) (-2 marks)
---
- [ ] Rotation - Wrong Angle (-1 marks)
- [ ] Rotation - Wrong Angle Direction (-1 marks)
- [ ] Rotation - Incorrect (1 case) (-1 marks)
- [x] Rotation - Incorrect (2+ cases) (-2 marks)
---
- [ ] Time - Complete Timeout (-3 marks)
- [ ] Time - Not Justified (-2 marks)
- [ ] Time - Partially Justified (-1 marks)
---
- [ ] Other Issue #1 (major) (-1 marks)
- [ ] Other Issue #2 (major) (-1 marks)
- [ ] Other Issue #3 (minor) (-0.5 marks)
- [ ] Other Issue #4 (minor) (-0.5 marks)
---
**Additional Comments:** -  
  
---

  
### Stage 3F
8:31:40 PM: Running test: 3F_1_beers_room @ tests\Stage_3F\3F_1_beers_room~120s.txt  
8:31:40 PM: Iteration timeout: 120 seconds  
8:31:40 PM: Additional args: none  
8:31:42 PM: Render completed in **1.72 seconds** user processor time (raw = 1.72s).  

<p float="left">
<img src="./report/benchmarks\3F_1_beers_room~120s.png" />
<img src="./report/outputs\3F_1_beers_room~120s.png" />
</p>

8:31:42 PM: Running test: 3F_2_beers_pyramid @ tests\Stage_3F\3F_2_beers_pyramid~120s.txt  
8:31:42 PM: Iteration timeout: 120 seconds  
8:31:42 PM: Additional args: none  
8:31:43 PM: Render completed in **1.53 seconds** user processor time (raw = 1.53s).  

<p float="left">
<img src="./report/benchmarks\3F_2_beers_pyramid~120s.png" />
<img src="./report/outputs\3F_2_beers_pyramid~120s.png" />
</p>

### Stage 3F Rubric
---
- [ ] Stage Attempted (+3 marks)
---
- [ ] Colour - No Change (-3 marks)
- [ ] Colour - Hue Incorrect (-1 marks)
- [ ] Colour - Blending Issue (minor) (-1 marks)
- [ ] Colour - Blending Issue (major) (-2 marks)
- [ ] Colour - Absorbance Issue (minor) (-1 marks)
- [ ] Colour - Absorbance Issue (major) (-2 marks)
- [ ] Colour - Other Issue (minor) (-0.5 marks)
- [ ] Colour - Other Issue (major) (-1 marks)
---
- [ ] Shape - Sphere Issue (-1 marks)
- [ ] Shape - Non-Sphere Issue (-1 marks)
- [ ] Shape - Other Issue (minor) (-0.5 marks)
- [ ] Shape - Other Issue (major) (-1 marks)
---
- [ ] Time - Complete Timeout (-3 marks)
- [ ] Time - Not Justified (-2 marks)
- [ ] Time - Partially Justified (-1 marks)
---
- [ ] Other Issue #1 (major) (-1 marks)
- [ ] Other Issue #2 (major) (-1 marks)
- [ ] Other Issue #3 (minor) (-0.5 marks)
- [ ] Other Issue #4 (minor) (-0.5 marks)
---
**Additional Comments:** -  
  
---

  
### Stage 3G
8:31:43 PM: Running test: 3G_1_dof @ tests\Stage_3G\3G_1_dof~1800s~--aperture-radius_0.06_--focal-length_1.5.txt  
8:31:43 PM: Iteration timeout: 1800 seconds  
8:31:43 PM: Additional args: --aperture-radius 0.06 --focal-length 1.5  
8:31:44 PM: Render completed in **1.03 seconds** user processor time (raw = 1.03s).  

<p float="left">
<img src="./report/benchmarks\3G_1_dof~1800s~--aperture-radius_0.06_--focal-length_1.5.png" />
<img src="./report/outputs\3G_1_dof~1800s~--aperture-radius_0.06_--focal-length_1.5.png" />
</p>

### Stage 3G Rubric
---
- [ ] Stage Attempted (+3 marks)
---
- [ ] Aperture - None/Incomprehensible Output (-3 marks)
- [ ] Aperture - Incorrect Size (-1 marks)
- [ ] Aperture - Other Issue (major) (-1 marks)
- [ ] Aperture - Other Issue (minor) (-0.5 marks)
---
- [ ] Focal Length - Incorrect Distance (-1 marks)
- [ ] Focal Length - Other Issue (major) (-1 marks)
- [ ] Focal Length - Other Issue (minor) (-0.5 marks)
---
- [ ] Time - Complete Timeout (-3 marks)
- [ ] Time - Not Justified (-2 marks)
- [ ] Time - Partially Justified (-1 marks)
---
- [ ] Other Issue #1 (major) (-1 marks)
- [ ] Other Issue #2 (major) (-1 marks)
- [ ] Other Issue #3 (minor) (-0.5 marks)
- [ ] Other Issue #4 (minor) (-0.5 marks)
---
**Additional Comments:** -  
  
---

  
### Stage Final


<img src="./images/final_scene.png" />


### Stage Final Rubric
---
- [x] Final Image Attempted (+3 marks)
---
- [ ] Coverage - Little/None (-1 marks)
- [ ] Coverage - Partial (-0.5 marks)
---
- [ ] Quality - Little/None (-1 marks)
- [x] Quality - Partial (-0.5 marks)
---
- [ ] Creativity - Little/None (-1 marks)
- [x] Creativity - Partial (-0.5 marks)
---
- [ ] Other - Repository Issue (minor) (-0.5 marks)
- [ ] Other - Repository Issue (major) (-1 marks)
- [ ] Other - README.md References Lacking (-1 marks)
- [ ] Other - README.md Utilised Incorrectly (-1 marks)
- [ ] Other - GitHub Not Utilised (-2 marks)
- [ ] Other - GitHub Incorrectly Utilised (-1 marks)
---
**Additional Comments:** -  
  
---

  
