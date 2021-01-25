using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public static class UtilityHelper
{
   public static void ChangeColor(GameObject obj)
   {
      obj.GetComponent<MeshRenderer>().material.color = new Color(Random.value, Random.value, Random.value);
   }
}
