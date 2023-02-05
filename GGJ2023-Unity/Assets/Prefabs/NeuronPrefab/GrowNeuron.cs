using System.Collections;
using UnityEngine;

public class GrowNeuron : MonoBehaviour
{
    public GameObject axonPrefab;

    private Transform dendrites;
    private Transform terminals;
    private Transform startingConnection;

    private void Start()
    {
        dendrites = transform.Find("Dendrites");
        terminals = transform.Find("Terminals");
        startingConnection = dendrites.transform.Find("Anchor");

        StartCoroutine(InstantiateAxonCoroutine());
    }

    private IEnumerator InstantiateAxonCoroutine()
    {
        while (true)
        {
            bool isPlaying = SwitchPlay.play;

            if (isPlaying)
            {
                // Create new axon instance
                GameObject newAxon = Instantiate(axonPrefab);
                newAxon.transform.rotation = terminals.rotation;
                newAxon.transform.localScale = transform.localScale;

                // Get remaining connections
                Transform newAxonAnchor = newAxon.transform.Find("Anchor");
                Transform newAxonAnchor2 = newAxon.transform.Find("Anchor2");
                Transform terminalsAnchor = terminals.transform.Find("Anchor");

                Vector3 snapVector;

                // Snap new axion
                snapVector = startingConnection.transform.position - newAxonAnchor.transform.position;
                newAxon.transform.position += snapVector;

                // Snap terminals
                snapVector = newAxonAnchor2.transform.position - terminalsAnchor.transform.position;
                terminals.transform.position += snapVector;

                // Update starting connection
                startingConnection = newAxonAnchor2;
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
