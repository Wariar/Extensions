using System.Collections;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace Extenstions
{
    #region UI Extenstions
    public enum FadeType
    {
        FadeIn = 0,
        FadeOut
    };
    /// <summary>
    /// Extension methods for UI components
    /// </summary>

    public static class UIExtensions
    {
        /// <summary>
        /// Fade from current Image color to specified color in time t using a curve (optional).
        /// </summary>
        /// <returns>The fade.</returns>
        /// <param name="image">Image.</param>
        /// <param name="to">To.</param>
        /// <param name="time">Time.</param>
        /// <param name="curve">Curve.</param>
        public static IEnumerator Fade(this Image image, Color to, float time, AnimationCurve curve = null)
        {
            float dr = to.r - image.color.r;
            float dg = to.g - image.color.g;
            float db = to.b - image.color.b;

            float cr = image.color.r;
            float cg = image.color.g;
            float cb = image.color.b;

            float dt = 0f;

            while (dt < time)
            {
                dt += Time.deltaTime;
                float? e = curve?.Evaluate(dt / time) ?? dt/time;
                float r = Mathf.Abs(cr + (dr * e.Value));
                float g = Mathf.Abs(cg + (dg * e.Value));
                float b = Mathf.Abs(cb + (db * e.Value));
                image.color = new Color(r, g, b);
                yield return null;
            }
            image.color = to;
        }

        /// <summary>
        /// Fades the image based on the FadeType specified.
        /// </summary>
        /// <returns>The alpha.</returns>
        /// <param name="image">Image.</param>
        /// <param name="type">Type.</param>
        /// <param name="time">Time.</param>
        /// <param name="curve">Curve.</param>
        public static IEnumerator FadeAlpha(this Image image, FadeType type, float time, AnimationCurve curve = null)
        {
            float ca = image.color.a;
            float dt = 0f;
            float to = (int)type;

            while (dt < time)
            {
                dt += Time.deltaTime;
                float? _dt = curve?.Evaluate(dt / time) ?? dt / time;
                float e = type == FadeType.FadeIn ? 1 - _dt.Value : _dt.Value;
                float a = Mathf.Abs(ca - to) * e;
                image.color = new Color(image.color.r, image.color.g, image.color.b, a);
                yield return null;
            }
            image.color = new Color(image.color.r, image.color.g, image.color.b, to);
        }
    }
    #endregion
}
