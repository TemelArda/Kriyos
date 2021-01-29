using System.Collections;
using UnityEngine;


public class Interactable : MonoBehaviour
{

    public float radius = 1.5f;
    [SerializeField] private Vector2 offset = new Vector2(0.0f, 0.0f);
    public string InterractionString => "Press F to interact with " + Name;
    private Vector3 Position => new Vector3(transform.position.x + offset.x, transform.position.y + offset.y, transform.position.z);
    public string Name { get; private set; }

    public void Awake()
    {
        Name = this.gameObject.name;
    }
    public virtual void Interact()
    {
        StartCoroutine(generalInterraction());
    }
    IEnumerator generalInterraction()
    {
        Debug.Log("Interracting...");
        yield return new WaitForSeconds(1.5f);
        Debug.Log("Interraction end...");
        //Remove these lines to remove dependency to player class...
        PlayerBasitState player = FindObjectOfType<PlayerBasitState>();
        player.State = PlayerState.NotInterracting;
        //

    }
    public bool CheckDistance(Vector3 playerTransform)
    {
        float distance = Vector3.Distance(playerTransform, Position);
        return distance <= radius;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(Position, radius);
    }
}
