using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.InputSystem;

public class Clicker : MonoBehaviour
{
   Camera m_Camera;
   void Awake()
   {
       m_Camera = Camera.main;
   }
   void Update()
   {
       if (Input.GetMouseButtonDown(0))
       {
           Vector3 mousePosition = Input.mousePosition;
           Ray ray = m_Camera.ScreenPointToRay(mousePosition);
           if (Physics.Raycast(ray, out RaycastHit hit))
           {
               // Use the hit variable to determine what was clicked on.
           }
       }
   }
}

