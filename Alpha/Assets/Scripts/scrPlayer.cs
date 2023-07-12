using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPlayer : MonoBehaviour
{
    //[SerializeField] Rigidbody rbPlayer;
    //[SerializeField] float speed;
    //[SerializeField] float turnSpeed = 360f;
    //[SerializeField] float jumptForce = 5f;
    ////[SerializeField] Animator aplayer;
    //Vector3 input;

    //private void Start()
    //{
    //    //aplayer = GetComponent<Animator>();
    //}

    //private void Update()
    //{
    //    GatherInput();
    //    Look();

    //    if (Input.GetButtonDown("Jump"))
    //    {
    //        rbPlayer.AddForce(input * jumptForce * Time.deltaTime, ForceMode.Impulse);
    //    }

    //    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 60f, Color.red);
    //}

    //private void FixedUpdate()
    //{
    //    Move();
    //}

    //void GatherInput()
    //{
    //    input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    //}

    //void Move()
    //{
    //    rbPlayer.MovePosition(rbPlayer.transform.position + (rbPlayer.transform.forward * input.magnitude) * speed * Time.deltaTime);
    //}

    //void Look()
    //{
    //    if (input != Vector3.zero)
    //    {
    //        var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 0, 0));

    //        var skewedinput = matrix.MultiplyPoint3x4(input);

    //        var relative = (transform.position + skewedinput) - transform.position;
    //        var rot = Quaternion.LookRotation(relative, Vector3.up);

    //        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, turnSpeed * Time.deltaTime);
    //    }
    //}

    public CharacterController controller;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothTime, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            controller.Move(direction * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            Debug.Log("Proxima fase");
        }
    }
}
