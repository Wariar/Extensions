# Extensions
## Transfrom Extensions
Below are the transform extensions available:
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
> Usage: 
10. **InterpTo**: Interpolates from **current position** to **destination** at the given **speed**. **isLocal** boolean checks if interpolating local or world position. 
 ``` cs
public static void InterpTo(this  Transform  transform, Vector3 destination, float interpSpeed, bool isLocal = false)
```

### Usage

MoveToX:
```cs
[SerializeField] AnimationCurve curve;
[SerializeField] float distanceToMoveX = 10.0f;
[SerializeField] float time = 3.0f;

StartCoroutine(transform.MoveToX(distanceToMoveX,  time));
StartCoroutine(transform.MoveToX(distanceToMoveX,  time, curve));
``` 

