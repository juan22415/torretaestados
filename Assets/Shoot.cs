using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Structures
{
    public class Shoot : MonoBehaviour
    {

        [SerializeField]
        private GameObject bullet;
        private Transform mytransform;
        private Vector3 mousepos;
        public Transform playertarget;
        State currentstate = 0;
        public float timer;
              
      
        void Start()
        {
            mytransform = GetComponent<Transform>();
        }

        void Update()
        {
            if (currentstate==State.patrol)
            { 
            Rotate();
            }

            else if (currentstate == State.kill)
            {
                followtarget(playertarget);
                timer += Time.deltaTime;
                if (timer<2)
                {
                    shoot();
                    timer = 0;
                }
                
                

            }

        }

        public void Rotate()
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 50);
        }

        public void shoot()
        {
            GameObject bull = Instantiate(bullet);
            bull.transform.position = mytransform.position;
            bull.GetComponent<Rigidbody>().velocity = mytransform.forward * 10;
        }

        public void followtarget(Transform target)
        {

            transform.LookAt(target.position);
        }


        void OnTriggerEnter(Collider other)
        {
            Debug.Log("entra");
            playertarget = other.transform;
            currentstate = State.kill;    
        }

        void OnTriggerExit(Collider other)
        {
            playertarget = null;
            currentstate = State.patrol;
        }
    }
}





