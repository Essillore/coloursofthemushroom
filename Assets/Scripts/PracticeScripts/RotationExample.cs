using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationExample : MonoBehaviour
{
        /*
         * Use [SerializeField] instead of public declaration for the ability to modify in the Inspector
         * unless other scripts will need direct access to 'turnSpeed'
         */
        [SerializeField] float turnSpeed = 20f;



        void Update()
        {
            /*
             * GetAxis returns a value between -1 and 1 (and not zero) when a left or right arrow key (or 'A' or 'D')
             * is pressed.  For simplicity and readability, I'm storing that value in a variable called 'horizontalInput'
             */
            float horizontalInput = Input.GetAxis("Horizontal");

            /*
             * Here we use 'Vector3.up' since using it here is equivalent to rotating around the y axis (0, 1, 0).
             * Also, because 'horizontalInput' can be negative when the 'left' arrow or 'A' is pressed, it will
             * make the Y rotation negative, thus rotating the player to the left.  A positive value rotates to the
             * right.
             */
            transform.Rotate(Vector3.up * horizontalInput * turnSpeed * Time.deltaTime);
        }
    }
