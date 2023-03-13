using UnityEngine;

public class MazeCellWall : MonoBehaviour
{
    public float scaleSize;
    [SerializeField] private Maze maze;
    private bool visible = true;
    private Renderer r;
    private Collider c;
   

    public bool Visible
    {
        get { return visible; }
        set
        {
            visible = value;
            r.enabled = visible;

        }
    }
    

    public void Awake()
    {
        r = GetComponent<Renderer>();

    }
    
   

}
