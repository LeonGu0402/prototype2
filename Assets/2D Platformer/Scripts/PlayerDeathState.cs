using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class PlayerDeathState : MonoBehaviour
    {
        public float jumpForce;

        private Rigidbody2D rgBody;
        void Start()
        {
            rgBody = GetComponent<Rigidbody2D>();
            rgBody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}

