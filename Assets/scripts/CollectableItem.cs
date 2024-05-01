using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableItem : MonoBehaviour
{
   public int apple;
   [SerializeField] private Text applesText;
   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.gameObject.CompareTag("CollectableItem"))
      {
         Destroy(collision.gameObject);
         apple++;
         applesText.text = "Collected: " + apple;
      }
   }
}
