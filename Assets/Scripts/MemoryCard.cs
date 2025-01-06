using UnityEngine;

public class MemoryCard : MonoBehaviour
{
    [SerializeField] GameObject cardBack;
    private SceneController controller; 

    private int _id;
    public int Id { get { return _id; } }

    public void SetCard(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }

    private void Start()
    {
        
        controller = Object.FindFirstObjectByType<SceneController>();
        if (controller == null)
        {
            Debug.LogError("SceneController not found in the scene!");
        }
    }


    public void OnMouseDown()
    {
        if (controller != null && cardBack.activeSelf && controller.canReveal)
        {
            cardBack.SetActive(false);
            controller.CardRevealed(this);
        }
    }

    public void Unrevealed()
    {
        cardBack.SetActive(true);
    }
}