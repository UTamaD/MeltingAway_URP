using UnityEngine;

public class DebrisDrop : MonoBehaviour
{
    public GameObject debrisPrefab;
    public float debrisRange = 5f;
    public int debrisCount = 10;
    public float debrisSpeed = 5f;
    public float debrisSpread = 45f;
    public float arcHeight = 2f; // adjust this to change the height of the arc

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Get the position of the collider
            Vector3 spawnPosition = other.transform.position;

            for (int i = 0; i < debrisCount; i++)
            {
                GameObject debrisInstance = Instantiate(debrisPrefab, spawnPosition, Quaternion.identity);
                Rigidbody debrisRigidbody = debrisInstance.GetComponent<Rigidbody>();

                // Calculate the initial velocity of the debris
                Vector3 initialVelocity = transform.forward * debrisSpeed;

                // Add an upward force to make the debris go up first
                Vector3 upForce = Vector3.up * Mathf.Sqrt(2f * arcHeight * Mathf.Abs(Physics.gravity.y));
                debrisRigidbody.AddForce(upForce, ForceMode.VelocityChange);

                // Add the initial velocity to the debris
                debrisRigidbody.velocity = initialVelocity;

                // Randomize the debris spread
                float spreadX = Random.Range(-debrisSpread, debrisSpread);
                float spreadY = Random.Range(-debrisSpread, debrisSpread);
                Vector3 forceDirection = Quaternion.Euler(spreadX, spreadY, 0f) * transform.forward;
                debrisRigidbody.AddForce(forceDirection.normalized * debrisSpeed, ForceMode.Impulse);

                // Randomize the drop point within range
                Vector3 dropPoint = spawnPosition + Random.insideUnitSphere * debrisRange;
                dropPoint.y = spawnPosition.y;
                debrisInstance.transform.position = dropPoint;
            }

            // Destroy the object that was hit
            Destroy(gameObject);
        }
    }
}