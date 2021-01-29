using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
        public Transform target;
        public float smoothTime = 0.3F;
        private Vector2 velocity = Vector2.zero;
     
        void Update()
        {
            //transform.position = new Vector3(transform.position.x, transform.position.y, -10);
            // Define a target position above and behind the target transform
            Vector3 targetPosition = target.TransformPoint(new Vector3(0, 5, -10));
            targetPosition.x = 0;
     
            // Smoothly move the camera towards that target position
            transform.position = Vector2.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
}
