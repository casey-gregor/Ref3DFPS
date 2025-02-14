using Interfaces;
using UnityEngine;

namespace Movement
{
    public class MoveComponent
    {
        public void Move(Rigidbody rb, Vector3 direction, float speed, float deltaTime)
        {
            // Vector3 horizontalMoveDirection = new Vector3(direction.x, 0, direction.y);
            // transform.Translate(horizontalMoveDirection * (speed * deltaTime));
            
            rb.linearVelocity = new Vector3(direction.x*speed, rb.linearVelocity.y, direction.y*speed);
        }
    }
}