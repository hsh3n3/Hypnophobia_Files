using System.Collections;
using UnityEngine;
using UnityEngine.UI;

class FunctLib
{
    public class Timing : MonoBehaviour
    {
        public static IEnumerator Wait(float sec)
        {
            yield return new WaitForSeconds(sec);
        }
    }
	public class Colors : MonoBehaviour
	{
		public static Color ColorMoveTowards(Color current, Color target, float speed){
            current = new Color (Mathf.MoveTowards (current.r, target.r, speed), Mathf.MoveTowards (current.g, target.g, speed), 
                Mathf.MoveTowards (current.b, target.b, speed), Mathf.MoveTowards (current.a, target.a, speed));
            return current;
        }
	}
    public class Math : MonoBehaviour
    {

        public static float LerpOverDistance(float lerpFrom, float lerpTo, float currentDistance, float maxDistance)
        {
            return Mathf.Lerp(lerpFrom, lerpTo, currentDistance / maxDistance);
        }
    }
    public class Audio : MonoBehaviour
    {

        public static void SoundEffect(GameObject prefab, Vector3 position)
        {
            GameObject g = Instantiate(prefab) as GameObject;
            g.transform.position = position;
        }
        public static void SoundEffect(GameObject prefab, Vector3 position, float PitchRange1, float PitchRange2)
        {
            GameObject g = Instantiate(prefab) as GameObject;
            g.transform.position = position;
            g.GetComponent<AudioSource>().pitch = Random.Range(PitchRange1, PitchRange2);
        }
    }
}
