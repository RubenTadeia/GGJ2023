using System.Collections;
using UnityEngine;

public class GrowNeuron : MonoBehaviour
{
    public GameObject axonPrefab;
    public int dendritesGrowth = 7;
    public int terminalsGrowth = 10;

    private Transform dendrites;
    private Transform terminals;
    private Transform startingConnection;
    private int dendritesRemainingGrowth;
    private int terminalsRemainingGrowth;

    private void Start()
    {
        dendrites = transform.Find("Dendrites");
        terminals = transform.Find("Terminals");
        startingConnection = dendrites.transform.Find("Anchor");
        dendritesRemainingGrowth = dendritesGrowth;
        terminalsRemainingGrowth = terminalsGrowth;

        StartCoroutine(InstantiateAxonCoroutine());
    }

    public void HandleTerminalsCollision(string colliderTag)
    {
        if (colliderTag.Equals("Comida")) {
            terminalsRemainingGrowth = terminalsGrowth;
        }
    }

    public void HandleStopGrowth(string partThatCollided)
    {
        if (partThatCollided.Equals("Dendrites")) {
            dendritesRemainingGrowth = 0;
        }
        if (partThatCollided.Equals("Terminals")) {
            terminalsRemainingGrowth = 0;
        }
    }

    public void HandleConnection(string colliderTag)
    {
        if (colliderTag.Equals("Input")) {
            WinningCondition.inputConnected = true;
        }
        if (colliderTag.Equals("Output")) {
            WinningCondition.outputConnected = true;
        }
    }
    
    private IEnumerator InstantiateAxonCoroutine()
    {
        while (true)
        {
            bool isPlaying = SwitchPlay.play;

            if (isPlaying)
            {
                if (dendritesRemainingGrowth > 0)
                {
                    // Grow Butt
                    Transform buttSprite = dendrites.transform.Find("DendritesSprite");
                    Transform buttCollider = dendrites.transform.Find("Collider");
                    buttSprite.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
                    buttCollider.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);

                    dendritesRemainingGrowth -= 1;
                }

                if (terminalsRemainingGrowth > 0)
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
                
                    terminalsRemainingGrowth -= 1;
                }
            }
            yield return new WaitForSeconds(0.25f);
        }
    }
}
