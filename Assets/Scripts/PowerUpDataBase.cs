using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu]
public class PowerUpDataBase : ScriptableObject
{
   
    public List<PowerUps> powersList;
    

    [Serializable]
    public class PowerUps
    {
        [field: SerializeField]

        public string name;
        [field: SerializeField]

        public int iD;
        [field: SerializeField]

        public int damage;
        [field: SerializeField]

        public float speed;
        [field: SerializeField]

        public float jumpForce;
        [field: SerializeField]

        public int extraJumps;
        [field: SerializeField]

        public float gravityScale;
        [field: SerializeField]


        public Sprite sprite;
        [field: SerializeField]

        public Sprite uiSprite;

        [field: SerializeField]
        public RuntimeAnimatorController controller;

        [field: SerializeField]
        public Vector2 colliderSize;

        [field: SerializeField]
        public Vector2 colliderOffset;

        [field: SerializeField]
        public Vector2 kbForce;

        [field: SerializeField]
        public float kbTotalTime;

        [field: SerializeField]
        public float attackCooldown;

        [field: SerializeField]
        public GameObject powerProyectil;

        [field: SerializeField]
        public bool isShooter;

        [field: SerializeField]
        public AudioClip iddleAudioClip;

        [field: SerializeField]
        public AudioClip attackAudioClip;

        [field: SerializeField]
        public AudioClip damageAudioClip;

        [field: SerializeField]
        public AudioClip effectAudioClip;

        [field: SerializeField]
        public float stopMovingTime;

    }
}
