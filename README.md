# Extensions
Extensions are helpful to improve development time and code readability. Below are some useful ones.
## Transfrom Extensions

1. **MoveToX**: Moves the transform **x** units in X axis in **t** time. 
 ``` cs
public static IEnumerator MoveToX(this Transform transform, float distanceToMoveinX, float time, AnimationCurve curve = null)
```
2. **MoveToY**: Moves the transform **y** units in Y axis in **t** time. 
 ``` cs
public static IEnumerator MoveToY(this Transform  transform, float distanceToMoveY, float time,  AnimationCurve curve = null)
```
3. **MoveToZ**: Moves the transform **z** units in Z axis in **t** time. 
 ``` cs
public static IEnumerator MoveToZ(this Transform  transform, float distanceToMoveZ, float time,  AnimationCurve curve = null)
```
4. **MoveTo**: Moves towards **destination** in **t** time. 
 ``` cs
public static IEnumerator MoveTo(this Transform  transform, Vector3 destination, float time,  AnimationCurve curve = null)
```
5. **PingPong**: Move back and forth between **current position** and **destination position** at given **speed**.
 ``` cs
public static IEnumerator PingPong(this Transform  transform, Vector3 destination, float speed,  AnimationCurve curve = null)
```
6. **PingPongX**: Move back and forth between **current position** and **destination position (x units in X axis)** at given **speed**.
 ``` cs
public static IEnumerator PingPongX(this Transform  transform, float distanceToMoveX, float speed,  AnimationCurve curve = null)
```
7. **PingPongY**: Move back and forth between **current position** and **destination position (y units in Y axis)** at given **speed**.
 ``` cs
public static IEnumerator PingPongY(this Transform  transform, float distanceToMoveY, float speed,  AnimationCurve curve = null)
```
8. **PingPongZ**: Move back and forth between **current position** and **destination position (z units in Z axis)** at given **speed**.
 ``` cs
public static IEnumerator PingPongZ(this Transform  transform, float distanceToMoveZ, float speed, AnimationCurve  curve = null)
```
10. **InterpTo**: Interpolates from **current position** to **destination** at the given **speed**. **isLocal** boolean checks if interpolating local or world position. 
 ``` cs
public static void InterpTo(this  Transform  transform, Vector3 destination, float interpSpeed, bool isLocal = false)
```

## Usage
```cs
[SerializeField] AnimationCurve curve;
[SerializeField] float distanceToMoveX = 10.0f;
[SerializeField] float time = 3.0f;

StartCoroutine(transform.MoveToX(distanceToMoveX,  time));
StartCoroutine(transform.MoveToX(distanceToMoveX,  time, curve));
----------------------------------------------

[SerializeField] AnimationCurve curve;
[SerializeField] float distanceToMoveY = 10.0f;
[SerializeField] float time = 3.0f;

StartCoroutine(transform.MoveToY(distanceToMoveY,  time));
StartCoroutine(transform.MoveToY(distanceToMoveY,  time, curve));
----------------------------------------------

[SerializeField] AnimationCurve curve;
[SerializeField] float distanceToMoveY = 10.0f;
[SerializeField] float time = 3.0f;

StartCoroutine(transform.MoveToZ(distanceToMoveZ,  time));
StartCoroutine(transform.MoveToZ(distanceToMoveZ,  time, curve));
----------------------------------------------

[SerializeField] AnimationCurve curve;
[SerializeField] Transform destination;
[SerializeField] float time = 3.0f;

StartCoroutine(transform.MoveTo(destination, time));
StartCoroutine(transform.MoveTo(destination, time, curve));
-----------------------------------------------

[SerializeField] AnimationCurve curve;
[SerializeField] Vector3 destination;
[SerializeField] float speed = 1.0f;

StartCoroutine(transform.PingPong(destination, speed));
StartCoroutine(transform.PingPong(destination, speed, curve));
-----------------------------------------------

[SerializeField] AnimationCurve curve;
[SerializeField] float distanceToMoveX = 10;
[SerializeField] float speed = 1.0f;

StartCoroutine(transform.PingPongX(distanceToMoveX, speed));
StartCoroutine(transform.PingPongX(distanceToMoveX, speed, curve));
-----------------------------------------------

[SerializeField] AnimationCurve curve;
[SerializeField] float distanceToMoveY = 10;
[SerializeField] float speed = 1.0f;

StartCoroutine(transform.PingPongY(distanceToMoveY, speed));
StartCoroutine(transform.PingPongY(distanceToMoveY, speed, curve));
-----------------------------------------------

[SerializeField] AnimationCurve curve;
[SerializeField] float distanceToMoveZ = 10;
[SerializeField] float speed = 1.0f;

StartCoroutine(transform.PingPongZ(distanceToMoveZ, speed));
StartCoroutine(transform.PingPongZ(distanceToMoveZ, speed, curve));
-----------------------------------------------

[SerializeField] Vector3 destination;
[SerializeField] float interpSpeed = 0.25f;

transform.InterpTo(destination, interpSpeed * Time.deltaTime));
transform.InterpTo(destination, interpSpeed * Time.deltaTime, isLocal:true));
-----------------------------------------------
``` 

## UI Extensions - Image

1.  **LerpColor**: Linearly interpolating  current color to destination color in time t.
```cs
public static IEnumerator LerpColor(this Image  image,  Color to, float time, AnimationCurve curve  =  null)
```
2.  **FadeAlpha**: Fade the image based on the FadeType:  FadeIn / FadeOut. 
```cs
public static IEnumerator FadeAlpha(this Image  image,  FadeType type, float time, AnimationCurve curve = null)
```

## Usage

```cs
[SerializeField] AnimationCurve curve;
[SerializeField] float time = 2.0f;

StartCoroutine(attachedImageComponent.LerpColor(Color.red, time));
StartCoroutine(attachedImageComponent.LerpColor(Color.red, time, curve));
-----------------------------------------------

[SerializeField] AnimationCurve curve;
[SerializeField] float time = 2.0f;

StartCoroutine(attachedImageComponent.FadeAlpha(FadeType.FadeIn, time));
StartCoroutine(attachedImageComponent.FadeAlpha(FadeType.FadeIn, time, curve));
```
-----------------------------------------------
> *Note*: *All the above mentioned functions takes an animation curve as  optional parameter. The curve gives more flexibility and control over how values interpolate.*

