using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWPSecond : MonoBehaviour
{
    public List<Transform> waypoints;
    int currentWP = 0;

    public float speed = 10.0f;
    public float lookAhead = 10.0f;

    GameObject tracker;

    // Start is called before the first frame update
    void Start()
    {
        tracker = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        DestroyImmediate(tracker.GetComponent<Collider>());
        tracker.GetComponent<MeshRenderer>().enabled = false;
        tracker.transform.position = this.transform.position;
        tracker.transform.rotation = this.transform.rotation;
    }

    void ProgressTracker()
    {
        if (Vector3.Distance(this.transform.position, tracker.transform.position) > lookAhead) return;

        if (Vector3.Distance(tracker.transform.position, waypoints[currentWP].position) < 5)
            currentWP++;

        if (currentWP >= waypoints.Count)
            currentWP = 0;

        tracker.transform.LookAt(waypoints[currentWP]);
        tracker.transform.Translate(0, 0, (speed + 20) * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        ProgressTracker();
        if (Vector3.Distance(this.transform.position, waypoints[currentWP].position) < 5)
            currentWP++;

        if (currentWP >= waypoints.Count)
            currentWP = 0;

        this.transform.LookAt(waypoints[currentWP]);

        // Elimina la rotación basada en Slerp y rotSpeed
        // Quaternion lookatWP = Quaternion.LookRotation(tracker.transform.position - this.transform.position);
        // this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookatWP, rotSpeed * Time.deltaTime);

        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
