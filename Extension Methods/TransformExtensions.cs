using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace Extenstions
{
    #region Transform Extenstions
    /// <summary>
    /// Extensions Method for Transform Class
    /// </summary>

    public static class TransformExtensions
    {
        /// <summary>
        /// Resets the postiton.
        /// </summary>
        /// <param name="transform">Transform.</param>
        public static void ResetPostiton(this Transform transform)
        {
            transform.position = Vector3.zero;
        }

        /// <summary>
        /// Resets the local postiton.
        /// </summary>
        /// <param name="transform">Transform.</param>
        public static void ResetLocalPostiton(this Transform transform)
        {
            transform.localPosition = Vector3.zero;
        }

        /// <summary>
        /// Reset Rotation
        /// </summary>
        /// <param name="transform"></param>

        public static void ResetRotation(this Transform transform)
        {
            transform.rotation = Quaternion.identity;
        }

        /// <summary>
        /// Resets the local rotation.
        /// </summary>
        /// <param name="transform">Transform.</param>
        public static void ResetLocalRotation(this Transform transform)
        {
            transform.localRotation = Quaternion.identity;
        }

        /// <summary>
        /// Resets the scale.
        /// </summary>
        /// <param name="transform">Transform.</param>
        public static void ResetScale(this Transform transform)
        {
            transform.localScale = Vector3.one;
        }

        /// <summary>
        /// Returns the children as list.
        /// </summary>
        /// <returns>The children as a list.</returns>
        /// <param name="transform">Transform.</param>
        public static List<Transform> GetChildrenAsList(this Transform transform)
        {
            var t = transform.GetComponentsInChildren<Transform>();
            var l = t?.ToList();
            l?.RemoveAt(0);
            return l;
        }

        /// <summary>
        /// Move x distance in t time. 
        /// </summary>
        /// <returns>Returns an IEnumerator</returns>
        /// <param name="transform">Transform.</param>
        /// <param name="distanceToMoveinX">Distance to move in X direction.</param>
        /// <param name="time">Time.</param>
        /// <param name="curve">Curve.</param>
        public static IEnumerator MoveToX(this Transform transform, float distanceToMoveinX, float time, AnimationCurve curve = null)
        {
            float x = transform.position.x;
            float dt = 0.0f;
            while (dt < time)
            {
                dt += Time.deltaTime;
                float? e = curve?.Evaluate(dt / time) ?? dt/time;
                float d = x + distanceToMoveinX * e.Value;
                transform.position = new Vector3(d, transform.position.y, transform.position.z);
                yield return null;
            }
            transform.position = new Vector3(x+distanceToMoveinX, transform.position.y, transform.position.z);

        }
        
        /// <summary>
        /// Move y distance in t time.
        /// </summary>
        /// <returns>Returns an IEnumerator</returns>
        /// <param name="transform">Transform.</param>
        /// <param name="distanceToMoveY">Distance y.</param>
        /// <param name="time">Time.</param>
        /// <param name="curve">Curve.</param>
        public static IEnumerator MoveToY(this Transform transform, float distanceToMoveY, float time, AnimationCurve curve = null) 
        {
            float y = transform.position.y;
            float dt = 0.0f;
            while (dt < time)
            {
                dt += Time.deltaTime;
                float? e = curve?.Evaluate(dt / time) ?? dt/time;
                float d = y + distanceToMoveY * e.Value;
                transform.position = new Vector3(transform.position.x, d, transform.position.z);
                yield return null;
            }
            transform.position = new Vector3(transform.position.x, y+distanceToMoveY, transform.position.z);

        }

        /// <summary>
        /// Move z distance in t time.
        /// </summary>
        /// <returns>Return an IEnumerator</returns>
        /// <param name="transform">Transform.</param>
        /// <param name="distanceToMoveZ">Distance z.</param>
        /// <param name="time">Time.</param>
        /// <param name="curve">Curve.</param>
        public static IEnumerator MoveToZ(this Transform transform, float distanceToMoveZ, float time, AnimationCurve curve = null)
        {
            float z = transform.position.z;
            float dt = 0.0f;
            while (dt < time)
            {
                dt += Time.deltaTime;
                float? e = curve?.Evaluate(dt / time) ?? dt/time;
                float d = z + distanceToMoveZ * e.Value;
                transform.position = new Vector3(transform.position.x, transform.position.y, d);
                yield return null;
            }
            transform.position = new Vector3(transform.position.x, transform.position.y, z+distanceToMoveZ);

        }

        /// <summary>
        /// Move to destination in t time.
        /// </summary>
        /// <returns>The to.</returns>
        /// <param name="transform">Transform.</param>
        /// <param name="destination">Destination.</param>
        /// <param name="curve">Curve.</param>
        /// <param name="time">Time.</param>
        public static IEnumerator MoveTo(this Transform transform, Vector3 destination, float time, AnimationCurve curve = null)
        {
            Vector3 tp = transform.position;
            Vector3 diff = destination - tp;
            float dt = 0f;
            while (dt < time)
            {
                dt += Time.deltaTime;
                float? e = curve?.Evaluate(dt / time) ?? dt/time;
                Vector3 d = tp + diff * e.Value;
                transform.position = d;
                yield return null;
            }
            transform.position = destination;
        }

        /// <summary>
        /// PingPong between current and destination at a given speed.
        /// </summary>
        /// <returns>Returns an IEnumerator</returns>
        /// <param name="transform">Transform.</param>
        /// <param name="destination">Destination.</param>
        /// <param name="curve">Curve.</param>
        /// <param name="speed">Speed.</param>
        public static IEnumerator PingPong(this Transform transform, Vector3 destination, float speed, AnimationCurve curve = null)
        {
            Vector3 tp = transform.position;
            Vector3 dp = tp + destination;
            float dt = 0f;
            while (true)
            {
                dt += Time.deltaTime * speed;
                float e = curve.Evaluate(dt);
                Vector3 d = dp * e;
                transform.position = d;
                tp = d;
                yield return null;
            }
        }

        /// <summary>
        /// PingPong between x distance from current position.
        /// </summary>
        /// <returns>Returns an IEnumerator</returns>
        /// <param name="transform">Transform.</param>
        /// <param name="distanceToMoveX">Distance x.</param>
        /// <param name="curve">Curve.</param>
        /// <param name="speed">Speed.</param>
        public static IEnumerator PingPongX(this Transform transform, float distanceToMoveX, float speed, AnimationCurve curve = null)
        {
            float x = transform.position.x;
            float dx = x + distanceToMoveX;
            float dt = 0f;
            while (true)
            {
                dt += Time.deltaTime * speed;
                float? e = curve?.Evaluate(dt) ?? dt;
                float d = dx * e.Value;
                transform.position = new Vector3(d, transform.position.y, transform.position.z);
                x = transform.position.x;
                yield return null;
            }
        }

        /// <summary>
        /// PingPong between y distance from current position.
        /// </summary>
        /// <returns>Returns an IEnumerator</returns>
        /// <param name="transform">Transform.</param>
        /// <param name="distanceToMoveY">Distance y.</param>
        /// <param name="curve">Curve.</param>
        /// <param name="speed">Speed.</param>
        public static IEnumerator PingPongY(this Transform transform, float distanceToMoveY, float speed, AnimationCurve curve = null)
        {
            float y = transform.position.y;
            float dx = y + distanceToMoveY;
            float dt = 0f;
            while (true)
            {
                dt += Time.deltaTime * speed;
                float? e = curve?.Evaluate(dt) ?? dt;
                float d = dx * e.Value;
                transform.position = new Vector3(transform.position.x, d, transform.position.z);
                y = transform.position.y;
                yield return null;
            }
        }

        /// <summary>
        /// PingPong between z distance from current position.
        /// </summary>
        /// <returns>Returns an IEnumerator</returns>
        /// <param name="transform">Transform.</param>
        /// <param name="distanceToMoveZ">Distance z.</param>
        /// <param name="curve">Curve.</param>
        /// <param name="speed">Speed.</param>
        public static IEnumerator PingPongZ(this Transform transform, float distanceToMoveZ, AnimationCurve curve, float speed)
        {
            float z = transform.position.z;
            float dz = z + distanceToMoveZ;
            float dt = 0f;
            while (true)
            {
                dt += Time.deltaTime * speed;
                float? e = curve?.Evaluate(dt) ?? dt;
                float d = dz * e.Value;
                transform.position = new Vector3(transform.position.x, transform.position.y, d);
                z = transform.position.z;
                yield return null;
            }
        }

        /// <summary>
        /// Interpolated to specified position.
        /// </summary>
        /// <param name="transform">Transform.</param>
        /// <param name="to">To.</param>
        /// <param name="interopSpeed">Interop speed.</param>
        /// <param name="isLocal">If set to <c>true</c> is local.</param>

        public static void InteropTo(this Transform transform, Vector3 to, float interopSpeed, bool isLocal = false)
        {
            Vector3 tp = isLocal ? transform.localPosition : transform.position;
            Vector3 diff = to - tp;
            interopSpeed = Mathf.Clamp01(interopSpeed);
            Vector3 d = tp + diff * Time.deltaTime * interopSpeed;
            if (isLocal) transform.localPosition = d;
            else transform.position = d;
        }   
    }
    #endregion
}