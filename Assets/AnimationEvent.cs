using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
   public void FireArrow()
   {
      EventSystem.FireArrow?.Invoke();
      Debug.Log("Fire Arrow");
   }
}
