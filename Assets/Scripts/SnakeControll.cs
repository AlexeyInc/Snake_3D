using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeControll : MonoBehaviour
{
    public GameObject tailPrefab;
    public List<Transform> BodyPositions = new List<Transform>();
    public float min_distance = 0.5f;
    public int beginSize = 1;
    public float speed = 3;
    public float speedRotate = 150;

    float dist;
    Transform _curBodyPart;
    Transform _prevBodypart;

    private void Start()
    {
        //independent startSize
        for (int i = 0; i < beginSize - 1; i++) { AddTail(); }
    }

    private void FixedUpdate()
    {
        Movement();

        //independent generation
        if (Input.GetKeyDown(KeyCode.Q)) { AddTail(); }
    }

    void Movement()
    {
        BodyPositions[0].Translate(BodyPositions[0].forward * speed * Time.smoothDeltaTime, Space.World);

        if (Input.GetAxis("Horizontal") != 0)
        {
            float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * speedRotate;
            BodyPositions[0].Rotate(Vector3.up * moveX);
        }

        for (int i = 1; i < BodyPositions.Count; i++)
        {
            _curBodyPart = BodyPositions[i];
            _prevBodypart = BodyPositions[i - 1];

            dist = Vector3.Distance(_prevBodypart.position, _curBodyPart.position);

            Vector3 newpos = _prevBodypart.position;
            newpos.y = BodyPositions[0].position.y;

            float time = Time.deltaTime * dist / min_distance * speed;
            if (time > 0.5f)
                time = 0.5f;

            _curBodyPart.position = Vector3.Slerp(_curBodyPart.position, newpos, time);
            _curBodyPart.rotation = Quaternion.Slerp(_curBodyPart.rotation, _prevBodypart.rotation, time);
        }
    }

    public void AddTail()
    {
        Vector3 lastTailPosition = BodyPositions[BodyPositions.Count - 1].position;
        GameObject newTail = Instantiate(tailPrefab, lastTailPosition, BodyPositions[BodyPositions.Count - 1].rotation) as GameObject;
        newTail.transform.SetParent(transform);
        if (BodyPositions.Count < 3)
        {
            newTail.name = "FrstTailSkip";
        }
        BodyPositions.Add(newTail.transform);
    }

}
