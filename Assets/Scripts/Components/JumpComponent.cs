using UnityEngine;

namespace Movement
{
    public class JumpComponent
    {
        public void Jump(Rigidbody rb, float jumpForce)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
        }
    }
}